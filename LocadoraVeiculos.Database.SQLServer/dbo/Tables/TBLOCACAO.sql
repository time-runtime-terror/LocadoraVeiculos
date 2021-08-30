CREATE TABLE [dbo].[TBLOCACAO] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Id_Veiculo]    INT           NULL,
    [Id_Cliente]    INT           NULL,
    [Plano]         VARCHAR (20)  NOT NULL,
    [DataSaida]     DATE          NOT NULL,
    [DataDevolucao] DATE          NOT NULL,
    [Caucao]        FLOAT (53)    NOT NULL,
    [Devolucao]     VARCHAR (20)  CONSTRAINT [DF__TBLOCACAO__Devol__1209AD79] DEFAULT ('Pendente') NULL,
    [Condutor]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_TBCLIENTE_ID] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBLOCACAO_TBCLIENTE] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[TBCLIENTE] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TBLOCACAO_TBVEICULO] FOREIGN KEY ([Id_Veiculo]) REFERENCES [dbo].[TBVEICULO] ([Id]) ON DELETE NO ACTION
);


