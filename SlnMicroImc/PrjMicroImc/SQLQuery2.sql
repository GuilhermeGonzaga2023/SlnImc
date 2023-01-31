-----------------usuario----------------------
Create table Usuario
(
idUsuario int identity primary key,
nomeUsu varchar(30) not null,
loginUsu varchar(20) unique not null,
senhaUsu varchar(100) not null,
dataNascimentoUsu datetime not null,
telefoneUsu char(11) not null
)

drop table Usuario

--exec pd_Usuario '123'
select*from Usuario
select*from Medico
select*from Avaliacao
select*from Dieta
GO
create procedure pi_usuario
/*parametros*/
@nomeUsu varchar(30),
@loginUsu varchar(20),
@senhaUsu varchar(100),
@dataNascimentoUsu datetime,
@telefoneUsu char(11) 
as
/*corpo*/
insert into Usuario
(nomeUsu, loginUsu,senhaUsu,dataNascimentoUsu,telefoneUsu)
values (@nomeUsu,@loginUsu, @senhaUsu, @dataNascimentoUsu,@telefoneUsu)


drop procedure pi_usuario

GO

create procedure ps_validaLoginUsu
@loginUsu varchar(20),
@senhaUsu varchar(100)
as
select * from Usuario
where loginUsu=@loginUsu and senhaUsu=@senhaUsu

exec ps_validaLoginUsu 'cod','cod'
--drop procedure ps_validaLoginUsu

Go

create procedure pu_usuario
@idUsuario int,
@nomeUsu varchar(30),
@loginUsu varchar(20),
@senhaUsu varchar(100),
@dataNascimentoUsu datetime, 
@telefoneUsu char(11) 
as
update Usuario 
set nomeUsu = @nomeUsu,loginUsu=@loginUsu,senhaUsu=@senhaUsu ,dataNascimentoUsu = @dataNascimentoUsu, telefoneUsu = @telefoneUsu
where idUsuario=@idUsuario

exec pu_usuario '4','pombo','p','p','2000-03-09','13123456789'
exec pu_usuario '4','pombo','p','p','2000-03-09','13123456789'
drop procedure pu_usuario

GO

create procedure ps_usuario
@nomeUsu varchar(30)
as
select * from Usuario
where nomeUsu like '%'+@nomeUsu+'%'


exec ps_Usuario ''
select*from Usuario

drop procedure ps_usuario

GO

create procedure pd_usuario
/*parametros*/
@loginUsu varchar(20)
as
/*corpo*/
delete Usuario
where loginUsu=@loginUsu

exec pd_usuario 'vi'
--drop procedure pd_usuario

Go

-----------------Medico---------------------

Create table Medico
(
idMedico int identity(1,1) primary key,
credencial varchar(6) unique not null,
nomeMedico varchar(30) not null,
loginMedico varchar(20) unique not null,
senhaMedico varchar(100) not null,
dataNascimentoMedico datetime not null,
telefoneMedico char(11) not null
)

drop table Medico

Go

create procedure pd_Medico
/*parametros*/
@loginMedico varchar(20)
as
/*corpo*/
delete Medico
where loginMedico=@loginMedico

--drop procedure pd_Medico
GO

create procedure pi_Medico
/*parametros*/
@credencial varchar(6),
@nomeMedico varchar(30),
@loginMedico varchar(20),
@senhaMedico varchar(100),
@dataNascimentoMedico datetime,
@telefoneMedico char(11)
as
/*corpo*/
insert into Medico
(credencial,nomeMedico,loginMedico,senhaMedico,dataNascimentoMedico,telefoneMedico)
values 
(@credencial,@nomeMedico,@loginMedico, @senhaMedico,@dataNascimentoMedico,@telefoneMedico)

select*from medico

exec pi_medico '123123','gui','aaa','aaa','2002-09-24','00123456789'

drop procedure pi_medico

GO

create procedure ps_validaLoginMedico
@loginMedico varchar(20),
@senhaMedico varchar(100)
as
select * from Medico
where loginMedico=@loginMedico and senhaMedico=@senhaMedico

--drop procedure ps_validaLoginMedico

Go

create procedure pu_Medico  
@idMedico int,
@credencial varchar(6), 
@nomeMedico varchar(30),
@loginMedico varchar(20),
@senhaMedico varchar(100),
@dataNascimentoMedico datetime,
@telefoneMedico char(11) 
as
update Medico
set credencial = @credencial, nomeMedico=@nomeMedico, loginMedico = @loginMedico, senhaMedico = @senhaMedico, dataNascimentoMedico=@dataNascimentoMedico, telefoneMedico = @telefoneMedico
where idMedico=@idMedico

select*from medico

exec pu_medico '1','123123','gui','aaa','aaa','2002-09-24','00123456789'

drop procedure pu_Medico

GO

create procedure ps_Medico
@nomeMedico varchar(20)
as
select * from Medico
where nomeMedico like '%'+ @nomeMedico +'%'

