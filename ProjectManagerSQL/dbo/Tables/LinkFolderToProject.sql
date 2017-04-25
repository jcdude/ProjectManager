CREATE TABLE [dbo].[LinkFolderToProject] (
    [Id]          NVARCHAR (128) NOT NULL,
    [FolderId]    NVARCHAR (128) NOT NULL,
    [ProjectId]   NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkFolderToProject] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkFolderToProject_Folders] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folders] ([Id]),
    CONSTRAINT [FK_LinkFolderToProject_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);

