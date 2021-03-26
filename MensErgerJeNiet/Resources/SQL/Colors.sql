/****** Object:  Table [dbo].[Color] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Color](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](9) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (1, N'Rood', N'#FFFF0000')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (2, N'Blauw', N'#FF0000FF')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (3, N'Geel', N'#FFFFFF00')
INSERT [dbo].[Color] ([ID], [Name], [Code]) VALUES (4, N'Groen', N'#FF008000')
SET IDENTITY_INSERT [dbo].[Color] OFF
