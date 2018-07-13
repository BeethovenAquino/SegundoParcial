CREATE DATABASE SegundoParcialDb
GO
USE SegundoParcialDb
GO
truncate table Mantenimientoes(
			MantenimientoID int primary key identity(1,1),
			VehiculoID int,
            Fecha date,
			Subtotal money,
			itbis money,
			Total money
	
	
);
go
go
truncate table MatenimientoDetalles(

		 ID int primary key identity(1,1),
			MantenimientoID int,
            TallerID int,
            ArticulosID int,
            Articulo varchar(40),
            Cantidad int,
            Precio money, 
            Importe money

);
go
go
truncate table EntradaArticulos(
	  EntradaID int primary key identity(1,1),
        Fecha date,
         Articulo varchar(30),
        Cantidad int,
		 ArticuloID int
);
go
go
truncate table Articulos(
	  ArticuloID int primary key identity(1,1),
        Descripcion varchar(max),
       Costo int,
        Precio money,
        Ganancia int,
		 Inventario int

);
go
go
truncate table Tallers(
	TallerID int primary key identity(1,1),
	Nombre varchar(30)
);
go
go
truncate table Vehiculos
(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	TotalMantenimiento money

);
go



select *From Mantenimientoes
select *From MatenimientoDetalles
select *From Vehiculos