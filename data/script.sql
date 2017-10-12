USE [GD2C2017]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su] DROP CONSTRAINT [FK_Su_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su] DROP CONSTRAINT [FK_Su_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] DROP CONSTRAINT [FK_Rol_Func_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] DROP CONSTRAINT [FK_Rol_Func_Rol]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Funcionalidad]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] DROP CONSTRAINT [FK_Rol_Func_Funcionalidad]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf] DROP CONSTRAINT [FK_Rf_Rendicion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf] DROP CONSTRAINT [FK_Rf_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd] DROP CONSTRAINT [FK_Rd_Rendicion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd] DROP CONSTRAINT [FK_Rd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF] DROP CONSTRAINT [FK_PF_Pago]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF] DROP CONSTRAINT [FK_PF_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pago]'))
ALTER TABLE [dbo].[Pago] DROP CONSTRAINT [FK_Pago_Sucursal]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Item]'))
ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd] DROP CONSTRAINT [FK_Fd_Factura]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd] DROP CONSTRAINT [FK_Fd_Devolucion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Empresa]'))
ALTER TABLE [dbo].[Empresa] DROP CONSTRAINT [FK_Empresa_Rubro]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sucursal]') AND type in (N'U'))
DROP TABLE [dbo].[Sucursal]
GO
/****** Object:  Table [dbo].[Su]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Su]') AND type in (N'U'))
DROP TABLE [dbo].[Su]
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rubro]') AND type in (N'U'))
DROP TABLE [dbo].[Rubro]
GO
/****** Object:  Table [dbo].[Rol_Func]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol_Func]') AND type in (N'U'))
DROP TABLE [dbo].[Rol_Func]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol]') AND type in (N'U'))
DROP TABLE [dbo].[Rol]
GO
/****** Object:  Table [dbo].[Rf]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rf]') AND type in (N'U'))
DROP TABLE [dbo].[Rf]
GO
/****** Object:  Table [dbo].[Rendicion]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rendicion]') AND type in (N'U'))
DROP TABLE [dbo].[Rendicion]
GO
/****** Object:  Table [dbo].[Rd]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rd]') AND type in (N'U'))
DROP TABLE [dbo].[Rd]
GO
/****** Object:  Table [dbo].[PF]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PF]') AND type in (N'U'))
DROP TABLE [dbo].[PF]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pago]') AND type in (N'U'))
DROP TABLE [dbo].[Pago]
GO
/****** Object:  Table [dbo].[MedioDePago]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MedioDePago]') AND type in (N'U'))
DROP TABLE [dbo].[MedioDePago]
GO
/****** Object:  Table [dbo].[Item]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
DROP TABLE [dbo].[Item]
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionalidad]') AND type in (N'U'))
DROP TABLE [dbo].[Funcionalidad]
GO
/****** Object:  Table [dbo].[Fd]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fd]') AND type in (N'U'))
DROP TABLE [dbo].[Fd]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
DROP TABLE [dbo].[Factura]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empresa]') AND type in (N'U'))
DROP TABLE [dbo].[Empresa]
GO
/****** Object:  Table [dbo].[Devolucion]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Devolucion]') AND type in (N'U'))
DROP TABLE [dbo].[Devolucion]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
/****** Object:  Schema [NO_TENGO_IDEA]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'NO_TENGO_IDEA')
EXEC sys.sp_executesql N'CREATE SCHEMA [NO_TENGO_IDEA]'

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cliente](
	[clie_id] [int] NOT NULL,
	[clie_nombre] [varchar](50) NULL,
	[clie_apellido] [varchar](50) NULL,
	[clie_email] [varchar](50) NULL,
	[clie_dni] [varchar](50) NULL,
	[clie_telefono] [varchar](50) NULL,
	[clie_direccion] [varchar](50) NULL,
	[clie_cp] [int] NULL,
	[clie_fecha] [date] NULL,
	[clie_inactivo] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Devolucion]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Devolucion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Devolucion](
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
/****** Object:  Table [dbo].[Empresa]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empresa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Empresa](
	[empr_id] [int] NOT NULL,
	[empr_nombre] [varchar](50) NULL,
	[empr_direccion] [varchar](50) NULL,
	[empr_rubro] [int] NULL,
	[empr_inactivo] [bit] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factura]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Factura](
	[fact_id] [int] NOT NULL,
	[fact_cliente] [int] NOT NULL,
	[fact_empresa] [int] NOT NULL,
	[fact_numero] [int] NULL,
	[fact_fecha_alta] [date] NULL,
	[fact_fecha_vencimiento] [date] NULL,
	[fact_total] [float] NULL,
	[fact_devolucion] [int] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Fd]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fd]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Fd](
	[fd_factura] [int] NOT NULL,
	[fd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionalidad]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcionalidad](
	[func_id] [int] NOT NULL,
	[func_nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Item](
	[item_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[MedioDePago]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MedioDePago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MedioDePago](
	[medi_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Pago]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pago](
	[pago_id] [int] NOT NULL,
	[pago_fecha] [date] NULL,
	[pago_importe] [float] NULL,
	[pago_sucursal] [int] NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PF]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PF](
	[pf_pago] [int] NOT NULL,
	[pf_factura] [int] NOT NULL,
	[pf_medio] [int] NOT NULL,
	[pf_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rd]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rd]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rd](
	[rd_rendicion] [int] NOT NULL,
	[rd_devolucion] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rendicion]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rendicion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rendicion](
	[rend_id] [int] NOT NULL,
	[rend_fecha] [date] NULL,
	[rend_cantidad] [int] NULL,
	[rend_importe] [float] NULL,
	[rend_empresa] [int] NULL,
	[rend_porc] [float] NULL,
	[rend_total] [int] NULL,
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rf]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rf]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rf](
	[rf_rendicion] [int] NULL,
	[rf_factura] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rol]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rol](
	[rol_id] [int] NOT NULL,
	[rol_nombre] [nvarchar](50) NULL,
	[rol_inactivo] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rol_Func]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rol_Func]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rol_Func](
	[rfu_rol] [int] NOT NULL,
	[rfu_funcion] [int] NOT NULL,
	[rfu_usuario] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rubro]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rubro](
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
/****** Object:  Table [dbo].[Su]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Su]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Su](
	[su_usuario] [int] NOT NULL,
	[su_sucursal] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sucursal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sucursal](
	[sucu_id] [int] NOT NULL,
	[sucu_nom] [varchar](50) NULL,
	[sucu_cp] [int] NULL,
	[sucu_inactive] [bit] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[sucu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[usua_id] [int] NOT NULL,
	[usua_nombre] [varchar](50) NULL,
	[usua_contraseña] [varchar](50) NULL,
	[usua_intentos] [int] NULL,
	[usua_inactivo] [bit] NULL,
	[usua_sucursal] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usua_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [gd_esquema].[Maestra]    Script Date: lunes, 11 de septiembre de 2017 10:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Empresa]'))
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Rubro] FOREIGN KEY([empr_rubro])
REFERENCES [dbo].[Rubro] ([rubr_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Empresa_Rubro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Empresa]'))
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Rubro]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Devolucion] FOREIGN KEY([fd_devolucion])
REFERENCES [dbo].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd] CHECK CONSTRAINT [FK_Fd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd]  WITH CHECK ADD  CONSTRAINT [FK_Fd_Factura] FOREIGN KEY([fd_factura])
REFERENCES [dbo].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fd_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fd]'))
ALTER TABLE [dbo].[Fd] CHECK CONSTRAINT [FK_Fd_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Item]'))
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura] FOREIGN KEY([item_factura])
REFERENCES [dbo].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Item]'))
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pago]'))
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Sucursal] FOREIGN KEY([pago_sucursal])
REFERENCES [dbo].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pago_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pago]'))
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Factura] FOREIGN KEY([pf_factura])
REFERENCES [dbo].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF] CHECK CONSTRAINT [FK_PF_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF]  WITH CHECK ADD  CONSTRAINT [FK_PF_Pago] FOREIGN KEY([pf_pago])
REFERENCES [dbo].[Pago] ([pago_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PF_Pago]') AND parent_object_id = OBJECT_ID(N'[dbo].[PF]'))
ALTER TABLE [dbo].[PF] CHECK CONSTRAINT [FK_PF_Pago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Devolucion] FOREIGN KEY([rd_devolucion])
REFERENCES [dbo].[Devolucion] ([devo_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Devolucion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd] CHECK CONSTRAINT [FK_Rd_Devolucion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd]  WITH CHECK ADD  CONSTRAINT [FK_Rd_Rendicion] FOREIGN KEY([rd_rendicion])
REFERENCES [dbo].[Rendicion] ([rend_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rd_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rd]'))
ALTER TABLE [dbo].[Rd] CHECK CONSTRAINT [FK_Rd_Rendicion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf]  WITH CHECK ADD  CONSTRAINT [FK_Rf_Factura] FOREIGN KEY([rf_factura])
REFERENCES [dbo].[Factura] ([fact_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Factura]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf] CHECK CONSTRAINT [FK_Rf_Factura]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf]  WITH CHECK ADD  CONSTRAINT [FK_Rf_Rendicion] FOREIGN KEY([rf_rendicion])
REFERENCES [dbo].[Rendicion] ([rend_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rf_Rendicion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rf]'))
ALTER TABLE [dbo].[Rf] CHECK CONSTRAINT [FK_Rf_Rendicion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Funcionalidad]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Func_Funcionalidad] FOREIGN KEY([rfu_funcion])
REFERENCES [dbo].[Funcionalidad] ([func_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Funcionalidad]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] CHECK CONSTRAINT [FK_Rol_Func_Funcionalidad]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Func_Rol] FOREIGN KEY([rfu_rol])
REFERENCES [dbo].[Rol] ([rol_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] CHECK CONSTRAINT [FK_Rol_Func_Rol]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Func_Usuario] FOREIGN KEY([rfu_usuario])
REFERENCES [dbo].[Usuario] ([usua_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Rol_Func_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Rol_Func]'))
ALTER TABLE [dbo].[Rol_Func] CHECK CONSTRAINT [FK_Rol_Func_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su]  WITH CHECK ADD  CONSTRAINT [FK_Su_Sucursal] FOREIGN KEY([su_sucursal])
REFERENCES [dbo].[Sucursal] ([sucu_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Sucursal]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su] CHECK CONSTRAINT [FK_Su_Sucursal]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su]  WITH CHECK ADD  CONSTRAINT [FK_Su_Usuario] FOREIGN KEY([su_usuario])
REFERENCES [dbo].[Usuario] ([usua_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Su_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Su]'))
ALTER TABLE [dbo].[Su] CHECK CONSTRAINT [FK_Su_Usuario]
GO
USE [master]
GO
ALTER DATABASE [GD2C2017] SET  READ_WRITE 
GO
INSERT INTO Cliente(clie_dni, clie_apellido, clie_nombre, clie_fecha, clie_email, clie_direccion, clie_cp, clie_inactivo)	
	 select [Cliente-Dni], MAX([Cliente-Apellido]), MAX([Cliente-Nombre]), MAX([Cliente-Fecha_Nac]), MAX(Cliente_Mail), MAX(Cliente_Direccion),MAX(Cliente_Codigo_Postal), 0  
		from gd_esquema.Maestra
		group by [Cliente-Dni]
GO
INSERT INTO Rubro( rubr_id, rubr_nombre) 
	SELECT Empresa_Rubro, Rubro_Descripcion
	from gd_esquema.Maestra
	GROUP BY Empresa_Rubro, Rubro_Descripcion
GO
INSERT INTO Empresa(empr_nombre, empr_cuit, empr_direccion, empr_rubro, empr_inactivo)
	select MAX(Empresa_Nombre), Empresa_Cuit, MAX(Empresa_Direccion), MAX(Empresa_Rubro), 0
	from gd_esquema.Maestra
	group by Empresa_Cuit
GO
insert into sucursal (sucu_nom, sucu_dire, sucu_cp)
	select Sucursal_Nombre, MAX(Sucursal_Dirección), MAX(Sucursal_Codigo_Postal) 
	from gd_esquema.Maestra 
	where  Sucursal_Nombre IS NOT NULL 
	group by Sucursal_Nombre
GO
insert into MedioDePago(medi_nombre)
	select FormaPagoDescripcion 
	from gd_esquema.Maestra 
	where FormaPagoDescripcion IS NOT NULL  
	group by FormaPagoDescripcion
GO
INSERT INTO Factura(fact_numero, fact_fecha_alta, fact_total, fact_fecha_vencimiento, fact_empresa, fact_cliente)
	select Nro_Factura, MAX(Factura_Fecha), MAX(Factura_Total), MAX(Factura_Fecha_Vencimiento), (select top 1 empr_id from empresa where empr_cuit = MAX(Empresa_Cuit)), (select top 1 clie_id from cliente where clie_dni = MAX([Cliente-Dni])) 
	from gd_esquema.Maestra 
	group by Nro_Factura
GO
INSERT INTO item(item_factura, item_monto, item_cantidad)	
	select (select fact_id from factura where  fact_numero = Nro_Factura), ItemFactura_Monto, ItemFactura_Cantidad 
	from gd_esquema.Maestra 
	group by Nro_Factura, ItemFactura_Monto, ItemFactura_Cantidad
	order by Nro_Factura
GO
INSERT INTO Pago(pago_numero, pago_fecha, pago_importe, pago_mediodepago, pago_sucursal)	
	select Pago_nro, MAX(Pago_Fecha), MAX(Total), (select medi_id from MedioDePago where medi_nombre = MAX(FormaPagoDescripcion)), (select sucu_id from Sucursal where sucu_nom = MAX(Sucursal_Nombre))
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Pago_nro
GO
INSERT INTO PF(pf_factura, pf_pago)	
	select (select fact_id from factura where  fact_numero = Nro_Factura), (select pago_id from Pago where pago_numero = Pago_nro) 
	from gd_esquema.Maestra
	where Pago_nro IS NOT NULL
	group by Nro_Factura, Pago_nro
GO
INSERT INTO Rendicion(rend_numero, rend_fecha, rend_importe)	
	select Rendicion_nro, MAX(Rendicion_Fecha), MAX(ItemRendicion_importe)
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Rendicion_Nro
GO
INSERT INTO Rf (rf_factura,  rf_rendicion)
	select (select fact_id from factura where  fact_numero = Nro_Factura),(select top 1 rend_id from Rendicion where rend_numero = Rendicion_Nro) 
	from gd_esquema.Maestra
	where Rendicion_Nro IS NOT NULL
	group by Nro_Factura, Rendicion_Nro
GO