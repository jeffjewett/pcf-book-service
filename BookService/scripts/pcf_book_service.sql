CREATE TABLE [dbo].[Authors] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Books] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX)  NOT NULL,
    [Year]     INT             NOT NULL,
    [Price]    DECIMAL (18, 2) NOT NULL,
    [Genre]    NVARCHAR (MAX)  NULL,
    [AuthorId] INT             NOT NULL,
    CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Books_dbo.Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

