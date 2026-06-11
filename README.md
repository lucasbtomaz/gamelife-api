# GameLife 
O Gerenciador de jogos para substituir as planilhas por um sistema moderno e robusto para gerenciar coleção de jogos e conquistas.

## Sobre o projeto
O GameLife é um projeto pessoal de backend, desenvolvido em .NET 10, com o objetivo de aprofundar seus conhecimentos em Programação Orientada a Objetos (POO), princípios SOLID e design patterns. 
Este documento serve como um guia para o desenvolvimento, especificando as regras de negócio, a arquitetura do sistema e o plano de implementação. 
O projeto será usado como portfólio, por isso, as boas práticas de CI/CD e a organização do repositório também são abordadas.

## Estrutura de branches

main         → produção (protegida)
release       → pré-produção/homologação (protegida)
development   → integração contínua (protegida, mas menos restrita)
feature/*     → branches de trabalho (a partir de development)

## Fluxo

feature/xxx → PR → development → PR → release → PR → main

## Funcionalidades
**Coleção de Jogos:** Adição, edição e remoção de jogos.
**Detalhes de Progresso:** Registro de tempo de jogo, conquistas, notas e data de finalização.
**Monitoramento de Preços:** Acompanhamento de preços de jogos em diferentes plataformas.