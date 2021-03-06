USE [master]
GO
/****** Object:  Database [PropertyRentalManagementWebSiteDB]    Script Date: 2021-12-10 2:06:16 AM ******/
CREATE DATABASE [PropertyRentalManagementWebSiteDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyRentalManagementWebSiteDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\PropertyRentalManagementWebSiteDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyRentalManagementWebSiteDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\PropertyRentalManagementWebSiteDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyRentalManagementWebSiteDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET QUERY_STORE = OFF
GO
USE [PropertyRentalManagementWebSiteDB]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 2021-12-10 2:06:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrators](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminUsername] [nvarchar](50) NOT NULL,
	[AdminPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 2021-12-10 2:06:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[ApartmentId] [int] IDENTITY(9000,1) NOT NULL,
	[ApartmentType] [nvarchar](50) NOT NULL,
	[ApartmentPrice] [nvarchar](50) NOT NULL,
	[ApartmentAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentAssignments]    Script Date: 2021-12-10 2:06:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentAssignments](
	[AssignmentId] [int] IDENTITY(5000,1) NOT NULL,
	[ManagerId] [int] NULL,
	[TenantId] [int] NULL,
	[ApartmentId] [int] NULL,
	[Date] [date] NULL,
	[NoteMessage] [nvarchar](50) NULL,
 CONSTRAINT [PK_AppointmentAssignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 2021-12-10 2:06:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ManagerId] [int] IDENTITY(1000,1) NOT NULL,
	[ManagerUsername] [nvarchar](50) NOT NULL,
	[ManagerPassword] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](50) NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 2021-12-10 2:06:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] IDENTITY(2000,1) NOT NULL,
	[TenantUsername] [nvarchar](50) NULL,
	[TenantPassword] [nvarchar](50) NULL,
	[TenantFirstName] [nvarchar](50) NULL,
	[TenantLastName] [nvarchar](50) NULL,
	[TenantEmail] [nvarchar](50) NULL,
	[TenantPhonenumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tenauts] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([AdminId], [AdminUsername], [AdminPassword]) VALUES (16, N'admin1', N'111')
INSERT [dbo].[Administrators] ([AdminId], [AdminUsername], [AdminPassword]) VALUES (17, N'admin2', N'222')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([ApartmentId], [ApartmentType], [ApartmentPrice], [ApartmentAddress]) VALUES (9020, N'Condo', N'2900/Month', N'2020 Lincon')
INSERT [dbo].[Apartments] ([ApartmentId], [ApartmentType], [ApartmentPrice], [ApartmentAddress]) VALUES (9022, N'House', N'900/Month', N'845 Ch Tiffin, Longueuil')
INSERT [dbo].[Apartments] ([ApartmentId], [ApartmentType], [ApartmentPrice], [ApartmentAddress]) VALUES (9023, N'Condo', N'1500/Month', N'2020 Rue Mario')
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[AppointmentAssignments] ON 

INSERT [dbo].[AppointmentAssignments] ([AssignmentId], [ManagerId], [TenantId], [ApartmentId], [Date], [NoteMessage]) VALUES (5023, 1002, 2060, 9022, CAST(N'2021-12-01' AS Date), N'On time!')
INSERT [dbo].[AppointmentAssignments] ([AssignmentId], [ManagerId], [TenantId], [ApartmentId], [Date], [NoteMessage]) VALUES (5024, 1002, 2059, 9022, CAST(N'2021-12-31' AS Date), N'On time!')
INSERT [dbo].[AppointmentAssignments] ([AssignmentId], [ManagerId], [TenantId], [ApartmentId], [Date], [NoteMessage]) VALUES (5025, 1004, 2060, 9020, CAST(N'2021-12-29' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[AppointmentAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Managers] ON 

INSERT [dbo].[Managers] ([ManagerId], [ManagerUsername], [ManagerPassword], [Message]) VALUES (1002, N'manager1', N'111', NULL)
INSERT [dbo].[Managers] ([ManagerId], [ManagerUsername], [ManagerPassword], [Message]) VALUES (1004, N'manager2', N'222', NULL)
SET IDENTITY_INSERT [dbo].[Managers] OFF
GO
SET IDENTITY_INSERT [dbo].[Tenants] ON 

INSERT [dbo].[Tenants] ([TenantId], [TenantUsername], [TenantPassword], [TenantFirstName], [TenantLastName], [TenantEmail], [TenantPhonenumber]) VALUES (2059, N'test1', N'test1', N'Mary', N'Brown', N'mary@gmail.com', N'514-444-4444')
INSERT [dbo].[Tenants] ([TenantId], [TenantUsername], [TenantPassword], [TenantFirstName], [TenantLastName], [TenantEmail], [TenantPhonenumber]) VALUES (2060, N'test2', N'test2', N'Joe', N'Bob', N'Joe@yahoo.com', N'514-555-5555')
SET IDENTITY_INSERT [dbo].[Tenants] OFF
GO
ALTER TABLE [dbo].[AppointmentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentAssignments_Apartments] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartments] ([ApartmentId])
GO
ALTER TABLE [dbo].[AppointmentAssignments] CHECK CONSTRAINT [FK_AppointmentAssignments_Apartments]
GO
ALTER TABLE [dbo].[AppointmentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentAssignments_Managers] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Managers] ([ManagerId])
GO
ALTER TABLE [dbo].[AppointmentAssignments] CHECK CONSTRAINT [FK_AppointmentAssignments_Managers]
GO
ALTER TABLE [dbo].[AppointmentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentAssignments_Tenauts] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenants] ([TenantId])
GO
ALTER TABLE [dbo].[AppointmentAssignments] CHECK CONSTRAINT [FK_AppointmentAssignments_Tenauts]
GO
USE [master]
GO
ALTER DATABASE [PropertyRentalManagementWebSiteDB] SET  READ_WRITE 
GO
