﻿using eFeiras.Business.Feiras;
using eFeiras.Business.Utilizadores;
using eFeiras.Business.Produtos;
using eFeiras.Business.Compras;
using eFeiras.Business.Bancas;

namespace eFeiras.Business
{
    public interface IEFeirasFacade
    {
        // Utilizadores
        public bool existsEmail(string email);

        public Utilizador getUtilizadorWithEmail(string email);

        public bool validateNewAccount(string email, string cc, string nif, string username);

        public bool adicionaConta(Utilizador utilizador);

        // Feiras
        public ICollection<Feira> getFeirasEmCurso();

        public Feira getFeira(int feiraID);

        // Produtos
        public int getQuantidadeDisponivelProduto(int produtoid);

        public int getQuantidadeDisponivelProduto(Produto produto);

        // Compras
        public void addCompra(Compra compra);

        // Bancas
        public Banca getBanca(int id_feira, int id_vendedor);

        // Relação banca_has_produto
        public void removeProdutoFromBanca(Produto p, Banca b);

        public void addToBancaHasProduto(Produto p, Banca b);

    }
}
