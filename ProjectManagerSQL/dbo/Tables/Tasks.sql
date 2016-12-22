CREATE TABLE [dbo].[Tasks] (
    [Id]           NVARCHAR (128) NOT NULL,
    [Description]  NVARCHAR (250) NOT NULL,
    [Body]         TEXT           NULL,
    [UserId]       NVARCHAR (128) NULL,
    [WorkflowId]   NVARCHAR (128) NULL,
    [DateStart]    DATETIME       NULL,
    [DateEnd]      DATETIME       NULL,
    [ParentTaskId] NVARCHAR (128) NULL,
    [DateCreated]  DATETIME       NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([Id] ASC)
);

