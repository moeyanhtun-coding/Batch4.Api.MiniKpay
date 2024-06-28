USE [master]
GO
/****** Object:  Database [MiniKpay]    Script Date: 6/28/2024 3:51:16 PM ******/
CREATE DATABASE [MiniKpay] ON  PRIMARY 
( NAME = N'MiniKpay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MiniKpay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiniKpay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MiniKpay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiniKpay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiniKpay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiniKpay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiniKpay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiniKpay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiniKpay] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiniKpay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiniKpay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiniKpay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiniKpay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiniKpay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiniKpay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiniKpay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiniKpay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiniKpay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiniKpay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MiniKpay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiniKpay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiniKpay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiniKpay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiniKpay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiniKpay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiniKpay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiniKpay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MiniKpay] SET  MULTI_USER 
GO
ALTER DATABASE [MiniKpay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiniKpay] SET DB_CHAINING OFF 
GO
USE [MiniKpay]
GO
/****** Object:  Table [dbo].[Tbl_Customer]    Script Date: 6/28/2024 3:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [varchar](50) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_CustomerBalance]    Script Date: 6/28/2024 3:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_CustomerBalance](
	[CustomerBalanceId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [varchar](50) NOT NULL,
	[Balance] [decimal](20, 2) NOT NULL,
	[MobileNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_CustomerBalance1] PRIMARY KEY CLUSTERED 
(
	[CustomerBalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_CustomerTransactionHistory]    Script Date: 6/28/2024 3:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_CustomerTransactionHistory](
	[CustomerTransactionHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[FromMobileNo] [varchar](20) NOT NULL,
	[ToMobileNo] [varchar](20) NOT NULL,
	[Amount] [decimal](20, 2) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerTransactionHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Customer] ON 

INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerCode], [CustomerName], [MobileNo]) VALUES (1, N'C001', N'Sann Lynn Htun', N'09123456789')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [CustomerCode], [CustomerName], [MobileNo]) VALUES (2, N'C002', N'Lynn Htun', N'0987654321')
SET IDENTITY_INSERT [dbo].[Tbl_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_CustomerBalance] ON 

INSERT [dbo].[Tbl_CustomerBalance] ([CustomerBalanceId], [CustomerCode], [Balance], [MobileNo]) VALUES (1, N'C001', CAST(5000.00 AS Decimal(20, 2)), N'09123456789')
INSERT [dbo].[Tbl_CustomerBalance] ([CustomerBalanceId], [CustomerCode], [Balance], [MobileNo]) VALUES (2, N'C002', CAST(10000.00 AS Decimal(20, 2)), N'0987654321')
SET IDENTITY_INSERT [dbo].[Tbl_CustomerBalance] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_CustomerTransactionHistory] ON 

INSERT [dbo].[Tbl_CustomerTransactionHistory] ([CustomerTransactionHistoryId], [FromMobileNo], [ToMobileNo], [Amount], [TransactionDate]) VALUES (1, N'09123456789', N'0987654321', CAST(5000.00 AS Decimal(20, 2)), CAST(N'2024-06-28T15:33:06.923' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_CustomerTransactionHistory] OFF
GO
USE [master]
GO
ALTER DATABASE [MiniKpay] SET  READ_WRITE 
GO
