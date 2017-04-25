CREATE TABLE [dbo].[LinkUserToProject] (
    [Id]          NVARCHAR (128) NOT NULL,
    [UserId]      NVARCHAR (128) NOT NULL,
    [ProjectId]   NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkUserToProject] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkUserToProject_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_LinkUserToProject_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);

