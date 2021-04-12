----- Setup -----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----- Drop existing tables -----
DROP TABLE IF EXISTS [dbo].[Position];
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
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_PlayerHistory_Player] FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[Player] ([ID]),
	CONSTRAINT [FK_PlayerHistory_Color] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Color] ([ID]),
	CONSTRAINT [FK_PlayerHistory_Game] FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game] ([ID])
);

-- Position --
CREATE TABLE [dbo].[Position](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerHistoryID] [int] NOT NULL,
	[Pion] [int] NULL,
	[Coordinate] [int] NULL,
	[isHome] [bit] NULL,
	[isActive] [bit] NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Position_PlayerHistory] FOREIGN KEY ([PlayerHistoryID]) REFERENCES [dbo].[PlayerHistory] ([ID])
);


----- Insert Data into Tables -----
-- Player --
SET IDENTITY_INSERT [dbo].[Player] ON 
INSERT [dbo].[Player] ([ID], [Name]) VALUES (1, N'Axel')
INSERT [dbo].[Player] ([ID], [Name]) VALUES (2, N'Dylan')
INSERT [dbo].[Player] ([ID], [Name]) VALUES (3, N'Tom')
INSERT [dbo].[Player] ([ID], [Name]) VALUES (4, N'Sten')
SET IDENTITY_INSERT [dbo].[Player] OFF

-- Color --
SET IDENTITY_INSERT [dbo].[Color] ON 
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (1, N'Red', N'#FFFF0000')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (2, N'Blue', N'#FF0000FF')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (3, N'Yellow', N'#FFFFFF00')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (4, N'Green', N'#FF008000')
SET IDENTITY_INSERT [dbo].[Color] OFF

-- Game --
SET IDENTITY_INSERT [dbo].[Game] ON 
INSERT [dbo].[Game] ([ID], [Date], [isActive]) VALUES (1, '2015-12-17', 0)
SET IDENTITY_INSERT [dbo].[Game] OFF

-- PlayerHistory --
SET IDENTITY_INSERT [dbo].[PlayerHistory] ON 
INSERT [dbo].[PlayerHistory] ([ID], [PlayerID], [ColorID], [GameID], [CountTime], [CountSixes], [CountTurns], [isTurn], [isWinner]) VALUES (1, 1, 1, 1, '00:00:00', 0, 0, 0, 1)
INSERT [dbo].[PlayerHistory] ([ID], [PlayerID], [ColorID], [GameID], [CountTime], [CountSixes], [CountTurns], [isTurn], [isWinner]) VALUES (2, 2, 2, 1, '00:00:00', 0, 0, 0, 0)
INSERT [dbo].[PlayerHistory] ([ID], [PlayerID], [ColorID], [GameID], [CountTime], [CountSixes], [CountTurns], [isTurn], [isWinner]) VALUES (3, 3, 3, 1, '00:00:00', 0, 0, 0, 0)
INSERT [dbo].[PlayerHistory] ([ID], [PlayerID], [ColorID], [GameID], [CountTime], [CountSixes], [CountTurns], [isTurn], [isWinner]) VALUES (4, 4, 4, 1, '00:00:00', 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[PlayerHistory] OFF

-- Position --
SET IDENTITY_INSERT [dbo].[Position] ON 
-- Player 1 --
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (1, 1, 1, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (2, 1, 2, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (3, 1, 3, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (4, 1, 4, 1, 1, 0) 
-- Player 2 --
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (5, 2, 1, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (6, 2, 2, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (7, 2, 3, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (8, 2, 4, 1, 1, 0) 
-- Player 3 --
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (9,  3, 1, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (10, 3, 2, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (11, 3, 3, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (12, 3, 4, 1, 1, 0) 
-- Player 4 --
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (13, 4, 1, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (14, 4, 2, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (15, 4, 3, 1, 1, 0)
INSERT [dbo].[Position] ([ID], [PlayerHistoryID], [Pion], [Coordinate], [isHome], [isActive]) VALUES (16, 4, 4, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Position] OFF
