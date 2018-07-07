CREATE DATABASE AquinoDb
GO
USE AquinoDb
GO
Create table Mantenimientos(
	MantenimientoID int  primary key identity(1,1),
	Fecha DateTime,
	Vehiculo varchar(30),
	Taller varchar(30),
	
);


create table MantenimientoDetalles(
	MantenimientoID int  primary key identity(1,1),
	 
         Cantidad int,
         Precio int,
         importe money,
         total money,
        Subtotal money,
         ITBIS money
);
create table EntradaArticulos(
	EntradaID int primary key identity(1,1),
	Fecha Datetime,
	Articulo varchar(30),
	Cantidad int
);
Create table Articulos(
	ArticuloID int primary key identity(1,1),
	Descripcion varchar(max),
	Costo int,
	Precio int,
	Granancia varchar(max),
	Inventario varchar(30)

);

create table Taller(
	TallerID int primary key identity(1,1),
	Nombre varchar(30)
);

create table Vehiculos(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	Cantidad int,
	Precio int,
	TotalMantenimiento int

);