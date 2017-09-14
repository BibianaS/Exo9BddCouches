
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2017 13:47:57
-- Generated from EDMX file: C:\Users\DL-CDI\Desktop\Exo9BddCouches\ClassLibrary2\Formations.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Exo9];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SectionsStagiaires]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StagiairesSet] DROP CONSTRAINT [FK_SectionsStagiaires];
GO
IF OBJECT_ID(N'[dbo].[FK_StagiaireDE_inherits_Stagiaires]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StagiairesSet_StagiaireDE] DROP CONSTRAINT [FK_StagiaireDE_inherits_Stagiaires];
GO
IF OBJECT_ID(N'[dbo].[FK_StagiaireCIF_inherits_Stagiaires]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StagiairesSet_StagiaireCIF] DROP CONSTRAINT [FK_StagiaireCIF_inherits_Stagiaires];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StagiairesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StagiairesSet];
GO
IF OBJECT_ID(N'[dbo].[SectionsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SectionsSet];
GO
IF OBJECT_ID(N'[dbo].[StagiairesSet_StagiaireDE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StagiairesSet_StagiaireDE];
GO
IF OBJECT_ID(N'[dbo].[StagiairesSet_StagiaireCIF]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StagiairesSet_StagiaireCIF];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StagiairesSet'
CREATE TABLE [dbo].[StagiairesSet] (
    [NumOsia] int  NOT NULL,
    [NomStagiaire] nvarchar(20)  NOT NULL,
    [PrenomStagiaire] nvarchar(20)  NOT NULL,
    [rueStagiare] nvarchar(20)  NOT NULL,
    [VilleStagiaire] nvarchar(20)  NOT NULL,
    [CodePostalStagiaire] nchar(5)  NOT NULL,
    [NbreNotes] int  NULL,
    [PointsNotes] int  NULL,
    [Sections_IdSection] int  NOT NULL
);
GO

-- Creating table 'SectionsSet'
CREATE TABLE [dbo].[SectionsSet] (
    [IdSection] int  NOT NULL,
    [NomSection] nvarchar(20)  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [DateFin] datetime  NOT NULL
);
GO

-- Creating table 'StagiairesSet_StagiaireDE'
CREATE TABLE [dbo].[StagiairesSet_StagiaireDE] (
    [RemuAfpa] bit  NOT NULL,
    [NumOsia] int  NOT NULL
);
GO

-- Creating table 'StagiairesSet_StagiaireCIF'
CREATE TABLE [dbo].[StagiairesSet_StagiaireCIF] (
    [FongeCif] nvarchar(max)  NOT NULL,
    [TypeCif] nvarchar(max)  NOT NULL,
    [NumOsia] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [NumOsia] in table 'StagiairesSet'
ALTER TABLE [dbo].[StagiairesSet]
ADD CONSTRAINT [PK_StagiairesSet]
    PRIMARY KEY CLUSTERED ([NumOsia] ASC);
GO

-- Creating primary key on [IdSection] in table 'SectionsSet'
ALTER TABLE [dbo].[SectionsSet]
ADD CONSTRAINT [PK_SectionsSet]
    PRIMARY KEY CLUSTERED ([IdSection] ASC);
GO

-- Creating primary key on [NumOsia] in table 'StagiairesSet_StagiaireDE'
ALTER TABLE [dbo].[StagiairesSet_StagiaireDE]
ADD CONSTRAINT [PK_StagiairesSet_StagiaireDE]
    PRIMARY KEY CLUSTERED ([NumOsia] ASC);
GO

-- Creating primary key on [NumOsia] in table 'StagiairesSet_StagiaireCIF'
ALTER TABLE [dbo].[StagiairesSet_StagiaireCIF]
ADD CONSTRAINT [PK_StagiairesSet_StagiaireCIF]
    PRIMARY KEY CLUSTERED ([NumOsia] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Sections_IdSection] in table 'StagiairesSet'
ALTER TABLE [dbo].[StagiairesSet]
ADD CONSTRAINT [FK_SectionsStagiaires]
    FOREIGN KEY ([Sections_IdSection])
    REFERENCES [dbo].[SectionsSet]
        ([IdSection])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionsStagiaires'
CREATE INDEX [IX_FK_SectionsStagiaires]
ON [dbo].[StagiairesSet]
    ([Sections_IdSection]);
GO

-- Creating foreign key on [NumOsia] in table 'StagiairesSet_StagiaireDE'
ALTER TABLE [dbo].[StagiairesSet_StagiaireDE]
ADD CONSTRAINT [FK_StagiaireDE_inherits_Stagiaires]
    FOREIGN KEY ([NumOsia])
    REFERENCES [dbo].[StagiairesSet]
        ([NumOsia])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [NumOsia] in table 'StagiairesSet_StagiaireCIF'
ALTER TABLE [dbo].[StagiairesSet_StagiaireCIF]
ADD CONSTRAINT [FK_StagiaireCIF_inherits_Stagiaires]
    FOREIGN KEY ([NumOsia])
    REFERENCES [dbo].[StagiairesSet]
        ([NumOsia])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------