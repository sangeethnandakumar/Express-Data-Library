# Express.Data

Express.Data allows easy SQL data transaction by making use of Dapper, DapperContrib and DTO classes 

### Versions

Version Information

| Version | Change log |
| ------ | ------ |
| 1.1 | Dapper 1.1, Dapper.Contrib 1.1 |



### Usage
Query a scalar
```csharp
var data = SqlHelper.Query<string>("SELECT Firstname FROM tblStudents WHERE Id=1", _connectionString).FirstOrDefault();
```
Query a model/dto object
```csharp
var data = SqlHelper.Query<User>("SELECT TOP(1) * FROM tblUsers", _connectionString).FirstOrDefault();
```
Query a list of model/dto object
```csharp
var data = SqlHelper.Query<User>("SELECT TOP(1) * FROM tblUsers", _connectionString);
```
Call a stored procedure
```csharp
var data = SqlHelper.Exec<User>("sp_GetUsers", _connectionString);
```
Insert a record modal
```csharp
var user = new User("fname", "lname");
var data = SqlHelper.Insert(user, _connectionString);
```
Update a record modal
```csharp
var user = new User("fname", "lname");
var data = SqlHelper.Update(user, _connectionString);
```
