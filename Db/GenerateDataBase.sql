use master
go 

create database lisitdb
go 

use lisitdb
go 

CREATE TABLE [dbo].[StoredEvent](
	[Id] [uniqueidentifier] NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[Action] [varchar](100) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[User] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

create table Usuario (
	Id [uniqueidentifier] primary key,
    Rut varchar(8), 
    Nombre varchar(200), 
    ApellidoPaterno varchar(200), 
    Contrasena varchar(20), 
    Rol varchar(20) -- (ADMINISTRADOR, USUARIO)
)
go 

create table Pais (
	Id [uniqueidentifier] primary key,
    Nombre varchar(200)
)
go 

create table Region (
	Id [uniqueidentifier] primary key,
	IdPais [uniqueidentifier]FOREIGN KEY REFERENCES Pais(Id),
    Nombre varchar(200)
)
go 


create table Comuna (
	Id [uniqueidentifier] primary key,
    IdRegion [uniqueidentifier]FOREIGN KEY REFERENCES Region(Id),
    Nombre varchar(200)
)
go 

create table AyudasSociales (
	Id [uniqueidentifier] primary key,
    IdComuna [uniqueidentifier]FOREIGN KEY REFERENCES Comuna(Id),
    Descripcion NVARCHAR(255),
    Anio INT
)
go

-- PENDIENTE
create table Asignaciones (
	Id [uniqueidentifier] primary key,
    idUsuario [uniqueidentifier],
    idAyudaSocial [uniqueidentifier],
    FechaAsignacion datetime 
);





