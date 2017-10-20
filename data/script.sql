USE [GD2C2017]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_USUARIO_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL] DROP CONSTRAINT [FK_USUARIO_ROL]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL] DROP CONSTRAINT [FK_ROL_USUARIO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Su]'))
ALTER TABLE [NO_TENGO_IDEA].[Su] DROP CONSTRAINT [FK_Su_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_FUNCIONALIDAD]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD] DROP CONSTRAINT [FK_ROL_FUNCIONALIDAD]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_FUNCIONALIDAD_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD] DROP CONSTRAINT [FK_FUNCIONALIDAD_ROL]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf] DROP CONSTRAINT [FK_Rf_Rendicion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf] DROP CONSTRAINT [FK_Rf_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd] DROP CONSTRAINT [FK_Rd_Rendicion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd] DROP CONSTRAINT [FK_Rd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF] DROP CONSTRAINT [FK_PF_Pago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF] DROP CONSTRAINT [FK_PF_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago] DROP CONSTRAINT [FK_Pago_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago] DROP CONSTRAINT [FK_Pago_MedioDePago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Item]'))
ALTER TABLE [NO_TENGO_IDEA].[Item] DROP CONSTRAINT [FK_Item_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd] DROP CONSTRAINT [FK_Fd_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd] DROP CONSTRAINT [FK_Fd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Factura]'))
ALTER TABLE [NO_TENGO_IDEA].[Factura] DROP CONSTRAINT [FK_Factura_CLIENTE]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Empresa]'))
ALTER TABLE [NO_TENGO_IDEA].[Empresa] DROP CONSTRAINT [FK_Empresa_Rubro]
GO
/****** Object:  Table [NO_TENGO_IDEA].[USUARIOXROL]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[USUARIOXROL]
GO
/****** Object:  Table [NO_TENGO_IDEA].[USUARIO]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIO]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[USUARIO]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Sucursal]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Sucursal]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Sucursal]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Su]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Su]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Su]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rubro]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rubro]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Rubro]
GO
/****** Object:  Table [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]
GO
/****** Object:  Table [NO_TENGO_IDEA].[ROL]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROL]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[ROL]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rf]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Rf]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rendicion]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rendicion]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Rendicion]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rd]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Rd]
GO
/****** Object:  Table [NO_TENGO_IDEA].[PF]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[PF]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Pago]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Pago]
GO
/****** Object:  Table [NO_TENGO_IDEA].[MedioDePago]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[MedioDePago]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[MedioDePago]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Item]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Item]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Item]
GO
/****** Object:  Table [NO_TENGO_IDEA].[FUNCIONALIDAD]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FUNCIONALIDAD]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[FUNCIONALIDAD]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Fd]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Fd]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Factura]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Factura]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Factura]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Empresa]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Empresa]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Empresa]
GO
/****** Object:  Table [NO_TENGO_IDEA].[Devolucion]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Devolucion]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[Devolucion]
GO
/****** Object:  Table [NO_TENGO_IDEA].[CLIENTE]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[CLIENTE]') AND type in (N'U'))
DROP TABLE [NO_TENGO_IDEA].[CLIENTE]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_empresaconMayorMontoRendid]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[sp_empresaconMayorMontoRendido]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[sp_empresaconMayorMontoRendido]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_porcentajeClienteMayorPorcPagos]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[sp_porcentajeClientesMayorPorcPagos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[sp_porcentajeClientesMayorPorcPagos]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_clienteConMasPagos]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[sp_clienteConMasPagos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[sp_clienteConMasPagos]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]    Script Date: 14/10/2017 19:59:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]
GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_inabilitarEmpresa]    Script Date: 19/10/2017 22:37:06 ******/
DROP PROCEDURE [NO_TENGO_IDEA].[sp_inabilitarEmpresa]
GO
/****** Object:  Schema [NO_TENGO_IDEA]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'NO_TENGO_IDEA')
DROP SCHEMA [NO_TENGO_IDEA]
GO
/****** Object:  Schema [NO_TENGO_IDEA]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'NO_TENGO_IDEA')
EXEC sys.sp_executesql N'CREATE SCHEMA [NO_TENGO_IDEA]'

GO
/****** Object:  StoredProcedure [NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
	/*devuelve el resultado de inicio de session.
	   1-No existe el usuario
	   2-Existe el usuario, no puede iniciar sesion por la cant de intentos fallidos
	   3-El usuario pudo iniciar sesion
	   4-El usuario ingreso mal la password, incremente la cant de intento fallidos 
	   */
	CREATE PROCEDURE [NO_TENGO_IDEA].[SP_INICIAR_SESION_DE_USUARIO]
			@USERNAME varchar(50),
			@PASSWORD varchar(50) ,
			@ESTADO_INICIO INT OUTPUT
	AS
	DECLARE   @CANT_INTENTOS_FALLIDOS TINYINT
	IF (EXISTS(SELECT * FROM NO_TENGO_IDEA.USUARIO WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME))
	BEGIN
		SELECT @CANT_INTENTOS_FALLIDOS = CANT_INTENTOS_FALLIDOS FROM NO_TENGO_IDEA.USUARIO WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME
		IF(@CANT_INTENTOS_FALLIDOS < 3)
		BEGIN
			IF (EXISTS(SELECT * FROM NO_TENGO_IDEA.USUARIO WHERE NO_TENGO_IDEA.USUARIO.USERNAME = USERNAME AND NO_TENGO_IDEA.USUARIO.PASS = @PASSWORD))
			BEGIN
				SET @ESTADO_INICIO = 3
				UPDATE NO_TENGO_IDEA.USUARIO SET CANT_INTENTOS_FALLIDOS = 0 WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME
			END
			ELSE
			BEGIN
				SET @ESTADO_INICIO = 4
				UPDATE NO_TENGO_IDEA.USUARIO SET CANT_INTENTOS_FALLIDOS=CANT_INTENTOS_FALLIDOS + 1 WHERE NO_TENGO_IDEA.USUARIO.USERNAME = @USERNAME 
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
			CREATE TABLE NO_TENGO_IDEA.CLIENTE 
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
	
	*/

	
