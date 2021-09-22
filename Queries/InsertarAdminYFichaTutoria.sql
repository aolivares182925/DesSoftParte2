--insertar Datos de administrador
insert into Administrador values('Admin1', 'Apellido1','Apellido1','Nombre1','admin', convert (varbinary,'contrasenia1'))
insert into Administrador values('Admin2', 'Apellido2','Apellido2','Nombre2', 'admin',convert (varbinary,'contrasenia2'))


-- insertar datos de prueba a ficha tutoria
set Dateformat dmy
go

insert into FichaTutoria values('001','112207','2019-I')
insert into FichaSesion values(1, 1,'10/09/2021 ','Academico', 1,'p1', 'p2','p3')
insert into FichaSesion values(1, 2,'17/09/2021 ','Profesional', 1,'p4', 'p5','p16')

insert into FichaTutoria values('001','112207','2019-II')
insert into FichaSesion values(2, 1,'10/09/2021 ','Academico', 1,'huola', 'p7','p8')
insert into FichaSesion values(2, 2,'17/09/2021 ','Profesional', 1,'p9', 'p10','P11')

insert into FichaTutoria values('001','150388','2019-II')
insert into FichaSesion values(3, 1,'10/09/2021 ','Academico', 1,'El alumno muestra un gran interes y desempeño por el campo de la Inteligencia Artificial. ','Nota del curso de IA.','El alumno tuvo un percance con el profesor Angelito')

