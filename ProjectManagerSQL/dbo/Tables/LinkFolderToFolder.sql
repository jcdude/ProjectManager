CREATE TABLE [dbo].[LinkFolderToFolder] (
    [Id]             NVARCHAR (128) NOT NULL,
    [FolderId]       NVARCHAR (128) NOT NULL,
    [ParentFolderId] NVARCHAR (128) NOT NULL,
    [DateCreated]    DATETIME       NOT NULL,
    CONSTRAINT [PK_LinkFolderToFolder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkFolderToFolder_Folders] FOREIGN KEY ([ParentFolderId]) REFERENCES [dbo].[Folders] ([Id]),
    CONSTRAINT [FK_LinkFolderToFolder_LinkFolderToFolder] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folders] ([Id])
);

