USE [master]
GO
/****** Object:  Database [IngredientChecklist]    Script Date: 28/01/2019 8:40:11 PM ******/
CREATE DATABASE [IngredientChecklist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IngredientChecklist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\IngredientChecklist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IngredientChecklist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\IngredientChecklist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IngredientChecklist] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IngredientChecklist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ARITHABORT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IngredientChecklist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IngredientChecklist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IngredientChecklist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IngredientChecklist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IngredientChecklist] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IngredientChecklist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IngredientChecklist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IngredientChecklist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IngredientChecklist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IngredientChecklist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IngredientChecklist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IngredientChecklist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IngredientChecklist] SET RECOVERY FULL 
GO
ALTER DATABASE [IngredientChecklist] SET  MULTI_USER 
GO
ALTER DATABASE [IngredientChecklist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IngredientChecklist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IngredientChecklist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IngredientChecklist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IngredientChecklist] SET DELAYED_DURABILITY = DISABLED 
GO
USE [IngredientChecklist]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 28/01/2019 8:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[RecipeId] [int] NULL,
	[IsChecked] [bit] NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 28/01/2019 8:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/01/2019 8:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredient_Ingredient] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([Id])
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredient_Ingredient]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_User]
GO
USE [master]
GO
ALTER DATABASE [IngredientChecklist] SET  READ_WRITE 
GO
-- INSERT RECORDS
-- User Table
INSERT INTO [IngredientChecklist].[dbo].[User]
VALUES ('admin', 'admin', 'aaaaa')

INSERT INTO [IngredientChecklist].[dbo].[User]
VALUES ('Arthur Boris', 'aboris', 'aboris')

INSERT INTO [IngredientChecklist].[dbo].[User]
VALUES ('Anastasia Petrov', 'apetrov', 'apetrov')

-- Recipe Table
INSERT INTO [IngredientChecklist].[dbo].[Recipe]
SELECT 'Grilled Cheese', u.Id FROM [IngredientChecklist].[dbo].[User] u WHERE UserName = 'aboris'

INSERT INTO [IngredientChecklist].[dbo].[Recipe]
SELECT 'Pasta Salad', u.Id FROM [IngredientChecklist].[dbo].[User] u WHERE UserName = 'aboris'

INSERT INTO [IngredientChecklist].[dbo].[Recipe]
SELECT 'Cake', u.Id FROM [IngredientChecklist].[dbo].[User] u WHERE UserName = 'apetrov'
INSERT INTO [IngredientChecklist].[dbo].[Recipe]
SELECT 'Macarons', u.Id FROM [IngredientChecklist].[dbo].[User] u WHERE UserName = 'apetrov'

-- Ingredient Table
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Bread', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Grilled Cheese'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Butter', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Grilled Cheese'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Cheese', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Grilled Cheese'

INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Chilled Pasta', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Pasta Salad'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Vinegar', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Pasta Salad'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Oil', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Pasta Salad'

INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Sugar', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Butter', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Flour', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Eggs', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Vanilla Extract', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Milk', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Baking Powder', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Cake'

INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Eggs', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Macarons'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Confectioners Sugar', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Macarons'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Almond Flour', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Macarons'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Salt', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Macarons'
INSERT INTO [IngredientChecklist].[dbo].[Ingredient]
SELECT 'Castor sugar', r.Id, 0 FROM [IngredientChecklist].[dbo].[Recipe] r WHERE Name = 'Macarons'