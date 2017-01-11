﻿CREATE TABLE [dbo].[LinkUserToFolder] (
    [Id]          NVARCHAR (128) NOT NULL,
    [UserId]      NVARCHAR (128) NOT NULL,
    [FolderId]    NVARCHAR (128) NOT NULL,
    [DateCreated] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_LinkUserToFolder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkUserToFolder_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_LinkUserToFolder_Folders] FOREIGN KEY ([FolderId]) REFERENCES [dbo].[Folders] ([Id])
);
