CREATE TABLE [dbo].[TBGRUPOAUTOMOVEIS]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NomeGrupo] NCHAR(50) NOT NULL, 
    [PlanoDiarioUm] DECIMAL(6, 2) NOT NULL, 
    [PlanoDiarioDois] DECIMAL(6, 2) NULL, 
    [KmControladoUm] DECIMAL(6, 2) NOT NULL, 
    [KmControladoDois] DECIMAL(6, 2) NULL, 
    [KmLivreUm] DECIMAL(6, 2) NOT NULL, 
    [KmLivreDois] DECIMAL(6, 2) NULL
)
