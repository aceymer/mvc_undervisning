
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/23/2016 11:07:48
-- Generated from EDMX file: \\fil-srv.syddanske.int\privat\jth\Documents\mvccourse\Jysk2_0\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JyskDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Colors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colors];
GO
IF OBJECT_ID(N'[dbo].[ColumnWidths]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColumnWidths];
GO
IF OBJECT_ID(N'[dbo].[Papers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Papers];
GO
IF OBJECT_ID(N'[dbo].[PaperTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Colors'
CREATE TABLE [dbo].[Colors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'ColumnWidths'
CREATE TABLE [dbo].[ColumnWidths] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MM] int  NOT NULL,
    [ColumnCount] int  NOT NULL
);
GO

-- Creating table 'Papers'
CREATE TABLE [dbo].[Papers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Amount] int  NOT NULL,
    [Readers] int  NOT NULL,
    [PricePrMM] float  NOT NULL
);
GO

-- Creating table 'PaperTypes'
CREATE TABLE [dbo].[PaperTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Colors'
ALTER TABLE [dbo].[Colors]
ADD CONSTRAINT [PK_Colors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColumnWidths'
ALTER TABLE [dbo].[ColumnWidths]
ADD CONSTRAINT [PK_ColumnWidths]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Papers'
ALTER TABLE [dbo].[Papers]
ADD CONSTRAINT [PK_Papers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaperTypes'
ALTER TABLE [dbo].[PaperTypes]
ADD CONSTRAINT [PK_PaperTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------