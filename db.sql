USE [master]
GO
/****** Object:  Database [AngularJsSample]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[Genre]    Script Date: 25.2.2021. 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[LastModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 25.2.2021. 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Rating] [int] NULL,
	[Description] [nvarchar](2000) NULL,
	[ReleaseDate] [datetimeoffset](0) NOT NULL,
	[PosterUrl] [nvarchar](2000) NULL,
	[IMDBUrl] [nvarchar](2000) NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NOT NULL,
	[LastModified] [datetimeoffset](0) NULL,
	[UserLastModified] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieIdGenreId]    Script Date: 25.2.2021. 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieIdGenreId](
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_MovieIdGenreId] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoviePerson]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[MovieRating]    Script Date: 25.2.2021. 14:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieRating](
	[MovieId] [int] NOT NULL,
	[UserRatedId] [int] NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreated] [int] NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_MovieRating] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[UserRatedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[UserLogin]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[UserRegistrationToken]    Script Date: 25.2.2021. 14:10:28 ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 25.2.2021. 14:10:28 ******/
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
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (1, 1, CAST(N'2021-02-17T17:09:11.0000000+00:00' AS DateTimeOffset), 1, N'History', N'Some descirpiton about history genre.', CAST(N'2021-02-25T11:38:10.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (2, 1, CAST(N'2021-02-18T01:04:03.0000000+00:00' AS DateTimeOffset), 1, N'Sci-fi', N'', CAST(N'2021-02-18T00:04:03.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (3, 1, CAST(N'2021-02-18T01:07:11.0000000+00:00' AS DateTimeOffset), 1, N'Sport', N'Genre about sport events and competition.', CAST(N'2021-02-18T01:16:37.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (4, 1, CAST(N'2021-02-18T01:07:25.0000000+00:00' AS DateTimeOffset), 1, N'Culture', N'', CAST(N'2021-02-19T18:09:31.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (5, 1, CAST(N'2021-02-18T01:16:32.0000000+00:00' AS DateTimeOffset), 1, N'Educational', N'Educational genre for school or academic purpose.', CAST(N'2021-02-24T23:54:40.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Genre] ([Id], [Active], [DateCreated], [UserCreated], [Name], [Description], [LastModified], [UserLastModified]) VALUES (6, 1, CAST(N'2021-02-24T23:51:00.0000000+00:00' AS DateTimeOffset), 1, N'Romantic movie', N'', CAST(N'2021-02-24T22:51:00.0000000+00:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (1, 1, N'Titanic', 5, N'Titanic je američka epska romansa i film katastrofe iz 1997. godine kojeg je režirao i napisao James Cameron....', CAST(N'2021-01-10T00:00:00.0000000+01:00' AS DateTimeOffset), N'https://images-na.ssl-images-amazon.com/images/I/71i6L1vZjiL._AC_SL1058_.jpg', N'https://www.imdb.com/title/tt0120338/', CAST(N'2021-02-19T17:45:40.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T13:57:48.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (2, 1, N'Iron Man', 2, N'Prevedeno s engleskog jezika-Iron Man je američki film o superherojima iz 2008. godine baziran na istoimenom liku Marvel Comicsa. U produkciji Marvel Studios, a u distribuciji Paramount Pictures, to je prvi film u Marvel Cinematic Universe.', CAST(N'2021-01-02T00:00:00.0000000+01:00' AS DateTimeOffset), N'https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg', N'https://www.imdb.com/title/tt0371746/', CAST(N'2021-02-21T22:00:44.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T13:53:05.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (3, 1, N'Saving Private Ryan', 3, N'Spašavanje vojnika Ryana je američki epski ratni film radnjom smješten tijekom invazije na Normandiju u Drugom svjetskom ratu...', CAST(N'2021-03-02T00:00:00.0000000+01:00' AS DateTimeOffset), N'https://images-na.ssl-images-amazon.com/images/I/7132RMjQwjL._RI_.jpg', N'https://www.imdb.com/title/tt0120815/', CAST(N'2021-02-22T00:59:30.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T13:57:54.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (71, 1, N'Forest Gump', 6, N'Forrest Gump je američka tragikomedija iz 1994. koju je režirao Robert Zemeckis. Film je snimljen po istoimenom satiričnom romanu Winstona Grooma iz 1985.', CAST(N'1994-08-06T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-22T14:56:52.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T13:53:19.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (84, 1, N'Dear John', 3, NULL, CAST(N'2021-01-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-24T23:51:35.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T02:08:17.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (85, 1, N'Matrix: Parabelum', 5, NULL, CAST(N'2021-03-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-24T23:52:04.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-24T23:52:12.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (86, 1, N'Avatar', 2, NULL, CAST(N'2004-10-09T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T02:06:09.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T01:06:09.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (89, 1, N'Godzila', 4, NULL, CAST(N'1998-08-10T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T02:38:32.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T01:38:32.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (91, 1, N'Paranormal activity', 1, NULL, CAST(N'1998-08-10T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T11:43:56.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T10:43:56.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (92, 1, N'Paranormal activity 2', 4, NULL, CAST(N'2021-10-02T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T11:45:27.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T11:48:10.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (93, 0, N'Paranormal activity 3', 2, NULL, CAST(N'2021-03-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T11:48:32.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T12:15:30.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[Movie] ([Id], [Active], [Name], [Rating], [Description], [ReleaseDate], [PosterUrl], [IMDBUrl], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (94, 1, N'Green Mile', 6, NULL, CAST(N'2000-03-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, CAST(N'2021-02-25T12:15:24.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T11:15:24.0000000+00:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (1, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (1, 6, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (2, 1, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (2, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (2, 3, 0)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (2, 4, 0)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (2, 5, 0)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (3, 1, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (3, 2, 0)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (3, 4, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (3, 5, 0)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (71, 1, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (71, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (71, 6, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (84, 4, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (84, 6, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (85, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (85, 5, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (86, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (86, 6, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (89, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (91, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (92, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (93, 2, 1)
INSERT [dbo].[MovieIdGenreId] ([MovieId], [GenreId], [Active]) VALUES (94, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[MoviePerson] ON 

INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (2, 1, N'Timy', N'Burton', N'LA', CAST(N'1995-10-08T00:00:00.0000000+02:00' AS DateTimeOffset), N'None', N'https://boldentrance.com/wp-content/uploads/2020/06/tim-burton-visual-style.jpg', N'https://www.imdb.com/name/nm0000318/', 6, CAST(N'2021-02-11T23:11:29.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-25T13:52:48.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (5, 1, N'James', N'Cameron', N'Ontario', CAST(N'1985-08-11T00:00:00.0000000+02:00' AS DateTimeOffset), N'James Francis Cameron (Kapuskasing, Ontario, 16. kolovoza 1954.), kanadski filmski redatelj i producent. Poznat je po svojim akcijskim i SF filmovima koji obično komercijalno uspješni i vrlo inovativni. Tematski, Cameronovi filmovi općenito istražuju odnos između čovjeka i tehnologije. Cameron je režirao Titanic, koji je postao najuspješniji film svih vremena, sa svjetskom zaradom od 1,8 milijardi dolara. Stvorio je i Terminator franšizu.', N'http://www.nyfa.edu/student-resources/wp-content/uploads/2014/06/James-Cameron.jpg', N'https://www.imdb.com/name/nm0000116/', 7, CAST(N'2021-02-15T22:35:45.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T12:23:18.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (8, 0, N'Ann', N'Lann', N'La', CAST(N'1995-12-06T00:00:00.0000000+00:00' AS DateTimeOffset), N'dsaa', N'', N'https://www.imdb.com/name/nm000031', 2, CAST(N'2021-02-16T21:23:56.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-19T18:04:47.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (9, 0, N'Sss', N'sss', N'Ch', CAST(N'1995-12-06T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, NULL, 3, CAST(N'2021-02-16T21:45:29.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:24:33.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (10, 0, N'Steven', N'Spilberg', N'Chicago', CAST(N'1995-05-12T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 6, CAST(N'2021-02-16T21:46:40.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-19T19:03:31.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (16, 1, N'Lana-Maria', N'Banana', N'Miami', CAST(N'1995-05-12T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 14, CAST(N'2021-02-17T17:10:12.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-19T18:05:12.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (21, 0, N'ggggg', N'ds', N'ssss', CAST(N'2021-03-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, NULL, 1, CAST(N'2021-02-18T12:07:01.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:24:38.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (22, 0, N'ggggg', N'ds', N'ssss', CAST(N'1990-07-03T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 1, CAST(N'2021-02-18T12:24:43.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:24:31.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (23, 0, N'Patty', N'Jenkins', N'Georgia', CAST(N'2021-11-02T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, NULL, 5, CAST(N'2021-02-18T12:46:11.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-19T18:04:39.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (24, 1, N'Quentin', N'Tarantino', N'Knoxville', CAST(N'1955-07-07T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, N'https://m.media-amazon.com/images/M/MV5BMTgyMjI3ODA3Nl5BMl5BanBnXkFtZTcwNzY2MDYxOQ@@._V1_UY1200_CR76,0,630,1200_AL_.jpg', N'https://www.imdb.com/name/nm0000233/', 5, CAST(N'2021-02-18T12:48:08.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T12:49:18.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (27, 0, N'dasda', N'dsada', N'ssss', CAST(N'2021-10-02T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 2, CAST(N'2021-02-18T13:24:09.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:24:27.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (28, 0, N'čć', N'ćććććććć', N'ććććććć', CAST(N'2021-09-02T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 1, CAST(N'2021-02-18T13:32:37.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:32:45.0000000+00:00' AS DateTimeOffset), 1)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (29, 1, N'Ridley', N'Scott', N'Chicago', CAST(N'1985-12-12T00:00:00.0000000+01:00' AS DateTimeOffset), NULL, NULL, NULL, 5, CAST(N'2021-02-18T14:27:40.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-18T13:27:40.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[MoviePerson] ([Id], [Active], [FirstName], [LastName], [BirthPlace], [Birthday], [Biography], [PhotoUrl], [IMDBUrl], [Popularity], [DateCreated], [UserCreated], [LastModified], [UserLastModified]) VALUES (31, 0, N'Ann', N'Tarantino', N'Knoxville', CAST(N'2021-04-02T00:00:00.0000000+02:00' AS DateTimeOffset), NULL, NULL, NULL, 1, CAST(N'2021-02-19T19:03:57.0000000+00:00' AS DateTimeOffset), 1, CAST(N'2021-02-19T19:04:04.0000000+00:00' AS DateTimeOffset), 1)
SET IDENTITY_INSERT [dbo].[MoviePerson] OFF
GO
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (1, 1, CAST(N'2021-02-22T09:45:12.0000000+00:00' AS DateTimeOffset), 1, 6)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (1, 5, CAST(N'2021-02-22T09:45:12.0000000+00:00' AS DateTimeOffset), 5, 4)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (2, 1, CAST(N'2021-02-22T10:35:46.0000000+00:00' AS DateTimeOffset), 1, 3)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (2, 5, CAST(N'2021-02-25T01:33:04.0000000+00:00' AS DateTimeOffset), 5, 2)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (3, 1, CAST(N'2021-02-22T10:36:30.0000000+00:00' AS DateTimeOffset), 1, 3)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (71, 1, CAST(N'2021-02-22T14:56:52.0000000+00:00' AS DateTimeOffset), 1, 6)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (84, 1, CAST(N'2021-02-24T23:51:35.0000000+00:00' AS DateTimeOffset), 1, 3)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (85, 1, CAST(N'2021-02-24T23:52:04.0000000+00:00' AS DateTimeOffset), 1, 5)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (86, 1, CAST(N'2021-02-25T02:06:09.0000000+00:00' AS DateTimeOffset), 1, 2)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (89, 1, CAST(N'2021-02-25T02:38:32.0000000+00:00' AS DateTimeOffset), 1, 4)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (91, 1, CAST(N'2021-02-25T11:43:56.0000000+00:00' AS DateTimeOffset), 1, 1)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (92, 1, CAST(N'2021-02-25T11:45:27.0000000+00:00' AS DateTimeOffset), 1, 4)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (93, 1, CAST(N'2021-02-25T11:48:32.0000000+00:00' AS DateTimeOffset), 1, 2)
INSERT [dbo].[MovieRating] ([MovieId], [UserRatedId], [DateCreated], [UserCreated], [Rating]) VALUES (94, 1, CAST(N'2021-02-25T12:15:24.0000000+00:00' AS DateTimeOffset), 1, 6)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [EMail], [Password], [CreationDate], [ApprovalDate], [LastLoginDate], [IsLocked], [PasswordQuestion], [PasswordAnswer], [ActivationToken], [EmailConfirmed], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'admin@info-novitas.hr', N'admin@info-novitas.hr', N'AORGCjHKWx9jYLb9A9EWK/nlkuobD+LyOWKqV6CFLCWOvMMkgqmemKwD/PRvZ+Y6lg==', NULL, NULL, NULL, 0, NULL, NULL, N'1', 0, N'0dfd8580-c7ca-41da-bdf1-31d50e2b8123', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[User] ([Id], [Login], [EMail], [Password], [CreationDate], [ApprovalDate], [LastLoginDate], [IsLocked], [PasswordQuestion], [PasswordAnswer], [ActivationToken], [EmailConfirmed], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount]) VALUES (5, N'admina@info-novitas.hr', N'admina@info-novitas.hr', N'AORGCjHKWx9jYLb9A9EWK/nlkuobD+LyOWKqV6CFLCWOvMMkgqmemKwD/PRvZ+Y6lg==', NULL, NULL, NULL, 0, NULL, NULL, N'1', 0, N'0dfd8580-c7ca-41da-bdf1-31d50e2b8123', NULL, 0, 0, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'System', N'Admin', N'admin@info-novitas.hr')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [Email]) VALUES (5, N'System', N'Admin', N'admina@info-novitas.hr')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_User_EMail]    Script Date: 25.2.2021. 14:10:29 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UX_User_EMail] UNIQUE NONCLUSTERED 
(
	[EMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_User_Login]    Script Date: 25.2.2021. 14:10:29 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UX_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 25.2.2021. 14:10:29 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[UserClaim]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 25.2.2021. 14:10:29 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserLogin]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_UserRegistrationToken_Token]    Script Date: 25.2.2021. 14:10:29 ******/
ALTER TABLE [dbo].[UserRegistrationToken] ADD  CONSTRAINT [UX_UserRegistrationToken_Token] UNIQUE NONCLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 25.2.2021. 14:10:29 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 25.2.2021. 14:10:29 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRole]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Genre] ADD  CONSTRAINT [DF_Genre_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Genre] ADD  CONSTRAINT [DF_Genre_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Genre] ADD  CONSTRAINT [DF_Genre_LastModified]  DEFAULT (sysutcdatetime()) FOR [LastModified]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_Date]  DEFAULT (sysutcdatetime()) FOR [ReleaseDate]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_LastModified]  DEFAULT (sysutcdatetime()) FOR [LastModified]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_Date]  DEFAULT (sysutcdatetime()) FOR [Birthday]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[MoviePerson] ADD  CONSTRAINT [DF_MoviePerson_LastModified]  DEFAULT (sysutcdatetime()) FOR [LastModified]
GO
ALTER TABLE [dbo].[MovieRating] ADD  CONSTRAINT [DF_MovieRating_DateCreated]  DEFAULT (sysutcdatetime()) FOR [DateCreated]
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
ALTER TABLE [dbo].[Genre]  WITH CHECK ADD  CONSTRAINT [FK_Genre_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Genre] CHECK CONSTRAINT [FK_Genre_UserInfo]
GO
ALTER TABLE [dbo].[Genre]  WITH CHECK ADD  CONSTRAINT [FK_Genre_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Genre] CHECK CONSTRAINT [FK_Genre_UserInfo1]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_UserInfo]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_UserInfo1]
GO
ALTER TABLE [dbo].[MovieIdGenreId]  WITH CHECK ADD  CONSTRAINT [FK_MovieIdGenreId_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[MovieIdGenreId] CHECK CONSTRAINT [FK_MovieIdGenreId_Genre]
GO
ALTER TABLE [dbo].[MovieIdGenreId]  WITH CHECK ADD  CONSTRAINT [FK_MovieIdGenreId_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieIdGenreId] CHECK CONSTRAINT [FK_MovieIdGenreId_Movie]
GO
ALTER TABLE [dbo].[MoviePerson]  WITH CHECK ADD  CONSTRAINT [FK_MoviePerson_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[MoviePerson] CHECK CONSTRAINT [FK_MoviePerson_UserInfo]
GO
ALTER TABLE [dbo].[MoviePerson]  WITH CHECK ADD  CONSTRAINT [FK_MoviePerson_UserInfo1] FOREIGN KEY([UserLastModified])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[MoviePerson] CHECK CONSTRAINT [FK_MoviePerson_UserInfo1]
GO
ALTER TABLE [dbo].[MovieRating]  WITH CHECK ADD  CONSTRAINT [FK_MovieRating_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieRating] CHECK CONSTRAINT [FK_MovieRating_Movie]
GO
ALTER TABLE [dbo].[MovieRating]  WITH CHECK ADD  CONSTRAINT [FK_MovieRating_UserInfo] FOREIGN KEY([UserCreated])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[MovieRating] CHECK CONSTRAINT [FK_MovieRating_UserInfo]
GO
ALTER TABLE [dbo].[MovieRating]  WITH CHECK ADD  CONSTRAINT [FK_MovieRating_UserInfo1] FOREIGN KEY([UserRatedId])
REFERENCES [dbo].[UserInfo] ([Id])
GO
ALTER TABLE [dbo].[MovieRating] CHECK CONSTRAINT [FK_MovieRating_UserInfo1]
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
/****** Object:  StoredProcedure [dbo].[Genre_Delete]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[Genre_Delete]
	@Id int,  @UserLastModified int	
AS
BEGIN
	 BEGIN  
            UPDATE  Genre 
			SET Active = 0, LastModified = GETDATE(), UserLastModified = @UserLastModified
            WHERE  Id = @Id  
        END  
END
GO
/****** Object:  StoredProcedure [dbo].[Genre_Insert]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[Genre_Insert]
	 @Name nvarchar(50), @Description nvarchar(50), 
	 @UserCreated int
AS
BEGIN
	Insert into Genre(Active, Name, Description, DateCreated, UserCreated) 
	VALUES (
	 1,
	 @Name,	
	 @Description,
	 GETDATE(), 
	 @UserCreated)
	END
GO
/****** Object:  StoredProcedure [dbo].[Genre_Save]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Antonija
-- Create date: 29.1.2021.
-- Description:	Updates selected records
-- =============================================
CREATE     PROCEDURE [dbo].[Genre_Save]
	@Id int, @Name nvarchar(50), @Description nvarchar(50),	@UserLastModified int
AS
BEGIN
	UPDATE Genre 
	SET 
	Name = @Name, 
	Description = @Description,
	LastModified = GETDATE(), 
	UserLastModified = @UserLastModified
	WHERE Id = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[GenreData.Get]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[GenreData.Get] @id int
AS
BEGIN
SELECT 
G.Id,
G.Active,
G.Name,
G.Description,
G.DateCreated,
G.UserCreated,
G.UserLastModified,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail
FROM dbo.Genre G
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = G.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = G.UserLastModified
WHERE G.Id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[Genres.Get]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[Genres.Get] 
AS
BEGIN
SELECT 
G.Id,
G.Active,
G.Name,
G.Description,
G.DateCreated,
G.UserCreated,
G.UserLastModified,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail
FROM dbo.Genre G
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = G.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = G.UserLastModified
WHERE G.Active = 1

END

GO
/****** Object:  StoredProcedure [dbo].[GenresFromMovie.Get]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE    PROC [dbo].[GenresFromMovie.Get] @id int
AS
BEGIN
SELECT 

GM.MovieId,
GM.GenreId,
M.Name AS MovieName,
G.Name AS GenreName
FROM dbo.MovieIdGenreId GM
LEFT OUTER JOIN [dbo].[Movie]  M
ON M.Id = GM.MovieId
LEFT OUTER JOIN [dbo].[Genre]  G
ON G.Id = GM.GenreId

WHERE GM.MovieId = @id
AND GM.Active = 1;

END

GO
/****** Object:  StoredProcedure [dbo].[Movie_Delete]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE     PROCEDURE [dbo].[Movie_Delete]
	@Id int,  @UserLastModified int	
AS
BEGIN
	 BEGIN  
            UPDATE  Movie 
			SET Active = 0, LastModified = GETDATE(), UserLastModified = @UserLastModified
            WHERE  Id = @Id  
        END  
END
GO
/****** Object:  StoredProcedure [dbo].[Movie_Insert]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[Movie_Insert]
	 @Name nvarchar(50),
	 @ReleaseDate datetimeoffset(0), 
	 @Description nvarchar(2000), 
	 @UserCreated int,
	 @PosterUrl nvarchar(2000), @IMDBUrl nvarchar(2000), 
	 @Rating int
AS
BEGIN
	Insert into Movie (Active, Name, ReleaseDate, Description, PosterUrl, IMDBUrl, Rating, 
	DateCreated, UserCreated) 
	VALUES (
	 1,
	 @Name,
	 @ReleaseDate, 
	 @Description,
	 @PosterUrl,
	 @IMDBUrl,
	 @Rating,	
	 GETDATE(), 
	 @UserCreated)

	 declare @MovieId int 
set @MovieId = SCOPE_IDENTITY()


	 INSERT into MovieRating (MovieId, UserRatedId, DateCreated, UserCreated, Rating)
	 VALUES(
	 @MovieId,  
	 @UserCreated,
	 GETDATE(), 
	 @UserCreated,
	 @Rating
	 )

	END

	--EXEC dbo.Movie_Insert @Name="ssss",	 @Description="aaa", @ReleaseDate="2021-02-22 09:45:12 +00:00", @PosterUrl="aaa",	 @IMDBUrl="aaa",	 @Rating=2,		 @UserCreated=1;
GO
/****** Object:  StoredProcedure [dbo].[Movie_Save]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Antonija
-- Create date: 29.1.2021.
-- Description:	Updates selected records
-- =============================================
CREATE     PROCEDURE [dbo].[Movie_Save]
	@Id int, @Name nvarchar(50),  @ReleaseDate datetimeoffset(0),
	@Description nvarchar(2000),  @PosterUrl nvarchar(2000), @IMDBUrl nvarchar(2000), @Rating int,

	@UserLastModified int
AS
BEGIN
	UPDATE Movie 
	SET 
	Name = @Name, 
	ReleaseDate = @ReleaseDate,
	Description = @Description,
	PosterUrl = @PosterUrl,
	IMDBUrl = @IMDBUrl,
	LastModified = GETDATE(), 
	UserLastModified = @UserLastModified
	WHERE Id = @Id

	 UPDATE MovieRating SET  	 
	 Rating = @Rating
	 WHERE MovieId = @Id AND UserRatedId=1
	
	END
GO
/****** Object:  StoredProcedure [dbo].[MovieData.Get]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[MovieData.Get] @id int
AS
BEGIN
SELECT 
M.Id,
M.Active,
M.Name,
M.Description,
M.ReleaseDate,
M.PosterUrl,
M.IMDBUrl,
M.DateCreated,
M.UserCreated,
M.UserLastModified,
MR.Rating,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail,
MG.GenreId
FROM dbo.Movie M
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = M.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = M.UserLastModified
LEFT OUTER JOIN [dbo].[MovieRating]  MR
ON M.Id = MR.MovieId
LEFT OUTER JOIN [dbo].[MovieIdGenreId]  MG
ON M.Id = MG.MovieId

WHERE M.Id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[MovieIdGenreId_Delete]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE     PROCEDURE [dbo].[MovieIdGenreId_Delete]
	@MovieId int,  @GenreId int	
AS
BEGIN
	 BEGIN  
            UPDATE  MovieIdGenreId 
			SET Active = 0
            WHERE  MovieId = @MovieId AND GenreId = @GenreId  
        END  
END
GO
/****** Object:  StoredProcedure [dbo].[MovieIdGenreId_Insert]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[MovieIdGenreId_Insert]
	 @GenreId int,
	 @MovieId int
AS
BEGIN
	--Insert into MovieIdGenreId(Active, MovieId, GenreId) 
	--VALUES (
	-- 1,
	-- @MovieId,
	-- @GenreId)
	 UPDATE MovieIdGenreId SET 	
	 Active=1
	 WHERE GenreId=@GenreId AND MovieId=@MovieId


	IF @@ROWCOUNT = 0
	
	--if MovieId == 0
	IF @MovieId = 0
		BEGIN
			SET @MovieId = IDENT_CURRENT('Movie');
			Insert into MovieIdGenreId(Active, MovieId, GenreId) 
			VALUES (
			 1,
			 @MovieId,
			 @GenreId)
		END
	--else
	ELSE
		BEGIN
		Insert into MovieIdGenreId(Active, MovieId, GenreId) 
			VALUES (
			 1,
			 @MovieId,
			 @GenreId)
	END
END

GO
/****** Object:  StoredProcedure [dbo].[MovieIdGenreId_Save]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE     PROCEDURE [dbo].[MovieIdGenreId_Save]
	 @MovieId int,
	 @GenreId int
AS
BEGIN
	Insert into MovieMovieIdGenreId(Active, MovieId, GenreId) 
	VALUES 
	(1,
	 @MovieId,
	 @GenreId)
	 

	END

GO
/****** Object:  StoredProcedure [dbo].[MoviePerson.Get]    Script Date: 25.2.2021. 14:10:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MoviePerson.GetDateCreated]    Script Date: 25.2.2021. 14:10:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MoviePerson_Delete]    Script Date: 25.2.2021. 14:10:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MoviePerson_Insert]    Script Date: 25.2.2021. 14:10:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MoviePerson_Save]    Script Date: 25.2.2021. 14:10:29 ******/
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
/****** Object:  StoredProcedure [dbo].[MoviePersonData.Get]    Script Date: 25.2.2021. 14:10:29 ******/
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
MP.UserLastModified,UC.FirstName AS UserCreatedFirstName,
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
/****** Object:  StoredProcedure [dbo].[Movies.Get]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROC [dbo].[Movies.Get] 
AS
BEGIN
SELECT 
M.Id,
M.Active,
M.Name,
M.Description,
M.DateCreated,
M.UserCreated,
M.UserLastModified,
M.ReleaseDate,
M.Rating,
M.PosterUrl,
M.IMDBUrl,
UC.FirstName AS UserCreatedFirstName,
UC.LastName AS UserCreatedLastName,
UC.FirstName + ' ' + UC.LastName AS UserCreatedFullName,
UC.Email AS UserCreatedEmail,
ULM.FirstName AS UserLastModifiedFirstName,
ULM.LastName AS UserLastModifiedLastName,
ULM.FirstName + ' ' + ULM.LastName AS UserLastModifiedFullName,
ULM.Email AS UserLastModifiedEmail
FROM dbo.Movie M
LEFT OUTER JOIN [dbo].[UserInfo]  UC
ON UC.Id = M.UserCreated
LEFT OUTER JOIN [dbo].[UserInfo]  ULM
ON ULM.Id = M.UserLastModified

WHERE M.Active = 1

END

GO
/****** Object:  StoredProcedure [dbo].[Rating_Insert]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE       PROCEDURE [dbo].[Rating_Insert]
	 @MovieId int,  @userRatedId int, @UserCreated int, @Rating int
AS
BEGIN
	Insert into MovieRating(MovieId, UserRatedId, DateCreated, UserCreated, Rating) 
	VALUES (
	 @MovieId,	
	 @userRatedId,
	 GETDATE(), 
	 @UserCreated,
	 @Rating)
	END
GO
/****** Object:  StoredProcedure [dbo].[Rating_Save]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Antonija
-- Create date: 29.1.2021.
-- Description:	Updates selected records
-- =============================================
CREATE   PROCEDURE [dbo].[Rating_Save]
	@MovieId int, @UserRatedId int, @Rating int
AS
BEGIN
	UPDATE MovieRating 
	SET 
	Rating = @Rating

	WHERE MovieId = @MovieId AND 
	UserRatedId = @UserRatedId
	END
GO
/****** Object:  StoredProcedure [dbo].[ReturnRecords]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[ReturnRecords]
	
AS
BEGIN
	UPDATE Movie SET Active = 1
END

exec dbo.ReturnRecords;



GO
/****** Object:  Trigger [dbo].[RatingControl2]    Script Date: 25.2.2021. 14:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE    TRIGGER [dbo].[RatingControl2]    
  ON [dbo].[MovieRating] 
  AFTER INSERT, UPDATE 
  AS 
  BEGIN  
    UPDATE Movie SET Rating = (
      Select AVG(Rating) 
      from MovieRating
	  	  WHERE MovieId = (SELECT Id FROM inserted)
	  GROUP BY MovieId
      )
	WHERE Id = (SELECT Id FROM inserted)

	END

GO
ALTER TABLE [dbo].[MovieRating] ENABLE TRIGGER [RatingControl2]
GO
USE [master]
GO
ALTER DATABASE [AngularJsSample] SET  READ_WRITE 
GO
