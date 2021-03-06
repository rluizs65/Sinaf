USE [Sinaf_Proposta]
GO
/****** Object:  Table [dbo].[Apolice]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apolice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProposta] [bigint] NOT NULL,
	[Numero] [nvarchar](100) NULL,
	[DataInicioVigencia] [datetime] NULL,
	[DataFimVigencia] [datetime] NULL,
 CONSTRAINT [Apolice_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [bigint] NOT NULL,
 CONSTRAINT [Cliente_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cobertura]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobertura](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProposta] [bigint] NOT NULL,
	[IdTipoCobertura] [bigint] NOT NULL,
	[LimiteMaximoIndenizacao] [decimal](12, 2) NOT NULL,
	[ValorPagoSegurado] [decimal](10, 2) NOT NULL,
	[ValorPremio] [decimal](10, 2) NOT NULL,
 CONSTRAINT [Cobertura_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corretor]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corretor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [bigint] NOT NULL,
	[Codigo] [nvarchar](100) NULL,
 CONSTRAINT [Corretor_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dependente]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dependente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [Dependente_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Cpf] [nvarchar](11) NOT NULL,
	[Cnpj] [nvarchar](14) NULL,
	[DataNascimento] [date] NOT NULL,
	[Sexo] [char](3) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [Pessoa_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PessoaEndereco]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PessoaEndereco](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [bigint] NOT NULL,
	[Endereco] [nvarchar](300) NOT NULL,
	[Numero] [nvarchar](20) NOT NULL,
	[Complemento] [nvarchar](200) NULL,
	[Cep] [nvarchar](20) NULL,
	[Uf] [char](2) NULL,
	[Cidade] [nvarchar](200) NULL,
	[Bairro] [nvarchar](200) NULL,
 CONSTRAINT [PessoaEndereco_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PessoaTelefone]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PessoaTelefone](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPessoa] [bigint] NOT NULL,
	[Numero] [nvarchar](10) NULL,
	[Ddd] [nvarchar](2) NULL,
	[Descricao] [nvarchar](50) NULL,
	[NumeroPrincipal] [bit] NULL,
 CONSTRAINT [PessoaTelefone_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proposta]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proposta](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdRamo] [bigint] NOT NULL,
	[Numero] [nvarchar](100) NULL,
	[IdCorretor] [bigint] NOT NULL,
	[DataEmissao] [datetime] NULL,
 CONSTRAINT [Proposta_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropostaDependente]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropostaDependente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProposta] [bigint] NOT NULL,
	[IdDependente] [bigint] NOT NULL,
 CONSTRAINT [PropostaDependente_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ramo]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ramo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
 CONSTRAINT [Ramo_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCobertura]    Script Date: 01/12/2020 15:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCobertura](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NULL,
 CONSTRAINT [TipoCobertura_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Apolice]  WITH CHECK ADD  CONSTRAINT [Apolice_Proposta_FK] FOREIGN KEY([IdProposta])
REFERENCES [dbo].[Proposta] ([Id])
GO
ALTER TABLE [dbo].[Apolice] CHECK CONSTRAINT [Apolice_Proposta_FK]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [Cliente_Pessoa_FK] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [Cliente_Pessoa_FK]
GO
ALTER TABLE [dbo].[Cobertura]  WITH CHECK ADD  CONSTRAINT [Cobertura_Proposta_FK] FOREIGN KEY([IdProposta])
REFERENCES [dbo].[Proposta] ([Id])
GO
ALTER TABLE [dbo].[Cobertura] CHECK CONSTRAINT [Cobertura_Proposta_FK]
GO
ALTER TABLE [dbo].[Cobertura]  WITH CHECK ADD  CONSTRAINT [Cobertura_TipoCobertura_FK] FOREIGN KEY([IdTipoCobertura])
REFERENCES [dbo].[TipoCobertura] ([Id])
GO
ALTER TABLE [dbo].[Cobertura] CHECK CONSTRAINT [Cobertura_TipoCobertura_FK]
GO
ALTER TABLE [dbo].[Corretor]  WITH CHECK ADD  CONSTRAINT [Corretor_Pessoa_FK] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Corretor] CHECK CONSTRAINT [Corretor_Pessoa_FK]
GO
ALTER TABLE [dbo].[Dependente]  WITH CHECK ADD  CONSTRAINT [Dependente_Cliente_FK] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Dependente] CHECK CONSTRAINT [Dependente_Cliente_FK]
GO
ALTER TABLE [dbo].[Dependente]  WITH CHECK ADD  CONSTRAINT [Dependente_Pessoa_FK] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Dependente] CHECK CONSTRAINT [Dependente_Pessoa_FK]
GO
ALTER TABLE [dbo].[PessoaEndereco]  WITH CHECK ADD  CONSTRAINT [PessoaEndereco_Pessoa_FK] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[PessoaEndereco] CHECK CONSTRAINT [PessoaEndereco_Pessoa_FK]
GO
ALTER TABLE [dbo].[PessoaTelefone]  WITH CHECK ADD  CONSTRAINT [PessoaTelefone_Pessoa_FK] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[PessoaTelefone] CHECK CONSTRAINT [PessoaTelefone_Pessoa_FK]
GO
ALTER TABLE [dbo].[Proposta]  WITH CHECK ADD  CONSTRAINT [Proposta_Cliente_FK] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Proposta] CHECK CONSTRAINT [Proposta_Cliente_FK]
GO
ALTER TABLE [dbo].[Proposta]  WITH CHECK ADD  CONSTRAINT [Proposta_Corretor_FK] FOREIGN KEY([IdCorretor])
REFERENCES [dbo].[Corretor] ([Id])
GO
ALTER TABLE [dbo].[Proposta] CHECK CONSTRAINT [Proposta_Corretor_FK]
GO
ALTER TABLE [dbo].[Proposta]  WITH CHECK ADD  CONSTRAINT [Proposta_Ramo_FK] FOREIGN KEY([IdRamo])
REFERENCES [dbo].[Ramo] ([Id])
GO
ALTER TABLE [dbo].[Proposta] CHECK CONSTRAINT [Proposta_Ramo_FK]
GO
ALTER TABLE [dbo].[PropostaDependente]  WITH CHECK ADD  CONSTRAINT [PropostaDependente_Dependente_FK] FOREIGN KEY([IdDependente])
REFERENCES [dbo].[Dependente] ([Id])
GO
ALTER TABLE [dbo].[PropostaDependente] CHECK CONSTRAINT [PropostaDependente_Dependente_FK]
GO
ALTER TABLE [dbo].[PropostaDependente]  WITH CHECK ADD  CONSTRAINT [PropostaDependente_Proposta_FK] FOREIGN KEY([IdProposta])
REFERENCES [dbo].[Proposta] ([Id])
GO
ALTER TABLE [dbo].[PropostaDependente] CHECK CONSTRAINT [PropostaDependente_Proposta_FK]
GO
