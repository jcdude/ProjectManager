CREATE TABLE [dbo].[WorkFlows] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (250) NOT NULL,
    [AccountId]   NVARCHAR (128) NOT NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_WorkFlows] PRIMARY KEY CLUSTERED ([Id] ASC)
);

