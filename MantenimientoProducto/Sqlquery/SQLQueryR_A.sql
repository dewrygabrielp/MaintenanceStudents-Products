USE [master]
GO
/****** Object:  Database [REGISTRO]    Script Date: 7/23/2021 3:41:11 PM ******/
CREATE DATABASE [REGISTRO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'REGISTRO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\REGISTRO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'REGISTRO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\REGISTRO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [REGISTRO] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [REGISTRO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [REGISTRO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [REGISTRO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [REGISTRO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [REGISTRO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [REGISTRO] SET ARITHABORT OFF 
GO
ALTER DATABASE [REGISTRO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [REGISTRO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [REGISTRO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [REGISTRO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [REGISTRO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [REGISTRO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [REGISTRO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [REGISTRO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [REGISTRO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [REGISTRO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [REGISTRO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [REGISTRO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [REGISTRO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [REGISTRO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [REGISTRO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [REGISTRO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [REGISTRO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [REGISTRO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [REGISTRO] SET  MULTI_USER 
GO
ALTER DATABASE [REGISTRO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [REGISTRO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [REGISTRO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [REGISTRO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [REGISTRO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [REGISTRO] SET QUERY_STORE = OFF
GO
USE [REGISTRO]
GO
/****** Object:  Table [dbo].[ALUMNO]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALUMNO](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO] [varchar](6) NULL,
	[NOMBRE] [varchar](25) NULL,
	[APELLIDO] [varchar](25) NULL,
	[DIRECCION] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ALUMNO] ON 
GO
INSERT [dbo].[ALUMNO] ([IdAlumno], [CODIGO], [NOMBRE], [APELLIDO], [DIRECCION]) VALUES (1, N'ITLA01', N'DEWRY', N'PENA', N'AV MAXIMO GOMEZ SANTO DOMINGO DN.')
GO
INSERT [dbo].[ALUMNO] ([IdAlumno], [CODIGO], [NOMBRE], [APELLIDO], [DIRECCION]) VALUES (4, N'ITLA03', N'BISMARCK', N'MONTERO', N'OTRA')
GO
INSERT [dbo].[ALUMNO] ([IdAlumno], [CODIGO], [NOMBRE], [APELLIDO], [DIRECCION]) VALUES (5, N'ITLA04', N'JUANA', N'VALDEZ', N'LAS AMERICAS')
GO
SET IDENTITY_INSERT [dbo].[ALUMNO] OFF
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_alumnos]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spbuscar_alumnos]
@textobuscar varchar(50)
as
select * from ALUMNO
where NOMBRE like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[speditare_alumno]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[speditare_alumno]
@idalumno int,
@codigo varchar(6),
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(200)
as

update ALUMNO set CODIGO=@codigo, NOMBRE=@nombre, APELLIDO=@apellido, DIRECCION=@direccion
where IdAlumno=@idalumno
GO
/****** Object:  StoredProcedure [dbo].[speliminar_alumnos]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[speliminar_alumnos]
@idalumno int
as
delete from ALUMNO
where IdAlumno=@idalumno
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_alumno]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spinsertar_alumno]
@idalumno int output,
@codigo varchar(6),
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(200)
as
 insert into ALUMNO (NOMBRE,CODIGO,APELLIDO,DIRECCION) values (@nombre,@codigo,@apellido,@direccion)
GO
/****** Object:  StoredProcedure [dbo].[spmostar_alumnos]    Script Date: 7/23/2021 3:41:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spmostar_alumnos]
as
select * from ALUMNO
GO
USE [master]
GO
ALTER DATABASE [REGISTRO] SET  READ_WRITE 
GO
