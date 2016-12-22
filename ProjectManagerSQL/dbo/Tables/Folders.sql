CREATE TABLE [dbo].[Folders] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (250) NULL,
    [DateCreated] DATETIME       NULL,
    CONSTRAINT [PK_Folders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

