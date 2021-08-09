CREATE TABLE [dbo].[TBCLIENTE] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (50) NOT NULL,
    [Endereco]          VARCHAR (50) NOT NULL,
    [Telefone]          VARCHAR (50) NOT NULL,
    [TipoPessoa]        VARCHAR (50) NOT NULL,
    [Cpf]               VARCHAR (50) NULL,
    [Cnpj]              VARCHAR (50) NULL,
    [Rg]                VARCHAR (50) NOT NULL,
    [DataVencimentoCNH] DATE         NOT NULL,
    [Id_Condutor]       INT          NULL
);

