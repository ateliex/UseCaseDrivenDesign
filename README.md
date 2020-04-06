# Use Case Driven Design

## Visão da Arquitetura

![Visão da Arquitetura](Resources/docs/Visão%20da%20Aqruitetura.png)

## 1 - Casos de Uso

![1 - Casos de Uso](Resources/docs/1%20-%20Casos%20de%20Uso.png)

## Calcula Taxa de Marcação

![Calcula Taxa de Marcação](Resources/docs/Calcula%20Taxa%20de%20Marcação.png)

# Observações
- Todas as camadas são modularizadas pelos conceitos e não pelo viés técnico.
- O projeto Data.SqlClient é para fins didáticos para entender o que um ORM está fazendo.
- Um projeto Net.Http seria ideal para os repositórios do domínio e não para os serviços de aplicação(!?).

# Limitações
- Seed do EF Core obriga "vazar" atributos do modelo de domínio.
- TransactionScope do Sqlite não funcionou.
- Investigar problema de escopo (validateScopes: true) pois o contexto de banco não foi "reaproveitado".
- MVC padrão (com postback) é opinativo e não permite modularizar por coneitos (áreas não são multiníveis).
- Requisições de alteração de estado seriam restritas a uma entidade de cada vez(!?).

# TODO
- Criar um cliente JS (código sob demanad) desacoplado (fora da solution, se possível), que usa o HATEOAS (RDD).
- Criar um cliente .NET (navigation service) desacoplado (fora da solution, se possível), que usa o HATEOAS (RDD).