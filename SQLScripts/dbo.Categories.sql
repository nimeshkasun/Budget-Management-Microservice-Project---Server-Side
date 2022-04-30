USE [BudgetPalDB]
GO

/****** Object: Table [dbo].[Categories] Script Date: 4/30/2022 11:13:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories] (
    [CatId]     INT           IDENTITY (1, 1) NOT NULL,
    [CatName]   NVARCHAR (20) NULL,
    [CatType]   NVARCHAR (10) NULL,
    [CatBudget] FLOAT (53)    NOT NULL
);


