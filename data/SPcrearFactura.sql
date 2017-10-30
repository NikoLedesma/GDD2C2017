USE [GD2C2017]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[crearFactura]    Script Date: domingo, 29 de octubre de 2017 00:27:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[crearFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[crearFactura]
GO
/****** Object:  UserDefinedTableType [dbo].[TableParameterItem]    Script Date: domingo, 29 de octubre de 2017 00:27:13 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterItem' AND ss.name = N'dbo')
DROP TYPE [dbo].[TableParameterItem]
GO
/****** Object:  UserDefinedTableType [dbo].[TableParameterItem]    Script Date: domingo, 29 de octubre de 2017 00:27:13 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterItem' AND ss.name = N'dbo')
CREATE TYPE [NO_TENGO_IDEA].[TableParameterItem] AS TABLE(
	[monto] [float] NULL,
	[cantidad] [int] NULL,
	[id] [int] NULL
)
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[crearFactura]    Script Date: domingo, 29 de octubre de 2017 00:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[crearFactura]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [NO_TENGO_IDEA].[crearFactura]
			@ID int,
			@CLIENTE int,
			@EMPRESA int ,
			@NUMERO int ,
			@FECHAALTA DATETIME ,
			@FECHAVENC DATETIME ,
			@TOTAL FLOAT, 
			@ITEMS  TableParameterItem READONLY,
			@RESULT INT OUTPUT
	AS
BEGIN
	DECLARE @idFactura int = 0;
	BEGIN TRAN tranFactura
		IF(@ID > 0)
			BEGIN
				UPDATE NO_TENGO_IDEA.Factura SET	
												fact_cliente = @CLIENTE, 
												fact_empresa = @EMPRESA, 
												fact_numero = @NUMERO, 
												fact_fecha_alta = @FECHAALTA,
												fact_fecha_vencimiento = @FECHAVENC,
												fact_total = @TOTAL
											WHERE fact_id = @ID;
				
				update NO_TENGO_IDEA.Item SET
											Item.item_cantidad = par.cantidad, Item.item_monto = par.monto
										FROM NO_TENGO_IDEA.Item INNER JOIN @ITEMS as par ON Item.item_id = par.id
										
				/*INSERT INTO NO_TENGO_IDEA.Item (item_factura, item_monto, item_cantidad)
							(SELECT @ID, monto, cantidad from @ITEMS)*/
				COMMIT TRAN tranFactura
											
			END

		ELSE
			BEGIN
				INSERT INTO NO_TENGO_IDEA.Factura(fact_numero, fact_fecha_alta, fact_total, fact_fecha_vencimiento, fact_empresa, fact_cliente)
				 VALUES (@NUMERO, @FECHAALTA, @TOTAL, @FECHAVENC, @EMPRESA, @CLIENTE);

				select TOP 1 @idFactura = fact_id from NO_TENGO_IDEA.Factura where fact_total = @TOTAL AND fact_numero = @NUMERO AND fact_fecha_alta = @FECHAALTA AND fact_fecha_vencimiento = @FECHAVENC AND fact_empresa = @EMPRESA AND fact_cliente = @CLIENTE order by fact_id DESC
				IF( @idFactura > 0)
					BEGIN
						INSERT INTO NO_TENGO_IDEA.Item (item_factura, item_monto, item_cantidad)
							(SELECT @idFactura, monto, cantidad from @ITEMS)
						COMMIT TRAN tranFactura
						RETURN
					END
				ELSE
					ROLLBACK;
			END
END' 
END
GO
