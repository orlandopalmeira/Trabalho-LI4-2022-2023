-- Este ficheiro serve para criar todas as tabelas da base de dados.

USE eFeiras;

-- 1
CREATE TABLE Utilizador (
    id int not null  identity(1,1) PRIMARY KEY,
	userType tinyint not null,
	nome varchar(45),
	nif varchar(9),
	cartao_cidadao varchar(9),
	e_mail varchar(45),
	rua_porta_andar varchar(45),
	cidade varchar(45),
	codigo_postal varchar(45),
	apresentacao varchar(4000),
	aprovado bit not null,
	username varchar(45) not null,
	password_ varchar(45) not null
); 

-- 2
CREATE TABLE Categoria (
	id int not null  identity(1,1) PRIMARY KEY,
	nome varchar(45)	
);

-- 3
create table Subcategoria (
	id int not null  identity(1,1) PRIMARY KEY,
	nome varchar(45),
	categoria_id int not null FOREIGN KEY REFERENCES Categoria(id)
);

-- 4
create table Feira (
	id int not null  identity(1,1) PRIMARY KEY,
	titulo varchar(50) not null,
	descricao varchar(500) not null,
	data_inicio date not null,
	data_fim date not null,
	imagem varchar(500) not null,
	limite_bancas int not null,
	categoria_id int not null FOREIGN KEY REFERENCES Categoria(id)
);

-- 5
create table Banca(
	Feira_id int not null identity(1,1),
	Utilizador_id int not null,
	titulo varchar(50) not null,
	primary key (Feira_id,Utilizador_id),
);

-- 6
create table Produto(
	id int not null  identity(1,1) PRIMARY KEY,
	nome varchar(45) not null,
	descricao varchar(500) not null,
	preco decimal(7,2) not null,
	quantidade_disponivel int not null,
	imagem varchar(500) not null,
	Utilizador_id int not null foreign key references Utilizador(id),
	SubCategoria int not null foreign key references Subcategoria(id)
);

-- 7
create table banca_has_produto(
	Feira_id int not null foreign key references Feira(id),
	Utilizador_id int not null foreign key references Utilizador(id),
	Produto_id int not null foreign key references Produto(id),
	primary key (Feira_id,Utilizador_id,Produto_id)
);

-- 8
create table Compra(
	id int not null identity(1,1) primary key,
	montante decimal(7,2) not null,
	data datetime not null,
	Utilizador_id int not null foreign key references Utilizador(id)
);

-- 9 
create table compra_has_produto(
	Compra_id int not null foreign key references Compra(id),
	Produto_id int not null foreign key references Compra(id),
	quantidade int not null,
	primary key(Compra_id,Produto_id)
);