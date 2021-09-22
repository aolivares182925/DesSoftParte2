use master
go
----drop database Tutoria
create database Tutoria
go

use Tutoria
go

--Tabla de tutor
create table Tutor
(
	CodTutor		char(3),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombres			varchar(30),
	Estado			varchar(40) check (Estado in('Contratado','Nombrado')),
	Contrase�a		varbinary(20),
	primary key (CodTutor)
)

--Tabla de escuela profesional
create table EscuelaProfesional
(
	CodEscuela		varchar(5),
	Nombre			varchar(50),
	primary key(CodEscuela)
)

--Tabla de alumnos
create table Alumno
(
	CodAlumno		char(6),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombres			varchar(30),
	Situacion		varchar(50) check (Situacion in('Riesgo', 'No riesgo')),
	CodTutor		char(3),
	CodEscuela		varchar(5),
	Activo			int check (Activo in(1, 0)), 
	primary key (CodAlumno),
	foreign key (CodTutor) references Tutor(CodTutor),
	foreign key ( CodEscuela) references EscuelaProfesional(CodEscuela)
)

--Tabla de Administrador
create table Administrador
(
	Usuario			varchar(6),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombre			varchar(30),
	Categoria		varchar(30),
	Contrase�a		varbinary(20) 
)

--Ficha de tutoria
create table FichaTutoria
(
	CodTutor			char(3),
	CodAlumno			char(6),
	Semestre			varchar(7),
	CodFichaTutoria		int identity (1,1),
	primary key (CodFichaTutoria),
	foreign key (CodTutor) references Tutor(CodTutor),
	foreign key ( CodAlumno) references Alumno(CodAlumno)
)

create table FichaSesion
(
	CodFichaTutoria		int,
	NroSesion			int check (NroSesion in(1,2,3)),
	FechaHora			datetime ,
	Tipo				varchar(30) check (Tipo in('Academico','Profesional','Personal')),
	Completado			int,
	Descripcion			varchar(400), 
	Referencia			varchar(400), 
	Observaciones		varchar(400),
	foreign key(CodFichaTutoria) references FichaTutoria(CodFichaTutoria)

)
--drop table FichaTutoria

create table Historial
(
	NroOperacion		int identity,
	Editor				varchar(250),
	Fecha				datetime,
	Tabla				varchar(30),
	Operacion			varchar(50),
	TuplaAfectada		char(6)
)
go
--TRIGGERS
--ALUMNO
--insert alumno
create trigger trHistorialAlumnoInsert
on Alumno for insert
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'insert', @cod)
go
--delete alumno
create trigger trHistorialAlumnoDelete
on Alumno for delete
as
declare @cod char(6)
select @cod = CodAlumno from deleted
insert into Historial values(system_user, getdate(), 'Alumno', 'delete', @cod)
go
--update alumno
create trigger trHistorialAlumnoUpdate
on Alumno for update
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'update', @cod)
go
--TUTOR
--insert tutor
create trigger trHistorialTutorInsert
on Tutor for insert
as
declare @cod char(6)
select @cod = CodTutor from inserted
insert into Historial values(system_user, getdate(), 'Tutor', 'insert', @cod)
go
--delete tutor
create trigger trHistorialTutorDelete
on Tutor for delete
as
declare @cod char(6)
select @cod = CodTutor from deleted
insert into Historial values(system_user, getdate(), 'Tutor', 'delete', @cod)
go
--drop trigger trHistorialTutorUpdate
--update tutor
create trigger trHistorialTutorUpdate
on Tutor for update
as
declare @cod char(6)
select @cod = CodTutor from INSERTED
insert into Historial values(system_user, getdate(), 'Tutor', 'update', @cod)
go
--FICHA TUTORIA
--insert ficha tutoria
create trigger trHistorialFichaTutInsert
on FichaTutoria for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'insert', @cod)
go
--delete ficha tutoria
create trigger trHistorialFichaTutDelete
on FichaTutoria for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'delete', @cod)
go
--update ficha tutoria
create trigger trHistorialFichaTutUpdate
on FichaTutoria for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'update', @cod)
go
--FICHA SESI�N
--insert ficha sesion
create trigger trHistorialFichaSesInsert
on FichaSesion for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'insert', @cod)
go
--delete ficha sesion
create trigger trHistorialFichaSesDelete
on FichaSesion for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'delete', @cod)
go
--update ficha sesion
create trigger trHistorialFichaSesUpdate
on FichaSesion for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaSesion', 'update', @cod)
go
insert into Tutor (CodTutor,Nombres,APaterno,AMaterno,Estado,Contrase�a)
values 
	('NNN','null','null','null','Nombrado',convert (varbinary,'')),
	('001','Boris','Chullo','Llave','Nombrado',convert (varbinary,'1234')),
	('002','Carlos Ramon','Quispe','Onofre','Nombrado',convert (varbinary,'1234')),
	('003','Dennis Ivan','Candia','Oviedo','Nombrado',convert (varbinary,'1234')),
	('004','Edwin','Carrasco','Poblete','Nombrado',convert (varbinary,'1234')),
	('005','Emilio','Palomino','Olivera','Nombrado',convert (varbinary,'1234')),
	('006','Enrique','Gamarra','Saldivar','Nombrado',convert (varbinary,'1234')),
	('007','Esther','Pacheco','Vasquez','Nombrado',convert (varbinary,'1234')),
	('008','Gladys Efraina','Cutipa','Arapa','Nombrado',convert (varbinary,'1234')),
	('009','Guzman','Ticona','Pari','Nombrado',convert (varbinary,'1234')),
	('010','Hector Eduardo','Ugarte','Rojas','Nombrado',convert (varbinary,'1234')),
	('011','Hernan','Nina','Hanco','Nombrado',convert (varbinary,'1234')),
	('012','Ivan','Cesar','Medrano','Nombrado',convert (varbinary,'1234')),
	('013','Javier Arturo','Rozas','Huacho','Nombrado',convert (varbinary,'1234')),
	('014','Javier David','Chavez','Centeno','Nombrado',convert (varbinary,'1234')),
	('015','Jose Luis','Soncco','Alvarez','Nombrado',convert (varbinary,'1234')),
	('016','Jose Mauro','Pillco','Quispe','Nombrado',convert (varbinary,'1234')),
	('017','Julio Cesar','Carvajal','Luna','Nombrado',convert (varbinary,'1234')),
	('018','Karelia','Medina','Miranda','Nombrado',convert (varbinary,'1234')),
	('019','Lauro','Enciso','Rodas','Nombrado',convert (varbinary,'1234')),
	('020','Lino Aquiles','Baca','Cardenas','Nombrado',convert (varbinary,'1234')),
	('021','Lino Prisciliano','Flores','Pacheco','Nombrado',convert (varbinary,'1234')),
	('022','Liseth Urpy','Segundo','Carpio','Nombrado',convert (varbinary,'1234')),
	('023','Luis Beltran','Palma','Ttito','Nombrado',convert (varbinary,'1234')),
	('024','Manuel','Pe�aloza','Figueroa','Nombrado',convert (varbinary,'1234')),
	('025','Maria del Pilar','Venegas','Vergara','Nombrado',convert (varbinary,'1234')),
	('026','Maritza','Irpanocca','Cusimayta','Nombrado',convert (varbinary,'1234')),
	('027','Nila Sonia','Acurio','Ucsa','Nombrado',convert (varbinary,'1234')),
	('028','Robert Wilbert','Alzamora','Paredes','Nombrado',convert (varbinary,'1234')),
	('029','Roger Mario','Cusihuaman','Phocco','Nombrado',convert (varbinary,'1234')),
	('030','Rony','Villafuerte','Serna','Nombrado',convert (varbinary,'1234')),
	('031','Roxana Lisette','Quintanilla','Portugal','Nombrado',convert (varbinary,'1234')),
	('032','Victor David','Sosa','Jauregui','Nombrado',convert (varbinary,'1234')),
	('033','Waldo Elio','Ibarra','Zambrano','Nombrado',convert (varbinary,'1234')),
	('034','Willian','Zamalloa','Paro','Nombrado',convert (varbinary,'1234')),
	('035','Yeshica Isela','Orme�o','Ayala','Nombrado',convert (varbinary,'1234'))

	
