USE [GD2C2017]
GO
/****** Object:  Trigger [cheuqueoSucursalModificacion]    Script Date: 4/11/2017 19:17:20 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[cheuqueoSucursalModificacion]'))
DROP TRIGGER [LOS_PUBERTOS].[cheuqueoSucursalModificacion]
GO
/****** Object:  Trigger [cheuqueoCPdeSucursales]    Script Date: 4/11/2017 19:17:20 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[cheuqueoCPdeSucursales]'))
DROP TRIGGER [LOS_PUBERTOS].[cheuqueoCPdeSucursales]
GO

/****** Object:  Trigger [modificacionEmpresa]    Script Date: 4/11/2017 19:17:20 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[modificacionEmpresa]'))
DROP TRIGGER [LOS_PUBERTOS].[modificacionEmpresa]
GO
/****** Object:  Trigger [chequeoCuitEmpresa]    Script Date: 4/11/2017 19:17:20 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[chequeoCuitEmpresa]'))
DROP TRIGGER [LOS_PUBERTOS].[chequeoCuitEmpresa]
GO

/****** Object:  Trigger [controlDePago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[controlDePago]'))
DROP TRIGGER [LOS_PUBERTOS].[controlDePago]
GO

/****** Object:  Trigger [chequeoMailEnCliente]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[chequeoMailEnCliente]'))
DROP TRIGGER [LOS_PUBERTOS].[chequeoMailEnCliente]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_USUARIO]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su] DROP CONSTRAINT [FK_Su_USUARIO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su] DROP CONSTRAINT [FK_Su_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rf]'))
ALTER TABLE [LOS_PUBERTOS].[Rf] DROP CONSTRAINT [FK_Rf_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd] DROP CONSTRAINT [FK_Rd_Rendicion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd] DROP CONSTRAINT [FK_Rd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF] DROP CONSTRAINT [FK_PF_Pago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF] DROP CONSTRAINT [FK_PF_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago] DROP CONSTRAINT [FK_Pago_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago] DROP CONSTRAINT [FK_Pago_MedioDePago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Item]'))
ALTER TABLE [LOS_PUBERTOS].[Item] DROP CONSTRAINT [FK_Item_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd] DROP CONSTRAINT [FK_Fd_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd] DROP CONSTRAINT [FK_Fd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_Empresa]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura] DROP CONSTRAINT [FK_Factura_Empresa]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura] DROP CONSTRAINT [FK_Factura_CLIENTE]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Empresa]'))
ALTER TABLE [LOS_PUBERTOS].[Empresa] DROP CONSTRAINT [FK_Empresa_Rubro]
GO
/****** Object:  Table [LOS_PUBERTOS].[USUARIOXROL]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[USUARIOXROL]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[USUARIOXROL]
GO
/****** Object:  Table [LOS_PUBERTOS].[USUARIO]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[USUARIO]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[USUARIO]
GO
/****** Object:  Table [LOS_PUBERTOS].[Sucursal]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Sucursal]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Sucursal]
GO
/****** Object:  Table [LOS_PUBERTOS].[Su]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Su]
GO
/****** Object:  Table [LOS_PUBERTOS].[Rubro]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rubro]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Rubro]
GO
/****** Object:  Table [LOS_PUBERTOS].[ROLXFUNCIONALIDAD]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[ROLXFUNCIONALIDAD]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[ROLXFUNCIONALIDAD]
GO
/****** Object:  Table [LOS_PUBERTOS].[ROL]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[ROL]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[ROL]
GO
/****** Object:  Table [LOS_PUBERTOS].[Rf]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rf]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Rf]
GO
/****** Object:  Table [LOS_PUBERTOS].[Rendicion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rendicion]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Rendicion]
GO
/****** Object:  Table [LOS_PUBERTOS].[Rd]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Rd]
GO
/****** Object:  Table [LOS_PUBERTOS].[PF]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[PF]
GO
/****** Object:  Table [LOS_PUBERTOS].[Pago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Pago]
GO
/****** Object:  Table [LOS_PUBERTOS].[MedioDePago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[MedioDePago]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[MedioDePago]
GO
/****** Object:  Table [LOS_PUBERTOS].[Item]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Item]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Item]
GO
/****** Object:  Table [LOS_PUBERTOS].[FUNCIONALIDAD]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FUNCIONALIDAD]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[FUNCIONALIDAD]
GO
/****** Object:  Table [LOS_PUBERTOS].[Fd]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Fd]
GO
/****** Object:  Table [LOS_PUBERTOS].[Factura]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Factura]
GO
/****** Object:  Table [LOS_PUBERTOS].[Empresa]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Empresa]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Empresa]
GO
/****** Object:  Table [LOS_PUBERTOS].[Devolucion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Devolucion]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[Devolucion]
GO
/****** Object:  Table [LOS_PUBERTOS].[CLIENTE]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[CLIENTE]') AND type in (N'U'))
DROP TABLE [LOS_PUBERTOS].[CLIENTE]
GO
/****** Object:  UserDefinedFunction [LOS_PUBERTOS].[comparaFecha]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[comparaFecha]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [LOS_PUBERTOS].[comparaFecha]
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[SP_VERIFICAR_FACTURA]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[SP_VERIFICAR_FACTURA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [LOS_PUBERTOS].SP_VERIFICAR_FACTURA
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[createDevolucion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[createDevolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [LOS_PUBERTOS].[createDevolucion]
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[crearFactura]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[crearFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [LOS_PUBERTOS].[crearFactura]
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[agregarRendicion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[agregarRendicion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [LOS_PUBERTOS].[agregarRendicion]
GO
/****** Object:  UserDefinedTableType [LOS_PUBERTOS].[TableParameterItem]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterItem' AND ss.name = N'LOS_PUBERTOS')
DROP TYPE [LOS_PUBERTOS].[TableParameterItem]
GO
/****** Object:  UserDefinedTableType [LOS_PUBERTOS].[TableParameterIDFACT]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterIDFACT' AND ss.name = N'LOS_PUBERTOS')
DROP TYPE [LOS_PUBERTOS].[TableParameterIDFACT]
GO
/****** Object:  Schema [LOS_PUBERTOS]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'LOS_PUBERTOS')
DROP SCHEMA [LOS_PUBERTOS]
GO
/****** Object:  Schema [LOS_PUBERTOS]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'LOS_PUBERTOS')
EXEC sys.sp_executesql N'CREATE SCHEMA [LOS_PUBERTOS]'

GO
/****** Object:  UserDefinedTableType [LOS_PUBERTOS].[TableParameterIDFACT]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterIDFACT' AND ss.name = N'LOS_PUBERTOS')
CREATE TYPE [LOS_PUBERTOS].[TableParameterIDFACT] AS TABLE(
	[idsFac] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [LOS_PUBERTOS].[TableParameterItem]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'TableParameterItem' AND ss.name = N'LOS_PUBERTOS')
CREATE TYPE [LOS_PUBERTOS].[TableParameterItem] AS TABLE(
	[monto] [float] NULL,
	[cantidad] [int] NULL,
	[id] [int] NULL
)
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[agregarRendicion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[agregarRendicion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [LOS_PUBERTOS].[agregarRendicion]
			@FECHA DATETIME ,
			@IMPORTE FLOAT,
			@PORCENTAJE FLOAT, 
			@IDFACT  TableParameterIDFACT READONLY,
			@RESULT INT OUTPUT
	AS
BEGIN
	DECLARE @idRendicion int = 0;
	BEGIN TRAN tranRendicion
		
		INSERT INTO LOS_PUBERTOS.Rendicion (rend_fecha,rend_importe,rend_porcentaje)
		VALUES (@FECHA,@IMPORTE,@PORCENTAJE)
	
		select TOP 1 @idRendicion = rend_id from LOS_PUBERTOS.Rendicion where rend_fecha = @FECHA AND 
									rend_importe = @IMPORTE AND rend_porcentaje = @PORCENTAJE 
									order by rend_id DESC
		IF( @idRendicion > 0)
			BEGIN
				INSERT INTO LOS_PUBERTOS.Rf (rf_rendicion,rf_factura)
					(SELECT @idRendicion, idsFac from @IDFACT)
				COMMIT TRAN tranRendicion
				RETURN
			END
		ELSE
			ROLLBACK;
			
END' 
END
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[crearFactura]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[crearFactura]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [LOS_PUBERTOS].[crearFactura]
			@ID int,
			@CLIENTE int,
			@EMPRESA int ,
			@NUMERO int ,
			@FECHAALTA DATETIME ,
			@FECHAVENC DATETIME ,
			@TOTAL FLOAT, 
			@HABILITADA bit,
			@ITEMS  TableParameterItem READONLY,
			@RESULT INT OUTPUT
	AS
BEGIN
	DECLARE @idFactura int = 0;
	BEGIN TRAN tranFactura
		IF(@ID > 0)
			BEGIN
				UPDATE LOS_PUBERTOS.Factura SET	
												fact_cliente = @CLIENTE, 
												fact_empresa = @EMPRESA, 
												fact_numero = @NUMERO, 
												fact_fecha_alta = @FECHAALTA,
												fact_fecha_vencimiento = @FECHAVENC,
												fact_total = @TOTAL,
												fact_inactiva = @HABILITADA
											WHERE fact_id = @ID;
				
				update LOS_PUBERTOS.Item SET
											Item.item_cantidad = par.cantidad, Item.item_monto = par.monto
										FROM LOS_PUBERTOS.Item INNER JOIN @ITEMS as par ON Item.item_id = par.id
										
				/*INSERT INTO LOS_PUBERTOS.Item (item_factura, item_monto, item_cantidad)
							(SELECT @ID, monto, cantidad from @ITEMS)*/
				COMMIT TRAN tranFactura
											
			END

		ELSE
			BEGIN
				INSERT INTO LOS_PUBERTOS.Factura(fact_numero, fact_fecha_alta, fact_total, fact_fecha_vencimiento, fact_empresa, fact_cliente, fact_inactiva)
				 VALUES (@NUMERO, @FECHAALTA, @TOTAL, @FECHAVENC, @EMPRESA, @CLIENTE, 1);

				select TOP 1 @idFactura = fact_id from LOS_PUBERTOS.Factura where fact_total = @TOTAL AND fact_numero = @NUMERO AND fact_fecha_alta = @FECHAALTA AND fact_fecha_vencimiento = @FECHAVENC AND fact_empresa = @EMPRESA AND fact_cliente = @CLIENTE order by fact_id DESC
				IF( @idFactura > 0)
					BEGIN
						INSERT INTO LOS_PUBERTOS.Item (item_factura, item_monto, item_cantidad)
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
/****** Object:  StoredProcedure [LOS_PUBERTOS].[createDevolucion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[createDevolucion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [LOS_PUBERTOS].[createDevolucion]
	@RAZON varchar(50),
	@FACTURA int,
	@RENDICION int
AS	
	BEGIN
		INSERT INTO LOS_PUBERTOS.Devolucion (devo_razon)
				VALUES (@RAZON);
	
		DECLARE  @devoId int = 0;
		SELECT TOP 1 @devoID = devo_id FROM LOS_PUBERTOS.Devolucion WHERE 1=1 order by devo_id DESC
	
		if(@devoId > 0 AND @FACTURA > 0)
			INSERT INTO LOS_PUBERTOS.Fd (fd_factura, fd_devolucion) VALUES (@FACTURA, @devoId)
		
		ELSE IF(@devoId > 0 AND @RENDICION > 0)
			INSERT INTO LOS_PUBERTOS.Rd (rd_devolucion, rd_rendicion) VALUES (@devoId, @RENDICION)
	END
' 
END
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
	/*devuelve el resultado de inicio de session.
	   1-No existe el usuario
	   2-Existe el usuario, no puede iniciar sesion por la cant de intentos fallidos
	   3-El usuario pudo iniciar sesion
	   4-El usuario ingreso mal la password, incremente la cant de intento fallidos 
	   */
	CREATE PROCEDURE [LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]
			@USERNAME varchar(50),
			@PASSWORD varchar(65) ,
			@ESTADO_INICIO INT OUTPUT
	AS
	DECLARE   @CANT_INTENTOS_FALLIDOS TINYINT
	IF (EXISTS(SELECT * FROM LOS_PUBERTOS.USUARIO WHERE LOS_PUBERTOS.USUARIO.USERNAME = @USERNAME))
	BEGIN
		SELECT @CANT_INTENTOS_FALLIDOS = CANT_INTENTOS_FALLIDOS FROM LOS_PUBERTOS.USUARIO WHERE LOS_PUBERTOS.USUARIO.USERNAME = @USERNAME
		IF(@CANT_INTENTOS_FALLIDOS < 3)
		BEGIN
			IF (EXISTS(SELECT * FROM LOS_PUBERTOS.USUARIO WHERE LOS_PUBERTOS.USUARIO.USERNAME = @USERNAME AND LOS_PUBERTOS.USUARIO.PASS = @PASSWORD))
			BEGIN
				SET @ESTADO_INICIO = 3
				UPDATE LOS_PUBERTOS.USUARIO SET CANT_INTENTOS_FALLIDOS = 0 WHERE LOS_PUBERTOS.USUARIO.USERNAME = @USERNAME
			END
			ELSE
			BEGIN
				SET @ESTADO_INICIO = 4
				UPDATE LOS_PUBERTOS.USUARIO SET CANT_INTENTOS_FALLIDOS=CANT_INTENTOS_FALLIDOS + 1 WHERE LOS_PUBERTOS.USUARIO.USERNAME = @USERNAME 
			END
		END
		ELSE
		BEGIN
			SET @ESTADO_INICIO = 2
		END	
	END
	ELSE
	BEGIN
		SET @ESTADO_INICIO=1
	END
	/*
			CREATE TABLE LOS_PUBERTOS.CLIENTE 
		(
		CLIENTE_ID INTEGER PRIMARY KEY,
		CLIENTE_NOMBRE VARCHAR(20),
		CLIENTE_APELLIDO VARCHAR(20),
		CLIENTE_DNI INTEGER,
		CLIENTE_MAIL VARCHAR(20),
		CLIENTE_DIRECCION VARCHAR(20),
		CLIENTE_NRO_PISO SMALLINT,
		CLIENTE_DEPTO CHAR(1),
		CLIENTE_LOCALIDAD VARCHAR(15),
		CLIENTE_NRO_TELEFONO INTEGER,
		CLIENTE_COD_POSTAL VARCHAR(20),
		CLIENTE_FECHA_NACIMIENTO DATETIME,
		CLIENTE_HABILITADO BIT,
		)
	
	*/' 
