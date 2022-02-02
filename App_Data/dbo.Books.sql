CREATE TABLE [dbo].[Books] (
    [BookID]      INT                  IDENTITY (100, 1) NOT NULL,
    [Title]       VARCHAR (100)        NOT NULL,
    [Author]      VARCHAR (120)        NOT NULL,
    [Description] VARCHAR (140) SPARSE NULL,
    [CategoryID]  INT                  NULL,
    [AddedTime]   DATETIME             DEFAULT (getdate()) NOT NULL,
    [ImagePath]   VARCHAR(MAX)         NULL,
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[BookCategories] ([CategoryID]) ON DELETE CASCADE,
    PRIMARY KEY CLUSTERED ([BookID] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[BookCategories] ([CategoryID]) ON DELETE CASCADE
);

