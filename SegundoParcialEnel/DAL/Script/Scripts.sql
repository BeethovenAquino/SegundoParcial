CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO
Create table Mantenimientos(

	  MantenimientoID int primary key identity(1,1),
        Fecha date
	
	
);
go
go
create table MantenimientoDetalles(

		  ID int primary key identity(1,1),
         MantenimientoID int, 
         ArticuloID int,
         VehiculoID int,
         TallerID int,
       Cantidad int,
       Precio int,
       importe int,
       total money,
       Subtotal money,
        ITBIS money
);
create table EntradaArticulos(
	  EntradaID int primary key identity(1,1),
        Fecha date,
         Articulo varchar(30),
        Cantidad int
);
go
go
Create table Articulos(
	  ArticuloID int primary key identity(1,1),
        Descripcion varchar(max),
       Costo int,
        Precio money,
        Ganancia int,
		 Inventario int

);
go
go
create table Talleres(
	TallerID int primary key identity(1,1),
	Nombre varchar(30)
);
go
go
create table Vehiculos
(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	Cantidad int,
	Precio int,
	TotalMantenimiento int

);
go