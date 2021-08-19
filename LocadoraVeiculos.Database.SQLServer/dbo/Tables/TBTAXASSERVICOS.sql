CREATE TABLE [dbo].[TBTAXASSERVICOS] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Servico]      VARCHAR (50)   NOT NULL,
    [Taxa]         DECIMAL (6, 2) NOT NULL,
    [OpcaoServico] VARCHAR (30)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

