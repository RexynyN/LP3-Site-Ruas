
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2019 15:19:37
-- Generated from EDMX file: C:\Users\User\Desktop\SeminarioLP3 3.0\SeminarioLP3\Models\SeminarioLP3.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Teste3.0];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LojaRua]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Loja] DROP CONSTRAINT [FK_LojaRua];
GO
IF OBJECT_ID(N'[dbo].[FK_BairroRua]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rua] DROP CONSTRAINT [FK_BairroRua];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoComercioRua]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rua] DROP CONSTRAINT [FK_TipoComercioRua];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaProdutoTipoComercio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoriaProdutoSet] DROP CONSTRAINT [FK_CategoriaProdutoTipoComercio];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Rua]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rua];
GO
IF OBJECT_ID(N'[dbo].[TipoComercio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoComercio];
GO
IF OBJECT_ID(N'[dbo].[Bairro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bairro];
GO
IF OBJECT_ID(N'[dbo].[CategoriaProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[Loja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loja];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Rua'
CREATE TABLE [dbo].[Rua] (
    [IdRua] int IDENTITY(1,1) NOT NULL,
    [FkBairro] int  NOT NULL,
    [FkTipoComercio] int  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [CEP] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TipoComercio'
CREATE TABLE [dbo].[TipoComercio] (
    [IdComercio] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [OrgaoRegulador] nvarchar(max)  NOT NULL,
    [Permissao] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bairro'
CREATE TABLE [dbo].[Bairro] (
    [IdBairro] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [UF] nvarchar(max)  NOT NULL,
    [Zona] nvarchar(max)  NOT NULL,
    [Cidade] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriaProdutoSet'
CREATE TABLE [dbo].[CategoriaProdutoSet] (
    [IdCategoriaProduto] int IDENTITY(1,1) NOT NULL,
    [FkTipoComercio] int  NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Loja'
CREATE TABLE [dbo].[Loja] (
    [IdLoja] int IDENTITY(1,1) NOT NULL,
    [FkRua] int  NOT NULL,
    [NomeComercial] nvarchar(max)  NOT NULL,
    [CNPJ] nvarchar(max)  NOT NULL,
    [RazaoSocial] nvarchar(max)  NOT NULL,
    [Telefone] nvarchar(max)  NOT NULL,
    [Site] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdRua] in table 'Rua'
ALTER TABLE [dbo].[Rua]
ADD CONSTRAINT [PK_Rua]
    PRIMARY KEY CLUSTERED ([IdRua] ASC);
GO

-- Creating primary key on [IdComercio] in table 'TipoComercio'
ALTER TABLE [dbo].[TipoComercio]
ADD CONSTRAINT [PK_TipoComercio]
    PRIMARY KEY CLUSTERED ([IdComercio] ASC);
GO

-- Creating primary key on [IdBairro] in table 'Bairro'
ALTER TABLE [dbo].[Bairro]
ADD CONSTRAINT [PK_Bairro]
    PRIMARY KEY CLUSTERED ([IdBairro] ASC);
GO

-- Creating primary key on [IdCategoriaProduto] in table 'CategoriaProdutoSet'
ALTER TABLE [dbo].[CategoriaProdutoSet]
ADD CONSTRAINT [PK_CategoriaProdutoSet]
    PRIMARY KEY CLUSTERED ([IdCategoriaProduto] ASC);
GO

-- Creating primary key on [IdLoja] in table 'Loja'
ALTER TABLE [dbo].[Loja]
ADD CONSTRAINT [PK_Loja]
    PRIMARY KEY CLUSTERED ([IdLoja] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FkRua] in table 'Loja'
ALTER TABLE [dbo].[Loja]
ADD CONSTRAINT [FK_LojaRua]
    FOREIGN KEY ([FkRua])
    REFERENCES [dbo].[Rua]
        ([IdRua])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LojaRua'
CREATE INDEX [IX_FK_LojaRua]
ON [dbo].[Loja]
    ([FkRua]);
GO

-- Creating foreign key on [FkBairro] in table 'Rua'
ALTER TABLE [dbo].[Rua]
ADD CONSTRAINT [FK_BairroRua]
    FOREIGN KEY ([FkBairro])
    REFERENCES [dbo].[Bairro]
        ([IdBairro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BairroRua'
CREATE INDEX [IX_FK_BairroRua]
ON [dbo].[Rua]
    ([FkBairro]);
GO

-- Creating foreign key on [FkTipoComercio] in table 'Rua'
ALTER TABLE [dbo].[Rua]
ADD CONSTRAINT [FK_TipoComercioRua]
    FOREIGN KEY ([FkTipoComercio])
    REFERENCES [dbo].[TipoComercio]
        ([IdComercio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoComercioRua'
CREATE INDEX [IX_FK_TipoComercioRua]
ON [dbo].[Rua]
    ([FkTipoComercio]);
GO

-- Creating foreign key on [FkTipoComercio] in table 'CategoriaProdutoSet'
ALTER TABLE [dbo].[CategoriaProdutoSet]
ADD CONSTRAINT [FK_CategoriaProdutoTipoComercio]
    FOREIGN KEY ([FkTipoComercio])
    REFERENCES [dbo].[TipoComercio]
        ([IdComercio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaProdutoTipoComercio'
CREATE INDEX [IX_FK_CategoriaProdutoTipoComercio]
ON [dbo].[CategoriaProdutoSet]
    ([FkTipoComercio]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------