-----------------usuario----------------------
Create table Usuario
(
idUsuario int identity primary key,
nomeUsu varchar(30) not null,
loginUsu varchar(20) unique not null,
senhaUsu varchar(100) not null,
dataNascimentoUsu date not null,
perfilUsu varchar(12) not null,  /*Cliente ou Profissional*/
telefoneUsu char(11) not null
)
exec pi_Usuario 'gui','123','123','2002-09-24','profissional','00123456789'
select*from Usuario
GO
create procedure pi_Usuario
/*parametros*/
@nomeUsu varchar(30),
@loginUsu varchar(20),
@senhaUsu varchar(100),
@dataNascimentoUsu date,
@perfilUsu char(12),
@telefoneUsu char(11) 
as
/*corpo*/
insert into Usuario
(nomeUsu, loginUsu,senhaUsu,dataNascimentoUsu,perfilUsu, telefoneUsu)
values (@nomeUsu,@loginUsu, @senhaUsu, @dataNascimentoUsu,@perfilUsu,@telefoneUsu)

GO

create procedure ps_validaLoginUsu
@loginUsu varchar(20),
@senhaUsu varchar(100)
as
select * from Usuario
where loginUsu=@loginUsu and senhaUsu=@senhaUsu

Go

create procedure pu_AtualizarUsu  
@nomeUsu varchar(30),
@loginUsu varchar(20),
@dataNascimentoUsu date, 
@perfilUsu varchar(12), 
@telefoneUsu char(11) 
as
update Usuario 
set nomeUsu = @nomeUsu, dataNascimentoUsu = @dataNascimentoUsu, perfilUsu = @perfilUsu, telefoneUsu = @telefoneUsu
where loginUsu=@loginUsu

GO

create procedure ps_Usuario
@chaveBuscaUsu varchar(30)
as
select nomeUsu,loginUsu,dataNascimentoUsu,perfilUsu,telefoneUsu from Usuario
where loginUsu=@chaveBuscaUsu +'%'

create procedure pd_Usuario
/*parametros*/
@loginUsu varchar(25)
as
/*corpo*/
delete Usuario
where loginUsu=@loginUsu

-----------------profissional---------------------

Create table Profissional
(
idProfissional int identity(1,1) primary key,
credencial varchar(6) unique not null,
nomePro varchar(30) not null,
loginPro varchar(20) unique not null,
senhaPro varchar(100) not null,
dataNascimentoPro date not null,
perfilPro varchar(12) not null,  /*Cliente ou Profissional*/
telefonePro char(11) not null
)
Go

create procedure pi_Profissional
/*parametros*/
@credencial varchar(6),
@nomePro varchar(30),
@loginPro varchar(20),
@senhaPro varchar(100),
@dataNascimentoPro date,
@perfilPro char(12),
@telefonePro char(11)
as
/*corpo*/
insert into Profissional
(credencial,nomePro,loginPro,senhaPro,dataNascimentoPro,perfilPro,telefonePro)
values 
(@credencial,@nomePro,@loginPro, @senhaPro,@dataNascimentoPro,@perfilPro,@telefonePro)

GO

create procedure ps_validaLoginPro
@loginPro varchar(20),
@senhaPro varchar(100)
as
select * from Profissional
where loginPro=@loginPro and senhaPro=@senhaPro

Go
create procedure pu_Profissional  
@credencial varchar(6), 
@nomePro varchar(30),
@loginPro varchar(20),
@dataNascimentoPro date,
@perfilPro char(12), 
@telefonePro char(11) 
as
update Profissional
set credencial = @credencial,nomePro=@nomePro,dataNascimentoPro=@dataNascimentoPro, perfilPro=@perfilPro, telefonePro = @telefonePro
where loginPro = @loginPro

GO

create procedure ps_Profissional
@chaveBuscaPro varchar(20)
as
select credencial,nomePro,dataNascimentoPro,perfilPro,telefonePro from Profissional
where loginPro=@chaveBuscaPro +'%'


-----------------avaliacao----------------------

Create table Avaliacao
(
idAvaliacao int identity(1,1) primary key,
idUsuario int,
idProfissional int,
dataAvaliacao date not null,
peso numeric (4,2) not null,
altura numeric (3,2) not null
constraint fk_idUsuario foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idProfissional foreign key(idProfissional) references Profissional (idProfissional)
)

GO

create procedure pi_Avaliacao 
@idUsuario int, 
@idProfissional int, 
@dataAvaliacao datetime ,
@peso numeric(4,2),
@altura numeric(3,2)
as
insert into Avaliacao 
(idUsuario, idProfissional, dataAvaliacao, peso, altura)
values
(@idUsuario, @idProfissional, @dataAvaliacao, @peso, @altura)

GO

create procedure ps_Avaliacao  
@idUsuario int 
as
select  Us.idUsuario, Us.nomeUsu, Pro.nomePro, Av.peso, Av.altura,Av.dataAvaliacao from Avaliacao Av 
inner join Usuario Us on Av.idUsuario = Us.idUsuario
inner join Profissional Pro on Av.idProfissional = Pro.idProfissional
where Av.idUsuario = 4 order by dataAvaliacao desc  


-----------------dieta----------------------

Create table Dieta
(
idDieta int identity(1,1) primary key,
idUsuario int,
idProfissional int,
idAvaliacao int,
restricoesAlimentares varchar(500),
dieta varchar(1000),
dataDieta date,
constraint fk_idUsuarioDieta foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idProfissionalDieta foreign key(idProfissional) references Profissional (idProfissional),
constraint fk_idAvaliacao foreign key(idAvaliacao) references Avaliacao (idAvaliacao)
)

GO

create procedure pi_Dieta 
@idUsuario int, 
@idProfissional int, 
@idAvaliacao int, 
@restricoesAlimentares varchar(500), 
@dieta varchar(1000) 
as
insert into Dieta
(idUsuario, idProfissional, idAvaliacao, restricoesAlimentares, dieta)
values
(@idUsuario, @idProfissional, @idAvaliacao, @restricoesAlimentares, @dieta)

create procedure ps_Tudo 
@idUsuario int 
as
select Us.nomeUsu, Pro.nomePro, Av.peso, Av.altura, D.dieta, D.restricoesAlimentares, Av.dataAvaliacao  from Dieta D  
inner join Usuario Us on D.idUsuario = Us.idUsuario
inner join Profissional Pro on D.idProfissional = Pro.idProfissional
inner join Avaliacao Av on D.idAvaliacao = Av.idAvaliacao
where Us.idUsuario = @idUsuario