go
insert into EscuelaProfesional values ('IN','Ingenieria Informatica y de Sistemas')
go
insert into Alumno values
						('112207','IBARRA','CASTILLO','WALDO ERICK','Riesgo','001','IN',1),
						('141660','AROSTEGUI','CERNA','JAIR FREDERICK','Riesgo','001','IN',1),
						('154856','HUAHUATICO','SORIA','RONALD','Riesgo','001','IN',1),
						('164563','CARPIO','HERMOZA','HAIDER ALEX','Riesgo','001','IN',1),
						('175101','QUISPE','ESCALANTE','CARLA','Riesgo','001','IN',1),
						('184212','VALENCIA','CUSIPUMA','LUIS MAO','Riesgo','001','IN',1),
						('125156','CONDORI','FLORES','WILLIAMS DENNIS','No riesgo','001','IN',1),
						('150388','CHACON','VARGAS','JUAN ANTONIO','No riesgo','001','IN',1),
						('160886','CACERES','LOAYZA','MARIA LUISA','No riesgo','001','IN',1),
						('164240','ESCOBEDO','DURAN','ROBERTO CARLOS','No riesgo','001','IN',1),
						('171571','ROA','LIMACHI','JHON NILSON','No riesgo','001','IN',1),
						('182901','COLLANTE','CARRASCO','ALBERTO','No riesgo','001','IN',1),
						('184655','SANCA','ZEVALLOS','JERY','No riesgo','001','IN',1),
						('194525','PAREDES','CURASCO','ARELI SHALON','No riesgo','001','IN',1),
						('201228','ACHAHUI','CRUZ','MILTON AMED','No riesgo','001','IN',1),	
						
											
						('113561','MAXDEO','LAGOS','KEVIN ROUSBEL','Riesgo','002','IN',1),
						('141671','PAREDES','DENOS','VICTOR ANIVAL','Riesgo','002','IN',1),
						('155182','MAR','GIBAJA','RENATO','Riesgo','002','IN',1),
						('164817','HUAYHUA','JURADO','TANY ARISTIDES','Riesgo','001','IN',1),
						('182893','AGUILAR','PORCEL','JAZMIN','Riesgo','002','IN',1),
						('184644','CCANCHI','CONDORI','ENMANUEL JESUS','Riesgo','002','IN',1),
						('130516','BUSTAMANTE','MAMANI','WASHINGTON MARCO','No riesgo','002','IN',1),
						('150396','LINARES','MIRANO','JOHN ABDUL','No riesgo','002','IN',1),
						('160889','CHOQUE','BUENO','FIORELLA SILVIA','No riesgo','002','IN',1),
						('164243','MACEDO','GHEILER','SEBASTIAN ISRAEL','No riesgo','002','IN',1),
						('171676','HUAMAN','AYMA','DERLY HAYLEY','No riesgo','002','IN',1),
						('182908','ESPINOZA','CHAMPI','ISRAEL ENRIQUE','No riesgo','002','IN',1),
						('185132','MAMANI','TAY�A','GABRIEL ARTURO','No riesgo','002','IN',1),
						('194529','TORRES','MAMANI','GERSON','No riesgo','002','IN',1),
						('201230','CABRERA','MEJIA','CRISTIAN ANDY','No riesgo','002','IN',1),


						('012117','PINARES','BUSTAMANTE','SAMMY YASSER','Riesgo','003','IN',1),
						('120886','GALLEGOS','QUI�ONES','FREDY JULMER','Riesgo','003','IN',1),
						('144986','SOTO','COCHAMA','HUGO ROBERTO','Riesgo','003','IN',1),
						('160328','HUAMAN','CABRERA','YONATHAN','Riesgo','003','IN',1),
						('171059','FLORES','IGNACIO','JOSE LUIS','Riesgo','003','IN',1),
						('182922','MONTES','HUILLCA','FRANKLIN JESUS','Riesgo','003','IN',1),
						('184802','MAMANI','LAROTA','PAUL DAVID','Riesgo','003','IN',1),
						('070730','YA�EZ','SANZ','ANTHONY JOSEPH','No riesgo','003','IN',1),
						('134403','CALLAPI�A','CASTILLA','CIRO GABRIEL','No riesgo','003','IN',1),
						('151780','QUISPE','PUMA','LUCERO','No riesgo','003','IN',1),
						('160923','GONZALES','HUISA','NELSON','No riesgo','003','IN',1),
						('170430','COVARRUBIAS','AGUILAR','GEREMY ANDRE','No riesgo','003','IN',1),
						('171918','VELARDE','FLORES','MANUEL HUMBERTO','No riesgo','003','IN',1),
						('182923','MORA','CCARHUARUPAY','LUZ LUCERO','No riesgo','003','IN',1),
						('192424','MACCARCCO','QUISPE','KAROL GIANELLA','No riesgo','003','IN',1),
						('194921','SAMATA','PUMAHUALCCA','CRISTHIAN','No riesgo','003','IN',1),
						('204322','ZULOAGA','CCOPA','NILSON LEONEL','No riesgo','003','IN',1),
						
						('032648','LIMPE','ZEVALLOS','LUIS ANDRES','Riesgo','004','IN',1),
						('120893','PORROA','SIVANA','YENI RUTH','Riesgo','004','IN',1),
						('145002','HUALLPA','MONTALVO','RALEXS','Riesgo','004','IN',1),
						('160331','MOZO','DAVILA','MILTON ADERLIN','Riesgo','004','IN',1),
						('171060','FUENTES','CCORI','KEVIN HERNAN','Riesgo','004','IN',1),
						('182924','MU�OZ','QUISPE','RUTH MERY','Riesgo','004','IN',1),
						('191871','IBARRA','HUAMANCARI','RAY MARCELO','Riesgo','004','IN',1),
						('071106','CCAHUANTICO','MENDOZA','JULIO CESAR','No riesgo','004','IN',1),
						('134540','VILLALBA','DELGADO','CLINTON EDSON','No riesgo','004','IN',1),
						('151827','LEVA','SALAS','RENAN FERDINAND','No riesgo','004','IN',1),
						('161133','FARFAN','LAZO','CESAR FRANCISCO','No riesgo','004','IN',1),
						('170432','GUTIERREZ','DAZA','GONZALO','No riesgo','004','IN',1),
						('171938','LOPE','TORRES','MARISOL','No riesgo','004','IN',1),
						('182926','ORTEGA','SULLCACCORI','ACCENT BLADIMIR','No riesgo','004','IN',1),
						('192426','NI�O DE GUZMAN','CONDE','WENDEL YOVAN','No riesgo','004','IN',1),
						('194922','SILVA','GUEVARA','ESTEFAN POL','No riesgo','004','IN',1),
						('204792','ACHAHUANCO','VALENZA','ANDREE','No riesgo','004','IN',1),
						
						('052113','PUMA','HUILLCA','RICHARD JESUS','Riesgo','005','IN',1),
						('120895','QUISPE','PICHUILLA','AYRTON','Riesgo','005','IN',1),
						('145003','BARAZORDA','CUELLAR','HECTOR PAOLO','Riesgo','005','IN',1),
						('160332','QUISPE','JIMENEZ','MIGUEL ANGEL','Riesgo','005','IN',1),
						('171062','GUTIERREZ','SALAZAR','JUAN MANUEL','Riesgo','005','IN',1),
						('182925','OLIVARES','CAMERO','ALER SEBASTIAN','Riesgo','005','IN',1),
						('192414','BARRIENTOS','CRUZ','CRISTHIAN','Riesgo','005','IN',1),
						('080219','MOREANO','BRICE�O','GROVER','No riesgo','005','IN',1),
						('134544','ZUNIGA','HUAMAN','EDI FRAI','No riesgo','005','IN',1),
						('151833','CONDE','CHURA','YURI FERNANDO','No riesgo','005','IN',1),
						('161134','FERNANDEZ','GUTIERREZ','MARUJEM LYLIBETH','No riesgo','005','IN',1),
						('170433','HOLGUIN','CONDORI','JULIO JOSUE','No riesgo','005','IN',1),
						('171943','BUSTAMANTE','FLORES','ERICK ANDREW','No riesgo','005','IN',1),
						('182927','PE�A','LUQUE','RAISA MELINA','No riesgo','005','IN',1),
						('192428','RADO','HUAYOTUMA','ARTUR MARTI','No riesgo','005','IN',1),
						('195050','LOZANO','LLACCTAHUAMAN','MEDALY','No riesgo','005','IN',1),
						('204793','AGUILAR','SANCHEZ','NIK ANTONI','No riesgo','005','IN',1),

						('073289','BALLON','SEGOVIA','HENRY LUIS','Riesgo','006','IN',1),
						('120897','TELLO','JUSTINIANI','LUIS DAVID','Riesgo','006','IN',1),
						('145009','YCHU','VALENCIA','MIGUEL HUMBERTO','Riesgo','006','IN',1),
						('160336','TRIVE�O','GUERRERO','MANUEL CAMILO','Riesgo','006','IN',1),
						('171524','PUMACAHUA','APAZA','LEONARDO CHEPPER','Riesgo','006','IN',1),
						('182929','QUISPE','ACERO','ALDAIR','Riesgo','006','IN',1),
						('192415','CARRION','QUINTANA','BRAYAN DANIEL','Riesgo','006','IN',1),
						('081561','HUACANI ','DE LA CRUZ','DANY DARWIN','No riesgo','006','IN',1),
						('140145','FLORES','MOLINA','GONZALO AMIR','No riesgo','006','IN',1),
						('151835','HUAMAN','LONCONI','MARCO ANTONIO','No riesgo','006','IN',1),
						('161365','GALLEGOS','HUAYHUA','VERONICA','No riesgo','006','IN',1),
						('170434','HUAMAN','HERMOZA','ANTONY ISAAC','No riesgo','006','IN',1),
						('174440','CONDORI','OCHOA','GIOVDEY ABRAHAM','No riesgo','006','IN',1),
						('182928','PUMA','SOTOMAYOR','RICHARD MIHAYLOR','No riesgo','006','IN',1),
						('192664','APARICIO','CASTILLA','BRAYAN GUSTAVO','No riesgo','006','IN',1),
						('200330','AMAO','ATAUCHI','JULIO CESAR','No riesgo','006','IN',1),
						('204794','CCANSAYA','SONCCO','REBECA ARACELI','No riesgo','006','IN',1),	
						
								('083221','TRUJILLO','TORBISCO','LUIS ANDERSON','Riesgo','007','IN',1),
								('124218','UGARTE-LLANCAY','CARLOS ALFONSO','Riesgo','Riesgo','007','IN',1),
								('145213','CONDORI','HUILLCA','LIDER','Riesgo','007','IN',1),
								('160337','VITORINO','MARIN','EFRAIN','Riesgo','007','IN',1),
								('171565','MU�OZ','PACHECO','CHRISTIAN FERNANDO','Riesgo','007','IN',1),
								('182931','QUISPE','MORA','ANDERSON','Riesgo','007','IN',1),
								('192416','CCASANI','HUAMAN','WILMAN','Riesgo','007','IN',1),
								('094303','NAHUAMEL','SARCE','DENIS ANGEL','No riesgo','007','IN',1),
								('140156','HUAMAN','MENDOZA','JOHAN WILFREDO','No riesgo','007','IN',1),
								('152128','ALTAMIRANO','ALMIRON','KONI INDIRA','No riesgo','007','IN',1),
								('161366','GONZALES','MANRRIQUE','LUCIO','No riesgo','007','IN',1),
								('170435','HUAMAN','TORRES','ALVARO RICARDO','No riesgo','007','IN',1),
								('174441','DEZA','KACHA','RENO MAX','No riesgo','007','IN',1),
								('182936','USUCACHI','ANO','ISAC ANDERSON','No riesgo','007','IN',1),
								('192665','FERNANDEZ','MANDURA','ROYER FUNACOSHI','No riesgo','007','IN',1),
								('200331','APAZA','CHOQQUE','WILSON','No riesgo','007','IN',1),
								('204795','CHOQUE','QUISPE','JADYRA CH@''ASKA','No riesgo','007','IN',1),


								('111868','VICENTE','RAMIREZ','GUIDO','Riesgo','008','IN',1),
								('141631','ABAL','VILLASANTE','JHOEL YOJHAN','Riesgo','008','IN',1),
								('154636','PALOMINO','AUQUITAYASI','JOSE RAMIRO','Riesgo','008','IN',1),
								('164246','PACHA','QUISPE','JEAN MARCO','Riesgo','008','IN',1),
								('175061','MAMANI','ZELA','NICHOLAS EDWARD','Riesgo','008','IN',1),
								('184209','SAIRE','SALAZAR','AXEL STEWARF','Riesgo','008','IN',1),
								('124821','ROJAS','CAHUANA','ETSON RONALDAO','No riesgo','008','IN',1),
								('150387','CARRILLO','INQUILTUPA','JULIO CESAR','No riesgo','008','IN',1),
								('160853','PUMA','MENDOZA','CARLOS EDUARDO','No riesgo','008','IN',1),
								('164238','CASILLA','TTITO','EVANDIR SAUL','No riesgo','008','IN',1),
								('171570','RAMOS','ALVAREZ','EDGAR DANIEL','No riesgo','008','IN',1),
								('182900','CHUNGA','CASTILLO','GARY BRIGHAM','No riesgo','008','IN',1),
								('184654','SACA','ACCOSTUPA','MIGUEL ENRIQUE','No riesgo','008','IN',1),
								('194524','MELENDRES','PEREZ','CRISTINA','No riesgo','008','IN',1),
								('200827','SUMIRE','CCAHUANA','KEVIN ARON','No riesgo','008','IN',1),

								('083222','VARGAS','QUISPE','CHARLY','Riesgo','009','IN',1),
								('124811','BERRIOS','VILLASANTE','RAQUEL MELISSA','Riesgo','009','IN',1),
								('150335','YUCRA','TTITO','LESLY YAHAIRA','Riesgo','009','IN',1),
								('160542','C�CERES','HUANCA','ADHAIR EDHINO','Riesgo','009','IN',1),
								('171568','QUINCHO','RODRIGUEZ','JORDY GERSON','Riesgo','009','IN',1),
								('182933','SALINAS','ALARCON','PAULO CESAR','Riesgo','009','IN',1),
								('192418','CORNEJO','CASTRO','ANGELA LORENA','Riesgo','009','IN',1),
								('100511','GUTIERREZ','AMACHI','JUAN CARLOS','No riesgo','009','IN',1),
								('140934','VEGA CENTENO','OLIVERA','RONALDINHO','No riesgo','009','IN',1),
								('154628','CONDORI','HUAYCHAY','CESAR APARICIO','No riesgo','009','IN',1),
								('161368','LUNA','CCASANI','CHARLIE JOEL','No riesgo','009','IN',1),
								('170436','LUYCHO','ANCAIFURO','MARIELA','No riesgo','009','IN',1),
								('174442','ESCOBEDO','MESCCO','ANGIE','No riesgo','009','IN',1),
								('182940','VILLASANTE','LEON','AMARU','No riesgo','009','IN',1),
								('192975','ZAPANA','FLORES','GEORGE ALEXANDER','No riesgo','009','IN',1),
								('200332','CUSACANI','GONZALES','GERALD ANTONIO','No riesgo','009','IN',1),
								('204796','FARFAN','LUNA','JANNIRA ALISON','No riesgo','009','IN',1),

								('120879','ANCCO','PERALTA','RUBEN','Riesgo','010','IN',1),
								('143830','AIMA','JALISTO','JOHN ALDAIR','Riesgo','010','IN',1),
								('160326','CANO','LOAIZA','MICHEL','Riesgo','010','IN',1),
								('170749','CARMONA','CHOQUEMAMANI','KENNY HAROLD','Riesgo','010','IN',1),
								('182913','HUAHUALUQUE','VARGAS','JHAMIL JHONATAN','Riesgo','010','IN',1),
								('184656','SUAREZ','MARISCAL','MARCELO EDUARDO','Riesgo','010','IN',1),
								('133962','CHOQUENAIRA','QUISPE','NOE FRANKLIN','No riesgo','010','IN',1),
								('151332','NOLAZCO','SANDOVAL','SHAROM MITCHEL','No riesgo','010','IN',1),
								('160895','TTITO','ENRIQUEZ','LEANDRO','No riesgo','010','IN',1),
								('170427','CARCAUSTO','MAMANI','ELIZON FRANK','No riesgo','010','IN',1),
								('171915','NINANTAY','DIAZ','MILEYDY','No riesgo','010','IN',1),
								('182917','MAMANI','GABRIEL','BRUCE MAXIMO','No riesgo','010','IN',1),
								('192419','CUSI','QUISPE','YANET','No riesgo','010','IN',1),
								('194918','GAMARRA','FLORES','DAYHANA LUCERO','No riesgo','010','IN',1),
								('204320','GARCIA','ROMERO','JHONATAN ALEXANDER','No riesgo','010','IN',1),

								('111856','BACA','CHOQUE','CARLOS ALFREDO','Riesgo','011','IN',1),
								('141599','VENTURA','JAUJA','JAIME','Riesgo','011','IN',1),
								('154632','CHAMPI','PUMA','WILLIAM RUIZ','Riesgo','011','IN',1),
								('164245','NINA','GUARDAPUCLLA','JHOSET DAVID','Riesgo','011','IN',1),
								('175022','BAUTISTA','HURTADO','OWEN DEISER','Riesgo','011','IN',1),
								('184206','MEZA','ZAMALLOA','MARCUS GEUSEPPE','Riesgo','011','IN',1),
								('124813','DE LA CRUZ','QUISPE','ALEX ALBERTO','No riesgo','011','IN',1),
								('150379','QUISPE','QUISPE','JOEL','No riesgo','011','IN',1),
								('160696','HUAMAN','MORALES','ANGGIE ANTUANE','No riesgo','011','IN',1),
								('164237','CARRION','ACU�A','JHOSEP ANTONY','No riesgo','011','IN',1),
								('171567','PUCLLA','HUAMAN','DIANA STEPHANIE','No riesgo','011','IN',1),
								('182898','CERATI','CERRILLO','FIORELLA','No riesgo','011','IN',1),
								('184653','RODRIGUEZ','CASAS','MARJORIE REBECCA','No riesgo','011','IN',1),
								('194523','MAMANI','MEZA','JOHANA MARIA','No riesgo','011','IN',1),
								('200826','RODRIGUEZ','PHILLCO','JAIME ANTONIO','No riesgo','011','IN',1),


								('091613','RAMIREZ','APAZA','EBERT','Riesgo','012','IN',1),
								('125110','VERA','CCASA','NAYLUZ ROSMERY','Riesgo','012','IN',1),
								('150389','CONDE','SALLO','JHACK STEVEN','Riesgo','012','IN',1),
								('160888','CANA','APU','ORLANDO','Riesgo','012','IN',1),
								('171569','QUISPE','HANCCO','FERNANDO','Riesgo','012','IN',1),
								('182934','SAPACAYO','HUAYHUA','TEOFILO SOCRATES','Riesgo','012','IN',1),
								('192420','GUEVARA','DELGADO','TIRSSA IVONNE','Riesgo','012','IN',1),
								('101059','CASTILLO','LOPEZ','RICARDO JORGE','No riesgo','012','IN',1),
								('140985','LIMPE','QUISPE','JERRY ANDERSON','No riesgo','012','IN',1),
								('154631','NOLASCO','SUYO','CARLOS ANTONI','No riesgo','012','IN',1),
								('161369','MU�OZ','MU�OZ','WILY RODRIGO','No riesgo','012','IN',1),
								('170594','DORADO','TORRES','DIEGO ALONSO','No riesgo','012','IN',1),
								('174447','QUISPE','CHAMBILLA','CARLOS ENRIQUE','No riesgo','012','IN',1),
								('182941','YUCA','LIMA','KARLA URBELINDA','No riesgo','012','IN',1),
								('192997','ARCE','QUISPE','RUTH MILAGROS','No riesgo','012','IN',1),
								('200333','ESPINOZA','COLCA','NAHYELY ALANIZ','No riesgo','012','IN',1),
								('204797','HANCCO','CHAMPI','FRAN ANTHONY','No riesgo','012','IN',1),

								('091622','VALDEZ','CGUNO','JULIO CESAR','Riesgo','013','IN',1),
								('130737','DIANDERAS','LOPEZ','JHOHELLS ERICK','Riesgo','013','IN',1),
								('150397','LOAIZA','MONROY','BRUNO WALDIR','Riesgo','013','IN',1),
								('160892', 'LIMACHI','ORTEGA','FREDDY' ,'Riesgo','013','IN',1),
								('171573','YA�EZ','TUERO','JOSE ANGEL','Riesgo','013','IN',1),
								('182935','USCACHI','CCAPA','ERICK ','Riesgo','013','IN',1),
								('192421','HUAMAN','MERINO','ALFREDO ALIPIO ','Riesgo','013','IN',1),
								('103170','MOROCCO','LAYME','JONATHAN','No riesgo','013','IN',1),
								('140987','VILLARES','SUBLE','ALDAIR WILBERT','No riesgo','013','IN',1),
								('154633','CONDORI','CCARHUARUPAY','BRUNO MOISES','No riesgo','013','IN',1),
								('161727','MU�OZ','PACHECO','ENIT','No riesgo','013','IN',1),
								('170748','ARAUJO','LECHUGA','LUIS AUGUSTO','No riesgo','013','IN',1),
								('174450','SALAS','CCOLQQUE','WILLIAN','No riesgo','013','IN',1),
								('182942','ZUNIGA','AUCCAHUAQUI','JUAN MANUEL','No riesgo','013','IN',1),
								('192998','CARDENAS','HUAMAN','FABRICIO YARED ','No riesgo','013','IN',1),
								('200334','LIMA','ESPERILLA','KATERINE CANDY','No riesgo','013','IN',1),
								('204798','HUARACALLO','ARENAS','LINO ZEYNT','No riesgo','013','IN',1),

						   ('093160','CHARA','TACURI','CESAR ','Riesgo','014','IN',1),
						   ('130740','HUILLCA','HUILLCA','ABIGAIL ','Riesgo','014','IN',1),
						   ('150400','OCHOA','MAMANI','RICARDO','Riesgo','014','IN',1),
						   ('161135','QUISPE','TACURI','RUDI','Riesgo','014','IN',1),
						   ('171605','SALINAS','ATAUSINCHI','JERSON','Riesgo','014','IN',1),
						   ('182937','VELASQUEZ','DURAND','HANS ROBERT','Riesgo','014','IN',1),
						   ('192423','LOPEZ','BARAZORDA','JHON ANTHONY','Riesgo','014','IN',1),
						   ('103172','PALOMINO','POVEA','ANGEL','No riesgo','014','IN',1),
						   ('140998','TTITO','QUILCA','CESAR RODRIGO','No riesgo','014','IN',1),
						   ('154637','NINA','PONCE','JOSUE JOSE','No riesgo','014','IN',1),
						   ('161731','SONCCO','CACHURA','DAVID','No riesgo','014','IN',1),
						   ('170750','CUSIHUAMAN','AUCCACUSI','LUIS ALDAIR','No riesgo','014','IN',1),
						   ('174452','SARCO','JACINTO','DANIEL EDUARDO','No riesgo','014','IN',1),
						   ('183055','CARBAJAL','CARRASCO','GABRIEL','No riesgo','014','IN',1),
						   ('192999','CCONCHO','CASTELLANOS','MIGUEL ANGEL','No riesgo','014','IN',1),
						   ('200335','MAMANI','SAMATA','MAYCOHLL BERLY','No riesgo','014','IN',1),
						   ('204799','JALLO','PACCAYA','YASUMY MARICELY','No riesgo','014','IN',1),

						   ('110597','LLOCLLE','PUMA','HOLGUER','Riesgo','015','IN',1),
						   ('141010','RAMIREZ','ALVAREZ','LUISBERTO','Riesgo','015','IN',1),
						   ('154623','SOTO','MAMANI','HEDDED JOEL','Riesgo','015','IN',1),
						   ('164241','GIRALDO','ENCISO','DAVID','Riesgo','015','IN',1),
						   ('174944','CONDORI','MOZO','WESLEY JUANPEDRO','Riesgo','015','IN',1),
						   ('184203','HUAMAN','ATAYUPANQUI','LISBET PAOLA','Riesgo','015','IN',1),
						   ('200339','QUISPE','HUITOCALLO','GABRIEL','Riesgo','015','IN',1),
						   ('124219','VALLE','HUAMAN','MARIA ANGELA','No riesgo','015','IN',1),
						   ('145005','QUISPE','CORONEL','ANDREE YORDAN','No riesgo','015','IN',1),
						   ('160544','JARA','HILLPA','LUIS ABELARDO','No riesgo','015','IN',1),
						   ('164235','CALLAPI�A','RODRIGUEZ','JOSUE CRISTIAN','No riesgo','015','IN',1),
						   ('171260','QUISPE','TTITO','JOEL WILLY','No riesgo','015','IN',1),
						   ('182894','ANDIA','JAEN','ANDRES RODRIGO','No riesgo','015','IN',1),
						   ('184647','FLORES','NIETO','CARLOS FABRICIO','No riesgo','015','IN',1),
						   ('194519','HUAMAN','QUISPE','JEMY SANDRO','No riesgo','015','IN',1),
						   ('200824','LEVITA','QUISPE','LUIS ALVINO','No riesgo','015','IN',1),

						   ('093169','HUAMANI','FLOREZ','RONALD','Riesgo','016','IN',1),
						   ('130741','MERMA','QUISPE','HAROL HELBERT','Riesgo','016','IN',1),
						   ('150404','QUEKQA�O','QUISPE','CAYO ABEL','Riesgo','016','IN',1),
						   ('161136','TTITO','OCSA','JOSE ROLANDO','Riesgo','016','IN',1),
						   ('171866','QUISPE','YAHUIRA','RONALDO JERSON','Riesgo','016','IN',1),
						   ('182938','VILLAFUERTE','GARCES','EDU RODRIGO','Riesgo','016','IN',1),
						   ('192425','MAYTA','SALAZAR','HERBERTH CLAUDD','Riesgo','016','IN',1),
						   ('103637','AMAO','SULLCAHUAMAN','SHUI DANITZA','No riesgo','016','IN',1),
						   ('140999','ANCCO','PERALTA','ROSARIO','No riesgo','016','IN',1),
						   ('155180','MASIAS','USCAMAYTA','NAOMI ISABEL','No riesgo','016','IN',1),
						   ('161756','CCONISLLA','MEDINA','ANTHONY ALDAIR','No riesgo','016','IN',1),
						   ('171057','CALDERON','TINTAYA','FALLCHA XIOMARA','No riesgo','016','IN',1),
						   ('174454','TINTAYA','TACO','YUREMA LISBETH','No riesgo','016','IN',1),
						   ('183369','DEL CASTILLO','OVALLE','LUZ MARINA','No riesgo','016','IN',1),
						   ('193000','CHOQUELUQUE','GARCIA','ALEJANDRO MIGUEL','No riesgo','016','IN',1),
						   ('200336','ORCCON','DIAZ','DARCY OMAR','No riesgo','016','IN',1),
						   ('204800','MU�OZ','CASTILLO','GEORGE IVANOK','No riesgo','016','IN',1),

                           ('093175','LAYME','MAMANI','NELSON','Riesgo','017','IN',1),
                           ('131050','SANDI','MAMANI','ALEX','Riesgo','017','IN',1),
						   ('150406','SANGA','MONRROY','ROGER','Riesgo','017','IN',1),
					       ('161367','HUALVERDE','QUISPE','BENJAMIN ALEXANDER','Riesgo','017','IN',1),
						   ('174439','CHOQUECONZA','QUISPE','NORGAN SANDRO','Riesgo','017','IN',1),
						   ('182939','VILLALOBOS','QUISPE','PAMELA ARACELY ','Riesgo','017','IN',1),
						   ('192427','PORTILLO','HUAMAN','ERICK NICASIO','Riesgo','017','IN',1),
						   ('103644','LARICO','RODRIGO','EDER PAUL','No riesgo','017','IN',1),
						   ('141000','ASCUE','PE�A','AXEL RICARDO','No riesgo','017','IN',1),
						   ('155183','VARGAS','ARQQUE','JEREMYK RUFINO','No riesgo','017','IN',1),
						   ('161757','CCUITO','QUISPE','JHON ALBERT','No riesgo','017','IN',1),
						   ('171058','DEZA','CONDORI','ROSMEL URIEL','No riesgo','017','IN',1),
						   ('174455','UGARTE','CASTILLO','BRIGGITTE LEONOR','No riesgo','017','IN',1),
						   ('183464','MALDONADO','CARDE�A','STIWARTH D�ALENBERT','No riesgo','017','IN',1),
						   ('193001','GIFONE','VILLASANTE','EDUARDO JUAREIS','No riesgo','017','IN',1),
						   ('200337','POMA','SUPO','JUAN GABRIEL','No riesgo','017','IN',1),
						   ('204801','OLIVARES','TORRES','YAQUELYN ROSALINDA','No riesgo','017','IN',1),
						  

						   ('093178','MAMANI','CRISPIN','ISAI ISAAC','Riesgo','018','IN', 1),
                           ('131605','AYQUIPA','GOMEZ','AMILCAR','Riesgo','018','IN', 1),
						   ('150495','QUISPE','CLEMENTE','SAMAN','Riesgo','018','IN', 1),
					       ('161759','HUACHACA','PINEDA','HUMBERTO','Riesgo','018','IN', 1),
						   ('174443','FARFAN','MOSCOSO','JUAN VICTOR','Riesgo','018','IN', 1),
						   ('183078','PHUYO','HUAMAN','EDSON LEONID','Riesgo','018','IN', 1),
						   ('192430','TTITO','QUISPE','ABELARDO','Riesgo','018','IN', 1),
						   ('110125','LOPINTA','HUAMAN','CRISTIAN RODRIGO','No riesgo','018','IN', 1),
						   ('141154','FERNANDEZ','TILCA','CHRIS IALEEN','No riesgo','018','IN', 1),
						   ('155184','MAMANI','CCANAHUIRE','LALO LEONEL','No riesgo','018','IN', 1),
						   ('161758','FLOREZ','CCOA','LUIGGI EDUARDO','No riesgo','018','IN', 1),
						   ('171061','GUEVARA','FERRO','CRISTIAN LUIS','No riesgo','018','IN', 1),
						   ('174905','AGUILAR','MAINICTA','GIAN MARCO','No riesgo','018','IN', 1),
						   ('183469','PIMENTEL','FRANCO','GONZALO MARTIN','No riesgo','018','IN', 1),
						   ('193002','MERCADO','HUAYCHO','ADELMECIA','No riesgo','018','IN', 1),
						   ('200338','QUISPE','AGUILAR','ROGER','No riesgo','018','IN', 1),
						   ('204803','PACHARI','LIPA','MILTON ALEXIS','No riesgo','018','IN', 1),

						   ('100031','DURAND','NAVARRO','LUISA SHIRLEY','Riesgo','019','IN', 1),
                           ('131612','MONTA�EZ','CHOQUE','WILLIANS','Riesgo','019','IN', 1),
						   ('151448','ROMAN','CUELLAR','JUAN MANUEL','Riesgo','019','IN', 1),
					       ('161760','HUAMAN','VARGAS','PERCY ELVIS','Riesgo','019','IN', 1),
						   ('174445','OLARTE','CASAS','RODRIGO FABRICIO','Riesgo','019','IN', 1),
						   ('183218','QUISPE','MENDOZA','DIEGO','Riesgo','019','IN', 1),
						   ('192666','MELENDEZ','MENDIGURE','EDWARD','Riesgo','019','IN', 1),
						   ('110603','PUMAYALLI','CUSICUNA','FRANK EDISON','No riesgo','019','IN', 1),
						   ('141158','SAIRE','HANCCO','CESAR ANDERSSON','No riesgo','019','IN', 1),
						   ('155185','PEZUA','CERNADES','ARACELY','No riesgo','019','IN', 1),
						   ('161762','MORA','HUICHI','ALEX CRISTIAN','No riesgo','019','IN', 1),
						   ('171063','MALLQUI','APAZA','NADIABETH DIANA','No riesgo','019','IN', 1),
						   ('174908','CASILLA','PERCCA','VLADIMIR DANTE','No riesgo','019','IN', 1),
						   ('184192','ARCE','QUISPE','LISBETH','No riesgo','019','IN', 1),
						   ('193003','NOA','LLASCCANOA','ELIAZAR','No riesgo','019','IN', 1),
						   ('200340','QUISPE','TAY�A','JOSE LUIS','No riesgo','019','IN', 1),
						   ('204804','PE�A','CABALLERO','JOSE LUIS','No riesgo','019','IN', 1),

						   ('100505','ARONI','SOTO','WARREN STEPHEN','Riesgo','020','IN', 1),
                           ('133960','CHAMPI','CHAMPI','ABRAHAN ELIAS','Riesgo','020','IN', 1),
						   ('151450','ACHAHUANCO','ACHAHUI','EURIDICE INGRID','Riesgo','020','IN', 1),
						   ('161761','HUAMANI','SURCO','GROBER ALBERT','Riesgo','020','IN', 1),
						   ('174446','PORRAS','CHARCA','JAVIER GUSTAVO','Riesgo','020','IN', 1),
					       ('183485','SULLCA','AQUINO','JOSE ANTONIO','Riesgo','020','IN', 1),
						   ('193004','PARQUE','AROSQUIPA','LENIN JOAQUIN','Riesgo','020','IN', 1),
						   ('111175','CARRASCO','CUNZA','DANIEL ALEXANDER','No riesgo','020','IN', 1),
						   ('141670','HALIRE','HUAMAN','JAIME ANDREE','No riesgo','020','IN', 1),
						   ('155186','ALARCON','MAMANI','JHON ALFRED','No riesgo','020','IN', 1),
						   ('161764','SALAS','HUAMANI','MARITZA FLOR','No riesgo','020','IN', 1),
						   ('171064','ORE','GAMARRA','ABRAHAM BENJAMIN','No riesgo','020','IN', 1),
						   ('174909','CHOQUE','SARMIENTO','LEYDI DIANA','No riesgo','020','IN', 1),
						   ('184194','CONDORCAHUA','AYLLONE','FERDINAN JUNIOR','No riesgo','020','IN', 1),
						   ('193027','BLANCO','MOZO','CARMEN GUADALUPE','No riesgo','020','IN', 1),
						   ('200341','SANCHEZ','CHACON','ELBERT CESAR','No riesgo','020','IN', 1),
						   ('204806','SANCHEZ','PALOMINO','DENNIS OSWALDO','No riesgo','020','IN', 1),

						   ('101526','ORUE','QUISPE','ALVARO AMERICO','Riesgo','021','IN', 1),
                           ('133963','CONSA','QQUECCA�O','FERDINAN','Riesgo','021','IN', 1),
						   ('151737','MERINO','SOLANO','WILLIAM','Riesgo','021','IN', 1),
                           ('163806','ASENCIO','ARQQUE','JHOEL FELIX','Riesgo','021','IN', 1),
						   ('174449','SAIRE','BUSTAMANTE','EDMIL JAMPIER','Riesgo','021','IN', 1),
					       ('183885','CHILE','QUIROGA','HILDEMARO','Riesgo','021','IN', 1),
						   ('193168','ESPINOZA','OTAZU','FREDIMAR','Riesgo','021','IN', 1),
						   ('111332','QUISPE','CALANCHI','JOSE WALTHER','No riesgo','021','IN', 1),
						   ('143833','MELO','GUTIERREZ','RAUL ELVER','No riesgo','021','IN', 1),
						   ('155189','HUARAYA','CHARA','BLADIMIR','No riesgo','021','IN', 1),
						   ('161765','ZU�IGA','RAMOS','DANIEL ANTONY','No riesgo','021','IN', 1),
						   ('171066','QUINTO','CATACHURA','LADY DIANA','No riesgo','021','IN', 1),
						   ('174910','CUSI','HUAYLLA','MIGUEL ANGEL','No riesgo','021','IN', 1),
						   ('184195','CORDOVA','CCOPA','EMERSON','No riesgo','021','IN', 1),
						   ('193109','COLQUE','GALINDO','JEAN FRANCO','No riesgo','021','IN', 1),
						   ('200518','ALAGON','FERNANDEZ','ANGHELO','No riesgo','021','IN', 1),
						   ('204807','TINOCO','CCOTO','LUIS MANUEL','No riesgo','021','IN', 1),

						   ('113553','FLORES','YUCRA','IGNACIO','Riesgo','022','IN', 1),
                           ('141664','CONDE','PADIN','GEORGE ADOLFO','Riesgo','022','IN', 1),
						   ('155179','QUISPE','LAROTA','YHON LENIN','Riesgo','022','IN', 1),
						   ('164564','ESPINAL','HUAMAN','ANGEL PLACIDO','Riesgo','022','IN', 1),
                           ('182727','CCAHUANTICO','NINAMEZA','LUIS FERNANDO','Riesgo','022','IN', 1),
					       ('184641','BAUTISTA','HUILLCA','RUBEN RONALD','Riesgo','022','IN', 1),
						   ('130322','PEREZ','TOMAYLLA','BRUNO','No riesgo','022','IN', 1),
						   ('150394','HUAMAN','GUEVARA','ALEXANDER JAVIER','No riesgo','022','IN', 1),
						   ('160887','CALLA','YARIHUAMAN','FERNANDO RAFAEL','No riesgo','022','IN', 1),
						   ('164242','INQUILTUPA','CORTEZ','PATRICK ANTONIO','No riesgo','022','IN', 1),
						   ('171572','SALCEDO','HURTADO','JORGE ANDRE','No riesgo','022','IN', 1),
						   ('182906','CUYO','TTITO','DENIS OMAR','No riesgo','022','IN', 1),
						   ('184689','PILLCO','FLORES','LISBETH','No riesgo','022','IN', 1),
						   ('194527','QUISPE','SANTA CRUZ','YOEL SANDRO','No riesgo','022','IN', 1),
						   ('201229','ARANA','FLORES','SHAIEL ALMENDRA','No riesgo','022','IN', 1),
						   

						   ('101658','CHOQUE','CCOA','DENNIS ALIPIO','Riesgo','023','IN', 1),
                           ('134033','QUISPE','USCAMAYTA','ROBERT ANDRES','Riesgo','023','IN', 1),
						   ('151760','SALAZAR','MUELLE','BRAYAN DARIO','Riesgo','023','IN', 1),
					       ('163808','LOZANO','LLACCTAHUAMAN','ROYER BRANDON','Riesgo','023','IN', 1),
						   ('174457','VELASQUEZ','QUISPE','OLIVER STIVEN','Riesgo','023','IN', 1),
						   ('184191','ALVAREZ','MEJIA','ARTURO','Riesgo','023','IN', 1),
						   ('193807','JANCCO','CONCHA','CESAR AUGUSTO','Riesgo','023','IN', 1),
						   ('111860','CHALCO','CARRASCO','DENNIS ERICK','No riesgo','023','IN', 1),
						   ('144884','POCCORI','ESCALANTE','JUAN DIEGO','No riesgo','023','IN', 1),
						   ('155372','KU','ANDRADE','ANGELO PIETRI','No riesgo','023','IN', 1),
						   ('161783','ALVAREZ','QUISPE','LISHIEL','No riesgo','023','IN', 1),
						   ('171067 ','QUISPE','SERRANO','HILLARY CRISTINA','No riesgo','023','IN', 1),
						   ('174911','HUANCARA','CCOLQQUE','ALEX HELDER','No riesgo','023','IN', 1),
						   ('184207','PACCO','YLLA','YONATAN','No riesgo','023','IN', 1),
						   ('193110','FIGUEROA','RODRIGUEZ','ASTRID','No riesgo','023','IN', 1),
						   ('200519','OCHOA','BARRIOS','JESUS GUSTAVO','No riesgo','023','IN', 1),
						   ('204808','TORREBLANCA','PAZ','SEBASTIAN VICTOR','No riesgo','023','IN', 1),

						   ('101659','FERIA','TAPARA','JOSE ADOLFO','Riesgo','024','IN', 1),
						   ('134134','MELGAREJO','SAAVEDRA','SAULO SHALON','Riesgo','024','IN', 1),
						   ('151775','QUISPE','GONZALES','BRENDA NAHOMI','Riesgo','024','IN', 1),
						   ('163809','MAMANI','CHINO','RUBEN','Riesgo','024','IN', 1),
						   ('174838','CALLHUA','ALDAZABAL','OSBALDO DAN','Riesgo','024','IN', 1),
						   ('184196','CUSI','FUENTES','GONZALO','Riesgo','024','IN', 1),
						   ('193830','CCALA','HUAMANI','CRISTHIAN ','Riesgo','024','IN', 1),
                           ('113567','QUISPE','HUARHUA','IVAN ARTHUR','No riesgo','024','IN', 1),
						   ('144987','MENDOZA','CJUIRO','NILO FIDEL','No riesgo','024','IN', 1),
						   ('160325','APAZA','GARRIDO','MANUEL ALFREDO','No riesgo','024','IN', 1),
						   ('163525','FARFAN','ENRIQUEZ','GABRIELA','No riesgo','024','IN', 1),
						   ('171068','RODRIGUEZ','HANCCO','RUDY RODRIGO','No riesgo','024','IN', 1),
						   ('174912','INCA','CRUZ','CARLOS EDUARDO','No riesgo','024','IN', 1),
						   ('184210','TAPIA','QUISPE','ANDRE WASHINGTON','No riesgo','024','IN', 1),
						   ('193129','TTITO','HUAMAN','KEVIN JHOEL','No riesgo','024','IN', 1),
						   ('200520','REYNAGA','FLORES','ANGELA VANESSA','No riesgo','024','IN', 1),
						   ('204809','TORRES','MENDOZA','RAUL','No riesgo','024','IN', 1),

						   
							('114141','FLORES','SANTOS','YEREMI ANDREI','Riesgo','025','IN', 1),
							('141674', 'VILCA','PANTIGOSO','KAROL BERLIZ', 'Riesgo','025','IN', 1),
							('155192','NU�EZ','HUALLA','ALFREDO','Riesgo','025','IN', 1),
							('170440' ,'ROJAS','GARAY','JAFET CALEB','Riesgo','025','IN', 1),
							('182904','CURO','MAMANI','ALEX YTALO','Riesgo','025','IN', 1),
							('184651','MAMANI','TAIRO','ROY MARVIN','Riesgo','025','IN', 1),
							('131610','MEDINA','VILLAFUERTE','GRAITD KATERINE','No riesgo','025','IN', 1),
							('150409','TTITO','RAMOS','MANUEL DARIO','No riesgo','025','IN', 1),
							('160893','OLAZABAL','CALLER','LETICIA GIULIANA','No riesgo','025','IN', 1),
							('164566','MAMANI','QUINTA','MICHAEL ANTONNI','No riesgo','025','IN', 1),
							('171910' ,'GUERRA','BELLIDO','JHON WALDIR','No riesgo','025','IN', 1),
							('182914' ,'HUAMAN','MENDOZA','ELVIS JORGE','No riesgo','025','IN', 1),
							('191874','VALENCIA','�AUPA','MARKO LEONEL','No riesgo','025','IN', 1),
							('194916','BACILIO','HUAMAN','JEAN MARCO','No riesgo','025','IN', 1),
							('204318','BELLIDO','ARMUTO','ABEL ENRIQUE','No riesgo','025','IN', 1),


							('113562','MENDOZA','HUAILLAPUMA','ELISBAN','Riesgo','026','IN', 1),
							('141672','CORNEJO','CRUZ','JULIO WILSON','Riesgo','026','IN', 1),
							('155190','HINOJOSA','HUARCA','BRAYAN ALEXANDERT','Riesgo','026','IN', 1),
							('170428','CASSA','LIPA','EDWAR YURI','Riesgo','026','IN', 1),
							('182899','CHOQUEPATA','HUAMAN','VANESSA','Riesgo','026','IN', 1),
							('184649','HUACHACA','PEDRAZA','ALVARO','Riesgo','026','IN', 1),
							('130736','CUTIRE','ARCE','NICO ALVARO','No riesgo','026','IN', 1),
							('150401','PARI','ARRIAGA','DENILSON','No riesgo','026','IN', 1),
							('160890','CORDOVA','CASTRO','MARKO LEUGIM','No riesgo','026','IN', 1),
							('164248','PUMA','POTOCINO','JOSE FRANCISCO','No riesgo','026','IN', 1),
							('171805','ROJAS','SOTO','CLAUDIA LUZ','No riesgo','026','IN', 1),
							('182909','ESTRELLA','VILCA','JAMES KEVIN','No riesgo','026','IN', 1),
							('191870','CAHUATA','LAVILLA','YOLMY MILAGROS','No riesgo','026','IN', 1),
							('194530','ZEVALLLOS','VIDAL','NYCOLL TATIANA','No riesgo','026','IN', 1),
							('201231','CALLA�AUPA','SALLO','JULIO CESAR','No riesgo','026','IN', 1),


							('101664','QUISPE','RODRIGUEZ','LUIS ALEXEI','Riesgo','027','IN', 1),
							('134537','HUAYTA','OBLITAS','JOSE CARLOS','Riesgo','027','IN', 1),
							('151812','FERRO','ALVAREZ','JUSTINO','Riesgo','027','IN', 1),
							('163810','RODRIGUEZ','HUARACA','YOFRE','Riesgo','027','IN', 1),
							('174856','MAMANI','HUAMAN','KALEB GEDEON','Riesgo','027','IN', 1),
							('184197','FERNANDEZ BACA','CASTRO','LUCIAN NEPTALI','Riesgo','027','IN', 1),
							('193835','LAVILLA','BOLA�OS','JERSON EDU','Riesgo','027','IN', 1),
							('113572','AUCAPI�A','SUVIZARRETA','EDWAR','No riesgo','027','IN', 1),
							('144992','QUINTANILLA','CERON','JIMY NICANOR','No riesgo','027','IN', 1),
							('160329','HUILLCA','MOZO','BRYAN','No riesgo','027','IN', 1),
							('163671','ROBLES','SILVA','ANGELO','No riesgo','027','IN', 1),
							('171069','RODRIGUEZ','OJEDA','JORGE VICTOR','No riesgo','027','IN', 1),
							('174913','NAOLA','PUMA','EDWARD BRAYAN','No riesgo','027','IN', 1),
							('184211','TINCUSI','CCORIMANYA','JHON JAIME','No riesgo','027','IN', 1),
							('193832','CORTEZ','CCAHUANTICO','PAOLA ANDREA','No riesgo','027','IN', 1),
							('200788','SULLCARANI','DIAZ','BORIS ELOY','No riesgo','027','IN', 1),
							('992091','CRUZ','ZAMALLOA','OMAR ROLANDO','No riesgo','027','IN', 1),


							('103171','NAHUAMEL','SARCE','JHON ANDER','Riesgo','028','IN', 1),
							('134683','DURAND','NAVARRO','ANNELLY','Riesgo','028','IN', 1),
							('151822','PUMA','MAMANI','NILSON MAURI�O','Riesgo','028','IN', 1),
							('163811','SENCIA','GUTIERREZ','BETO RONALDO','Riesgo','028','IN', 1),
							('174864','RAMOS','CONDORI','DANNY','Riesgo','028','IN', 1),
							('184198','FERNANDEZ','ALVAREZ','DIEGO','Riesgo','028','IN', 1),
							('194520','LLAMOCCA','QUISPE','FRANKLIN','Riesgo','028','IN', 1),
							('114146','JOVE','CHIRINOS','PERCY BRYAN','No riesgo','028','IN', 1),
							('144993','IBARRA','HUAMAN','ALEXANDER PAVEL','No riesgo','028','IN', 1),
							('160333','REYES','VALLE','NILSON','No riesgo','028','IN', 1),
							('163807','CHATA','HUALLPAYUNCA','MILTON ANDERSON','No riesgo','028','IN', 1),
							('171070','SULLCA','PERALTA','MELANIE INDIRA','No riesgo','028','IN', 1),
							('174914','QUISPE','PALOMINO','LUIYI ANTONY','No riesgo','028','IN', 1),
							('184604','LOPEZ','OQUENDO','ANTHONY MAYRON','No riesgo','028','IN', 1),
							('193834','GODOY','LACUTA','CRISTIAN AYRTHON','No riesgo','028','IN', 1),
							('200820','ATAUCHI','MAMANI','JOSE EMILIO','No riesgo','028','IN', 1),
							('992175','MONDRAGON','PORRAS','LUIS CARLOS','No riesgo','028','IN', 1),



							('120883','CJUNO','MACHACA','ALEX SAIN','Riesgo','029','IN', 1),
							('144202','CURSE','CACERES','MAVILA DANITZA','Riesgo','029','IN', 1),
							('160327','CUSI','HUAMAN','KEVIN YEISON','Riesgo','029','IN', 1),
							('170751','ENRIQUEZ','QUISPE','JOHN KEVIN','Riesgo','029','IN', 1),
							('182921','MOLLINEDO','PE�A','ALVARO SEBASTIAN','Riesgo','029','IN', 1),
							('184780','PAUCCAR','BLANCO','HAPMYR ERWIN','Riesgo','029','IN', 1),
							('133964','GONZALES','MEZA','JHENDY EDER','No riesgo','029','IN', 1),
							('151388','CACERES','QUISPE','MARIA FERNANDA','No riesgo','029','IN', 1),
							('160920','CHOQUE','NAVARRO','MARCELO FABIAN','No riesgo','029','IN', 1),
							('170429','CONDORI','LOPEZ','JUAN CARLOS','No riesgo','029','IN', 1),
							('171916','PEREIRA','CHINCHERO','RICHARD MIKHAEL','No riesgo','029','IN', 1),
							('182920','MERMA','HUAMAN','NOHEMI NATALIA','No riesgo','029','IN', 1),
							('192422','HUAMAN','QUISPE','ANDY MARCELO','No riesgo','029','IN', 1),
							('194919','HUAICOCHEA','CARDENAS','WILBER EMANUEL','No riesgo','029','IN', 1),
							('204321','NIETO','BARRIENTOS','YISHAR PIERO','No riesgo','029','IN', 1),


							('103179','YARANGA','ACHAHUI','ALDO','Riesgo','030','IN', 1),
							('140984','CCAPATINTA','QQUECCA�O','DENNIS MOISES','Riesgo','030','IN', 1),
							('151830','VALDEIGLESIAS','DUE�AS','NAJOR JOSUE','Riesgo','030','IN', 1),
							('163813','VIZCARRA','VARGAS','MARCELO ANGELO','Riesgo','030','IN', 1),
							('174906','APAZA','HUAMANI','FRANK CLINTON','Riesgo','030','IN', 1),
							('184199','GALLEGOS','CJUIRO','LUIS ALBERTO','Riesgo','030','IN', 1),
							('194522','MAMANI','MESCCO','LUIS ANTHONY','Riesgo','030','IN', 1),
							('120285','PUMA','JARA',' MIGUEL ANGEL CRISOLOGO','No riesgo','030','IN', 1),
							('144994','SULLCAHUAMAN','VALDEZ','DENNYS YUTARO','No riesgo','030','IN', 1),
							('160338','YUPANQUI','CARRILLO','HOLGER ALFREDO','No riesgo','030','IN', 1),
							('163812','VIZA','AEDO','NESTOR','No riesgo','030','IN', 1),
							('171071','YARAHUAMAN','ROJAS','MILAGROS','No riesgo','030','IN', 1),
							('174961','VILCAHUAMAN','CACERES','MIGUEL','No riesgo','030','IN', 1),
							('184643','CASTRO','HUAYHUA','NELSON BERTOL','No riesgo','030','IN', 1),
							('193837','PFOCCORI','QUISPE','ALEX HARVEY','No riesgo','030','IN', 1),
							('200821','AUCAPURI','CORIMANYA','WILGER FABRICIO','No riesgo','030','IN', 1),


							('111651','QUISPE','SOTO','WILLIAM','Riesgo','031','IN', 1),
							('141011','SIPAUCAR','CONDORI','MARITZA MARIBEL','Riesgo','031','IN', 1),
							('154630','YUCRA','VALDEZ','YEFER YOSELIN','Riesgo','031','IN', 1),
							('164244','MOLOCHO','CONDORI','BRAYAN VLADYMIR','Riesgo','031','IN', 1),
							('174948','HUAMAN','CHILO','ELVIS','Riesgo','031','IN', 1),
							('184204','HUILLCA','QUISPE','JOEL','Riesgo','031','IN', 1),
							('124799','NINA','GUARDAPUCLLA','CARLOS ALEX','No riesgo','031','IN', 1),
							('150372','HANCCO','CHACO','JOSE MARIA','No riesgo','031','IN', 1),
							('160545','NAOLA','PEREYRA','ALEXANDER YERIM','No riesgo','031','IN', 1),
							('164236','CARBAJAL','LAURA','KOSMAR HUGO','No riesgo','031','IN', 1),
							('171564','FLORES','AQUINO','LUIS ENRIQUE','No riesgo','031','IN', 1),
							('182897','CALDERON','GARMENDIA','JOSEPH TIMOTHY','No riesgo','031','IN', 1),
							('184648','GALICIA','CENTENO','EDSON RAUL','No riesgo','031','IN', 1),
							('194521','MALDONADO','CHALCO','CRISTIAN DANIEL','No riesgo','031','IN', 1),
							('200825','MENDOZA','MAYTA','ANDRE MARCELO','No riesgo','031','IN', 1),



							('120008','CUETO','SANCHEZ','CARLA PALOMA','Riesgo','032','IN', 1),
							('141677','NINAHUANCA','CHOQUE','JUAN CARLOS','Riesgo','032','IN', 1),
							('155637','CORRALES','USCA','NESTOR','Riesgo','032','IN', 1),
							('170441','VILLAFUERTE','TURPO','ALEX CHRISTOPHER','Riesgo','032','IN', 1),
							('182911','GAMARRA','HERRERA','GABRIELA','Riesgo','032','IN', 1),
							('184652','PANDO','MU�OZ','ROSWELL JAIME','Riesgo','032','IN', 1),
							('133959','ANCCO','PERALTA','JUAN ABEL','No riesgo','032','IN', 1),
							('150411','VALLENAS','CHOQUECOTA','EDU','No riesgo','032','IN', 1),
							('160894','RAMOS','CONDORI','DIEGO ARMANDO','No riesgo','032','IN', 1),
							('164567','QUISPE','CHAUCCA','MELANY FABIOLA','No riesgo','032','IN', 1),
							('171914','MONZON','MONTALVO','ALEXANDER JUNIOR','No riesgo','032','IN', 1),
							('182916','LAZO','MENDOZA','JEREMY AXL','No riesgo','032','IN', 1),
							('192417','CESPEDES','VILCA','ANGEL LUIS','No riesgo','032','IN', 1),
							('194917','FLORES','CASTRO','MARY CARMEN','No riesgo','032','IN', 1),
							('204319','CONDORI','LACUTA','LUIS FERNANDO','No riesgo','032','IN', 1),



							('103647','QUISPE','ARONI','JESUS ADEL','Riesgo','033','IN', 1),
							('140997','TRIVE�OS','CALLER','DERICK ADOLPHO','Riesgo','033','IN', 1),
							('151832','CASTELLANOS','AMANQUI','GEORGE SANTIAGO','Riesgo','033','IN', 1),
							('163842','FERNANDEZ','HUILLCA','CARLOS ENRIQUE','Riesgo','033','IN', 1),
							('174907','CAMPOS','SEGOVIA','JEFFERSON LENNART','Riesgo','033','IN', 1),
							('184201','GUTIERREZ','TAQQUERE','LUIS FERNANDO','Riesgo','033','IN', 1),
							('194526','QUISPE','SALAS','JOSE ALEXANDER','Riesgo','033','IN', 1),
							('121957','ARANGURE','TORRES','ERNESTO FRANCISCO','No riesgo','033','IN', 1),
							('144995','MENDOZA','INO�AN','VANESSA','No riesgo','033','IN', 1),
							('160541','AYME','CONDORI','BRANDON RODRIGO','No riesgo','033','IN', 1),
							('163839','CORAZAO','HINOJOSA','REISON DARIO','No riesgo','033','IN', 1),
							('171258','ESPEJO','FRANCO','MELISSA BRIGGITTE','No riesgo','033','IN', 1),
							('182731','CHIRINOS','VILCA','YERSON JOAB','No riesgo','033','IN', 1),
							('184645','CCOTO','MACHACA','EDWIN BRAYAN','No riesgo','033','IN', 1),
							('194516','CCA�IHUA','LAYME','ELIAZAR','No riesgo','033','IN', 1),
							('200822','ESTACIO','MEDRANO','AMILCAR','No riesgo','033','IN', 1),



							('114136','ALMIRON','GONZALES','JUAN RAISER','Riesgo','034','IN', 1),
							('141673','RAMOS','DELGADO','AMIRE','Riesgo','034','IN', 1),
							('155191','URQUIZO','CARBAJAL','VICTOR','Riesgo','034','IN', 1),
							('170431','CRUZ','CARRION','JOSE LUIS','Riesgo','034','IN', 1),
							('182902','CONDE','QUISPE','REINHARD VICENT','Riesgo','034','IN', 1),
							('184650','HUARHUA','QUISPE','JUANA YULIANA','Riesgo','034','IN', 1),
							('131532','ANTAYHUA','SAPILLADO','DAVIS WASHINGTON','No riesgo','034','IN', 1),
							('150408','TACUSI','LAROTA','JHON EDWIN','No riesgo','034','IN', 1),
							('160891','CRUZ','BEJAR','WILLY ALDAIR','No riesgo','034','IN', 1),
							('164249','TTITO','SAYA','ALEXANDER','No riesgo','034','IN', 1),
							('171879','QUISPE','MAMANI','THALIA','No riesgo','034','IN', 1),
							('182910','FLORES','ROBLES','KATHERYNE SHARMELLY','No riesgo','034','IN', 1),
							('191873','PUMA','HUAMANI','GLINA DE LA FLOR','No riesgo','034','IN', 1),
							('194892','SONCCO','LUQUE','MAX ALEX','No riesgo','034','IN', 1),
							('201232','HUERTA','MEDINA','VITO JHON','No riesgo','034','IN', 1),


							('110071','MUNIVE','SALAS','CIRO','Riesgo','035','IN', 1),
							('141005','FLORES','MONTOYA','NILTHON JAIR','Riesgo','035','IN', 1),
							('154622','CONDORI','ALCAZAR','JUAN CARLOS','Riesgo','035','IN', 1),
							('164239','CONTRERAS','RAMIREZ','CARLOS DANIEL','Riesgo','035','IN', 1),
							('174941','CHOQUENAIRA','GARCIA','RONAL FRANKLIN','Riesgo','035','IN', 1),
							('184202','HANCCO','LE�N','ALEXANDER','Riesgo','035','IN', 1),
							('194920','HUAMANI','CRIOLLO','JUVENAL','Riesgo','035','IN', 1),
							('124211','PUMASUPA','BALLON','DAVIS VLADIMIR','No riesgo','035','IN', 1),
							('145004','ESPIRILLA','MACHACA','JOSEPH ODE','No riesgo','035','IN', 1),
							('160543','DONGO','ESQUIVEL','DIEGO YOSHIRO','No riesgo','035','IN', 1),
							('163845','HUILLCA','HERRERA','VICTOR POOL','No riesgo','035','IN', 1),
							('171259','QUISPE','LEON','WIDMAR RAUL','No riesgo','035','IN', 1),
							('182765','SUMIRE','HANCCO','IVAN MARIO','No riesgo','035','IN', 1),
							('184646','DIAZ','HUAYLUPO','CHRISTIAN ENRIQUE','No riesgo','035','IN', 1),
							('194518','HUAMAN','JAIMES','NICANOR','No riesgo','035','IN', 1),
							('200823','FERNANDEZ BACA','PILLCO','FABRICIO','No riesgo','035','IN', 1)
