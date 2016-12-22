CREATE TABLE [dbo].[LinkUserToTask] (
    [Id]          NVARCHAR (128) NOT NULL,
    [UserId]      NVARCHAR (128) NOT NULL,
    [TaskId]      NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkUserToTask] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkUserToTask_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_LinkUserToTask_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Tasks] ([Id])
);