drop procedure ps_Medico

-----------------avaliacao----------------------

Create table Avaliacao
(
idAvaliacao int identity(1,1) primary key,
idUsuario int,
idMedico int,
dataAvaliacao date not null,
peso numeric (5,2) not null,
altura numeric (3,2) not null
constraint fk_idUsuario foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idMedico foreign key(idMedico) references Medico (idMedico)
)
select*from Avaliacao

drop table Avaliacao

GO

create procedure pi_Avaliacao 
@idUsuario int, 
@idMedico int, 
@dataAvaliacao date,
@peso numeric(5,2),
@altura numeric(3,2)
as
insert into Avaliacao 
(idUsuario, idMedico, dataAvaliacao, peso, altura)
values
(@idUsuario, @idMedico, @dataAvaliacao, @peso, @altura)

--drop procedure pi_Avaliacao

GO

create procedure ps_Ava
@nomeUsu varchar(20)
as
select Av.idAvaliacao,Us.idUsuario,Med.idMedico,Us.nomeUsu, Med.nomeMedico, Av.peso, Av.altura,Av.dataAvaliacao from Avaliacao Av
inner join Usuario Us on Av.idUsuario = Us.idUsuario
inner join Medico Med on Av.idMedico = Med.idMedico
where Us.nomeUsu like '%'+ @nomeUsu + '%' order by dataAvaliacao desc
--where @dataAvaliacao like '%'+ @dataAvaliacao +'%' order by dataAvaliacao desc

exec ps_ava 'fernando'
drop procedure ps_Ava

Go
create procedure ps_Avaliacao  
@idUsuario int 
as
select  Us.nomeUsu, Med.nomeMedico, Av.peso, Av.altura,Av.dataAvaliacao from Avaliacao Av 
inner join Usuario Us on Av.idUsuario = Us.idUsuario
inner join Medico Med on Av.idMedico = Med.idMedico
where Av.idUsuario = @idUsuario order by dataAvaliacao desc  

exec ps_Avaliacao '7'

drop procedure ps_Avaliacao

select*from Avaliacao
-----------------dieta---------------------- 

Create table Dieta
(
idDieta int identity(1,1) primary key,
idUsuario int,
idMedico int,
idAvaliacao int,
dieta varchar(1000),
restricoesAlimentares varchar(500),
constraint fk_idUsuarioDieta foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idMedicolDieta foreign key(idMedico) references Medico (idMedico),
constraint fk_idAvaliacao foreign key(idAvaliacao) references Avaliacao (idAvaliacao)
)

drop table Dieta

GO

create procedure pi_Dieta 
@idUsuario int, 
@idMedico int, 
@idAvaliacao int, 
@dieta varchar(1000),
@restricoesAlimentares varchar(500)
as
insert into Dieta
(idUsuario, idMedico, idAvaliacao, restricoesAlimentares, dieta)
values
(@idUsuario, @idMedico, @idAvaliacao, @restricoesAlimentares, @dieta)

drop procedure pi_Dieta
GO

create procedure pu_Dieta
@idDieta int,
--@idUsuario int, 
--@idMedico int, 
--@idAvaliacao int, 
@dieta varchar(1000),
@restricoesAlimentares varchar(500)
as
update Dieta
set restricoesAlimentares = @restricoesAlimentares, dieta=@dieta
where idDieta=@idDieta
--where idUsuario=@idUsuario and idMedico=@idMedico and idAvaliacao=@idAvaliacao

exec pu_Dieta '4','funk','pop e guitarra'
drop procedure pu_Dieta

GO
select*from Dieta
select*from Avaliacao
exec ps_dieta 'michael jackson'
exec ps_Ava ''
GO

create procedure ps_Dieta
@nomeUsu varchar (30)
as
select idDieta,Us.nomeUsu, Med.nomeMedico, Av.peso, Av.altura, D.dieta, D.restricoesAlimentares, Av.dataAvaliacao  from Dieta D  
inner join Usuario Us on D.idUsuario = Us.idUsuario
inner join Medico Med on D.idMedico = Med.idMedico
inner join Avaliacao Av on D.idAvaliacao = Av.idAvaliacao
where nomeUsu like '%'+ @nomeUsu +'%' order by dataAvaliacao desc

drop procedure ps_Dieta
GO

create procedure ps_Tudo 
@idUsuario int 
as
select Us.nomeUsu, Med.nomeMedico, Av.peso, Av.altura, D.dieta, D.restricoesAlimentares, Av.dataAvaliacao  from Dieta D  
inner join Usuario Us on D.idUsuario = Us.idUsuario
inner join Medico Med on D.idMedico = Med.idMedico
inner join Avaliacao Av on D.idAvaliacao = Av.idAvaliacao
where Us.idUsuario = @idUsuario order by dataAvaliacao desc

exec ps_Tudo '7'
drop procedure ps_tudo





