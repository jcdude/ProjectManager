CREATE TABLE [dbo].[EmailQueue] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ToAddress]   NVARCHAR (150) NOT NULL,
    [FromAddress] NVARCHAR (150) NOT NULL,
    [Subject]     NVARCHAR (250) NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [IsProcessed] BIT            CONSTRAINT [DF_EmailQueue_IsProcessed] DEFAULT ((0)) NULL,
    [DateCreated] DATETIME       NULL,
    CONSTRAINT [PK_EmailQueue] PRIMARY KEY CLUSTERED ([Id] ASC)
);

