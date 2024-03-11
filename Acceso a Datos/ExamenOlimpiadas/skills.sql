drop database if exists skills;
create database skills;
use skills;

create table modalidad(
	id int auto_increment primary key,
    modalidad varchar(50) unique
)engine innodb;
insert into modalidad values
(default,'Desarrollo Web'),
(default,'Carpintería'),
(default,'Electricidad');

create table alumno(
	id int auto_increment primary key,
    dni varchar(9) unique not null,
    nombre varchar(100) not null,
    modalidad int not null,
    puntuacion int not null default 0,
    finalizado boolean not null default false,
    foreign key(modalidad) references modalidad(id) on update cascade on delete restrict
)engine innodb;

insert into alumno(id, dni, nombre, modalidad) values 
(default, '1A', 'Pedro',1),
(default, '2A', 'María',1),
(default, '3A', 'Clara',1),
(default, '4A', 'Luis',1),
(default, '5A', 'Lucía',2),
(default, '6A', 'María',2),
(default, '7A', 'Javier',2),
(default, '8A', 'Paco',2),
(default, '9A', 'Martina',3),
(default, '10A', 'Paula',3),
(default, '11A', 'Matías',3),
(default, '12A', 'Quique',3);

create table prueba(
	id int auto_increment primary key,
    modalidad int not null,
    fecha datetime not null,
    descripcion varchar(255),
    puntuacion int,
    foreign key(modalidad) references modalidad(id) on update cascade on delete restrict
)engine innodb;
insert into prueba values 
(default, 3, '20240501100000', 'Prueba 1', 4),
(default, 3, '20240501100000','Prueba 2', 3),
(default, 3, '20240502140000','Prueba 3', 2),
(default, 3, '20240502140000','Prueba 4', 1),
(default, 2, '20240501100000','Prueba 1', 3),
(default, 2, '20240501100000','Prueba 2', 3),
(default, 2, '20240502140000','Prueba 3', 2),
(default, 2, '20240502140000','Prueba 4', 2),
(default, 1, '20240501100000','Prueba 1', 3),
(default, 1, '20240501100000','Prueba 2', 2),
(default, 1, '20240502140000','Prueba 3', 2),
(default, 1, '20240501100000','Prueba 4', 3);

create table correccion(
	alumno int,
    prueba int,
    puntos int,
    comentario varchar(100),
    primary key (alumno, prueba),
    foreign key (alumno) references alumno(id) on update cascade on delete restrict,
    foreign key (prueba) references prueba(id) on update cascade on delete restrict
)engine innodb;



delimiter //
create function crearModalidad(pNombre varchar(50))
returns int deterministic begin
	declare vId int;
    select id into vId from modalidad where modalidad = pNombre;
    if(vId is null) then
		insert into modalidad values (default,pNombre);
		return last_insert_id();
	else
		return -1;
	end if;
end//
create procedure obtenerGandadores()
begin
	select m.modalidad, a.nombre, a.puntuacion 
		from alumno a inner join modalidad m on a.modalidad = m.id
        where a.finalizado = true and a.puntuacion = (select max(puntuacion) from alumno where finalizado=true and modalidad = m.id);
end//