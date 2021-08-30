CREATE TABLE [dbo].[TBTAXASSERVICOS] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Servico]      VARCHAR (50)   NOT NULL,
    [Taxa]         DECIMAL (6, 2) NOT NULL,
    [OpcaoServico] VARCHAR (30)   NOT NULL,
    [localServico] VARCHAR (30)   NOT NULL,
    CONSTRAINT [PK__TBTAXASS__3214EC070B08FE3A] PRIMARY KEY CLUSTERED ([Id] ASC)
);



