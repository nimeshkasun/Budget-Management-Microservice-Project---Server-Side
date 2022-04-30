USE [BudgetPalDB]
GO

/****** Object: Table [dbo].[Transactions] Script Date: 4/30/2022 11:14:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions] (
    [TranId]          INT           IDENTITY (1, 1) NOT NULL,
    [TranCatId]       INT           NOT NULL,
    [TranDescription] NVARCHAR (20) NULL,
    [TranDate]        DATETIME2 (7) NOT NULL,
    [TranRecurring]   BIT           NOT NULL,
    [TranAmount]      FLOAT (53)    NOT NULL
);


