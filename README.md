- ASP.NET Core Web API
	- C# - Database
		- Ado.Net (old school)
		- Dapper
		- EFCore
--------------------

AdoDotNetService
DapperService

--------------------

C#

Banking Project

Mobile Banking
Internet Banking (Web)

React Native

C# ASP.NET Core Web API
.net core 3.1
.net 7
	- asp.net core web api
	- ibanking, admin portal (blazor server)

--------------------
	
asp.net core web api
- create project
- http method (get, post, put, patch, delete)
- http status code 
- controller (web api)
- postman testing
- controller + database (dapper)

--------------------

- controller
	- validation
- business logic
	- kpay
		- from mobile no - to mobile no, amount => password => transfer
		if mobile no amount (max amount) > transfer amount
		to mobile no (account doesn't exist)
		
		- from mobile no - decrease amount
		- to mobile no - increase amount
		- from - to - amount ? - tranfer - transaction history one row
- data access
	- database
		- update query
		- update query
		- insert query

--------------------
		
```sql
Tbl_Customer
- CustomerId int
- CustomerCode varchar(50)
- CustomerName varchar(50)
- MobileNo varchar(20)

Tbl_CustomerBalance
- CustomerBalanceId int
- CustomerCode varchar(50)
- Balance decimal(20, 2)

Tbl_CustomerTransactionHistory
- CustomerTransactionHistoryId int
- FromMobileNo varchar(20)
- ToMobileNo varchar(20)
- Amount decimal(20, 2)
- TransactionDate datetime
```

