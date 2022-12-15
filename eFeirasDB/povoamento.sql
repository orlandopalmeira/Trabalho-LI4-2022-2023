-- Script de povoamento
use eFeiras;
-- userType -> 0: ADMIN, 1: COMPRADOR, 2: VENDEDOR 

-- Inserir Administradores
insert into dbo.Utilizador (userType,nome,nif,cartao_cidadao,e_mail,rua_porta_andar,cidade,codigo_postal,apresentacao,aprovado,username,password_) values
	('0',null,null,null,null,null,null,null,null,'1','root0','eFeirasRoot0'),
	('0',null,null,null,null,null,null,null,null,'1','root1','eFeirasRoot1');

-- Inserir Vendedores
insert into dbo.Utilizador (userType,nome,nif,cartao_cidadao,e_mail,rua_porta_andar,cidade,codigo_postal,apresentacao,aprovado,username,password_) values
	('2','Alberto Magalhães','123456789','7654321','albertomagalhaes@gmail.com','Rua de Cima, n.º10, 3DTO','Braga','4710-000',null,'1','bertomagalhaes','bertomag123'),
	('2','Cristina Pais','987654321','1234567','cristinapais@gmail.com','Rua de Baixo, n.º30, 2ESQ','Braga','4710-120',null,'1','crispais','crispais432'),
	('2','Ermelinda Silva','928374233','2873463','ermelindasilva@hotmail.com','Rua da Alegria, n.º33, 1DTO','Braga','4700-454',null,'1','erm_silva','ermsilva999');

-- Inserir Compradores
insert into dbo.Utilizador (userType,nome,nif,cartao_cidadao,e_mail,rua_porta_andar,cidade,codigo_postal,apresentacao,aprovado,username,password_) values
	('1','Orlando Palmeira','921378463','1283746','orlandopalmeira@gmail.com','Avenida da Liberdade, n.º5, 5Esq','Braga','4700-234', null,'1','orlandopalmeira','orlando912'),
	('1','Pedro Martins','198482172','9283475','pedromartins@gmail.com','Rua 1º de Maio, n.º23, 3ESQ','Braga','4700-923',null,'1','pedromartins','pedromartins123'),
	('1','Miguel Pinto','918752341','1028742','miguelpinto@hotmail.com','Rua Pedro Rocha, n.º5, 5Esq','Braga','4700-234',null,'1','miguelpinto','miguelpinto035'),
	('1','João Ribeiro','192783234','8172354','joaoribeiro@hotmail.com','Rua Francisco Sanches, n.º7, 4DTO','Braga','4700-846', null,'1','joaoribeiro','joaoribeiro643');

-- Inserir Categorias
insert into dbo.Categoria (nome) values
	('Alimentos'),
	(''),
	(''),
	(''),
	(''),
	(''),
	(''),
	(''),
	('');

