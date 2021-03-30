----- Setup -----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----- Drop existing tables -----
DROP TABLE IF EXISTS [dbo].[Game];
DROP TABLE IF EXISTS [dbo].[Position];
DROP TABLE IF EXISTS [dbo].[PlayerHistory];
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

-- PlayerHistory --
CREATE TABLE [dbo].[PlayerHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[CountTime] [int] NULL,
	[CountSixes] [int] NULL,
	[CountTurns] [int] NULL,
	[isTurn] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_PlayerHistory_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([ID]),
	CONSTRAINT [FK_PlayerHistory_Color] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Color] ([ID])
);

-- Position --
CREATE TABLE [dbo].[Position](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerHistoryID] [int] NOT NULL,
	[Pion] [varchar](50) NULL,
	[Position] [varchar](50) NULL,
	[isHome] [bit] NULL,
	[isActive] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Position_PlayerHistory] FOREIGN KEY ([PlayerHistoryID]) REFERENCES [dbo].[PlayerHistory] ([ID])
);

-- Game --
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerHistoryID] [int] NOT NULL,
	[Date] [date] NULL,
	[isActive] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Game_PlayerHistory] FOREIGN KEY ([PlayerHistoryID]) REFERENCES [dbo].[PlayerHistory] ([ID])
);


----- Insert Data into Tables -----
-- Player --
SET IDENTITY_INSERT [dbo].[Player] ON 
SET IDENTITY_INSERT [dbo].[Player] OFF

-- Color --
SET IDENTITY_INSERT [dbo].[Color] ON 
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (1, N'Rood', N'#FFFF0000')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (2, N'Blauw', N'#FF0000FF')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (3, N'Geel', N'#FFFFFF00')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (4, N'Groen', N'#FF008000')
SET IDENTITY_INSERT [dbo].[Color] OFF

-- PlayerHistory --
SET IDENTITY_INSERT [dbo].[PlayerHistory] ON 
SET IDENTITY_INSERT [dbo].[PlayerHistory] OFF

-- Position --
SET IDENTITY_INSERT [dbo].[Position] ON 
SET IDENTITY_INSERT [dbo].[Position] OFF

-- Game --
SET IDENTITY_INSERT [dbo].[Game] ON 
SET IDENTITY_INSERT [dbo].[Game] OFF
