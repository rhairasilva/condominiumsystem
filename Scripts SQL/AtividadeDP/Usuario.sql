USE [sistemarh]
GO

/****** Object:  Table [dbo].[Usuario]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[NomeDeUsuario] [nvarchar](20) NOT NULL,
	[Senha] [nvarchar](100) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Sobrenome] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Cargo] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeDeUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [Admin]
GO


