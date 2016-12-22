CREATE TABLE [dbo].[Colors] (
    [Id]          NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (50)  NOT NULL,
    [Hex]         NVARCHAR (50)  NOT NULL,
    [DateCreated] DATETIME       NOT NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Colors_DateCreated]
    ON [dbo].[Colors]([DateCreated] ASC);

