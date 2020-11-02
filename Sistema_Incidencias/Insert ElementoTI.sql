/****** Script for Insert Into ElementoTI command from SSMS   ******/
SELECT TOP (1000) [id]
      ,[tipo]
      ,[marca]
      ,[modelo]
      ,[Descripcion]
      ,[garantia]
      ,[fechaCompra]
  FROM [Sistema_Incidencias].[dbo].[elementoTI]

  INSERT INTO elementoTI(
	tipo,
	marca,
	modelo,
	Descripcion,
	garantia,
	fechaCompra
)

VALUES
 /***** Elementos de TI *****/
(1, 'DELL', 'Optiplex 7040', 'PROCESADOR INTEL CORE I7 6700 DE 6TH 8 GB DE RAM 2 TB DE DISCO DURO', 1, GETDATE())