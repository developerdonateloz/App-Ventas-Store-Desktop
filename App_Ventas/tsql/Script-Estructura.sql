IF OBJECT_ID('[dbo].[Persona]') IS NOT NULL
DROP TABLE [dbo].[Persona]
GO
CREATE TABLE [dbo].[Persona]
(
	idpersona int identity(1,1) primary key,
	codigo varchar(10),
	nombre varchar(50),
	apellidopaterno varchar(50),
	apellidomaterno varchar(50),
	usuario varchar(50),
	contrasenia varchar(32),
	fechacreacion datetime,
	habilitado bit
)
GO
--
IF OBJECT_ID('[dbo].[crearpersona]') IS NOT NULL
DROP PROC [dbo].[crearpersona]
GO
CREATE PROC [dbo].[crearpersona]
(
	@codigo nvarchar(10),
	@nombre nvarchar(50),
	@appaterno nvarchar(50),
	@apmaterno nvarchar(50),
	@usuario nvarchar(50),
	@contrasenia varchar(32)
)
AS
BEGIN
	INSERT INTO persona(codigo,nombre,apellidopaterno,apellidomaterno,usuario,contrasenia,fechacreacion,habilitado)
	VALUES(@codigo,@nombre,@appaterno,@apmaterno,@usuario,@contrasenia,DATEADD(hh,-5,getutcdate()),1)
	SELECT @@IDENTITY
END
GO
--
IF OBJECT_ID('[dbo].[Login]') IS NOT NULL
DROP PROC [dbo].[Login]
GO
CREATE PROC [dbo].[Login]
(
	@usuario nvarchar(50),
	@contrasenia nvarchar(32)
)
AS
BEGIN
	--
	DECLARE	@id int
	--
	SELECT	@id=idpersona
	FROM	persona
	WHERE	usuario=@usuario
			AND contrasenia=@contrasenia
	--
	IF(@id IS NOT NULL)
	BEGIN
		SELECT CONVERT(bit,1)
	END
	ELSE
	BEGIN
		SELECT CONVERT(bit,0)
	END
END
GO
--
IF OBJECT_ID('[dbo].[BuscarPersonas]') IS NOT NULL
DROP PROC [dbo].[BuscarPersonas]
GO
CREATE PROC [dbo].[BuscarPersonas]
(
	@dato nvarchar(50)
)
AS
BEGIN
	SELECT	idpersona,
			codigo,
			nombre+ ' '+ apellidopaterno+' '+apellidomaterno as nombrecompleto
	FROM	persona
	WHERE	codigo like '%'+@dato+'%'
			or nombre like '%'+@dato+'%'
			or apellidopaterno like '%'+@dato+'%'
			or apellidomaterno like '%'+@dato+'%'
END
GO