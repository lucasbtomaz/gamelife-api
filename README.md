# GameLife 
O Gerenciador de jogos para substituir as planilhas por um sistema moderno e robusto para gerenciar coleção de jogos e conquistas.

## Sobre o projeto
O GameLife é um projeto pessoal de backend, desenvolvido em .NET 8, com o objetivo de aprofundar seus conhecimentos em Programação Orientada a Objetos (POO), princípios SOLID e design patterns. Este documento serve como um guia para o desenvolvimento, especificando as regras de negócio, a arquitetura do sistema e o plano de implementação. O projeto será usado como portfólio, por isso, as boas práticas de CI/CD e a organização do repositório também são abordadas.

## Configurações do Repositório e CI/CD
**main:** Branch de produção. Protegida contra commits diretos.
**dev:** Branch de desenvolvimento e homologação. Todas as novas funcionalidades são mergeadas aqui.
**feature/<nome-da-feature>:** Branch para o desenvolvimento de novas funcionalidades, como feature/adicionar-jogo.

## Funcionalidades
**Coleção de Jogos:** Adição, edição e remoção de jogos.
**Detalhes de Progresso:** Registro de tempo de jogo, conquistas, notas e data de finalização.
**Monitoramento de Preços:** Acompanhamento de preços de jogos em diferentes plataformas.

## Tecnologias e Boas Práticas
**Backend:** ASP.NET 8 Web API
**Banco de Dados:** Entity Framework Core com SQLite
**Padrões de Projeto:** Repository Pattern
**Princípios:** SOLID
**CI/CD:** GitHub Actions

## Como Executar o Projeto
Para incluir instruções claras para clonar o repositório, instalar dependências, rodar migrações e iniciar a API.
