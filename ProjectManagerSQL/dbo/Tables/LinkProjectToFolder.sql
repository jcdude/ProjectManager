CREATE TABLE [dbo].[LinkProjectToFolder] (
    [Id]          NVARCHAR (128) NOT NULL,
    [FolderId]    NVARCHAR (128) NOT NULL,
    [ProjectId]   NVARCHAR (128) NOT NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_LinkProjectToFolder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkProjectToFolder_LinkProjectToFolder] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_LinkProjectToFolder_LinkProjectToFolder1] FOREIGN KEY ([Id]) REFERENCES [dbo].[LinkProjectToFolder] ([Id])
);