END
GO
/****** Object:  StoredProcedure [LOS_PUBERTOS].[SP_INICIAR_SESION_DE_USUARIO]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[SP_VERIFICAR_FACTURA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/*
1.La factura no existe
2.La factura existe, no fue pagada
3.La factura existe, pero ya fue pagada
4.La factura existe, no fue pagada,la empresa esta deshabilitada
*/

	CREATE PROCEDURE [LOS_PUBERTOS].[SP_VERIFICAR_FACTURA]
			@NUMERO_DE_FACTURA varchar(50),
			@ESTADO_FACTURA INT OUTPUT
	AS
	DECLARE   @EMPRESA_ID INTEGER
	DECLARE   @EMPRESA_INACTIVO INTEGER
	IF (EXISTS(SELECT * FROM LOS_PUBERTOS.Factura f WHERE f.fact_numero=@NUMERO_DE_FACTURA))
	BEGIN
		IF(NOT EXISTS(SELECT * FROM LOS_PUBERTOS.pf WHERE pf_factura=(SELECT f.fact_id FROM LOS_PUBERTOS.Factura f WHERE f.fact_numero =  @NUMERO_DE_FACTURA )))
		BEGIN
			SELECT @EMPRESA_ID=f.fact_empresa FROM LOS_PUBERTOS.Factura f WHERE f.fact_numero=@NUMERO_DE_FACTURA
			SELECT @EMPRESA_INACTIVO =e.empr_inactivo FROM LOS_PUBERTOS.Empresa e WHERE e.empr_id=@EMPRESA_ID
			IF(@EMPRESA_INACTIVO=0)
			BEGIN
				SET @ESTADO_FACTURA = 4
			END
			ELSE
			BEGIN
				SET @ESTADO_FACTURA = 2 ;
			END
		END
		ELSE
		BEGIN
			SET @ESTADO_FACTURA = 3;
		END
	END
	ELSE
	BEGIN
		SET @ESTADO_FACTURA = 1;
	END' 
