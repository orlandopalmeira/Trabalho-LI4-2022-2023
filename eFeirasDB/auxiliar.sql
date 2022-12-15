use eFeiras;
-- seleciona todos os utilizadores
select * from dbo.Utilizador;

-- reinicia o auto increment da tabela dos utilizadores
DBCC CHECKIDENT ('dbo.Utilizador', RESEED, 0)

-- apaga o utilizador.
delete from dbo.Utilizador where id = 1;