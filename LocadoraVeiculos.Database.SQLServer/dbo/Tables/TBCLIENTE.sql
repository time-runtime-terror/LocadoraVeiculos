CREATE TABLE [dbo].[TBCLIENTE] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (50) NOT NULL,
    [Endereco]          VARCHAR (50) NOT NULL,
    [Telefone]          VARCHAR (50) NOT NULL,
    [TipoCadastro]      VARCHAR (50) NOT NULL,
    [NumeroCadastro]    VARCHAR (50) NOT NULL,
    [Rg]                VARCHAR (50) NULL,
    [Cnh]               VARCHAR (50) NULL,
    [DataVencimentoCNH] DATE         NULL,
    [Id_Empresa]        INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



