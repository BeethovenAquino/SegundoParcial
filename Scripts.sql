CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO
create table Mantenimientoes(

	  MantenimientoID int primary key identity(1,1),
         VehiculoID int,
         Fecha date,
         Subtotal money,
         itbis money,
         Total money

	
	
);
go
go
create table MatenimientoDetalles(

		  ID int primary key identity(1,1),
         MantenimientoID int, 
         ArticuloID int,
         VehiculoID int,
         TallerID int,
       Cantidad int,
       Precio money,
       importe money,
       total money,
       Subtotal money,
        ITBIS money
);
go
go
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
create table Tallers(
	TallerID int primary key identity(1,1),
	Nombre varchar(30)
);
go
go
create table Vehiculos
(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	TotalMantenimiento money

);
go



select *From Mantenimientoes
select *From MatenimientoDetalles