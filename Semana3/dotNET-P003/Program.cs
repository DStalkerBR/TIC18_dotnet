// See https://aka.ms/new-console-template for more information
using dotNET_P003.GerenciadorEstoque;

namespace dotNET_P003
{
    class Program
    {
        static void Main(string[] args)
        {
            Estoque produtos = App.CriarEstoque();

            Console.WriteLine("Bem-vindo ao sistema de cadastro de produtos!");
            Console.WriteLine("Cadastre um produto para começar!");
            try
            {
                App.CadastroProdutos(produtos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}