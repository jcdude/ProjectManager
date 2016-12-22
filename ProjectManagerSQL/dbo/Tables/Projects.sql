CREATE TABLE [dbo].[Projects] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (150) NOT NULL,
    [ColorId]     NVARCHAR (128) NULL,
    [StartDate]   DATETIME       NULL,
    [EndDate]     DATETIME       NULL,
    [PriorityId]  NVARCHAR (128) NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Projects_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id])
);

