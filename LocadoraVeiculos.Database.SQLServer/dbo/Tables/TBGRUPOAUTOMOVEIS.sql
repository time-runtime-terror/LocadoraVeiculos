CREATE TABLE [dbo].[TBGRUPOAUTOMOVEIS] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [NomeGrupo]            VARCHAR (50)   NOT NULL,
    [PlanoDiarioUm]        DECIMAL (6, 2) NOT NULL,
    [PlanoDiarioDois]      DECIMAL (6, 2) NULL,
    [KmControladoUm]       DECIMAL (6, 2) NOT NULL,
    [KmControladoDois]     DECIMAL (6, 2) NULL,
    [KmLivreUm]            DECIMAL (6, 2) NOT NULL,
    [KmControladoIncluido] DECIMAL (6, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


