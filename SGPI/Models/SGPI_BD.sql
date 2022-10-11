Create Database SGPI_BD
Go
Use SGPI_BD
Go

Create Table tblPagos(
IdPagos int identity primary Key,
ValorPago int,
Fecha date,
estado bit
)

Go
Create table tblTipoDocumento(
IDDoc int identity primary key,
TipoDocumento varchar(30)
)

Go
Create table tblGenero(
IDGenero int identity primary key,
Genero varchar(30)
)

Go
Create table tblRol(
IDRol int identity primary key,
Rol varchar(50)
)

Go
create table tblPrograma
(
IDPrograma int identity primary key,
Programa varchar(100)
)


Go
Create table tblAsignatura(
IDAsignatura int primary key,
Nombre varchar(100),
cod varchar(150),
IDPrograma int,
nivel int,
credito int
constraint FK_tblAsignatura foreign key(IDPrograma)  references tblPrograma(IDPrograma)
)

Go
create table tblTipoHomolo(
IDTipoHomolo int identity primary key,
TipoHomolo varchar(100)
)
Go
Create Table tblUsuario(
IDUsuario int identity primary key,
NumeroDocumento varchar(30),
IDDoc int,
PrimerNombre varchar(255),
SegundoNombre varchar(255),
PrimerApellido varchar(255),
SegundoApellido varchar(255),
IDGenero int,
Email varchar (255),
IDRol int,
vcPassword varchar(255),
IDPrograma int
constraint FK_tblUsuario_TipoDoc foreign key(IDDoc)  references tblTipoDocumento(IDDoc),
constraint FK_tblUsuario_Genero foreign key(IDGenero)  references tblGenero(IDGenero),
constraint FK_tblUsuario_Rol foreign key(IDRol)  references tblRol(IDRol),
constraint FK_tblUsuario_Programa foreign key(IDPrograma)  references tblPrograma(IDPrograma)
)

Go
Create table tblProgramacion(
IDProgramacion int identity primary key,
PeriodoAcademico varchar(30),
IDPrograma int,
Sala varchar(30),
IDAsignatura int,
IDUsuario int
constraint FK_tblProgramacion_Programa foreign key(IDPrograma)  references tblPrograma(IDPrograma),
constraint FK_tblProgramacion_Asignatura foreign key(IDAsignatura)  references tblAsignatura(IDAsignatura),
constraint FK_tblProgramacion_Usuario foreign key(IDUsuario)  references tblUsuario(IDUsuario)
)

GO
Create Table tblEstudiante(
IDEstudiante int primary key,
Archivo varchar(500),
IDpago int,
IDUsuario int,
Egresado bit
constraint FK_tblEstudiante_Pago foreign key(IDpago)  references tblPagos(IdPagos),
constraint FK_tblEstudiante_Usuario foreign key(IDUsuario)  references tblUsuario(IDUsuario)
)

Go
create table tblHomologacion(
IDHomologacion int identity primary key,
IDEstudiante int,
IDPrograma int,
IDTipoHomolo int,
PeriodoAcademico varchar(30),
IDAsignatura int,
CodHomologacion varchar(30),
NomAsigHomolo varchar(30),
CreditosHomologacion int,
Nota float(53)
constraint FK_tblHomologacion_Estudiante foreign key(IDEstudiante)  references tblEstudiante(IDEstudiante),
constraint FK_tblHomologacion_Programa foreign key(IDPrograma)  references tblPrograma(IDPrograma),
constraint FK_tblHomologacion_TipoH foreign key(IDTipoHomolo)  references tblTipoHomolo(IDTipoHomolo),
constraint FK_tblHomologacion_Asignatura foreign key(IDAsignatura)  references tblAsignatura(IDAsignatura)
)
Go
create table tblEntrevista(
IDEntrevista int primary key,
IDUsuario int,
IDEstudiante int,
Fecha date
constraint FK_tblEntrevista_Usuario foreign key(IDUsuario)  references tblUsuario(IDUsuario),
constraint FK_tblEntrevista_Estudiante foreign key(IDEstudiante)  references tblEstudiante(IDEstudiante)
)
