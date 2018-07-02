drop table Vehiculos
drop database SegundoParcialDb
create database SegundoParcialDb
GO
use SegundoParcialDb
Create table vehiculos
(
	VehiculoID int primary key identity(1,1),
	Descripcion varchar(max),
	Mantenimiento int
	
);
Go
insert into Vehiculos(Descripcion,Mantenimiento)
values('Toyota Corolla 2015 LE ',0);



