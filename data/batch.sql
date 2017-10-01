USE GD2C2017;
GO
IF EXISTS (SELECT name FROM sys.schemas WHERE name = 'NO_TENGO_IDEA')
BEGIN
	IF OBJECT_ID('NO_TENGO_IDEA.ROLXFUNCIONALIDAD','U') IS NOT NULL
	DROP TABLE NO_TENGO_IDEA.ROLXFUNCIONALIDAD;

	IF OBJECT_ID('NO_TENGO_IDEA.FUNCIONALIDAD','U') IS NOT NULL
	DROP TABLE NO_TENGO_IDEA.FUNCIONALIDAD;

	IF OBJECT_ID('NO_TENGO_IDEA.USUARIOXROL','U') IS NOT NULL
	DROP TABLE NO_TENGO_IDEA.USUARIOXROL;

	IF OBJECT_ID('NO_TENGO_IDEA.ROL','U') IS NOT NULL
	DROP TABLE NO_TENGO_IDEA.ROL;

	IF OBJECT_ID('NO_TENGO_IDEA.USUARIO','U') IS NOT NULL
	DROP TABLE NO_TENGO_IDEA.USUARIO;

	IF OBJECT_ID('NO_TENGO_IDEA.SP_INICIAR_SESION_DE_USUARIO','P') IS NOT NULL
	DROP PROC NO_TENGO_IDEA.SP_INICIAR_SESION_DE_USUARIO
	
	DROP SCHEMA NO_TENGO_IDEA;
END
	GO
	CREATE SCHEMA NO_TENGO_IDEA
	GO
	CREATE TABLE NO_TENGO_IDEA.ROL 
		(	
		ID INTEGER PRIMARY KEY,
		NOMBRE VARCHAR(50),
		HABILITADO BIT,
		)
	GO	
	CREATE TABLE NO_TENGO_IDEA.USUARIO 
	(
	ID INTEGER PRIMARY KEY,
	USERNAME VARCHAR(50),
	PASS VARCHAR(50),
	HABILITADO BIT,
	CANT_INTENTOS_FALLIDOS TINYINT
	)
	GO
	CREATE TABLE NO_TENGO_IDEA.USUARIOXROL 
		(
		USUARIO_ID INTEGER ,
		ROL_ID INTEGER ,
		CONSTRAINT USUARIO_ROL_PK PRIMARY KEY(USUARIO_ID,ROL_ID),
		CONSTRAINT FK_USUARIO_ROL FOREIGN KEY (USUARIO_ID) REFERENCES NO_TENGO_IDEA.USUARIO (ID),
		CONSTRAINT FK_ROL_USUARIO FOREIGN KEY (ROL_ID) REFERENCES NO_TENGO_IDEA.ROL (ID)
		)
	GO
	CREATE TABLE NO_TENGO_IDEA.FUNCIONALIDAD
		(
		ID INTEGER PRIMARY KEY ,
		NOMBRE   VARCHAR(255),
		)
	GO
	CREATE TABLE NO_TENGO_IDEA.ROLXFUNCIONALIDAD 
		(
		ROL_ID INTEGER ,
		FUNCIONALIDAD_ID INTEGER ,
		CONSTRAINT ROL_FUNCIONALIDAD_PK PRIMARY KEY(ROL_ID,FUNCIONALIDAD_ID),
		CONSTRAINT FK_ROL_FUNCIONALIDAD FOREIGN KEY (ROL_ID) REFERENCES NO_TENGO_IDEA.ROL (ID),
		CONSTRAINT FK_FUNCIONALIDAD_ROL FOREIGN KEY (FUNCIONALIDAD_ID) REFERENCES NO_TENGO_IDEA.FUNCIONALIDAD (ID)
		)
	GO
	INSERT INTO  NO_TENGO_IDEA.ROL (ID,NOMBRE,HABILITADO)
	VALUES	(1,'Administrador',1), 
			(2,'Cobrador',1) 
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

	/*devuelve el resultado de inicio de session.
	   1-No existe el usuario
	   2-Existe el usuario, no puede iniciar sesion por la cant de intentos fallidos
	   3-El usuario pudo iniciar sesion
	   4-El usuario ingreso mal la password, incremente la cant de intento fallidos 
	   */
	CREATE PROCEDURE NO_TENGO_IDEA.SP_INICIAR_SESION_DE_USUARIO
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
	
	
	/**************************************/
	DELETE FROM NO_TENGO_IDEA.ROLXFUNCIONALIDAD WHERE 
	ROL_ID IN (SELECT R.ID FROM NO_TENGO_IDEA.ROL R WHERE R.NOMBRE='')      
	AND FUNCIONALIDAD_ID IN (SELECT F.ID FROM NO_TENGO_IDEA.FUNCIONALIDAD F WHERE F.NOMBRE = '');
	
	GO
	INSERT INTO NO_TENGO_IDEA.ROLXFUNCIONALIDAD (ROL_ID,FUNCIONALIDAD_ID) SELECT 
	(SELECT R.ID FROM NO_TENGO_IDEA.ROL R WHERE R.NOMBRE = 'rolx'), 
	(SELECT F.ID FROM NO_TENGO_IDEA.FUNCIONALIDAD F WHERE F.NOMBRE = 'funx')
	
	/******************************************/

	SELECT * FROM NO_TENGO_IDEA.ROL 
	
	UPDATE NO_TENGO_IDEA.ROL SET HABILITADO = 0 WHERE NOMBRE = ''  



	/*
//parent.ForeColor = Color.Gray; PARA poder agregar
*/
	        /*
 * para poder eliminar
 private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
{
if (Color.Gray == e.Node.ForeColor)
e.Cancel = true;
}
	
private void Form1_Load(object sender, EventArgs e)
{
foreach (TreeNode node in treeView1.Nodes)
if (node.Text == "sample")
node.ForeColor = Color.Gray;
}
         
         
 */