CREATE TABLE [dbo].[TBVEICULO] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Foto]               VARBINARY (MAX) NULL,
    [Placa]              VARCHAR (50)    NOT NULL,
    [Modelo]             VARCHAR (50)    NOT NULL,
    [Marca]              VARCHAR (50)    NOT NULL,
    [TipoCombustivel]    VARCHAR (50)    NOT NULL,
    [CapacidadeTanque]   INT             NOT NULL,
    [Quilometragem]      INT             NOT NULL,
    [Id_GrupoAutomoveis] INT             NULL,
    CONSTRAINT [PK__TBVEICUL__3214EC0792D2BD47] PRIMARY KEY CLUSTERED ([Id] ASC)
);



