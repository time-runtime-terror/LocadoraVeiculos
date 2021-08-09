CREATE TABLE [dbo].[TBFUNCIONARIO] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [NomeUsuario] VARCHAR (50) NOT NULL,
    [Senha]       VARCHAR (50) NOT NULL,
    [DataEntrada] DATE         NOT NULL,
    [Salario]     VARCHAR (50) NOT NULL
);

