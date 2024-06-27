create table Tbl_Customer
(
    CustomerId   int identity
        primary key,
    CustomerCode varchar(50) not null,
    CustomerName varchar(50) not null,
    MobileNo     varchar(20) not null
)
    go

create table Tbl_CustomerBalance
(
    CustomerBalanceId int identity
        primary key,
    CustomerCode      varchar(50)    not null,
    Balance           decimal(20, 2) not null
)
    go

create table Tbl_CustomerTransactionHistory
(
    CustomerTransactionHistoryId int identity
        primary key,
    FromMobileNo                 varchar(20)    not null,
    ToMobileNo                   varchar(20)    not null,
    Amount                       decimal(20, 2) not null,
    TransactionDate              datetime       not null
)
    go

INSERT INTO dbo.Tbl_Customer (CustomerCode, CustomerName, MobileNo) VALUES (N'C001', N'Sann Lynn Htun', N'09123456789');
INSERT INTO dbo.Tbl_Customer (CustomerCode, CustomerName, MobileNo) VALUES (N'C002', N'Lynn Htun', N'0987654321');
INSERT INTO dbo.Tbl_CustomerBalance (CustomerCode, Balance) VALUES (N'C001', 10000.00);
INSERT INTO dbo.Tbl_CustomerBalance (CustomerCode, Balance) VALUES (N'C002', 3000.00);
INSERT INTO dbo.Tbl_CustomerTransactionHistory (FromMobileNo, ToMobileNo, Amount, TransactionDate) VALUES (N'09123456789', N'0987654321', 5000.00, N'2024-06-15 00:00:00.000');
INSERT INTO dbo.Tbl_CustomerTransactionHistory (FromMobileNo, ToMobileNo, Amount, TransactionDate) VALUES (N'09123456789', N'0987654321', 1000.00, N'2024-06-15 00:00:00.000');