go
--insertar Datos de administrador
insert into Administrador values('Admin1', 'Apellido1','Apellido1','Nombre1','admin', convert (varbinary,'contrasenia1'))
insert into Administrador values('Admin2', 'Apellido2','Apellido2','Nombre2', 'admin',convert (varbinary,'contrasenia2'))
go

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
insert into FichaSesion values(3, 1,'10/09/2021 ','Academico', 1,'El alumno muestra un gran interes y desempe�o por el campo de la Inteligencia Artificial. ','Nota del curso de IA.','El alumno tuvo un percance con el profesor Angelito')
go
create proc ModificarAlumno
@CodAlumno varchar(15),
@APaterno varchar(50),
@AMaterno varchar(50),
@Nombres varchar(30),
@Situacion varchar(50),
@CodTutor char(3),
@CodEscuela varchar(5),
@Activo int
as
update Alumno set CodAlumno = @CodAlumno, 
					APaterno = @APaterno,
					AMaterno = @AMaterno,
					Nombres = @Nombres,
					Situacion = @Situacion,
					CodTutor = @CodTutor,
					CodEscuela = @CodEscuela,
					Activo = @Activo
where CodAlumno = @CodAlumno

go
---
create proc ModificarTutor
@CodTutor char(3),
@APaterno varchar(50),
@AMaterno varchar(50),
@Nombres varchar(30),
@Estado varchar(40)
as
update Tutor set CodTutor = @CodTutor, 
					APaterno = @APaterno,
					AMaterno = @AMaterno,
					Nombres = @Nombres,
					Estado = @Estado
where Codtutor = @CodTutor
go

---go
create proc ModificarContrase�aTutor
@CodTutor char(3),
@Contrase�a varchar(20)
as
update Tutor set Contrase�a = convert (varbinary,@Contrase�a)
where Codtutor = @CodTutor
go
---
create proc ModificarFichaSesion
@CodFichaTutoria	int,
@NroSesion			int,
@FechaHora			date ,
@Tipo				varchar(30),
@Completado			int,
@Descripcion		varchar(400), 
@Referencia			varchar(400), 
@Observaciones		varchar(400)
as
update FichaSesion set CodFichaTutoria = @CodFichaTutoria, 
					NroSesion = @NroSesion,
					FechaHora = @FechaHora,
					Tipo = @Tipo,
					Completado = @Completado,
					Descripcion = @Descripcion,
					Referencia = @Referencia,
					Observaciones = @Observaciones
where CodFichaTutoria = @CodFichaTutoria and NroSesion = @NroSesion
go
--- cambiar contrase�a administrador
create proc ModificarContrase�aAdministrador
@Usuario char(6),
@Contrase�a varchar(20)
as
update Administrador set Contrase�a = convert (varbinary,@Contrase�a)
where Usuario = @Usuario
go