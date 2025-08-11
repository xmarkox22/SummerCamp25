CREATE TABLE [dbo].[DistrictStreet] (
    [DistrictId] VARCHAR (36) NOT NULL,
    [StreetId]   VARCHAR (36) NOT NULL,
    PRIMARY KEY CLUSTERED ([DistrictId] ASC, [StreetId] ASC),
    CONSTRAINT [FKDistrictSt200593] FOREIGN KEY ([StreetId]) REFERENCES [dbo].[Street] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FKDistrictSt746137] FOREIGN KEY ([DistrictId]) REFERENCES [dbo].[District] ([Id]) ON DELETE CASCADE
);

