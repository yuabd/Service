USE [master]
GO
/****** Object:  Database [BJ_Life]    Script Date: 05/13/2014 01:37:20 ******/
CREATE DATABASE [BJ_Life] ON  PRIMARY 
( NAME = N'BJ_Life', FILENAME = N'D:\Github\Service\Projects\BJ_Life.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BJ_Life_log', FILENAME = N'D:\Github\Service\Projects\BJ_Life_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BJ_Life] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BJ_Life].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BJ_Life] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BJ_Life] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BJ_Life] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BJ_Life] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BJ_Life] SET ARITHABORT OFF
GO
ALTER DATABASE [BJ_Life] SET AUTO_CLOSE ON
GO
ALTER DATABASE [BJ_Life] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BJ_Life] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BJ_Life] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BJ_Life] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BJ_Life] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BJ_Life] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BJ_Life] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BJ_Life] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BJ_Life] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BJ_Life] SET  DISABLE_BROKER
GO
ALTER DATABASE [BJ_Life] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BJ_Life] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BJ_Life] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BJ_Life] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BJ_Life] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BJ_Life] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BJ_Life] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BJ_Life] SET  READ_WRITE
GO
ALTER DATABASE [BJ_Life] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BJ_Life] SET  MULTI_USER
GO
ALTER DATABASE [BJ_Life] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BJ_Life] SET DB_CHAINING OFF
GO
USE [BJ_Life]
GO
/****** Object:  Table [dbo].[userrolepermission]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrolepermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[TargetID] [int] NULL,
	[Type] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userrolejoin]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrolejoin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userrole]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[IsManage] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[DateLastLogin] [datetime] NULL,
	[IsActive] [nvarchar](50) NULL,
	[PhotoFile] [nvarchar](200) NULL,
	[Question] [nvarchar](100) NULL,
	[Answer] [nvarchar](100) NULL,
	[Contact] [nvarchar](50) NULL,
	[RealName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[QQ] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Description] [nvarchar](2000) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Website] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_config]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys_config](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WebsiteName] [nvarchar](100) NULL,
	[PageTitle] [nvarchar](200) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[MetaKeywords] [nvarchar](500) NULL,
	[Copyright] [nvarchar](200) NULL,
	[ICP] [nvarchar](100) NULL,
	[AdminEmail] [nvarchar](100) NULL,
	[SmtpHost] [nvarchar](50) NULL,
	[SmtpPort] [nvarchar](50) NULL,
	[SmtpEmail] [nvarchar](100) NULL,
	[SmtpUserAccount] [nvarchar](100) NULL,
	[SmtpPassword] [nvarchar](100) NULL,
	[IsStatic] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recyclebin]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recyclebin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Table] [nvarchar](100) NULL,
	[TargetID] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[picture]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[picture](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TargetID] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[IsDefault] [nvarchar](50) NULL,
	[PictureUrl] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[page]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[page](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[PageName] [nvarchar](50) NULL,
	[Enable] [nvarchar](50) NULL,
	[PageUrl] [nvarchar](200) NULL,
	[OrderIndex] [int] NULL,
	[Selected] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](100) NULL,
	[ParentID] [int] NULL,
	[Enable] [nvarchar](50) NULL,
	[Selected] [nvarchar](50) NULL,
	[OrderIndex] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[links]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[links](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LinkCategoryID] [int] NULL,
	[LinkUrl] [nvarchar](300) NULL,
	[SortOrder] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[PictureFile] [nvarchar](200) NULL,
	[Description] [nvarchar](1000) NULL,
	[Contact] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[DateCreated] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[linkcategory]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[linkcategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[SortOrder] [int] NULL,
	[DateCreated] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IndustryName] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[UserID] [int] NULL,
	[AddDate] [datetime] NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[document]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Content] [ntext] NULL,
	[Overview] [nvarchar](1000) NULL,
	[DateCreated] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
	[PageVisits] [int] NULL,
	[PageTitle] [nvarchar](300) NULL,
	[MetaDescription] [nvarchar](300) NULL,
	[MetaKeywords] [nvarchar](300) NULL,
	[Slug] [nvarchar](300) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseType]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
	[SortOrder] [int] NOT NULL,
	[ParentID] [int] NULL,
	[UserID] [int] NULL,
	[AddDate] [datetime] NULL,
 CONSTRAINT [PK_CourseType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IndustryID] [int] NULL,
	[UserID] [int] NULL,
	[CourseName] [nvarchar](300) NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [nvarchar](200) NULL,
	[Contact] [nvarchar](100) NULL,
	[AddUserID] [int] NULL,
	[AddDate] [datetime] NULL,
	[CourseTypeID] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contenttemplate]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contenttemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContentName] [nvarchar](50) NULL,
	[Enable] [nvarchar](50) NULL,
	[AdminListUrl] [nvarchar](300) NULL,
	[WebListUrl] [nvarchar](300) NULL,
	[WebDetailUrl] [nvarchar](300) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TargetID] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[Message] [nvarchar](1000) NULL,
	[IsPublic] [nvarchar](5) NULL,
	[DateCreated] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[column]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[column](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[ContentTemplateID] [int] NULL,
	[ParentID] [int] NULL,
	[ColumnName] [nvarchar](50) NULL,
	[IsPublic] [nvarchar](50) NULL,
	[PageTitle] [nvarchar](300) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[MetaKeywords] [nvarchar](300) NULL,
	[Slug] [nvarchar](200) NULL,
	[SortOrder] [int] NULL,
	[AdminListUrl] [nvarchar](300) NULL,
	[WebListUrl] [nvarchar](300) NULL,
	[WebDetailUrl] [nvarchar](300) NULL,
	[UpdateUser] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[IsDelete] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[articletag]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articletag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[articleimage]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleimage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColumnID] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[ShortTitle] [nvarchar](100) NULL,
	[SortOrder] [int] NULL,
	[Overview] [nvarchar](500) NULL,
	[Content] [ntext] NULL,
	[Source] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[PageVisits] [int] NULL,
	[DateCreated] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
	[IsDelete] [nvarchar](50) NULL,
	[PageTitle] [nvarchar](300) NULL,
	[MetaDescription] [nvarchar](300) NULL,
	[MetaKeywords] [nvarchar](300) NULL,
	[Slug] [nvarchar](300) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[article]    Script Date: 05/13/2014 01:37:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColumnID] [int] NULL,
	[Title] [nvarchar](300) NULL,
	[ShortTitle] [nvarchar](300) NULL,
	[Content] [ntext] NULL,
	[Overview] [nvarchar](500) NULL,
	[IsPublic] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUser] [nvarchar](50) NULL,
	[PageVisits] [int] NULL,
	[PageTitle] [nvarchar](200) NULL,
	[MetaDescription] [nvarchar](200) NULL,
	[MetaKeywords] [nvarchar](200) NULL,
	[Slug] [nvarchar](200) NULL,
	[Source] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[SortOrder] [int] NULL,
	[IsDelete] [nvarchar](50) NULL,
 CONSTRAINT [PK_article] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF__recyclebi__Targe__1273C1CD]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[recyclebin] ADD  CONSTRAINT [DF__recyclebi__Targe__1273C1CD]  DEFAULT ((0)) FOR [TargetID]
GO
/****** Object:  Default [DF__picture__TargetI__0F975522]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[picture] ADD  CONSTRAINT [DF__picture__TargetI__0F975522]  DEFAULT ((0)) FOR [TargetID]
GO
/****** Object:  Default [DF__picture__IsDefau__108B795B]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[picture] ADD  CONSTRAINT [DF__picture__IsDefau__108B795B]  DEFAULT ('N') FOR [IsDefault]
GO
/****** Object:  Default [DF_CourseType_SortOrder]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[CourseType] ADD  CONSTRAINT [DF_CourseType_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
GO
/****** Object:  Default [DF__column__IsDelete__07020F21]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[column] ADD  CONSTRAINT [DF__column__IsDelete__07020F21]  DEFAULT ('N') FOR [IsDelete]
GO
/****** Object:  Default [DF__articleim__Colum__014935CB]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__Colum__014935CB]  DEFAULT ((0)) FOR [ColumnID]
GO
/****** Object:  Default [DF__articleim__SortO__023D5A04]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__SortO__023D5A04]  DEFAULT ((0)) FOR [SortOrder]
GO
/****** Object:  Default [DF__articleim__PageV__03317E3D]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__PageV__03317E3D]  DEFAULT ((0)) FOR [PageVisits]
GO
/****** Object:  Default [DF__articleim__IsDel__0425A276]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__IsDel__0425A276]  DEFAULT ('N') FOR [IsDelete]
GO
/****** Object:  Default [DF__article__SortOrd__7E6CC920]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[article] ADD  CONSTRAINT [DF__article__SortOrd__7E6CC920]  DEFAULT ((0)) FOR [SortOrder]
GO
/****** Object:  Default [DF__article__IsDelet__7F60ED59]    Script Date: 05/13/2014 01:37:22 ******/
ALTER TABLE [dbo].[article] ADD  CONSTRAINT [DF__article__IsDelet__7F60ED59]  DEFAULT ('N') FOR [IsDelete]
GO
