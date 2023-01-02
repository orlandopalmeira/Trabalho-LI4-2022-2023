use eFeiras;
-- seleciona todos os utilizadores
select * from dbo.Utilizador;

-- reinicia o auto increment da tabela 
delete from Compra;
DBCC CHECKIDENT ('dbo.Compra', RESEED, 0);
select * from Compra;
select * from compra_has_produto;
delete from compra_has_produto;
-- apaga o utilizador.
delete from dbo.Utilizador where id = 1;

select * from Produto;

select * from Banca;
update Produto set quantidade_disponivel = 30;

select * from banca_has_produto;
insert into banca_has_produto (Feira_id,Utilizador_id,Produto_id) values ('1','4','6');