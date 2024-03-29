USE [master]
GO
/****** Object:  Database [Workshop]    Script Date: 12.05.2022 10:19:45 ******/
CREATE DATABASE [Workshop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Workshop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Workshop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Workshop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Workshop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Workshop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Workshop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Workshop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Workshop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Workshop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Workshop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Workshop] SET ARITHABORT OFF 
GO
ALTER DATABASE [Workshop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Workshop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Workshop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Workshop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Workshop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Workshop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Workshop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Workshop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Workshop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Workshop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Workshop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Workshop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Workshop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Workshop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Workshop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Workshop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Workshop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Workshop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Workshop] SET  MULTI_USER 
GO
ALTER DATABASE [Workshop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Workshop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Workshop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Workshop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Workshop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Workshop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Workshop] SET QUERY_STORE = OFF
GO
USE [Workshop]
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 12.05.2022 10:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NOT NULL,
	[Count] [int] NULL,
	[Month] [tinyint] NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatalog]    Script Date: 12.05.2022 10:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Shop] [int] NOT NULL,
	[ProductGroup] [int] NOT NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_ProductCatalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 12.05.2022 10:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopCatalog]    Script Date: 12.05.2022 10:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopCatalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ShopCatalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Plan] ON 

INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (1, 1, 100, 5)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (2, 7, 450, 3)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (3, 2, 30, 2)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (4, 3, 13, 12)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (5, 5, 400, 7)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (6, 4, 354, 8)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (7, 6, 5000, 11)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (8, 9, 100, 5)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (9, 10, 12, 4)
INSERT [dbo].[Plan] ([Id], [Product], [Count], [Month]) VALUES (10, 8, 45444, 9)
SET IDENTITY_INSERT [dbo].[Plan] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCatalog] ON 

INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (1, N'Ткани готовые льняные', N'м2', 1, 1, 100.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (2, N'Ткани шерстяные', N'м2', 2, 1, 250.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (3, N'Ткани шелковые', N'м2', 1, 1, 135.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (4, N'Трансформаторы силовые', N'шт', 6, 6, 70000.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (5, N'Комплектные подстанции', N'шт', 7, 6, 700000.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (6, N'Насосное оборудование', N'шт', 6, 7, 350000.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (7, N'Мясо', N'кг', 1, 4, 354.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (8, N'Субпродукт', N'кг', 1, 4, 200.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (9, N'Сахар', N'кг', 10, 5, 278.0000)
INSERT [dbo].[ProductCatalog] ([Id], [Name], [Unit], [Shop], [ProductGroup], [Price]) VALUES (10, N'Хлеб из пшеничной муки', N'кг', 3, 2, 120.0000)
SET IDENTITY_INSERT [dbo].[ProductCatalog] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductGroup] ON 

INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (1, N'Продукция текстильной промышленности')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (2, N'Продукция трикотажной промышленности')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (3, N'Продукция кожевенной промышленности')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (4, N'Продукция мясной, молочной промышленности')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (5, N'Продукция животноводства')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (6, N'Продукция кабельная')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (7, N'Продукция химического машиностроения')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (8, N'Продукция нефтяного машиностроения')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (9, N'Продукция резинотехническая')
INSERT [dbo].[ProductGroup] ([Id], [Name]) VALUES (10, N'Продукция неорганической химии')
SET IDENTITY_INSERT [dbo].[ProductGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[ShopCatalog] ON 

INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (1, N'Колбасный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (2, N'Кондитерский цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (3, N'Горячий цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (4, N'Холодный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (5, N'Рыбный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (6, N'Швейный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (7, N'Транспортный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (8, N'Ремонтный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (9, N'Сварочный цех')
INSERT [dbo].[ShopCatalog] ([Id], [Name]) VALUES (10, N'Овощной цех')
SET IDENTITY_INSERT [dbo].[ShopCatalog] OFF
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_ProductCatalog] FOREIGN KEY([Product])
REFERENCES [dbo].[ProductCatalog] ([Id])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_Plan_ProductCatalog]
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [FK_ProductCatalog_ProductGroup] FOREIGN KEY([ProductGroup])
REFERENCES [dbo].[ProductGroup] ([Id])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [FK_ProductCatalog_ProductGroup]
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [FK_ProductCatalog_ShopCatalog] FOREIGN KEY([Shop])
REFERENCES [dbo].[ShopCatalog] ([Id])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [FK_ProductCatalog_ShopCatalog]
GO
USE [master]
GO
ALTER DATABASE [Workshop] SET  READ_WRITE 
GO
