USE [master]
GO
/****** Object:  Database [PreguntadOrt]    Script Date: 6/9/2024 08:50:13 ******/
CREATE DATABASE [PreguntadOrt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PreguntadOrt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PreguntadOrt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PreguntadOrt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PreguntadOrt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PreguntadOrt] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PreguntadOrt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PreguntadOrt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PreguntadOrt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PreguntadOrt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PreguntadOrt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PreguntadOrt] SET ARITHABORT OFF 
GO
ALTER DATABASE [PreguntadOrt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PreguntadOrt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PreguntadOrt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PreguntadOrt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PreguntadOrt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PreguntadOrt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PreguntadOrt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PreguntadOrt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PreguntadOrt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PreguntadOrt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PreguntadOrt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PreguntadOrt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PreguntadOrt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PreguntadOrt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PreguntadOrt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PreguntadOrt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PreguntadOrt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PreguntadOrt] SET RECOVERY FULL 
GO
ALTER DATABASE [PreguntadOrt] SET  MULTI_USER 
GO
ALTER DATABASE [PreguntadOrt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PreguntadOrt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PreguntadOrt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PreguntadOrt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PreguntadOrt] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PreguntadOrt', N'ON'
GO
ALTER DATABASE [PreguntadOrt] SET QUERY_STORE = OFF
GO
USE [PreguntadOrt]
GO
/****** Object:  User [alumno]    Script Date: 6/9/2024 08:50:13 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 6/9/2024 08:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dificultades]    Script Date: 6/9/2024 08:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificultades](
	[idDificultad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Dificultad] PRIMARY KEY CLUSTERED 
(
	[idDificultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 6/9/2024 08:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[idPregunta] [int] IDENTITY(1,1) NOT NULL,
	[idCategoria] [int] NOT NULL,
	[idDificultad] [int] NOT NULL,
	[enunciado] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[idPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 6/9/2024 08:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[idRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[idPregunta] [int] NOT NULL,
	[opcion] [int] NOT NULL,
	[contenido] [varchar](100) NOT NULL,
	[correcta] [bit] NOT NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[idRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([idCategoria], [nombre]) VALUES (1, N'Matemáticas')
INSERT [dbo].[Categorias] ([idCategoria], [nombre]) VALUES (2, N'Ciencias')
INSERT [dbo].[Categorias] ([idCategoria], [nombre]) VALUES (3, N'Historia')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Dificultades] ON 

INSERT [dbo].[Dificultades] ([idDificultad], [nombre]) VALUES (1, N'Fácil')
INSERT [dbo].[Dificultades] ([idDificultad], [nombre]) VALUES (2, N'Media')
INSERT [dbo].[Dificultades] ([idDificultad], [nombre]) VALUES (3, N'Difícil')
SET IDENTITY_INSERT [dbo].[Dificultades] OFF
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 

INSERT [dbo].[Preguntas] ([idPregunta], [idCategoria], [idDificultad], [enunciado]) VALUES (1, 1, 1, N'¿Cuál es el resultado de 2+2?')
INSERT [dbo].[Preguntas] ([idPregunta], [idCategoria], [idDificultad], [enunciado]) VALUES (2, 2, 2, N'¿Qué es la fotosíntesis?')
INSERT [dbo].[Preguntas] ([idPregunta], [idCategoria], [idDificultad], [enunciado]) VALUES (3, 3, 3, N'¿Cuándo ocurrió la Revolución Francesa?')
INSERT [dbo].[Preguntas] ([idPregunta], [idCategoria], [idDificultad], [enunciado]) VALUES (4, 1, 2, N'¿Cuánto es 5x5?')
INSERT [dbo].[Preguntas] ([idPregunta], [idCategoria], [idDificultad], [enunciado]) VALUES (5, 2, 1, N'¿Cuál es el gas más abundante en la atmósfera?')
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuestas] ON 

INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (1, 1, 1, N'4', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (2, 1, 2, N'3', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (3, 1, 3, N'5', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (4, 2, 1, N'Proceso mediante el cual las plantas producen su alimento', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (5, 2, 2, N'Proceso de respiración celular', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (6, 2, 3, N'Movimiento de savia en las plantas', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (7, 3, 1, N'1789', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (8, 3, 2, N'1812', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (9, 3, 3, N'1776', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (10, 4, 1, N'25', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (11, 4, 2, N'20', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (12, 4, 3, N'30', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (13, 5, 1, N'Nitrógeno', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (14, 5, 2, N'Oxígeno', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [opcion], [contenido], [correcta]) VALUES (15, 5, 3, N'Dióxido de carbono', 0)
SET IDENTITY_INSERT [dbo].[Respuestas] OFF
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Categorias] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categorias] ([idCategoria])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Categorias]
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Dificultades] FOREIGN KEY([idDificultad])
REFERENCES [dbo].[Dificultades] ([idDificultad])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Dificultades]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Preguntas] FOREIGN KEY([idPregunta])
REFERENCES [dbo].[Preguntas] ([idPregunta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Preguntas]
GO
USE [master]
GO
ALTER DATABASE [PreguntadOrt] SET  READ_WRITE 
GO
