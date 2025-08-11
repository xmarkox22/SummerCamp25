CREATE TABLE [dbo].[BuildingStatusLog] (
    [BuildingId] VARCHAR (36) NOT NULL,
    [StatusId]   VARCHAR (36) NOT NULL,
    [CreatedAt]  DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([BuildingId] ASC, [StatusId] ASC, [CreatedAt] ASC),
    CONSTRAINT [FKBuildingSt501021] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FKBuildingSt885424] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
);

