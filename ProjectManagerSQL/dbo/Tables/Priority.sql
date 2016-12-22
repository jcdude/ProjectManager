CREATE TABLE [dbo].[Priority] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (250) NOT NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED ([Id] ASC)
);

