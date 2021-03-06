USE [DB_DSD_GOV]
GO
/****** Object:  Table [dbo].[actividad]    Script Date: 30/11/2018 0:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actividad](
	[cActividad] [int] IDENTITY(1,1) NOT NULL,
	[nActividad] [varchar](50) NULL,
	[cCliente] [varchar](50) NULL,
	[cUsuario] [varchar](50) NULL,
	[cTipoActividad] [varchar](50) NULL,
	[dDescripcion] [varchar](400) NULL,
	[dAsunto] [varchar](100) NULL,
	[sEstado] [char](1) NULL,
 CONSTRAINT [PK_actividad_cActividad] PRIMARY KEY CLUSTERED 
(
	[cActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[actividad] ON 

INSERT [dbo].[actividad] ([cActividad], [nActividad], [cCliente], [cUsuario], [cTipoActividad], [dDescripcion], [dAsunto], [sEstado]) VALUES (1, N'A000001', N'12345678', N'1234', N'1', N'TRANSFORMACIÒN DE UN AUTO MODELO X', N'ACTIVIDAD 000001', N'C')
INSERT [dbo].[actividad] ([cActividad], [nActividad], [cCliente], [cUsuario], [cTipoActividad], [dDescripcion], [dAsunto], [sEstado]) VALUES (2, N'A000002', N'12345678', N'1234', N'2', N'DESCRIPCION xxx', N'ASUNTOdad', N'A')
SET IDENTITY_INSERT [dbo].[actividad] OFF
ALTER TABLE [dbo].[actividad] ADD  DEFAULT ('C') FOR [sEstado]
GO
