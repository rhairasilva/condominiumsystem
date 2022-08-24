USE [sistemarh]
GO

-- Object  Table [dbo].[AtividadeDP]    
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AtividadeDP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prazoDeEntrega] [datetime] NOT NULL,
	[vencimento] [datetime] NOT NULL,
	[nome] [nvarchar](100) NULL,
	[cargoDoResponsavel] [nvarchar](50) NULL,
	[emailDoResponsavel] [nvarchar](50) NULL,
	[qtCond] [int] NULL,
	[encerrada] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AtividadeDP] ADD  DEFAULT ((0)) FOR [encerrada]
GO


