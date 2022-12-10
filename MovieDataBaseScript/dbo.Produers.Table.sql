USE [moviesdb]
GO
/****** Object:  Table [dbo].[Produers]    Script Date: 10-12-2022 14:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produers](
	[ProducerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Bio] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Company] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
 CONSTRAINT [PK_Produers] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
