CREATE TABLE [dbo].[LinkProjectToTask] (
    [Id]          NVARCHAR (128) NOT NULL,
    [ProjectId]   NVARCHAR (128) NOT NULL,
    [TaskId]      NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkProjectToTask] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkProjectToTask_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_LinkProjectToTask_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Tasks] ([Id])
);

