USE [master]
GO
/****** Object:  Database [Lab1_231]    Script Date: 22-Sep-23 9:42:16 AM ******/
CREATE DATABASE [Lab1_231]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lab1_231', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\Lab1_231.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lab1_231_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\Lab1_231_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Lab1_231] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lab1_231].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lab1_231] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lab1_231] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lab1_231] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lab1_231] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lab1_231] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lab1_231] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lab1_231] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lab1_231] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lab1_231] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lab1_231] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lab1_231] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lab1_231] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lab1_231] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lab1_231] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lab1_231] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lab1_231] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lab1_231] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lab1_231] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lab1_231] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lab1_231] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lab1_231] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lab1_231] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lab1_231] SET RECOVERY FULL 
GO
ALTER DATABASE [Lab1_231] SET  MULTI_USER 
GO
ALTER DATABASE [Lab1_231] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lab1_231] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lab1_231] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lab1_231] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lab1_231] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lab1_231] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Lab1_231', N'ON'
GO
ALTER DATABASE [Lab1_231] SET QUERY_STORE = OFF
GO
USE [Lab1_231]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 22-Sep-23 9:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 22-Sep-23 9:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[CategoryID] [int] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitPrice] [money] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [Lab1_231] SET  READ_WRITE 
GO
