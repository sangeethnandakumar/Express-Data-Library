# Express.Data

Express.Data allows easy SQL data transaction by making use of Dapper, DapperContrib and DTO classes 

### Versions

Version Information

| Version | Change log |
| ------ | ------ |
| 1.1 | Dapper 1.1, Dapper.Contrib 1.1 |



### Usage
Insert a modal
```csharp
var record = new tblUser {
	Id = 1,
	FName = "Sangeeth",
	LName = "Nandakumar"
};
var primaryKey = SqlHelper.Insert < tblUser > (record, _connectionString);
```
Update a modal
```csharp
record = new tblUser {
	Id = 1,
	FName = "Navaneeth",
	LName = "Nandakumar"
};
var isUpdated = SqlHelper.Update < tblUser > (record, _connectionString);
```
Run a query
```csharp
var sql1 = $ "SELECT * FROM tblUser WHERE Id=1";
var result = SqlHelper.Query < tblUser > (sql1, _connectionString).FirstOrDefault();
```
Run a safe query (Parameterised query)
```csharp
var sql2 = $ "SELECT * FROM tblUser WHERE Id=@id AND Fname=@fname";
result = SqlHelper.QuerySafe < tblUser > (sql2, new {
	id = 1,
	fname = "Navaneeth"
},
_connectionString);
```
Run a stored procedure
```csharp
var procedureName = $ "spGetUsers";
result = SqlHelper.Execute < tblUser > (procedureName, new {
	id = 1
},
_connectionString).FirstOrDefault();
```
