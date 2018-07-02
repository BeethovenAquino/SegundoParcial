

create database SegundoParcialEnelDb
GO
use SegundoParcialEnelDb
Create table Vehiculos
(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	Mantenimiento int
	
);
Go
insert into Vehiculos(Descripcion,Mantenimiento)
values('Toyota Corolla 2015 LE ',0);

