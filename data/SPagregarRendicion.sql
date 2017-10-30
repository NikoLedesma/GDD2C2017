
CREATE TYPE [NO_TENGO_IDEA].[TableParameterIDFACT] AS TABLE(
	[idsFac] [int] NULL
)

ALTER PROCEDURE [NO_TENGO_IDEA].[agregarRendicion]
			@FECHA DATETIME ,
			@IMPORTE FLOAT,
			@PORCENTAJE FLOAT, 
			@IDFACT  TableParameterIDFACT READONLY,
			@RESULT INT OUTPUT
	AS
BEGIN
	DECLARE @idRendicion int = 0;
	BEGIN TRAN tranRendicion
		
		INSERT INTO NO_TENGO_IDEA.Rendicion (rend_fecha,rend_importe,rend_porcentaje)
		VALUES (@FECHA,@IMPORTE,@PORCENTAJE)
	
		select TOP 1 @idRendicion = rend_id from NO_TENGO_IDEA.Rendicion where rend_fecha = @FECHA AND 
									rend_importe = @IMPORTE AND rend_porcentaje = @PORCENTAJE 
									order by rend_id DESC
		IF( @idRendicion > 0)
			BEGIN
				INSERT INTO NO_TENGO_IDEA.Rf (rf_rendicion,rf_factura)
					(SELECT @idRendicion, idsFac from @IDFACT)
				COMMIT TRAN tranRendicion
				RETURN
			END
		ELSE
			ROLLBACK;
			
END


DECLARE	@PEPA as TableParameterIDFACT

INSERT INTO @PEPA (idsFac)
	values (1),(4)

exec [NO_TENGO_IDEA].[agregarRendicion] 
			 '28/10/2017' ,
			 222,
			 41, 
			@PEPA ,
			 0


select * from NO_TENGO_IDEA.Rendicion

select fact_id from NO_TENGO_IDEA.Factura join NO_TENGO_IDEA.Rf ON fact_id != rf_factura

select * from NO_TENGO_IDEA.Factura


