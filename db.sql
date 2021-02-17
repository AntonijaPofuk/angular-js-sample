USE [master]
GO
/****** Object:  Database [AngularJsSample]    Script Date: 17.2.2021. 16:09:20 ******/
CREATE DATABASE [AngularJsSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AngularJsSample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AngularJsSample_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AngularJsSample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AngularJsSample_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AngularJsSample] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AngularJsSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AngularJsSample] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [AngularJsSample] SET ANSI_NULLS ON 
GO
ALTER DATABASE [AngularJsSample] SET ANSI_PADDING ON 
GO
ALTER DATABASE [AngularJsSample] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [AngularJsSample] SET ARITHABORT ON 
GO
ALTER DATABASE [AngularJsSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AngularJsSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AngularJsSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AngularJsSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AngularJsSample] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [AngularJsSample] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [AngularJsSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AngularJsSample] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [AngularJsSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AngularJsSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AngularJsSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AngularJsSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AngularJsSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AngularJsSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AngularJsSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AngularJsSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AngularJsSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AngularJsSample] SET RECOVERY FULL 
GO
ALTER DATABASE [AngularJsSample] SET  MULTI_USER 
GO
ALTER DATABASE [AngularJsSample] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [AngularJsSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AngularJsSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AngularJsSample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AngularJsSample] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AngularJsSample] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AngularJsSample', N'ON'
GO
ALTER DATABASE [AngularJsSample] SET QUERY_STORE = OFF
GO
USE [AngularJsSample]
GO
/****** Object:  Table [dbo].[MoviePerson]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoviePerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthPlace] [nvarchar](50) NOT NULL,
	[Birthday] [datetimeoffset](0) NOT NULL,
	[Biography] [nvarchar](2000) NULL,
	[PhotoUrl] [nvarchar](2000) NULL,
	[IMDBUrl] [nvarchar](2000) NULL,
	[Popularity] [int] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NOT NULL,
	[LastModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_MoviePerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](500) NULL,
	[CreationDate] [datetime] NULL,
	[ApprovalDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[IsLocked] [bit] NOT NULL,
	[PasswordQuestion] [nvarchar](max) NULL,
	[PasswordAnswer] [nvarchar](max) NULL,
	[ActivationToken] [nvarchar](200) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime2](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [Key1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistrationToken]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistrationToken](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Token] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SecurityToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MoviePerson] ON 

INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (2, 1, N'Timy', N'Burton', N'LA', CAST(N'1995-10-08T00:00:00.0000000+02:00' AS DateTimeOffset), N'None', N'https://boldentrance.com/wp-content/uploads/2020/06/tim-burton-visual-style.jpg', N'https://www.imdb.com/name/nm0000318/', 5, CAST(N'2021-02-11T23:11:29.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-17T15:46:17.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (5, 1, N'John', N'Cameron', N'LA', CAST(N'1985-08-11T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 3, CAST(N'2021-02-15T22:35:45.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-17T13:09:07.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (8, 1, N'Ann', N'Lann', N'La', CAST(N'1995-12-06T00:00:00.0000000+00:00' AS DateTimeOffset), N'dsaa', N'', N'https://www.imdb.com/name/nm000031', 2, CAST(N'2021-02-16T21:23:56.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-17T13:17:05.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (9, 1, N'Sss', N'sss', N'Ch', CAST(N'1995-12-06T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, NULL, 3, CAST(N'2021-02-16T21:45:29.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-17T13:16:33.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (10, 1, N'Steven', N'Spilberg', N'Chicago', CAST(N'1995-05-12T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 6, CAST(N'2021-02-16T21:46:40.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-17T13:22:33.0000000+00:00' AS DateTimeOffset), 1)
SET IDENTITY_INSERT [dbo].[MoviePerson] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [EMail], [Password], [CreationDate], [ApprovalDate], [LastLoginDate], [IsLocked], [PasswordQuestion], [PasswordAnswer], [ActivationToken], [EmailConfirmed], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'admin@info-novitas.hr', N'admin@info-novitas.hr', N'AORGCjHKWx9jYLb9A9EWK/nlkuobD+LyOWKqV6CFLCWOvMMkgqmemKwD/PRvZ+Y6lg==', NULL, NULL, NULL, 0, NULL, NULL, N'1', 0, N'0dfd8580-c7ca-41da-bdf1-31d50e2b8123', NULL, 0, 0, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'System', N'Admin', N'admin@info-novitas.hr')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_User_EMail]    Script Date: 17.2.2021. 16:09:20 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UX_User_EMail] UNIQUE NONCLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_User_Login]    Script Date: 17.2.2021. 16:09:20 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UX_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 17.2.2021. 16:09:20 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[UserClaim]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 17.2.2021. 16:09:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserLogin]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_UserRegistrationToken_Token]    Script Date: 17.2.2021. 16:09:20 ******/
ALTER TABLE [dbo].[UserRegistrationToken] ADD  CONSTRAINT [UX_UserRegistrationToken_Token] UNIQUE NONCLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 17.2.2021. 16:09:20 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 17.2.2021. 16:09:20 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_Date]  DEFAULT (sysutcdatetime()) FOR [Birthday]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_LastModified]  DEFAULT (sysutcdatetime()) FOR [LastModified]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_EmailConfirmed]  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_PhoneNumberConfirmed]  DEFAULT ((0)) FOR [PhoneNumberConfirmed]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_TwoFactorEnabled]  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_AccessFailCount]  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [Relationship6] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [Relationship6]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
/****** Object:  StoredProcedure [dbo].[MoviePerson.Get]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROC [dbo].[MoviePerson.Get] 
AS
BEGIN
SELECT 
MP.Id,
MP.Active,
MP.FirstName,
MP.LastName,
MP.Birthday,
MP.Biography,
MP.BirthPlace,
MP.PhotoUrl,
MP.IMDBUrl,
MP.Popularity,
MP.DateCreated,
MP.UserCreated,
MP.UserLastModified,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail
FROM dbo.MoviePerson MP
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = MP.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = MP.UserLastModified
WHERE MP.Active = 1

END

GO
/****** Object:  StoredProcedure [dbo].[MoviePerson.GetDateCreated]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[MoviePerson.GetDateCreated] 
AS
BEGIN
SELECT 
MP.Id,
MP.DateCreated
FROM MoviePerson MP
WHERE MP.Active = 1

END
GO
/****** Object:  StoredProcedure [dbo].[MoviePerson_Delete]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Antonija
-- Create date: 29.1.2021.
-- Description:	DELETE procedure
-- =============================================
CREATE   PROCEDURE [dbo].[MoviePerson_Delete]
	@Id int,  @UserLastModified int	
AS
BEGIN
	 BEGIN  
            UPDATE  MoviePerson 
			SET Active = 0, LastModified = GETDATE(), UserLastModified = @UserLastModified
            WHERE  Id = @Id  
        END  
END
GO
/****** Object:  StoredProcedure [dbo].[MoviePerson_Insert]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[MoviePerson_Insert]
	 @FirstName nvarchar(50), @LastName nvarchar(50), 
	 @Birthday datetimeoffset(0), 
	 @BirthPlace nvarchar(50), @Biography nvarchar(2000), 
	 @UserCreated int,
	 @PhotoUrl nvarchar(2000), @IMDBUrl nvarchar(2000), 
	 @Popularity int
AS
BEGIN
	Insert into MoviePerson (Active, FirstName, LastName, Birthday, BirthPlace, Biography, PhotoUrl, IMDBUrl, Popularity, 
	DateCreated, UserCreated) 
	VALUES (
	 1,
	 @FirstName,
	 @LastName,
	 @Birthday, 
	 @BirthPlace, 
	 @Biography,
	 @PhotoUrl,
	 @IMDBUrl,
	 @Popularity,	
	 GETDATE(), 
	 @UserCreated)
	END
GO
/****** Object:  StoredProcedure [dbo].[MoviePerson_Save]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Antonija
-- Create date: 29.1.2021.
-- Description:	Updates selected records
-- =============================================
CREATE   PROCEDURE [dbo].[MoviePerson_Save]
	@Id int, @FirstName nvarchar(50), @LastName nvarchar(50), @BirthPlace nvarchar(50), @Birthday datetimeoffset(0),
	@Biography nvarchar(2000), 	@PhotoUrl nvarchar(2000), @IMDBUrl nvarchar(2000), @Popularity int,

	@UserLastModified int
AS
BEGIN
	UPDATE MoviePerson 
	SET 
	FirstName = @FirstName, 
	LastName = @LastName, 
	BirthPlace = @BirthPlace,
	Birthday = @Birthday,
	Biography = @Biography,
	PhotoUrl = @PhotoUrl,
	IMDBUrl = @IMDBUrl,
	Popularity = @Popularity,
	LastModified = GETDATE(), 
	UserLastModified = @UserLastModified
	WHERE Id = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[MoviePersonData.Get]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROC [dbo].[MoviePersonData.Get] @id int
AS
BEGIN
SELECT 
MP.Id,
MP.Active,
MP.FirstName,
MP.LastName,
MP.Birthday,
MP.Biography,
MP.BirthPlace,
MP.PhotoUrl,
MP.IMDBUrl,
MP.Popularity,
MP.DateCreated,
MP.UserCreated,
MP.UserLastModified,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail
FROM dbo.MoviePerson MP
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = MP.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = MP.UserLastModified
WHERE MP.Id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[ReturnRecords]    Script Date: 17.2.2021. 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[ReturnRecords]
	
AS
BEGIN
	UPDATE MoviePerson SET Active = 1;
END

exec dbo.ReturnRecords;
GO
USE [master]
GO
ALTER DATABASE [AngularJsSample] SET  READ_WRITE 
GO
