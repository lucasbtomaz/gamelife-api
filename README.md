# GameLife

API para organizar a biblioteca, o backlog e as ofertas de jogos, substituindo o controle feito em planilhas.

## Estado atual

O projeto está na fase de prova de conceito da importação do backlog. A primeira hipótese é validar se o sistema consegue identificar jogos repetidos ou já possuídos antes de uma nova compra.

O escopo, as regras de negócio e os critérios de sucesso estão descritos em [POC: importação e revisão do backlog](poc-backlog.md).

## Tecnologias

- .NET 10;
- ASP.NET Core;
- xUnit;
- GitHub Actions;
- SQL Server planejado para a etapa de persistência.

## Arquitetura

A POC utiliza um monólito modular organizado nos seguintes projetos:

| Projeto | Responsabilidade |
|---|---|
| `GameLife.Api` | Endpoints HTTP e composição da aplicação. |
| `GameLife.Application` | Casos de uso e coordenação do domínio. |
| `GameLife.Domain` | Entidades, objetos de valor e regras de negócio. |
| `GameLife.Infrastructure` | Persistência e integrações externas. |
| `GameLife.Tests.Unit` | Testes unitários do domínio e da aplicação. |
| `GameLife.Tests.Integration` | Testes de integração da API. |

As dependências seguem em direção ao domínio:

```text
API -> Application -> Domain
  |          ^
  +-> Infrastructure

Unit Tests -> Application/Domain
Integration Tests -> API
```

Microserviços, mensageria, inteligência artificial e a interface React definitiva estão fora do escopo desta POC.

## Idioma do código

Os nomes das classes, métodos, propriedades, testes e regras de domínio são escritos em português. Nomes próprios de tecnologias e o nome do produto `GameLife` são mantidos no idioma original.

## Executar localmente

É necessário ter o SDK do .NET 10 instalado.

```powershell
dotnet restore GameLife.slnx
dotnet build GameLife.slnx --configuration Release --no-restore
dotnet test GameLife.slnx --configuration Release --no-build
```

Para executar a API:

```powershell
dotnet run --project GameLife.Api
```

## Banco de dados

A persistência usa Entity Framework Core com SQL Server. A conexão local padrão aponta para a instância SQL Server Express `SQLEXPRESS` e pode ser substituída pela configuração `ConnectionStrings__GameLife`.

> `Encrypt=False` é usado apenas no ambiente local. Ambientes publicados devem configurar uma conexão segura por variável de ambiente.

Restaure a ferramenta local e aplique as migrations com:

```powershell
dotnet tool restore
dotnet tool run dotnet-ef database update --project GameLife.Infrastructure --startup-project GameLife.Api
```

## Biblioteca

Os primeiros endpoints disponíveis são:

```http
POST /biblioteca
GET /biblioteca
```

Exemplo de inclusão:

```json
{
  "titulo": "Hades",
  "plataforma": "PC"
}
```

## Fluxo de branches

- `main`: versão estável;
- `development`: integração das funcionalidades;
- `feature/*`: desenvolvimento isolado, criado a partir de `development`.

O fluxo de promoção é manual:

```text
feature/* -> pull request -> development -> pull request -> main
```

As versões publicadas em `main` são identificadas por tags no formato `vX.Y.Z`. Não são criadas branches automáticas de release.

## Integração contínua

O GitHub Actions executa restauração, compilação e testes:

- em pull requests destinados a `development` ou `main`;
- em envios para `main`, `development`, `feature/*` e para o padrão legado `feature-*`;
- manualmente pela interface do GitHub.

Uma alteração só deve ser integrada quando o workflow `Validação contínua` estiver aprovado.