END
GO
/****** Object:  UserDefinedFunction [LOS_PUBERTOS].[comparaFecha]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[comparaFecha]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [LOS_PUBERTOS].[comparaFecha] ( @fecha1 SMALLDATETIME, @fecha2 SMALLDATETIME )
RETURNS int
AS
BEGIN
	DECLARE @res int
  IF YEAR(@fecha1) > YEAR(@fecha2)	
     SET @res = 1
  ELSE
	IF YEAR (@fecha1) < YEAR(@fecha2)	
	SET @res =  -1
  ELSE -- AÑOS IGUALES
	IF MONTH(@fecha1) > MONTH(@fecha2)	
	SET @res =  1
	ELSE
	  IF MONTH(@fecha1) < MONTH(@fecha2)	
	  SET @res =  -1
	ELSE -- AÑOS Y MESES IGUALES
	  IF DAY(@fecha1) > DAY(@fecha2)
	  SET @res =  1
	  ELSE
		IF DAY(@fecha1) < DAY(@fecha2)
		SET @res =  -1
	  ELSE -- AÑOS, MESES Y DIAS IGUALES
		SET @res = 0
	RETURN @res
END' 
END

GO
/****** Object:  Table [LOS_PUBERTOS].[CLIENTE]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[CLIENTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[CLIENTE](
	[CLIENTE_ID] [int] IDENTITY(1,1) NOT NULL,
	[CLIENTE_NOMBRE] [varchar](255) NULL,
	[CLIENTE_APELLIDO] [varchar](255) NULL,
	[CLIENTE_DNI] [int] NULL,
	[CLIENTE_MAIL] [varchar](255) NULL,
	[CLIENTE_DIRECCION] [varchar](255) NULL,
	[CLIENTE_NRO_PISO] [smallint] NULL,
	[CLIENTE_DEPTO] [char](1) NULL,
	[CLIENTE_LOCALIDAD] [varchar](15) NULL,
	[CLIENTE_NRO_TELEFONO] [int] NULL,
	[CLIENTE_COD_POSTAL] [varchar](255) NULL,
	[CLIENTE_FECHA_NACIMIENTO] [datetime] NULL,
	[CLIENTE_HABILITADO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CLIENTE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Devolucion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Devolucion]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Devolucion](
	[devo_id] [int] IDENTITY(1,1) NOT NULL,
	[devo_razon] [varchar](50) NULL,
	[devo_tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[devo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Empresa]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Empresa](
	[empr_id] [int] IDENTITY(1,1) NOT NULL,
	[empr_nombre] [varchar](50) NULL,
	[empr_direccion] [varchar](50) NULL,
	[empr_rubro] [int] NULL,
	[empr_inactivo] [bit] NULL,
	[empr_cuit] [nvarchar](50) NULL,
	[empr_fechaRendicion] [datetime] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Factura]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Factura](
	[fact_id] [int] IDENTITY(1,1) NOT NULL,
	[fact_cliente] [int] NOT NULL,
	[fact_empresa] [int] NOT NULL,
	[fact_numero] [int] NULL,
	[fact_fecha_alta] [datetime] NULL,
	[fact_fecha_vencimiento] [datetime] NULL,
	[fact_total] [float] NULL,
	[fact_inactiva] [bit] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Fd]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Fd](
	[fd_factura] [int] NOT NULL,
	[fd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[FUNCIONALIDAD]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FUNCIONALIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[FUNCIONALIDAD](
	[ID] [int] NOT NULL,
	[NOMBRE] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Item]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Item](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_factura] [int] NULL,
	[item_monto] [float] NULL,
	[item_cantidad] [int] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[MedioDePago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[MedioDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[MedioDePago](
	[medi_id] [int] IDENTITY(1,1) NOT NULL,
	[medi_nombre] [varchar](50) NULL,
 CONSTRAINT [PK_MedioDePago] PRIMARY KEY CLUSTERED 
(
	[medi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Pago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Pago](
	[pago_id] [int] IDENTITY(1,1) NOT NULL,
	[pago_fecha] [datetime] NULL,
	[pago_importe] [float] NULL,
	[pago_sucursal] [int] NULL,
	[pago_numero] [int] NULL,
	[pago_mediodepago] [int] NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[PF]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[PF](
	[pf_pago] [int] NOT NULL,
	[pf_factura] [int] NOT NULL,
	[pf_devolucion] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Rd]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Rd](
	[rd_rendicion] [int] NOT NULL,
	[rd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Rendicion]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rendicion]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Rendicion](
	[rend_id] [int] IDENTITY(1,1) NOT NULL,
	[rend_fecha] [datetime] NULL,
	[rend_importe] [float] NULL,
	[rend_numero] [int] NULL,
	[rend_porcentaje] [float] NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Rf]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rf]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Rf](
	[rf_rendicion] [int] NULL,
	[rf_factura] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[ROL]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[ROL]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[ROL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[HABILITADO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NOMBRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[ROLXFUNCIONALIDAD]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[ROLXFUNCIONALIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[ROLXFUNCIONALIDAD](
	[ROL_ID] [int] NOT NULL,
	[FUNCIONALIDAD_ID] [int] NOT NULL,
 CONSTRAINT [ROL_FUNCIONALIDAD_PK] PRIMARY KEY CLUSTERED 
(
	[ROL_ID] ASC,
	[FUNCIONALIDAD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Rubro]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rubro]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Rubro](
	[rubr_id] [int] NOT NULL,
	[rubr_nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[rubr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[Su]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Su](
	[su_usuario] [int] NOT NULL,
	[su_sucursal] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [LOS_PUBERTOS].[Sucursal]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Sucursal]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[Sucursal](
	[sucu_id] [int] IDENTITY(1,1) NOT NULL,
	[sucu_nom] [varchar](50) NULL,
	[sucu_cp] [int] NULL,
	[sucu_inactive] [bit] NULL,
	[sucu_dire] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[sucu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[USUARIO]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[USUARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[USUARIO](
	[ID] [int] NOT NULL,
	[USERNAME] [varchar](50) NULL,
	[PASS] [varchar](65) NULL,
	[HABILITADO] [bit] NULL,
	[CANT_INTENTOS_FALLIDOS] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [LOS_PUBERTOS].[USUARIOXROL]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[USUARIOXROL]') AND type in (N'U'))
BEGIN
CREATE TABLE [LOS_PUBERTOS].[USUARIOXROL](
	[USUARIO_ID] [int] NOT NULL,
	[ROL_ID] [int] NOT NULL,
 CONSTRAINT [USUARIO_ROL_PK] PRIMARY KEY CLUSTERED 
(
	[USUARIO_ID] ASC,
	[ROL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Empresa]'))
ALTER TABLE [LOS_PUBERTOS].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Rubro] FOREIGN KEY([empr_rubro])
REFERENCES [LOS_PUBERTOS].[Rubro] ([rubr_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Empresa]'))
ALTER TABLE [LOS_PUBERTOS].[Empresa] CHECK CONSTRAINT [FK_Empresa_Rubro]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_CLIENTE] FOREIGN KEY([fact_cliente])
REFERENCES [LOS_PUBERTOS].[CLIENTE] ([CLIENTE_ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura] CHECK CONSTRAINT [FK_Factura_CLIENTE]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_Empresa]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empresa] FOREIGN KEY([fact_empresa])
REFERENCES [LOS_PUBERTOS].[Empresa] ([empr_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Factura_Empresa]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Factura]'))
ALTER TABLE [LOS_PUBERTOS].[Factura] CHECK CONSTRAINT [FK_Factura_Empresa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Devolucion] FOREIGN KEY([fd_devolucion])
REFERENCES [LOS_PUBERTOS].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd] CHECK CONSTRAINT [FK_Fd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Factura] FOREIGN KEY([fd_factura])
REFERENCES [LOS_PUBERTOS].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Fd]'))
ALTER TABLE [LOS_PUBERTOS].[Fd] CHECK CONSTRAINT [FK_Fd_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Item]'))
ALTER TABLE [LOS_PUBERTOS].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura] FOREIGN KEY([item_factura])
REFERENCES [LOS_PUBERTOS].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Item]'))
ALTER TABLE [LOS_PUBERTOS].[Item] CHECK CONSTRAINT [FK_Item_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_MedioDePago] FOREIGN KEY([pago_mediodepago])
REFERENCES [LOS_PUBERTOS].[MedioDePago] ([medi_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago] CHECK CONSTRAINT [FK_Pago_MedioDePago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Sucursal] FOREIGN KEY([pago_sucursal])
REFERENCES [LOS_PUBERTOS].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Pago]'))
ALTER TABLE [LOS_PUBERTOS].[Pago] CHECK CONSTRAINT [FK_Pago_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Factura] FOREIGN KEY([pf_factura])
REFERENCES [LOS_PUBERTOS].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF] CHECK CONSTRAINT [FK_PF_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Pago] FOREIGN KEY([pf_pago])
REFERENCES [LOS_PUBERTOS].[Pago] ([pago_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[PF]'))
ALTER TABLE [LOS_PUBERTOS].[PF] CHECK CONSTRAINT [FK_PF_Pago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Devolucion] FOREIGN KEY([rd_devolucion])
REFERENCES [LOS_PUBERTOS].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd] CHECK CONSTRAINT [FK_Rd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Rendicion] FOREIGN KEY([rd_rendicion])
REFERENCES [LOS_PUBERTOS].[Rendicion] ([rend_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rd]'))
ALTER TABLE [LOS_PUBERTOS].[Rd] CHECK CONSTRAINT [FK_Rd_Rendicion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rf]'))
ALTER TABLE [LOS_PUBERTOS].[Rf]  WITH CHECK ADD  CONSTRAINT [FK_Rf_Factura] FOREIGN KEY([rf_factura])
REFERENCES [LOS_PUBERTOS].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Rf]'))
ALTER TABLE [LOS_PUBERTOS].[Rf] CHECK CONSTRAINT [FK_Rf_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su]  WITH CHECK ADD  CONSTRAINT [FK_Su_Sucursal] FOREIGN KEY([su_sucursal])
REFERENCES [LOS_PUBERTOS].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su] CHECK CONSTRAINT [FK_Su_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_USUARIO]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su]  WITH CHECK ADD  CONSTRAINT [FK_Su_USUARIO] FOREIGN KEY([su_usuario])
REFERENCES [LOS_PUBERTOS].[USUARIO] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[FK_Su_USUARIO]') AND parent_object_id = OBJECT_ID(N'[LOS_PUBERTOS].[Su]'))
ALTER TABLE [LOS_PUBERTOS].[Su] CHECK CONSTRAINT [FK_Su_USUARIO]
GO
/****** Object:  Trigger [LOS_PUBERTOS].[chequeoMailEnCliente]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Trigger [LOS_PUBERTOS].[chequeoMailEnCliente]    Script Date: domingo, 29 de octubre de 2017 22:11:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

INSERT INTO  LOS_PUBERTOS.ROL (NOMBRE,HABILITADO)
	VALUES	('Administrador',1), 
			('Cobrador',1) 
   GO
	INSERT INTO  LOS_PUBERTOS.USUARIO(ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS)
	VALUES	(1,'USER1','0a041b9462caa4a31bac3567e0b6e6fd9100787db2ab433d96f6d178cabfce90',1,0), 
			(2,'USER2','6025d18fe48abd45168528f18a82e265dd98d421a7084aa09f61b341703901a3',1,0),
			(3,'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1,0)

GO
	INSERT INTO LOS_PUBERTOS.USUARIOXROL (USUARIO_ID,ROL_ID)
	VALUES	(1,1),
			(1,2),
			(2,2),
			(3,1),
			(3,2)
GO
	INSERT INTO LOS_PUBERTOS.FUNCIONALIDAD(ID,NOMBRE)
	VALUES	(1,'ABM de Rol'),
			(2,'Login y Seguridad'),
			(3,'Registro de Usuario'),
			(4,'ABM de Cliente'),
			(5,'ABM de Empresa'),
			(6,'ABM de Sucursal'),
			(7,'ABM Facturas'),
			(8,'Registro de Pago de Facturas'),
			(9,'Rendicion de Facturas cobradas'),
			(10,'Listado Estadistico'),
			(11,'Devoluciones'),
			(12,'Devolucion Factura')
			
GO
	INSERT INTO LOS_PUBERTOS.ROLXFUNCIONALIDAD(ROL_ID,FUNCIONALIDAD_ID)
	VALUES	(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),
		(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),(2,8),(2,12),(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),(3,9),(3,10),(3,11),(3,12),(3,13)

GO
INSERT INTO LOS_PUBERTOS.CLIENTE(CLIENTE_DNI, CLIENTE_APELLIDO, CLIENTE_NOMBRE, CLIENTE_FECHA_NACIMIENTO, CLIENTE_MAIL, CLIENTE_DIRECCION, CLIENTE_COD_POSTAL, CLIENTE_HABILITADO)	
	 select [Cliente-Dni], MAX([Cliente-Apellido]), MAX([Cliente-Nombre]), MAX([Cliente-Fecha_Nac]), MAX(Cliente_Mail), MAX(Cliente_Direccion),MAX(Cliente_Codigo_Postal), 1  
		from gd_esquema.Maestra
		group by [Cliente-Dni]
GO
INSERT INTO LOS_PUBERTOS.Rubro( rubr_id, rubr_nombre) 
	SELECT Empresa_Rubro, Rubro_Descripcion
	from gd_esquema.Maestra
	GROUP BY Empresa_Rubro, Rubro_Descripcion
GO
INSERT INTO LOS_PUBERTOS.Empresa(empr_nombre, empr_cuit, empr_direccion, empr_rubro, empr_inactivo)
	select MAX(Empresa_Nombre), Empresa_Cuit, MAX(Empresa_Direccion), MAX(Empresa_Rubro), 1
	from gd_esquema.Maestra
	group by Empresa_Cuit
GO
insert into LOS_PUBERTOS.sucursal (sucu_nom, sucu_dire, sucu_cp, sucu_inactive)
	select Sucursal_Nombre, MAX(Sucursal_Dirección), MAX(Sucursal_Codigo_Postal), 1
	from gd_esquema.Maestra 
	where  Sucursal_Nombre IS NOT NULL 
	group by Sucursal_Nombre
GO
INSERT INTO LOS_PUBERTOS.SU (su_sucursal,su_usuario)
	VALUES	(1,1),
			(1,2),
			(1,3)
GO
insert into LOS_PUBERTOS.MedioDePago(medi_nombre)
	select FormaPagoDescripcion 
	from gd_esquema.Maestra 
	where FormaPagoDescripcion IS NOT NULL  
	group by FormaPagoDescripcion
GO
INSERT INTO LOS_PUBERTOS.Factura(fact_numero, fact_fecha_alta, fact_total, fact_fecha_vencimiento, fact_empresa, fact_cliente, fact_inactiva)
	select Nro_Factura, MAX(Factura_Fecha), MAX(Factura_Total), MAX(Factura_Fecha_Vencimiento), (select top 1 empr_id from LOS_PUBERTOS.empresa where empr_cuit = MAX(Empresa_Cuit)), (select top 1 CLIENTE_ID from LOS_PUBERTOS.cliente where CLIENTE_DNI = MAX([Cliente-Dni])),1
	from gd_esquema.Maestra 
	group by Nro_Factura
GO
INSERT INTO LOS_PUBERTOS.item(item_factura, item_monto, item_cantidad)	
	select (select fact_id from LOS_PUBERTOS.factura where  fact_numero = Nro_Factura), ItemFactura_Monto, ItemFactura_Cantidad 
	from gd_esquema.Maestra 
	group by Nro_Factura, ItemFactura_Monto, ItemFactura_Cantidad
	order by Nro_Factura
GO
INSERT INTO LOS_PUBERTOS.Pago(pago_numero, pago_fecha, pago_importe, pago_mediodepago, pago_sucursal)	
	select Pago_nro, MAX(Pago_Fecha), MAX(Total), (select medi_id from LOS_PUBERTOS.MedioDePago where medi_nombre = MAX(FormaPagoDescripcion)), (select sucu_id from LOS_PUBERTOS.Sucursal where sucu_nom = MAX(Sucursal_Nombre))
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Pago_nro
GO
INSERT INTO LOS_PUBERTOS.PF(pf_factura, pf_pago)	
	select (select fact_id from LOS_PUBERTOS.factura where  fact_numero = Nro_Factura), (select pago_id from LOS_PUBERTOS.Pago where pago_numero = Pago_nro) 
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Nro_Factura, Pago_nro
GO
INSERT INTO LOS_PUBERTOS.Rendicion(rend_numero, rend_fecha, rend_importe)	
	select Rendicion_nro, MAX(Rendicion_Fecha), MAX(ItemRendicion_importe)
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Rendicion_Nro
GO
INSERT INTO LOS_PUBERTOS.Rf (rf_factura,  rf_rendicion)
	select (select fact_id from LOS_PUBERTOS.factura where  fact_numero = Nro_Factura),(select top 1 rend_id from LOS_PUBERTOS.Rendicion where rend_numero = Rendicion_Nro) 
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Nro_Factura, Rendicion_Nro
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[chequeoMailEnCliente]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [LOS_PUBERTOS].[chequeoMailEnCliente] ON [LOS_PUBERTOS].[CLIENTE] INSTEAD OF INSERT
AS
DECLARE @nombre varchar(255)
DECLARE @apellido varchar(255)
DECLARE @dni int
DECLARE @mail varchar(255)
DECLARE @direccion varchar(255)
DECLARE @NROPISO smallint
DECLARE @DEPTO char(1)
DECLARE @localidad varchar(255)
declare @telefono int
declare @cp varchar(255)
declare @fechaN datetime



select  @nombre=cliente_nombre, @apellido=CLIENTE_APELLIDO,
 @dni=CLIENTE_DNI, @mail= CLIENTE_MAIL, @direccion=CLIENTE_DIRECCION, 
 @NROPISO=CLIENTE_NRO_PISO , @DEPTO=CLIENTE_DEPTO, 
 @localidad=CLIENTE_LOCALIDAD, @telefono=CLIENTE_NRO_TELEFONO, @cp=CLIENTE_COD_POSTAL, @fechaN=CLIENTE_FECHA_NACIMIENTO
FROM inserted

IF (exists (SELECT top 1 CLIENTE_MAIL 
			from LOS_PUBERTOS.Cliente
			WHERE CLIENTE_MAIL = @mail
	))

	BEGIN
			RAISERROR (''MAIL REPETIDO '',16,12) 
			ROLLBACK TRANSACTION
	END
ELSE 
INSERT INTO [LOS_PUBERTOS].[CLIENTE]
           ([CLIENTE_NOMBRE]
           ,[CLIENTE_APELLIDO]
           ,[CLIENTE_DNI]
           ,[CLIENTE_MAIL]
           ,[CLIENTE_DIRECCION]
           ,[CLIENTE_NRO_PISO]
           ,[CLIENTE_DEPTO]
           ,[CLIENTE_LOCALIDAD]
           ,[CLIENTE_NRO_TELEFONO]
           ,[CLIENTE_COD_POSTAL]
           ,[CLIENTE_FECHA_NACIMIENTO]
           ,[CLIENTE_HABILITADO])
	SELECT CLIENTE_NOMBRE
           ,CLIENTE_APELLIDO
           ,CLIENTE_DNI
           ,CLIENTE_MAIL
           ,CLIENTE_DIRECCION
           ,CLIENTE_NRO_PISO
           ,CLIENTE_DEPTO
           ,CLIENTE_LOCALIDAD
           ,CLIENTE_NRO_TELEFONO
           ,CLIENTE_COD_POSTAL
           ,CLIENTE_FECHA_NACIMIENTO
           ,CLIENTE_HABILITADO
      FROM inserted
' 
GO

/****** Object:  Trigger [LOS_PUBERTOS].[controlDePago]    Script Date: jueves, 02 de noviembre de 2017 17:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[LOS_PUBERTOS].[controlDePago]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [LOS_PUBERTOS].[controlDePago] ON [LOS_PUBERTOS].[Pago] INSTEAD OF INSERT
AS

DECLARE @pago_fecha datetime
DECLARE @pago_importe float
DECLARE @pago_sucursal int
DECLARE @pago_numero int
DECLARE @pago_mediodepago int
DECLARE @FechaActual date
DECLARE @FechaPago date

SELECT @pago_fecha=pago_fecha ,@pago_importe=pago_importe ,@pago_sucursal=pago_sucursal ,@pago_numero=pago_numero ,@pago_mediodepago=pago_mediodepago
FROM inserted

select @fechaActual = (convert(date, GETDATE() ,103));
select @fechaPago = (convert(date, @pago_fecha ,103));

IF ((@pago_importe>0))

			BEGIN
				INSERT INTO [LOS_PUBERTOS].[Pago]
				   ([pago_fecha]
				   ,[pago_importe]
				   ,[pago_sucursal]
				   ,[pago_numero]
				   ,[pago_mediodepago])
			 VALUES
				  ( @pago_fecha, @pago_importe, @pago_sucursal, @pago_numero, @pago_mediodepago)

			END


ELSE 
begin
			RAISERROR (''los campos fecha y monto son incorrectos'',16,12) 
			ROLLBACK TRANSACTION
end

' 
GO

/****** Object:  Trigger [LOS_PUBERTOS].[chequeoCuitEmpresa]    Script Date: 4/11/2017 19:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [LOS_PUBERTOS].[chequeoCuitEmpresa] ON [LOS_PUBERTOS].[Empresa] INSTEAD OF INSERT
AS
DECLARE @cuit nvarchar(50)
DECLARE @nombre varchar(50)
DECLARE @direccion nvarchar(50)
DECLARE @rubro INT
DECLARE @inactivo int
DECLARE @fecha datetime


select  @cuit=empr_cuit, @direccion=empr_direccion, @nombre=empr_nombre, @rubro=empr_rubro, @inactivo=empr_inactivo, @fecha=empr_fechaRendicion
FROM inserted

IF (exists (SELECT top 1 empr_cuit 
			from LOS_PUBERTOS.Empresa
			WHERE @cuit=empr_cuit
	))

	BEGIN
			RAISERROR ('error repeticion de cuit',16,@cuit) 
			ROLLBACK TRANSACTION
	END
ELSE 
	insert into LOS_PUBERTOS.Empresa (empr_nombre, empr_direccion, empr_cuit, empr_rubro, empr_inactivo, empr_fechaRendicion)
	 SELECT empr_nombre, empr_direccion, empr_cuit, empr_rubro,empr_inactivo, empr_fechaRendicion
      FROM inserted


GO
/****** Object:  Trigger [LOS_PUBERTOS].[modificacionEmpresa]    Script Date: 4/11/2017 19:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [LOS_PUBERTOS].[modificacionEmpresa] ON [LOS_PUBERTOS].[Empresa] INSTEAD OF UPDATE
AS
DECLARE @id int
DECLARE @nombre varchar(50)
DECLARE @direccion varchar(50)
DECLARE @rubro int
DECLARE @inactivo bit
DECLARE @cuit nvarchar(50)
DECLARE @fecha datetime

select @id=empr_id, @rubro=empr_rubro,  @inactivo=empr_inactivo, @cuit=empr_cuit, @fecha=empr_fechaRendicion , @direccion=empr_direccion, @nombre=empr_nombre
FROM inserted


IF (UPDATE(empr_inactivo) or UPDATE(empr_cuit))

BEGIN
	IF (exists (SELECT top 1 f.fact_id
				from LOS_PUBERTOS.Factura f
				WHERE @id=fact_empresa AND f.fact_id NOT IN (select rf_factura from LOS_PUBERTOS.Rf ) ) AND @inactivo=0)
				
							BEGIN

							RAISERROR('la empresa tiene RENDICIONES pendientes',16,217) WITH SETERROR   

							END
	ELSE
					
				IF (exists (SELECT top 1 empr_cuit 
							from LOS_PUBERTOS.Empresa
							WHERE @cuit=empr_cuit and empr_id<>@id))

									BEGIN
											RAISERROR ('error repeticion de cuit',16,12) 
											ROLLBACK TRANSACTION
									END	
				ELSE
					
									update [LOS_PUBERTOS].[Empresa]
									set [empr_nombre]=@nombre,[empr_direccion]=@direccion, [empr_rubro]=@rubro, [empr_inactivo]=@inactivo, [empr_cuit]=@cuit, [empr_fechaRendicion]=@fecha
									where empr_id=@id
					
end

			
ELSE
	
			update [LOS_PUBERTOS].[Empresa]
			set [empr_nombre]=@nombre,[empr_direccion]=@direccion, [empr_rubro]=@rubro, [empr_inactivo]=@inactivo, [empr_cuit]=@cuit, [empr_fechaRendicion]=@fecha
			where empr_id=@id
	


GO

/****** Object:  Trigger [LOS_PUBERTOS].[cheuqueoCPdeSucursales]    Script Date: 4/11/2017 19:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [LOS_PUBERTOS].[cheuqueoCPdeSucursales] ON [LOS_PUBERTOS].[Sucursal] INSTEAD OF INSERT
AS
DECLARE @codigoPostal int
DECLARE @nombre varchar(50)
DECLARE @direccion nvarchar(max)
DECLARE @inactivo bit
DECLARE @id int


select  @id = sucu_id, @codigoPostal=sucu_cp, @direccion=sucu_dire, @nombre=sucu_nom, @inactivo=sucu_inactive
FROM inserted

IF (exists (SELECT top 1 sucu_cp 
			from LOS_PUBERTOS.Sucursal
			WHERE sucu_cp = @codigoPostal
	))

	BEGIN
			RAISERROR ('error duplicacion de codigo postal',16,12) 
			ROLLBACK TRANSACTION
	END
ELSE 
	insert into LOS_PUBERTOS.sucursal (sucu_nom, sucu_dire, sucu_cp, sucu_inactive)
	VALUES (@nombre, @direccion, @codigoPostal, @inactivo)

GO
/****** Object:  Trigger [LOS_PUBERTOS].[cheuqueoSucursalModificacion]    Script Date: 4/11/2017 19:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [LOS_PUBERTOS].[cheuqueoSucursalModificacion] ON [LOS_PUBERTOS].[Sucursal] INSTEAD OF UPDATE
AS
DECLARE @codigoPostal int
DECLARE @nombre varchar(50)
DECLARE @direccion nvarchar(max)
DECLARE @inactivo bit
DECLARE @id int


select  @id = sucu_id, @codigoPostal=sucu_cp, @direccion=sucu_dire, @nombre=sucu_nom, @inactivo=sucu_inactive
FROM inserted

IF UPDATE(sucu_cp)
				IF (exists (SELECT top 1 sucu_cp 
							from LOS_PUBERTOS.Sucursal
							WHERE sucu_cp = @codigoPostal and sucu_id<>@id
					))

									BEGIN
											RAISERROR ('error duplicacion de codigo postal',16,12) 
											ROLLBACK TRANSACTION
									END
				ELSE 
									UPDATE  LOS_PUBERTOS.sucursal 
									SET sucu_nom=@nombre, sucu_dire=@direccion, sucu_cp=@codigoPostal,sucu_inactive=@inactivo
									WHERE sucu_id=@id
				
ELSE
					UPDATE  LOS_PUBERTOS.sucursal 
					SET sucu_nom=@nombre, sucu_dire=@direccion, sucu_cp=@codigoPostal,sucu_inactive=@inactivo
					WHERE sucu_id=@id	
GO


