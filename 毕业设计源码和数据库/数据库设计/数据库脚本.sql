USE [master]
GO
/****** Object:  Database [HomeDB]    Script Date: 2020/6/20 09:06:38 ******/
CREATE DATABASE [HomeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HomeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HomeDB] SET  MULTI_USER 
GO
ALTER DATABASE [HomeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HomeDB', N'ON'
GO
USE [HomeDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminLogin] [nvarchar](20) NOT NULL,
	[AdminPwd] [nvarchar](20) NOT NULL,
	[AdminName] [nvarchar](20) NOT NULL,
	[AdminIdentity] [nvarchar](20) NOT NULL,
	[AdminSex] [nvarchar](2) NOT NULL,
	[AdminAge] [int] NOT NULL,
	[AdminPhone] [nvarchar](11) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyHouse]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyHouse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [date] NOT NULL,
	[UserID] [int] NOT NULL,
	[SellID] [int] NOT NULL,
	[AdminID] [int] NOT NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_BuyHouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lease]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lease](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [date] NOT NULL,
	[StartTime] [date] NOT NULL,
	[EndTime] [date] NOT NULL,
	[UserID] [int] NOT NULL,
	[LeaseID] [int] NOT NULL,
	[AdminID] [int] NOT NULL,
	[RentingState] [int] NULL,
 CONSTRAINT [PK_SingleLease] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaseHouse]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaseHouse](
	[LeaseID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](300) NOT NULL,
	[Describe] [nvarchar](300) NOT NULL,
	[Area] [float] NOT NULL,
	[HouseType] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[LeaseFurniture] [nvarchar](200) NOT NULL,
	[LeaseType] [int] NOT NULL,
	[IsLease] [nvarchar](10) NOT NULL,
	[Contacts] [nvarchar](20) NULL,
	[ContactsPhone] [nvarchar](11) NULL,
	[HousePhone] [nvarchar](11) NULL,
 CONSTRAINT [PK_LeaseHouse] PRIMARY KEY CLUSTERED 
(
	[LeaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Picture]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](100) NULL,
	[LeaseID] [int] NULL,
	[SellID] [int] NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestHouse]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestHouse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReqSex] [nvarchar](2) NULL,
	[ReqAge] [int] NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](300) NULL,
 CONSTRAINT [PK_RequestRent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SellHouse]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellHouse](
	[SellID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](500) NOT NULL,
	[Describe] [nvarchar](500) NOT NULL,
	[Area] [float] NOT NULL,
	[HouseType] [nvarchar](50) NOT NULL,
	[SellPrice] [money] NOT NULL,
	[BuyType] [int] NULL,
	[IsSell] [nvarchar](10) NOT NULL,
	[Contacts] [nvarchar](20) NULL,
	[ContactsPhone] [nvarchar](11) NULL,
	[HousePhone] [nvarchar](11) NULL,
 CONSTRAINT [PK_SellHouse] PRIMARY KEY CLUSTERED 
(
	[SellID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StagesBuyHouse]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StagesBuyHouse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [date] NOT NULL,
	[UserID] [int] NOT NULL,
	[SellID] [int] NOT NULL,
	[AdminID] [int] NOT NULL,
	[NowStages] [int] NOT NULL,
	[ByStages] [int] NOT NULL,
	[IsFinish] [nvarchar](10) NOT NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_StagesBuyHouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2020/6/20 09:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](20) NOT NULL,
	[UserPwd] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[UserSex] [nvarchar](2) NULL,
	[UserAge] [int] NULL,
	[UserPhone] [nvarchar](11) NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminID], [AdminLogin], [AdminPwd], [AdminName], [AdminIdentity], [AdminSex], [AdminAge], [AdminPhone], [State]) VALUES (1, N'yck', N'123456', N'易炽昆', N'123456789011111', N'男', 20, N'17680451251', N'正常')
INSERT [dbo].[Admin] ([AdminID], [AdminLogin], [AdminPwd], [AdminName], [AdminIdentity], [AdminSex], [AdminAge], [AdminPhone], [State]) VALUES (2, N'admin', N'123456', N'管理员', N'123456789011112', N'男', 20, N'17680451251', N'正常')
INSERT [dbo].[Admin] ([AdminID], [AdminLogin], [AdminPwd], [AdminName], [AdminIdentity], [AdminSex], [AdminAge], [AdminPhone], [State]) VALUES (4, N'admin1', N'123456', N'管理员1', N'111111111111112', N'男', 30, N'18174419507', N'正常')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[BuyHouse] ON 

INSERT [dbo].[BuyHouse] ([ID], [Time], [UserID], [SellID], [AdminID], [State]) VALUES (1, CAST(0x3A410B00 AS Date), 11, 7, 2, 0)
SET IDENTITY_INSERT [dbo].[BuyHouse] OFF
SET IDENTITY_INSERT [dbo].[Lease] ON 

INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (4, CAST(0x34410B00 AS Date), CAST(0x34410B00 AS Date), CAST(0x45410B00 AS Date), 11, 7, 2, 0)
INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (6, CAST(0x38410B00 AS Date), CAST(0x28410B00 AS Date), CAST(0x45410B00 AS Date), 6, 5, 2, 0)
INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (7, CAST(0x38410B00 AS Date), CAST(0x28410B00 AS Date), CAST(0x45410B00 AS Date), 7, 5, 2, 0)
INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (8, CAST(0x38410B00 AS Date), CAST(0x38410B00 AS Date), CAST(0x64410B00 AS Date), 9, 4, 2, 0)
INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (9, CAST(0x38410B00 AS Date), CAST(0x28410B00 AS Date), CAST(0x45410B00 AS Date), 10, 5, 2, 0)
INSERT [dbo].[Lease] ([ID], [Time], [StartTime], [EndTime], [UserID], [LeaseID], [AdminID], [RentingState]) VALUES (13, CAST(0x3A410B00 AS Date), CAST(0x28410B00 AS Date), CAST(0x45410B00 AS Date), 1, 6, 2, 1)
SET IDENTITY_INSERT [dbo].[Lease] OFF
SET IDENTITY_INSERT [dbo].[LeaseHouse] ON 

INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (1, N'湖南长沙岳麓区', N'面积大，地理位置好', 60, N'一室一厅', 500.0000, N'空调，电视，洗衣机', 0, N'否', N'管理员', N'17680451251', N'15107305280')
INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (2, N'湖南长沙芙蓉区', N'靠近小吃街', 70, N'两室一厅', 700.0000, N'空调，洗衣机', 1, N'否', N'管理员1', N'18174419507', N'15107305281')
INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (4, N'湖南长沙县', N'交通便利，附近有大商场', 100, N'三室一厅', 1000.0000, N'空调，洗衣机，电视', 1, N'是', N'管理员', N'17680451251', N'15107305282')
INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (5, N'湖南长沙岳麓区XX小区', N'环境绿化很好', 120, N'三室一厅', 1200.0000, N'无', 1, N'是', N'管理员', N'17680451251', N'15107305283')
INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (6, N'湖南长沙星沙XX小区', N'交通便利', 80, N'一室一厅', 600.0000, N'洗衣机', 0, N'否', N'易炽昆', N'17680451251', N'15107305284')
INSERT [dbo].[LeaseHouse] ([LeaseID], [Position], [Describe], [Area], [HouseType], [Price], [LeaseFurniture], [LeaseType], [IsLease], [Contacts], [ContactsPhone], [HousePhone]) VALUES (7, N'湖南芙蓉区XX小区', N'环境好，交通便利', 120, N'三室一厅', 1300.0000, N'洗衣机', 0, N'是', N'管理员', N'17680451251', N'15107305289')
SET IDENTITY_INSERT [dbo].[LeaseHouse] OFF
SET IDENTITY_INSERT [dbo].[Picture] ON 

INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (1, N'1.jpg', 7, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (3, N'2.jpg', 7, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (4, N'11.jpg', 6, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (5, N'12.jpg', 6, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (6, N'13.jpg', 6, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (7, N'14.jpg', 6, NULL)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (8, N'8.jpg', NULL, 7)
INSERT [dbo].[Picture] ([ID], [PictureName], [LeaseID], [SellID]) VALUES (9, N'15.jpg', NULL, 7)
SET IDENTITY_INSERT [dbo].[Picture] OFF
SET IDENTITY_INSERT [dbo].[RequestHouse] ON 

INSERT [dbo].[RequestHouse] ([ID], [ReqSex], [ReqAge], [Name], [Phone], [UserLogin], [Position]) VALUES (1, NULL, 18, N'客户5', N'18174419500', N'user5', N'湖南长沙芙蓉区')
INSERT [dbo].[RequestHouse] ([ID], [ReqSex], [ReqAge], [Name], [Phone], [UserLogin], [Position]) VALUES (2, NULL, NULL, N'客户4', N'18174419509', N'user4', N'湖南长沙岳麓区')
SET IDENTITY_INSERT [dbo].[RequestHouse] OFF
SET IDENTITY_INSERT [dbo].[SellHouse] ON 

INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (1, N'湖南长沙', N'位置好', 120, N'三室一厅', 800000.0000, NULL, N'否', N'管理员', N'17680451251', N'18174419507')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (2, N'湖南长沙芙蓉区XXXX小区', N'交通便利', 100, N'两室一厅', 800000.0000, NULL, N'否', N'管理员', N'17680451251', N'18174419502')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (3, N'湖南长沙岳麓区XXX公寓', N'临近小吃街', 200, N'三室一厅', 1000000.0000, NULL, N'否', N'管理员', N'17680451251', N'18174419506')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (4, N'湖南长沙星沙XX号楼', N'绿化好', 120, N'三室一厅', 700000.0000, NULL, N'否', N'管理员', N'17680451251', N'18174419505')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (5, N'湖南长沙五一广场', N'靠近街区', 120, N'三室一厅', 800000.0000, NULL, N'否', N'管理员', N'17680451251', N'18174419504')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (6, N'湖南长沙世界之窗附近', N'娱乐场所多', 150, N'四室一厅', 1200000.0000, 1, N'是', N'管理员', N'17680451251', N'18174419503')
INSERT [dbo].[SellHouse] ([SellID], [Position], [Describe], [Area], [HouseType], [SellPrice], [BuyType], [IsSell], [Contacts], [ContactsPhone], [HousePhone]) VALUES (7, N'湖南长沙星沙XX学区房', N'环境绿化很好', 120, N'三室一厅', 800000.0000, 0, N'是', N'管理员', N'17680451251', N'13873087053')
SET IDENTITY_INSERT [dbo].[SellHouse] OFF
SET IDENTITY_INSERT [dbo].[StagesBuyHouse] ON 

INSERT [dbo].[StagesBuyHouse] ([ID], [Time], [UserID], [SellID], [AdminID], [NowStages], [ByStages], [IsFinish], [State]) VALUES (1, CAST(0x3A410B00 AS Date), 2, 6, 2, 8, 20, N'否', 0)
SET IDENTITY_INSERT [dbo].[StagesBuyHouse] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (1, N'zs', N'123456', N'张三', N'男', 18, N'18174419507', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (2, N'ls', N'123456', N'李四', N'男', 20, N'18174419505', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (3, N'ww', N'123456', N'王五', N'男', 23, N'18174419501', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (4, N'zl', N'123456', N'赵六', N'女', 24, N'18174419502', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (5, N'zq', N'123456', N'赵七', N'男', 25, N'18174419503', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (6, N'user1', N'123456', N'客户1', N'男', 18, N'18174419504', 0)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (7, N'user2', N'123456', N'客户2', N'女', 32, N'18174419506', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (9, N'user3', N'123456', N'客户3', N'男', 30, N'18174419508', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (10, N'user4', N'123456', N'客户4', N'女', 30, N'18174419509', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPwd], [UserName], [UserSex], [UserAge], [UserPhone], [State]) VALUES (11, N'user5', N'123456', N'客户5', N'女', 26, N'18174419500', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[BuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_BuyHouse_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[BuyHouse] CHECK CONSTRAINT [FK_BuyHouse_Admin]
GO
ALTER TABLE [dbo].[BuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_BuyHouse_SellHouse] FOREIGN KEY([SellID])
REFERENCES [dbo].[SellHouse] ([SellID])
GO
ALTER TABLE [dbo].[BuyHouse] CHECK CONSTRAINT [FK_BuyHouse_SellHouse]
GO
ALTER TABLE [dbo].[BuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_BuyHouse_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BuyHouse] CHECK CONSTRAINT [FK_BuyHouse_User]
GO
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_Admin]
GO
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_LeaseHouse] FOREIGN KEY([LeaseID])
REFERENCES [dbo].[LeaseHouse] ([LeaseID])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_LeaseHouse]
GO
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_User]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_LeaseHouse] FOREIGN KEY([LeaseID])
REFERENCES [dbo].[LeaseHouse] ([LeaseID])
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_LeaseHouse]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_SellHouse] FOREIGN KEY([SellID])
REFERENCES [dbo].[SellHouse] ([SellID])
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_SellHouse]
GO
ALTER TABLE [dbo].[StagesBuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_StagesBuyHouse_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[StagesBuyHouse] CHECK CONSTRAINT [FK_StagesBuyHouse_Admin]
GO
ALTER TABLE [dbo].[StagesBuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_StagesBuyHouse_SellHouse] FOREIGN KEY([SellID])
REFERENCES [dbo].[SellHouse] ([SellID])
GO
ALTER TABLE [dbo].[StagesBuyHouse] CHECK CONSTRAINT [FK_StagesBuyHouse_SellHouse]
GO
ALTER TABLE [dbo].[StagesBuyHouse]  WITH CHECK ADD  CONSTRAINT [FK_StagesBuyHouse_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[StagesBuyHouse] CHECK CONSTRAINT [FK_StagesBuyHouse_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LeaseHouse', @level2type=N'COLUMN',@level2name=N'HouseType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserID'
GO
USE [master]
GO
ALTER DATABASE [HomeDB] SET  READ_WRITE 
GO
