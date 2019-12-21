--create database InversocaApp
--use InversocaApp

create table Roles(
IdRol int identity(1,1) not null,
Nombre varchar(50) not null,
Descripcion text,
Active bit default 1,
Constraint pk_Roles primary key(IdRol))

create table Propiedades(
IdPropiedad int identity(1,1) not null,
Nombre varchar(50) not null,
Descripcion text null,
Active bit default 1,
Constraint pk_Propiedades primary key(IdPropiedad))

create table Modulos(
IdModulo int identity(1,1) not null,
Nombre varchar(50) not null,
Descripcion text null,
Active bit default 1,
Constraint pk_Modulos primary key(IdModulo))

create table Operaciones(
IdOperacion int identity(1,1) not null,
Nombre varchar(50) not null,
IdModulo int,
Descripcion text null,
Active bit default 1,
Constraint pk_Operaciones primary key(IdOperacion),
Constraint fk_Operaciones_Modulos foreign key (IdModulo)
references Modulos(IdModulo))

create table Usuarios(
IdUsuario int identity(1,1) not null,
Nombre varchar(50) not null,
Correo varchar(50),
Contrasena varchar(50),
Active bit default 1,
Constraint pk_Usuario primary key(IdUsuario))

--RELACION DE MUCHO A MUCHO ENTRE ROLES Y OPERACIONES
create table Roles_Operaciones(
IdRol int not null,
IdOperacion int not null,
Descripcion text null,
Constraint pk_Roles_Operaciones primary key(IdRol,IdOperacion),
Constraint fk_Roles_Operaciones_Operaciones foreign key (IdOperacion)
references Operaciones(IdOperacion),
Constraint fk_Roles_Operaciones_Roles foreign key (IdRol)
references Roles(IdRol))



-- RELACION DE MUCHO A MUCHSO ENTRE USUARIO Y ROLES
create table Usuarios_Roles(
IdUsuario int not null,
IdRol int not null,
Descripcion text null,
Constraint pk_Usuarios_Roles primary key(IdUsuario,IdRol),
Constraint fk_Usuarios_Roles_Usuarios foreign key (IdUsuario)
references Usuarios(IdUsuario),
Constraint fk_Usuarios_Roles__Roles foreign key (IdRol)
references Roles(IdRol))
-- RELACION DE UNO A MUCHOS ROLES Y USUARIO
