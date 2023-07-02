# GenericRepositoryPattern
# Description
Web API using a generic repository with Entity Framework Core with MySql database
# Web
Includes the startup project where the project ist configured an the database context is injected.
# Service
- Service.User provides a endpoint(s) to add or get the user data from database.
# BusinessLogic
- BusinessLogic.Shared
  provaides a generic repository to access the data stored in database.

- BusinessLogic.User
  provaides the user data repository to access the user data stored in database.
# Data
- Data.AppContext
  includes the configuration of the database context.
# Shared
- Shared.AppContext
  provides the entities for the database context
  

