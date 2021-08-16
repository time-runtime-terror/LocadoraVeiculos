CREATE TABLE [dbo].[TBVEICULO] (
    [Id]               INT             IDENTITY NOT NULL,
    [Foto]             VARBINARY (MAX) NULL,
    [Placa]            VARCHAR (50)    NOT NULL,
    [Modelo]           VARCHAR (50)    NOT NULL,
    [Marca]            VARCHAR (50)    NOT NULL,
    [TipoCombustivel]  VARCHAR (50)    NOT NULL,
    [CapacidadeTanque] VARCHAR (50)    NOT NULL,
    [Quilometragem]    VARCHAR (50)    NOT NULL,
    [TipoVeiculo]      VARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

