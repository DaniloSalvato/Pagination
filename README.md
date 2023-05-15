
# Título do Projeto

Uma API de teste de paginação com o intuito de praticar programação com C# e .NET, ela dispõe de end point's para criação de uma lista de algo genérico, e um com uma listagem paginada. Neste projeto também foi utilizado o EntityFramework é um framework de mapeamento objeto-relacional (ORM) para a plataforma .NET o banco de dados utilizado foi o Sqlite. 


# Documentação da API

## Agendas


``http
  GET /v1/todos/load
``
#### Cria uma lista de itens

``http
  GET /v1/todos/skip/{skip}/take/{take}
``
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `skip` | `int` | **Obrigatório** |
| `take` | `int` | **Obrigatório** |

#### Faz a listagem paginada



