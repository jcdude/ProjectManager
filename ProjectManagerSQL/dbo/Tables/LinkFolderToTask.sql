CREATE TABLE [dbo].[LinkFolderToTask] (
    [Id]          NVARCHAR (128) NOT NULL,
    [FolderId]    NVARCHAR (128) NOT NULL,
    [TaskId]      NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkFolderToTask] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkFolderToTask_Folders] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folders] ([Id]),
    CONSTRAINT [FK_LinkFolderToTask_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Tasks] ([Id])
);

