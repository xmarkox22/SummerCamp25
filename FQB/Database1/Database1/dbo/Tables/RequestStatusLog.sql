CREATE TABLE [dbo].[RequestStatusLog] (
    [RequestId] VARCHAR (36) NOT NULL,
    [StatusId]  VARCHAR (36) NOT NULL,
    [CreatedAt] DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([RequestId] ASC, [StatusId] ASC, [CreatedAt] ASC),
    CONSTRAINT [FKRequestSta565383] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[Request] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FKRequestSta994406] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
);

