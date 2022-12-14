USE [moviesdb]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 10-12-2022 14:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorsActorId] [int] NOT NULL,
	[MoviesMovieId] [int] NOT NULL,
 CONSTRAINT [PK_ActorMovie] PRIMARY KEY CLUSTERED 
(
	[ActorsActorId] ASC,
	[MoviesMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Actors_ActorsActorId] FOREIGN KEY([ActorsActorId])
REFERENCES [dbo].[Actors] ([ActorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Actors_ActorsActorId]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Movies_MoviesMovieId] FOREIGN KEY([MoviesMovieId])
REFERENCES [dbo].[Movies] ([MovieId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Movies_MoviesMovieId]
GO
