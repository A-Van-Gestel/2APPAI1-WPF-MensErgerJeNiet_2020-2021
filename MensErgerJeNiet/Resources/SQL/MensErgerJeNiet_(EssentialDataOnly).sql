----- Setup -----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----- Drop existing tables -----
DROP TABLE IF EXISTS [dbo].[Pion];
DROP TABLE IF EXISTS [dbo].[PlayerHistory];
DROP TABLE IF EXISTS [dbo].[Game];
DROP TABLE IF EXISTS [dbo].[Color];
DROP TABLE IF EXISTS [dbo].[Player];
GO


----- Create Tables -----
-- Player --
CREATE TABLE [dbo].[Player](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Color --
CREATE TABLE [dbo].[Color](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](9) NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Game --
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[isActive] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- PlayerHistory --
CREATE TABLE [dbo].[PlayerHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[GameID] [int] NOT NULL,
	[CountTime] [time] NULL,
	[CountSixes] [int] NULL,
	[CountTurns] [int] NULL,
	[isTurn] [bit] NULL,
	[isWinner] [bit] NULL,
	[PionOffset] [int] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_PlayerHistory_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([ID]),
	CONSTRAINT [FK_PlayerHistory_Color] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Color] ([ID]),
	CONSTRAINT [FK_PlayerHistory_Game] FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game] ([ID])
);

-- Pion --
CREATE TABLE [dbo].[Pion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerHistoryID] [int] NOT NULL,
	[PionNr] [int] NULL,
	[Coordinate] [int] NULL,
	[isHome] [bit] NULL,
	[isActive] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Pion_PlayerHistory] FOREIGN KEY ([PlayerHistoryID]) REFERENCES [dbo].[PlayerHistory] ([ID])
);


----- Insert Data into Tables -----
-- Color --
SET IDENTITY_INSERT [dbo].[Color] ON 
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (1, N'Red', N'#FFFF0000')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (2, N'Blue', N'#FF3c59ff')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (3, N'Yellow', N'#FFFFFF00')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (4, N'Green', N'#FF008000')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (5, N'Neon Red', N'#FFfd0048')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (6, N'Neon Green', N'#FF33ff00')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (7, N'Neon Orange', N'#FFff6600')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (8, N'Neon Yellow', N'#FFf5f528')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (9, N'Neon Purple', N'#FF990099')
SET IDENTITY_INSERT [dbo].[Color] OFF