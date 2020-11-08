IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [Status] nvarchar(max) NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Preco] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PedidosItem] (
    [Id] uniqueidentifier NOT NULL,
    [IdPedido] uniqueidentifier NOT NULL,
    [IdProduto] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PedidosItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidosItem_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidosItem_Produtos_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PedidosItem_IdPedido] ON [PedidosItem] ([IdPedido]);

GO

CREATE INDEX [IX_PedidosItem_IdProduto] ON [PedidosItem] ([IdProduto]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201106203359_InitialCreate', N'3.1.9');

GO

ALTER TABLE [PedidosItem] ADD [Quantidade] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201106205602_ALterTablePedidosItem', N'3.1.9');

GO

