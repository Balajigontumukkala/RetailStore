USE [master]
GO
/****** Object:  Database [RetailStore]    Script Date: 12/5/2019 12:59:18 PM ******/
CREATE DATABASE [RetailStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RetailStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RetailStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RetailStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RetailStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RetailStore] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RetailStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RetailStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RetailStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RetailStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RetailStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RetailStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [RetailStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RetailStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RetailStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RetailStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RetailStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RetailStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RetailStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RetailStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RetailStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RetailStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RetailStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RetailStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RetailStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RetailStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RetailStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RetailStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RetailStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RetailStore] SET RECOVERY FULL 
GO
ALTER DATABASE [RetailStore] SET  MULTI_USER 
GO
ALTER DATABASE [RetailStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RetailStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RetailStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RetailStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RetailStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RetailStore', N'ON'
GO
ALTER DATABASE [RetailStore] SET QUERY_STORE = OFF
GO
USE [RetailStore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [RetailStore]
GO
/****** Object:  Schema [metadata]    Script Date: 12/5/2019 12:59:18 PM ******/
CREATE SCHEMA [metadata]
GO
/****** Object:  Schema [sec]    Script Date: 12/5/2019 12:59:18 PM ******/
CREATE SCHEMA [sec]
GO
/****** Object:  Schema [sku]    Script Date: 12/5/2019 12:59:18 PM ******/
CREATE SCHEMA [sku]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [metadata].[Category]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [metadata].[Category](
	[CategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [metadata].[Department]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [metadata].[Department](
	[DepartmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [metadata].[Location]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [metadata].[Location](
	[LocationId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [metadata].[SubCategory]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [metadata].[SubCategory](
	[SubcategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubcategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sku].[SkuDetails]    Script Date: 12/5/2019 12:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sku].[SkuDetails](
	[SkuId] [bigint] IDENTITY(1,1) NOT NULL,
	[SkuName] [varchar](100) NULL,
	[LocationId] [bigint] NULL,
	[DepartmentId] [bigint] NULL,
	[CategoryId] [bigint] NULL,
	[SubcategoryId] [bigint] NULL,
 CONSTRAINT [PK_SKUDetails] PRIMARY KEY CLUSTERED 
(
	[SkuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0a1eec45-2b99-492d-8c6c-58efc98586e4', N'g.balaji225@gmail.com', N'G.BALAJI225@GMAIL.COM', N'g.balaji225@gmail.com', N'G.BALAJI225@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHzXxYS0GwLo6+OEbcVBfnemkhPf/UW6Xxn8p2lnqOnsysB12MNP136hgZZJw7rt8g==', N'G4CJBI6ZKB7WUAPBIRIVH3FXE3225KB7', N'1c06557c-9480-4c79-b241-9733952e26da', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [metadata].[Category] ON 

INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (2, 5, N'Bakery Bread', N'Bakery Bread')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (3, 5, N'In Store Bakery', N'In Store Bakery')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (4, 9, N'Cheese', N'Cheese')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (5, 9, N'Cream or Creamer', N'Cream or Creamer')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (6, 10, N'Frozen Bake', N'Frozen Bake')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (7, 10, N'Frozen Breakfast', N'Frozen Breakfast')
INSERT [metadata].[Category] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (8, 6, N'Self Service Deli Cold', N'Self Service Deli Cold')
SET IDENTITY_INSERT [metadata].[Category] OFF
SET IDENTITY_INSERT [metadata].[Department] ON 

INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (5, 7, N'Bakery', N'Bakery')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (6, 7, N'Deli and Foodservice', N'Deli and Foodservice')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (7, 7, N'Floral', N'Floral')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (8, 7, N'Seafood', N'Seafood')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (9, 8, N'Dairy', N'Dairy')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (10, 8, N'Frozen', N'Frozen')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (11, 8, N'GM', N'GM')
INSERT [metadata].[Department] ([DepartmentId], [LocationId], [Name], [Description]) VALUES (12, 8, N'Grocery', N'Grocery')
SET IDENTITY_INSERT [metadata].[Department] OFF
SET IDENTITY_INSERT [metadata].[Location] ON 

INSERT [metadata].[Location] ([LocationId], [Name], [Description]) VALUES (7, N'Perimeter', N'Perimeter')
INSERT [metadata].[Location] ([LocationId], [Name], [Description]) VALUES (8, N'Center', N'Center')
SET IDENTITY_INSERT [metadata].[Location] OFF
SET IDENTITY_INSERT [metadata].[SubCategory] ON 

INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (3, 2, N'Bagels', N'Bagels')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (4, 2, N'Baking or Breading Products ', N'Baking or Breading Products ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (5, 2, N'English Muffins or Biscuits ', N'English Muffins or Biscuits ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (6, 2, N'Flatbreads ', N'Flatbreads ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (7, 3, N',Breakfast Cake or Sweet Roll ', N',Breakfast Cake or Sweet Roll ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (8, 3, N'Cakes ', N'Cakes ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (9, 3, N'Pies ', N'Pies ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (10, 3, N'Seasonal ', N'Seasonal ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (11, 4, N'Cheese Sauce ', N'Cheese Sauce ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (12, 4, N'Specialty Cheese ', N'Specialty Cheese ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (13, 5, N'Dairy Alternative Creamer ', N'Dairy Alternative Creamer ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (14, 5, N'Whipping Creams ', N'Whipping Creams ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (15, 6, N'Bread or Dough Products Frozen ', N'Bread or Dough Products Frozen ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (16, 6, N'Breakfast Cake or Sweet Roll Frozen ', N'Breakfast Cake or Sweet Roll Frozen ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (17, 7, N'Frozen Breakfast Entrees', N'Frozen Breakfast Entrees')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (18, 7, N'Frozen Breakfast Sandwich', N'Frozen Breakfast Sandwich')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (19, 7, N'Frozen Egg Substitutes ', N'Frozen Egg Substitutes ')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (20, 7, N'Frozen Syrup Carriers', N'Frozen Syrup Carriers')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (21, 8, N'Beverages', N'Beverages')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (22, 8, N'Cheese All Other', N'Cheese All Other
')
INSERT [metadata].[SubCategory] ([SubcategoryId], [CategoryId], [Name], [Description]) VALUES (23, 8, N'Cheese American ', N'Cheese American ')
SET IDENTITY_INSERT [metadata].[SubCategory] OFF
SET IDENTITY_INSERT [sku].[SkuDetails] ON 

INSERT [sku].[SkuDetails] ([SkuId], [SkuName], [LocationId], [DepartmentId], [CategoryId], [SubcategoryId]) VALUES (3, N'SKUDESC1', 7, 5, 2, 3)
INSERT [sku].[SkuDetails] ([SkuId], [SkuName], [LocationId], [DepartmentId], [CategoryId], [SubcategoryId]) VALUES (4, N'SKUDESC2', 7, 6, 8, 21)
INSERT [sku].[SkuDetails] ([SkuId], [SkuName], [LocationId], [DepartmentId], [CategoryId], [SubcategoryId]) VALUES (5, N'SKUDESC3', 7, 5, 2, 3)
INSERT [sku].[SkuDetails] ([SkuId], [SkuName], [LocationId], [DepartmentId], [CategoryId], [SubcategoryId]) VALUES (6, N'SKUDESC4', 7, 6, 8, 21)
INSERT [sku].[SkuDetails] ([SkuId], [SkuName], [LocationId], [DepartmentId], [CategoryId], [SubcategoryId]) VALUES (7, N'SKUDESC5', 8, 9, 4, 11)
SET IDENTITY_INSERT [sku].[SkuDetails] OFF
USE [master]
GO
ALTER DATABASE [RetailStore] SET  READ_WRITE 
GO