' 
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[CLIENTE]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[CLIENTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[CLIENTE](
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
/****** Object:  Table [NO_TENGO_IDEA].[Devolucion]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Devolucion]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Devolucion](
	[devo_id] [int] NOT NULL,
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
/****** Object:  Table [NO_TENGO_IDEA].[Empresa]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Empresa](
	[empr_id] [int] IDENTITY(1,1) NOT NULL,
	[empr_nombre] [varchar](50) NULL,
	[empr_direccion] [varchar](50) NULL,
	[empr_rubro] [int] NULL,
	[empr_inactivo] [bit] NULL,
	[empr_cuit] [nvarchar](50) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NO_TENGO_IDEA].[Factura]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Factura]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Factura](
	[fact_id] [int] IDENTITY(1,1) NOT NULL,
	[fact_cliente] [int] NOT NULL,
	[fact_empresa] [int] NOT NULL,
	[fact_numero] [int] NULL,
	[fact_fecha_alta] [datetime] NULL,
	[fact_fecha_vencimiento] [datetime] NULL,
	[fact_total] [float] NULL,
	[fact_devolucion] [int] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[Fd]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Fd](
	[fd_factura] [int] NOT NULL,
	[fd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[FUNCIONALIDAD]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FUNCIONALIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[FUNCIONALIDAD](
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
/****** Object:  Table [NO_TENGO_IDEA].[Item]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Item](
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
/****** Object:  Table [NO_TENGO_IDEA].[MedioDePago]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[MedioDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[MedioDePago](
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
/****** Object:  Table [NO_TENGO_IDEA].[Pago]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Pago](
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
/****** Object:  Table [NO_TENGO_IDEA].[PF]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[PF](
	[pf_pago] [int] NOT NULL,
	[pf_factura] [int] NOT NULL,
	[pf_devolucion] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rd]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Rd](
	[rd_rendicion] [int] NOT NULL,
	[rd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rendicion]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rendicion]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Rendicion](
	[rend_id] [int] IDENTITY(1,1) NOT NULL,
	[rend_fecha] [datetime] NULL,
	[rend_importe] [float] NULL,
	[rend_numero] [int] NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[Rf]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Rf](
	[rf_rendicion] [int] NULL,
	[rf_factura] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[ROL]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROL]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[ROL](
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
/****** Object:  Table [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD](
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
/****** Object:  Table [NO_TENGO_IDEA].[Rubro]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rubro]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Rubro](
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
/****** Object:  Table [NO_TENGO_IDEA].[Su]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Su]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Su](
	[su_usuario] [int] NOT NULL,
	[su_sucursal] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [NO_TENGO_IDEA].[Sucursal]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Sucursal]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[Sucursal](
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
/****** Object:  Table [NO_TENGO_IDEA].[USUARIO]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[USUARIO](
	[ID] [int] NOT NULL,
	[USERNAME] [varchar](50) NULL,
	[PASS] [varchar](50) NULL,
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
/****** Object:  Table [NO_TENGO_IDEA].[USUARIOXROL]    Script Date: sábado, 14 de octubre de 2017 16:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]') AND type in (N'U'))
BEGIN
CREATE TABLE [NO_TENGO_IDEA].[USUARIOXROL](
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
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Empresa]'))
ALTER TABLE [NO_TENGO_IDEA].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Rubro] FOREIGN KEY([empr_rubro])
REFERENCES [NO_TENGO_IDEA].[Rubro] ([rubr_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Empresa]'))
ALTER TABLE [NO_TENGO_IDEA].[Empresa] CHECK CONSTRAINT [FK_Empresa_Rubro]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Factura]'))
ALTER TABLE [NO_TENGO_IDEA].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_CLIENTE] FOREIGN KEY([fact_cliente])
REFERENCES [NO_TENGO_IDEA].[CLIENTE] ([CLIENTE_ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Factura_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Factura]'))
ALTER TABLE [NO_TENGO_IDEA].[Factura] CHECK CONSTRAINT [FK_Factura_CLIENTE]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Devolucion] FOREIGN KEY([fd_devolucion])
REFERENCES [NO_TENGO_IDEA].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd] CHECK CONSTRAINT [FK_Fd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Factura] FOREIGN KEY([fd_factura])
REFERENCES [NO_TENGO_IDEA].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Fd]'))
ALTER TABLE [NO_TENGO_IDEA].[Fd] CHECK CONSTRAINT [FK_Fd_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Item]'))
ALTER TABLE [NO_TENGO_IDEA].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura] FOREIGN KEY([item_factura])
REFERENCES [NO_TENGO_IDEA].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Item]'))
ALTER TABLE [NO_TENGO_IDEA].[Item] CHECK CONSTRAINT [FK_Item_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_MedioDePago] FOREIGN KEY([pago_mediodepago])
REFERENCES [NO_TENGO_IDEA].[MedioDePago] ([medi_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_MedioDePago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago] CHECK CONSTRAINT [FK_Pago_MedioDePago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Sucursal] FOREIGN KEY([pago_sucursal])
REFERENCES [NO_TENGO_IDEA].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Pago]'))
ALTER TABLE [NO_TENGO_IDEA].[Pago] CHECK CONSTRAINT [FK_Pago_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Factura] FOREIGN KEY([pf_factura])
REFERENCES [NO_TENGO_IDEA].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF] CHECK CONSTRAINT [FK_PF_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Pago] FOREIGN KEY([pf_pago])
REFERENCES [NO_TENGO_IDEA].[Pago] ([pago_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[PF]'))
ALTER TABLE [NO_TENGO_IDEA].[PF] CHECK CONSTRAINT [FK_PF_Pago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Devolucion] FOREIGN KEY([rd_devolucion])
REFERENCES [NO_TENGO_IDEA].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd] CHECK CONSTRAINT [FK_Rd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Rendicion] FOREIGN KEY([rd_rendicion])
REFERENCES [NO_TENGO_IDEA].[Rendicion] ([rend_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rd]'))
ALTER TABLE [NO_TENGO_IDEA].[Rd] CHECK CONSTRAINT [FK_Rd_Rendicion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf]  WITH CHECK ADD  CONSTRAINT [FK_Rf_Factura] FOREIGN KEY([rf_factura])
REFERENCES [NO_TENGO_IDEA].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf] CHECK CONSTRAINT [FK_Rf_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf]  WITH CHECK ADD  CONSTRAINT [FK_Rf_Rendicion] FOREIGN KEY([rf_rendicion])
REFERENCES [NO_TENGO_IDEA].[Rendicion] ([rend_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Rf]'))
ALTER TABLE [NO_TENGO_IDEA].[Rf] CHECK CONSTRAINT [FK_Rf_Rendicion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_FUNCIONALIDAD_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]  WITH CHECK ADD  CONSTRAINT [FK_FUNCIONALIDAD_ROL] FOREIGN KEY([FUNCIONALIDAD_ID])
REFERENCES [NO_TENGO_IDEA].[FUNCIONALIDAD] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_FUNCIONALIDAD_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD] CHECK CONSTRAINT [FK_FUNCIONALIDAD_ROL]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_FUNCIONALIDAD]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]  WITH CHECK ADD  CONSTRAINT [FK_ROL_FUNCIONALIDAD] FOREIGN KEY([ROL_ID])
REFERENCES [NO_TENGO_IDEA].[ROL] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_FUNCIONALIDAD]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[ROLXFUNCIONALIDAD]'))
ALTER TABLE [NO_TENGO_IDEA].[ROLXFUNCIONALIDAD] CHECK CONSTRAINT [FK_ROL_FUNCIONALIDAD]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Su]'))
ALTER TABLE [NO_TENGO_IDEA].[Su]  WITH CHECK ADD  CONSTRAINT [FK_Su_Sucursal] FOREIGN KEY([su_sucursal])
REFERENCES [NO_TENGO_IDEA].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[Su]'))
ALTER TABLE [NO_TENGO_IDEA].[Su] CHECK CONSTRAINT [FK_Su_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL]  WITH CHECK ADD  CONSTRAINT [FK_ROL_USUARIO] FOREIGN KEY([ROL_ID])
REFERENCES [NO_TENGO_IDEA].[ROL] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_ROL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL] CHECK CONSTRAINT [FK_ROL_USUARIO]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_USUARIO_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY([USUARIO_ID])
REFERENCES [NO_TENGO_IDEA].[USUARIO] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[FK_USUARIO_ROL]') AND parent_object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[USUARIOXROL]'))
ALTER TABLE [NO_TENGO_IDEA].[USUARIOXROL] CHECK CONSTRAINT [FK_USUARIO_ROL]
GO
INSERT INTO  NO_TENGO_IDEA.ROL (NOMBRE,HABILITADO)
	VALUES	('Administrador',1), 
			('Cobrador',1) 
   GO
	INSERT INTO  NO_TENGO_IDEA.USUARIO(ID,USERNAME,PASS,HABILITADO,CANT_INTENTOS_FALLIDOS)
	VALUES	(1,'USER1','USER1',1,0), 
			(2,'USER2','USER2',1,0)

GO
	INSERT INTO NO_TENGO_IDEA.USUARIOXROL (USUARIO_ID,ROL_ID)
	VALUES	(1,1),
			(1,2),
			(2,2)
GO
	INSERT INTO NO_TENGO_IDEA.FUNCIONALIDAD(ID,NOMBRE)
	VALUES	(1,'ABM de Rol'),
			(2,'Login y Seguridad'),
			(3,'Registro de Usuario'),
			(4,'ABM de Cliente'),
			(5,'ABM de Empresa'),
			(6,'ABM de Sucursal'),
			(7,'ABM Facturas'),
			(8,'Registro de Pago de Facturas'),
			(9,'Rendicion de Facturas cobradas'),
			(10,'Listado Estadistico')

GO
	INSERT INTO NO_TENGO_IDEA.ROLXFUNCIONALIDAD(ROL_ID,FUNCIONALIDAD_ID)
	VALUES	(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),
		(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7)

GO
INSERT INTO NO_TENGO_IDEA.CLIENTE(CLIENTE_DNI, CLIENTE_APELLIDO, CLIENTE_NOMBRE, CLIENTE_FECHA_NACIMIENTO, CLIENTE_MAIL, CLIENTE_DIRECCION, CLIENTE_COD_POSTAL, CLIENTE_HABILITADO)	
	 select [Cliente-Dni], MAX([Cliente-Apellido]), MAX([Cliente-Nombre]), MAX([Cliente-Fecha_Nac]), MAX(Cliente_Mail), MAX(Cliente_Direccion),MAX(Cliente_Codigo_Postal), 1  
		from gd_esquema.Maestra
		group by [Cliente-Dni]
GO
INSERT INTO NO_TENGO_IDEA.Rubro( rubr_id, rubr_nombre) 
	SELECT Empresa_Rubro, Rubro_Descripcion
	from gd_esquema.Maestra
	GROUP BY Empresa_Rubro, Rubro_Descripcion
GO
INSERT INTO NO_TENGO_IDEA.Empresa(empr_nombre, empr_cuit, empr_direccion, empr_rubro, empr_inactivo)
	select MAX(Empresa_Nombre), Empresa_Cuit, MAX(Empresa_Direccion), MAX(Empresa_Rubro), 0
	from gd_esquema.Maestra
	group by Empresa_Cuit
GO
insert into NO_TENGO_IDEA.sucursal (sucu_nom, sucu_dire, sucu_cp)
	select Sucursal_Nombre, MAX(Sucursal_Dirección), MAX(Sucursal_Codigo_Postal) 
	from gd_esquema.Maestra 
	where  Sucursal_Nombre IS NOT NULL 
	group by Sucursal_Nombre
GO
insert into NO_TENGO_IDEA.MedioDePago(medi_nombre)
	select FormaPagoDescripcion 
	from gd_esquema.Maestra 
	where FormaPagoDescripcion IS NOT NULL  
	group by FormaPagoDescripcion
GO
INSERT INTO NO_TENGO_IDEA.Factura(fact_numero, fact_fecha_alta, fact_total, fact_fecha_vencimiento, fact_empresa, fact_cliente)
	select Nro_Factura, MAX(Factura_Fecha), MAX(Factura_Total), MAX(Factura_Fecha_Vencimiento), (select top 1 empr_id from NO_TENGO_IDEA.empresa where empr_cuit = MAX(Empresa_Cuit)), (select top 1 CLIENTE_ID from NO_TENGO_IDEA.cliente where CLIENTE_DNI = MAX([Cliente-Dni])) 
	from gd_esquema.Maestra 
	group by Nro_Factura
GO
INSERT INTO NO_TENGO_IDEA.item(item_factura, item_monto, item_cantidad)	
	select (select fact_id from NO_TENGO_IDEA.factura where  fact_numero = Nro_Factura), ItemFactura_Monto, ItemFactura_Cantidad 
	from gd_esquema.Maestra 
	group by Nro_Factura, ItemFactura_Monto, ItemFactura_Cantidad
	order by Nro_Factura
GO
INSERT INTO NO_TENGO_IDEA.Pago(pago_numero, pago_fecha, pago_importe, pago_mediodepago, pago_sucursal)	
	select Pago_nro, MAX(Pago_Fecha), MAX(Total), (select medi_id from NO_TENGO_IDEA.MedioDePago where medi_nombre = MAX(FormaPagoDescripcion)), (select sucu_id from NO_TENGO_IDEA.Sucursal where sucu_nom = MAX(Sucursal_Nombre))
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Pago_nro
GO
INSERT INTO NO_TENGO_IDEA.PF(pf_factura, pf_pago)	
	select (select fact_id from NO_TENGO_IDEA.factura where  fact_numero = Nro_Factura), (select pago_id from NO_TENGO_IDEA.Pago where pago_numero = Pago_nro) 
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Nro_Factura, Pago_nro
GO
INSERT INTO NO_TENGO_IDEA.Rendicion(rend_numero, rend_fecha, rend_importe)	
	select Rendicion_nro, MAX(Rendicion_Fecha), MAX(ItemRendicion_importe)
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Rendicion_Nro
GO
INSERT INTO NO_TENGO_IDEA.Rf (rf_factura,  rf_rendicion)
	select (select fact_id from NO_TENGO_IDEA.factura where  fact_numero = Nro_Factura),(select top 1 rend_id from NO_TENGO_IDEA.Rendicion where rend_numero = Rendicion_Nro) 
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Nro_Factura, Rendicion_Nro
GO

--------------------------------------------------------------------------------------------------------------------------------
----------------------------------Validacion de codigo postal de sucursal repeditos.-------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------


CREATE TRIGGER cheuqueoCPdeSucursales ON NO_TENGO_IDEA.Sucursal INSTEAD OF INSERT
AS
DECLARE @codigoPostal int
DECLARE @nombre varchar(50)
DECLARE @direccion nvarchar(max)


select  @codigoPostal=sucu_cp, @direccion=sucu_dire, @nombre=sucu_nom
FROM inserted

IF (exists (SELECT top 1 sucu_cp 
			from NO_TENGO_IDEA.Sucursal
			WHERE sucu_cp = @codigoPostal
	))

	BEGIN
			RAISERROR ('error',16,@codigoPostal) 
			ROLLBACK TRANSACTION
	END
ELSE 
	insert into NO_TENGO_IDEA.sucursal (sucu_nom, sucu_dire, sucu_cp)
	VALUES (@nombre, @direccion, @codigoPostal)
GO

---------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------controlar que no ingrese empresa con el mismo cuit-------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------

CREATE TRIGGER chequeoCuitEmpresa ON NO_TENGO_IDEA.Empresa INSTEAD OF INSERT
AS
DECLARE @cuit nvarchar(50)
DECLARE @nombre varchar(50)
DECLARE @direccion nvarchar(50)
DECLARE @rubro INT


select  @cuit=empr_cuit, @direccion=empr_direccion, @nombre=empr_nombre, @rubro=empr_rubro
FROM inserted

IF (exists (SELECT top 1 empr_cuit 
			from NO_TENGO_IDEA.Empresa
			WHERE @cuit=empr_cuit
	))

	BEGIN
			RAISERROR ('error repeticion de cuit',16,@cuit) 
			ROLLBACK TRANSACTION
	END
ELSE 
	insert into NO_TENGO_IDEA.Empresa (empr_nombre, empr_direccion, empr_cuit, empr_rubro)
	 SELECT empr_nombre, empr_direccion, empr_cuit, empr_rubro
      FROM inserted

go
	  
 --------------------------------------------------------------------------------------------------------------------------------
----------------------------------Validacion de mails en clientes.-------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------


CREATE TRIGGER chequeoMailEnCliente ON NO_TENGO_IDEA.Cliente INSTEAD OF INSERT
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
			from NO_TENGO_IDEA.Cliente
			WHERE CLIENTE_MAIL = @mail
	))

	BEGIN
			RAISERROR ('MAIL REPETIDO ',16,12) 
			ROLLBACK TRANSACTION
	END
ELSE 
INSERT INTO [NO_TENGO_IDEA].[CLIENTE]
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
GO   


--------------------------------------------------------------------------------------------------------------------------------------
-----------lista estadistico----------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------


--------------------------------------------------------------------------------------------------------------------------------------
----------- top 5 de CLIENTES CON MAS PAGOS----------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE NO_TENGO_IDEA.sp_clienteConMasPagos   
    @fecha datetime,   
    @trimestre int
AS  
SELECT TOP 5 CLIENTE_ID , CLIENTE_NOMBRE, CLIENTE_APELLIDO , COUNT(pago_id) CANTIDAD
FROM NO_TENGO_IDEA.CLIENTE C, NO_TENGO_IDEA.Factura f, NO_TENGO_IDEA.Pago p, NO_TENGO_IDEA.PF pf
where fact_cliente=CLIENTE_ID AND fact_id=pf_factura AND pf_pago=pago_id AND YEAR(pago_fecha)=@fecha AND DATEPART ( QUARTER , pago_fecha )= @trimestre
GROUP BY CLIENTE_ID , CLIENTE_NOMBRE, CLIENTE_APELLIDO 
order by COUNT(pago_id) desc 
go




--------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------Empresas con mayor monto rendido.--------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE NO_TENGO_IDEA.sp_empresaconMayorMontoRendido   
    @fecha datetime,   
    @trimestre int
AS  
SELECT TOP 5 empr_id , empr_nombre, SUM(rend_importe) MONTO
FROM NO_TENGO_IDEA.Empresa E, NO_TENGO_IDEA.Rendicion, NO_TENGO_IDEA.Factura, NO_TENGO_IDEA.Rf
where empr_id=fact_empresa AND fact_id=rf_factura and rf_rendicion=rend_id  AND YEAR(rend_fecha)=@fecha AND DATEPART ( QUARTER , rend_fecha )= @trimestre
GROUP BY  empr_id , empr_nombre
order by SUM(rend_importe) desc 
go

-----------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------Porcentaje de facturas cobradas por empresa.---------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]    Script Date: 14/10/2017 19:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [NO_TENGO_IDEA].[sp_porcentajeFacturaCobradasPorEmpresa]
    @fecha datetime,   
    @trimestre int
AS  
SELECT TOP 5 COUNT(fact_id)*100/(SELECT COUNT (fact_id) 
								FROM NO_TENGO_IDEA.Empresa , NO_TENGO_IDEA.Factura 
								WHERE fact_empresa=empr_id AND empr_id=E.empr_id AND YEAR(fact_fecha_alta)= @fecha AND DATEPART ( QUARTER , fact_fecha_alta )= @trimestre
								GROUP BY empr_id) PORCENTAJE, empr_id
FROM NO_TENGO_IDEA.Empresa E, NO_TENGO_IDEA.Factura f
WHERE F.fact_empresa=E.empr_id AND fact_id in (Select rf_factura FROM RF) AND YEAR(fact_fecha_alta)= @fecha AND DATEPART ( QUARTER , fact_fecha_alta )= @trimestre
GROUP BY empr_id 
ORDER by PORCENTAJE DESC' 
END
go
 

--------------------------------------------------------------------------------------------------------------------
------------------------------Clientes con mayor porcentaje de facturas pagadas (clientes cumplidores).-------------
--------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE NO_TENGO_IDEA.sp_porcentajeClientesMayorPorcPagos 
    @fecha datetime,   
    @trimestre int
AS
SELECT TOP 5 COUNT(fact_id)*100/(SELECT COUNT (fact_id) 
								FROM NO_TENGO_IDEA.Cliente , NO_TENGO_IDEA.Factura, Pago
								WHERE fact_cliente=CLIENTE_ID AND CLIENTE_ID=C.CLIENTE_ID AND YEAR(fact_fecha_alta)=@fecha AND DATEPART ( QUARTER , fact_fecha_alta )= @trimestre
								GROUP BY CLIENTE_ID) PORCENTAJE, CLIENTE_ID, CLIENTE_NOMBRE, CLIENTE_APELLIDO
FROM Cliente C, Factura f, Pago p
WHERE F.fact_cliente=C.CLIENTE_ID AND fact_id in (Select pf_factura FROM PF) AND YEAR(fact_fecha_alta)=@fecha AND DATEPART ( QUARTER , fact_fecha_alta )= @trimestre
GROUP BY CLIENTE_ID, CLIENTE_NOMBRE, CLIENTE_APELLIDO
ORDER by PORCENTAJE DESC
GO
