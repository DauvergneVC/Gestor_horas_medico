create database if not EXISTS gestor_horas;
use gestor_horas;

drop table if exists Consulta;
drop table if exists Empleados;
drop table if exists Pacientes;

create table if not exists Empleados(
e_id int auto_increment primary key,
e_rut varchar(10) not null,
e_nombre varchar(50) not null,
e_apellido varchar(50) not null,
e_genero varchar(20) not null,
e_especialidad varchar (50) not null
);

create table if not exists Pacientes(
p_id int auto_increment primary key,
p_rut varchar(10) not null,
p_nombre varchar(50) not null,
p_apellido varchar(50) not null,
p_edad int not null,
p_genero varchar(20) not null,
p_telefono int(9) not null,
p_provicion varchar(10) not null
);


create table if not exists Consulta(
c_id int auto_increment primary key,
e_id int not null,
p_id int not null,
foreign key (e_id) references gestor_horas.empleados(e_id),
foreign key (p_id) references gestor_horas.pacientes(p_id),
c_fecha date not null
);

insert into empleados(e_rut, e_nombre, e_apellido, e_genero, e_especialidad) Values (
"11111111-1", "test 1", "General", "NoEspecificado", "General");
insert into empleados(e_rut, e_nombre, e_apellido, e_genero, e_especialidad) Values (
"22222222-2", "test 2", "Psiquiatra", "Femenino", "Psiquiatra");
insert into empleados(e_rut, e_nombre, e_apellido, e_genero, e_especialidad) Values (
"33333333-3", "test 3", "Psicologo", "Masculino", "Psicologo");
insert into empleados(e_rut, e_nombre, e_apellido, e_genero, e_especialidad) Values (
"44444444-4", "test 4", "Gastroenterologo", "Femenino", "Gastroenterologo");
insert into empleados(e_rut, e_nombre, e_apellido, e_genero, e_especialidad) Values (
"55555555-5", "test 5", "Dentista", "Indefinido", "Dentista");