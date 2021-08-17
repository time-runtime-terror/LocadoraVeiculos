CREATE TABLE [dbo].[TBVEICULO] (
    [Id]               INT             IDENTITY NOT NULL,
    [Foto]             VARBINARY (MAX) NULL,
    [Placa]            VARCHAR (50)    NOT NULL,
    [Modelo]           VARCHAR (50)    NOT NULL,
    [Marca]            VARCHAR (50)    NOT NULL,
    [TipoCombustivel]  VARCHAR (50)    NOT NULL,
    [CapacidadeTanque] VARCHAR (50)    NOT NULL,
    [Quilometragem]    VARCHAR (50)    NOT NULL,
    [Id_GrupoAutomoveis] INT    NULL,
    CONSTRAINT [FK_TBVEICULO_TBGRUPOAUTOMOVEIS] FOREIGN KEY (Id_GrupoAutomoveis) REFERENCES [dbo].[TBGRUPOAUTOMOVEIS] ([Id]) ON DELETE SET NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

