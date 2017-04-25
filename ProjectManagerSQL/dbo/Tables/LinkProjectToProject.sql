CREATE TABLE [dbo].[LinkProjectToProject] (
    [Id]              NVARCHAR (128) NOT NULL,
    [ProjectId]       NVARCHAR (128) NOT NULL,
    [ParentProjectId] NVARCHAR (128) NOT NULL,
    [DateCreated]     DATETIME       NOT NULL,
    CONSTRAINT [PK_LinkProjectToProject] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkProjectToProject_LinkProjectToProject] FOREIGN KEY ([ParentProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_LinkProjectToProject_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);

