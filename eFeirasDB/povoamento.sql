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
	('1','Miguel Pinto','918752341','1028742','miguelpinto@hotmail.com','Rua D.Afonso Henriques, n.º80, 5Esq','Braga','4700-234',null,'1','miguelpinto','miguelpinto035'),
	('1','João Ribeiro','192783234','8172354','joaoribeiro@hotmail.com','Rua Francisco Sanches, n.º7, 4DTO','Braga','4700-846', null,'1','joaoribeiro','joaoribeiro643');

-- Inserir Categorias
-- select * from dbo.Categoria;
insert into dbo.Categoria (nome) values
	('Alimentos'),
	('Livros'),
	('Roupa'),
	('Eletrónica'),
	('Artesanato'),
	('Brinquedos');

-- select * from dbo.Subcategoria; 
insert into dbo.Subcategoria (nome,categoria_id) values
	('Legumes','1'),
	('Fruta','1'),
	('Frutos secos','1'),
	('Lacticínios','1'),
	('Livros de acção','2'),
	('Livros de drama','2'),
	('Livros de ficção','2');

-- select * from dbo.Feira;
insert into dbo.Feira (titulo,descricao,data_inicio,data_fim,imagem,limite_bancas,categoria_id) values 
	('Feira semanal de Braga','Feira semanal de Braga que costuma ser realizada no mercado municipal','2022-12-14','2023-01-10','Media/IlustrFeiras/feira_semanal.jpg','10','1'),
	('Feira do livro 2022','Feira do livro realizada em Braga','2022-12-14','2023-01-10','Media/IlustrFeiras/feira_do_livro2022.jpg','10','2'),
	('Feira de roupa usada','Feira de venda de roupas em segunda mão','2022-12-14','2023-01-10','Media/IlustrFeiras/feira_roupa_usada.jpg','10','3'),
	('Feira de eletrónica','Feira de venda de produtos eletrónicos (smartphones, tablets, etc...)','2022-12-14','2023-01-10','Media/IlustrFeiras/feira_tecnologia.jpg','10','4'),
	('Feira de artesanato','Feira de venda de produtos personalizados feitos manualmente','2022-12-14','2023-01-10','Media/IlustrFeiras/feira_artesanato.jpg','10','5');

SET IDENTITY_INSERT dbo.Banca ON; -- sou obrigado a fazer isto, não sei porquê :)
insert into dbo.Banca (Feira_id,Utilizador_id,titulo) values
	('1','5','A Banca do Sr.Alberto'),
	('1','6','Frutas e Companhia'),
	('1','7','Banca Gourmet');
SET IDENTITY_INSERT dbo.Banca OFF;

INSERT INTO dbo.Produto (nome, descricao, preco, quantidade_disponivel, imagem, Utilizador_id, SubCategoria_id)
VALUES 
	('Batata doce', 'Batata doce, unidade: 1Kg', 4.50, 20, '/Media/uploads/prod1.jpg', 5, 1),
	('Cenoura', 'Cenoura biológica, unidade: 1Kg', 3.50, 15, '/Media/uploads/prod2.jpg', 5, 1),
	('Beringela', 'Beringela, unidade: 1Kg', 2.50, 10, '/Media/uploads/prod3.jpg', 5, 1),
	('Abóbora', 'Abóbora, unidade: 1Kg', 5.00, 15, '/Media/uploads/prod4.jpg', 5, 1),
	('Espargos', 'Espargos, unidade: 1Kg', 6.00, 10, '/Media/uploads/prod5.jpg', 5, 1),
	('Maçã verde', 'Maçã verde, unidade: 1Kg', 1.50, 25, '/Media/uploads/prod6.jpg', 6, 2),
	('Pêra rocha', 'Pêra rocha, unidade: 1Kg', 2.00, 20, '/Media/uploads/prod7.jpg', 6, 2),
	('Kiwi', 'Kiwi, unidade: 1Kg', 1.75, 15, '/Media/uploads/prod8.jpg', 6, 2),
	('Manga', 'Manga, unidade: 1Kg', 2.25, 10, '/Media/uploads/prod9.jpg', 6, 2),
	('Ameixa', 'Ameixa, unidade: 1Kg', 1.50, 15, '/Media/uploads/prod10.jpg', 6, 2),
	('Amendoins', 'Amendoins descascados, unidade: 250g', 3.50, 20, '/Media/uploads/prod11.jpg', 7, 3),
	('Pistácios', 'Pistácios descascados, unidade: 250g', 4.00, 15, '/Media/uploads/prod12.jpg', 7, 3),
	('Nozes', 'Nozes frescas, unidade: 250g', 3.75, 10, '/Media/uploads/prod13.jpg', 7, 3),
	('Avelãs', 'Avelãs torradas e salgadas, unidade: 250g', 4.25, 15, '/Media/uploads/prod14.jpg', 7, 3),
	('Castanhas', 'Castanhas frescas, unidade: 250g', 3.50, 10, '/Media/uploads/prod15.jpg', 7, 3);


insert into dbo.banca_has_produto (Feira_id,Utilizador_id,Produto_id)
values
	('1','5','1'),
	('1','5','2'),
	('1','5','3'),
	('1','5','4'),
	('1','5','5'),
	('1','6','6'),
	('1','6','7'),
	('1','6','8'),
	('1','6','9'),
	('1','6','10'),
	('1','7','11'),
	('1','7','12'),
	('1','7','13'),
	('1','7','14'),
	('1','7','15');



SELECT f.titulo as 'Feira' , b.titulo as 'Banca', u.nome as 'Vendedor', p.nome as 'Produto', p.descricao as 'ProdDesc', p.preco as 'Preço'
FROM dbo.Banca b
INNER JOIN dbo.banca_has_produto bp ON b.Utilizador_id = bp.Utilizador_id AND b.Feira_id = bp.Feira_id
INNER JOIN dbo.Produto p ON bp.Produto_id = p.id
INNER JOIN dbo.Utilizador u on b.Utilizador_id = u.id
INNER JOIN dbo.Feira f ON f.id = b.Feira_id
;

