IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [Desserts] (
        [Id] int NOT NULL IDENTITY,
        [Naam] nvarchar(100) NOT NULL,
        [Prijs] float NOT NULL,
        [Hoeveelheid] float NOT NULL,
        [Omschrijving] nvarchar(150) NULL,
        [Foto] nvarchar(100) NULL,
        CONSTRAINT [PK_Desserts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [Gerechten] (
        [Id] int NOT NULL IDENTITY,
        [Naam] nvarchar(100) NOT NULL,
        [Prijs] float NOT NULL,
        [Hoeveelheid] float NOT NULL,
        [Omschrijving] nvarchar(150) NULL,
        [Foto] nvarchar(100) NULL,
        CONSTRAINT [PK_Gerechten] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [Menus] (
        [Id] int NOT NULL IDENTITY,
        [Datum] datetime2 NOT NULL,
        [Omschrijving] nvarchar(150) NULL,
        CONSTRAINT [PK_Menus] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [Soepen] (
        [Id] int NOT NULL IDENTITY,
        [Naam] nvarchar(100) NOT NULL,
        [Prijs] float NOT NULL,
        [Hoeveelheid] float NOT NULL,
        [Omschrijving] nvarchar(150) NULL,
        [Foto] nvarchar(100) NULL,
        CONSTRAINT [PK_Soepen] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [MenuDessert] (
        [MenuId] int NOT NULL,
        [DessertId] int NOT NULL,
        [Datum] datetime2 NOT NULL,
        CONSTRAINT [PK_MenuDessert] PRIMARY KEY ([MenuId], [DessertId]),
        CONSTRAINT [FK_MenuDessert_Desserts_DessertId] FOREIGN KEY ([DessertId]) REFERENCES [Desserts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MenuDessert_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [MenuGerecht] (
        [MenuId] int NOT NULL,
        [GerechtId] int NOT NULL,
        [Datum] datetime2 NOT NULL,
        CONSTRAINT [PK_MenuGerecht] PRIMARY KEY ([MenuId], [GerechtId]),
        CONSTRAINT [FK_MenuGerecht_Gerechten_GerechtId] FOREIGN KEY ([GerechtId]) REFERENCES [Gerechten] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MenuGerecht_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE TABLE [MenuSoep] (
        [MenuId] int NOT NULL,
        [SoepId] int NOT NULL,
        [Datum] datetime2 NOT NULL,
        CONSTRAINT [PK_MenuSoep] PRIMARY KEY ([MenuId], [SoepId]),
        CONSTRAINT [FK_MenuSoep_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MenuSoep_Soepen_SoepId] FOREIGN KEY ([SoepId]) REFERENCES [Soepen] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Desserts]'))
        SET IDENTITY_INSERT [Desserts] ON;
    INSERT INTO [Desserts] ([Id], [Foto], [Hoeveelheid], [Naam], [Omschrijving], [Prijs])
    VALUES (1, NULL, 1.0E0, N'Chocomousse', NULL, 2.0E0),
    (2, NULL, 1.0E0, N'Potje panna cotta met chocolade', NULL, 1.5E0),
    (3, NULL, 1.0E0, N'Appeltaart met kaneel', NULL, 2.0E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Desserts]'))
        SET IDENTITY_INSERT [Desserts] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Gerechten]'))
        SET IDENTITY_INSERT [Gerechten] ON;
    INSERT INTO [Gerechten] ([Id], [Foto], [Hoeveelheid], [Naam], [Omschrijving], [Prijs])
    VALUES (1, NULL, 1.0E0, N'Spaghetti', N'De lekkerste spaghetti bolognese die je geproefd zal hebben', 8.5E0),
    (2, NULL, 1.0E0, N'Hespenrolletjes met witloof in de kaassaus, samen met puree', N'Met verse groenten uit de tuin', 8.5E0),
    (3, NULL, 1.0E0, N'Aardappelschotel met burgers, feta en kerstomaatjes', N'Feest op je bord', 9.0E0),
    (4, NULL, 1.0E0, N'Parelcouscous met kippenfilet, een slaatje met kruidenyoghurtsausje', N'De parelcouscous is een soort pasta', 9.0E0),
    (5, NULL, 1.0E0, N'Wortelpuree met braadworst', N'De famous wortelpuree van KSA Berlare', 9.0E0),
    (6, NULL, 1.0E0, N'Schelvis met prei en aardappel uit de oven', NULL, 9.0E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Gerechten]'))
        SET IDENTITY_INSERT [Gerechten] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Datum', N'Omschrijving') AND [object_id] = OBJECT_ID(N'[Menus]'))
        SET IDENTITY_INSERT [Menus] ON;
    INSERT INTO [Menus] ([Id], [Datum], [Omschrijving])
    VALUES (1, '2019-08-13T16:29:39.9196962+02:00', N'Dit is de eerste menu dat mama gekookt zal hebben'),
    (2, '2019-05-27T16:29:39.9227852+02:00', N'Dit is de tweede menu die mama gemaakt heeft!'),
    (3, '2019-06-13T16:29:39.9227878+02:00', N'Dit is een voorlopige menu! ');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Datum', N'Omschrijving') AND [object_id] = OBJECT_ID(N'[Menus]'))
        SET IDENTITY_INSERT [Menus] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Soepen]'))
        SET IDENTITY_INSERT [Soepen] ON;
    INSERT INTO [Soepen] ([Id], [Foto], [Hoeveelheid], [Naam], [Omschrijving], [Prijs])
    VALUES (1, NULL, 0.5E0, N'Groentensoep', NULL, 2.0E0),
    (2, NULL, 0.5E0, N'Tomatensoep met balletjes', NULL, 2.5E0),
    (3, NULL, 0.5E0, N'Gebraden paprikasoep', NULL, 1.5E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Foto', N'Hoeveelheid', N'Naam', N'Omschrijving', N'Prijs') AND [object_id] = OBJECT_ID(N'[Soepen]'))
        SET IDENTITY_INSERT [Soepen] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_MenuDessert_DessertId] ON [MenuDessert] ([DessertId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_MenuGerecht_GerechtId] ON [MenuGerecht] ([GerechtId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    CREATE INDEX [IX_MenuSoep_SoepId] ON [MenuSoep] ([SoepId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190513142940_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190513142940_InitialCreate', N'2.2.2-servicing-10034');
END;

GO

