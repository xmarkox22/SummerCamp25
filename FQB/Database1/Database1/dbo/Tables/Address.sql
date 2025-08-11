CREATE TABLE [dbo].[Address] (
    [Id]          VARCHAR (36)  NOT NULL,
    [BuildingId]  VARCHAR (36)  NOT NULL,
    [ApartmentId] VARCHAR (36)  NOT NULL,
    [IsApartment] BIT           DEFAULT ((1)) NOT NULL,
    [Country]     VARCHAR (255) NOT NULL,
    [City]        VARCHAR (255) NOT NULL,
    [CreatedAt]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [UpdatedAt]   DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AddressIsApartment] CHECK ([IsApartment]=(1) OR [IsApartment]=(0)),
    CONSTRAINT [FKAddress69853] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([Id]),
    CONSTRAINT [FKAddress937616] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([Id]) ON DELETE CASCADE
);

