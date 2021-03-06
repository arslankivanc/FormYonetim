USE [master]
GO
/****** Object:  Database [FormManagement]    Script Date: 26.11.2020 02:17:03 ******/
CREATE DATABASE [FormManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FormManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FormManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FormManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\FormManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FormManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FormManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FormManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FormManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FormManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FormManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [FormManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FormManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FormManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FormManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FormManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FormManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FormManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FormManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FormManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FormManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FormManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FormManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FormManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FormManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FormManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FormManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FormManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FormManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FormManagement] SET  MULTI_USER 
GO
ALTER DATABASE [FormManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FormManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FormManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FormManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [FormManagement]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 26.11.2020 02:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[formName] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[createdAt] [datetime] NULL,
	[createdBy] [int] NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[age] [int] NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26.11.2020 02:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([Id], [formName], [description], [createdAt], [createdBy], [name], [surname], [age]) VALUES (1006, N'form name', NULL, CAST(N'2020-11-25T22:21:54.677' AS DateTime), 1, N'ad', N'soyad', NULL)
INSERT [dbo].[Forms] ([Id], [formName], [description], [createdAt], [createdBy], [name], [surname], [age]) VALUES (1007, N'Kullanıcı Formu', NULL, CAST(N'2020-11-25T22:25:00.313' AS DateTime), 1, N'Gazi Osman', N'Paşa', NULL)
INSERT [dbo].[Forms] ([Id], [formName], [description], [createdAt], [createdBy], [name], [surname], [age]) VALUES (1008, N'Fatura', NULL, CAST(N'2020-11-25T22:27:23.670' AS DateTime), 1, N'Halime', N'Çavuş', NULL)
SET IDENTITY_INSERT [dbo].[Forms] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [username], [password], [role]) VALUES (1, N'kivanc', N'Arslan123', N'user')
INSERT [dbo].[User] ([Id], [username], [password], [role]) VALUES (2, N'admin', N'Admin123', N'user')
INSERT [dbo].[User] ([Id], [username], [password], [role]) VALUES (3, N'admin1', N'Admin111', N'user')
INSERT [dbo].[User] ([Id], [username], [password], [role]) VALUES (4, N'admin2', N'Admin2312', N'user')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Forms]  WITH CHECK ADD  CONSTRAINT [FK_Forms_User] FOREIGN KEY([createdBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Forms] CHECK CONSTRAINT [FK_Forms_User]
GO
USE [master]
GO
ALTER DATABASE [FormManagement] SET  READ_WRITE 
GO
