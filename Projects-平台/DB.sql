USE [BJ_Life]
GO
/****** Object:  Table [dbo].[userrolepermission]    Script Date: 05/05/2014 22:36:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrolepermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [float] NULL,
	[TargetID] [float] NULL,
	[Type] [nvarchar](50) NULL,
	[IsManage] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userrolejoin]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[userrole]    Script Date: 05/05/2014 22:36:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 05/05/2014 22:36:03 ******/
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
	[IsActive] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys_config]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[sidebar]    Script Date: 05/05/2014 22:36:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sidebar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Type] [nvarchar](50) NULL,
	[ColumnID] [int] NULL,
	[Content] [nvarchar](1000) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[recyclebin]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[picture]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[page]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[menu]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[links]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[linkcategory]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[document]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[contenttemplate]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[comment]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[column]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[articletag]    Script Date: 05/05/2014 22:36:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articletag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[articleimage]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Table [dbo].[article]    Script Date: 05/05/2014 22:36:03 ******/
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
/****** Object:  Default [DF__article__SortOrd__7E6CC920]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[article] ADD  CONSTRAINT [DF__article__SortOrd__7E6CC920]  DEFAULT ((0)) FOR [SortOrder]
GO
/****** Object:  Default [DF__article__IsDelet__7F60ED59]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[article] ADD  CONSTRAINT [DF__article__IsDelet__7F60ED59]  DEFAULT ('N') FOR [IsDelete]
GO
/****** Object:  Default [DF__articleim__Colum__014935CB]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__Colum__014935CB]  DEFAULT ((0)) FOR [ColumnID]
GO
/****** Object:  Default [DF__articleim__SortO__023D5A04]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__SortO__023D5A04]  DEFAULT ((0)) FOR [SortOrder]
GO
/****** Object:  Default [DF__articleim__PageV__03317E3D]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__PageV__03317E3D]  DEFAULT ((0)) FOR [PageVisits]
GO
/****** Object:  Default [DF__articleim__IsDel__0425A276]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[articleimage] ADD  CONSTRAINT [DF__articleim__IsDel__0425A276]  DEFAULT ('N') FOR [IsDelete]
GO
/****** Object:  Default [DF__column__IsDelete__07020F21]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[column] ADD  CONSTRAINT [DF__column__IsDelete__07020F21]  DEFAULT ('N') FOR [IsDelete]
GO
/****** Object:  Default [DF__picture__TargetI__0F975522]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[picture] ADD  CONSTRAINT [DF__picture__TargetI__0F975522]  DEFAULT ((0)) FOR [TargetID]
GO
/****** Object:  Default [DF__picture__IsDefau__108B795B]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[picture] ADD  CONSTRAINT [DF__picture__IsDefau__108B795B]  DEFAULT ('N') FOR [IsDefault]
GO
/****** Object:  Default [DF__recyclebi__Targe__1273C1CD]    Script Date: 05/05/2014 22:36:03 ******/
ALTER TABLE [dbo].[recyclebin] ADD  CONSTRAINT [DF__recyclebi__Targe__1273C1CD]  DEFAULT ((0)) FOR [TargetID]
GO
