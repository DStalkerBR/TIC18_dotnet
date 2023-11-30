// See https://aka.ms/new-console-template for more information
using System.Globalization;
using dotNET_P003.GerenciadorEstoque;

namespace dotNET_P003
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            Estoque produtos = App.CriarEstoque();
            int opcao = -1;
            int opcaoRelatorio = -1;

            do {
                Console.Clear();
                Console.WriteLine("Sistema de Gerenciamento de Estoque");
                Console.WriteLine("1 - Cadastro de Produtos");
                Console.WriteLine("2 - Consulta de Produtos");
                Console.WriteLine("3 - Atualizar Estoque");
                Console.WriteLine("4 - Gerar Relatório de Produtos");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite uma opção: ");
                try {
                    opcao = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                switch (opcao)
                {
                    case 1:
                        try {
                            App.CadastroProdutos(produtos);
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            App.PressioneQualquerTecla();
                        }
                        break;
                    case 2:
                        try {
                            App.ConsultaProdutos(produtos);
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            App.PressioneQualquerTecla();
                        }
                        break;
                    case 3:
                        try {
                            App.AtualizarEstoque(produtos);
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            App.PressioneQualquerTecla();
                        }
                        break;
                    case 4:
                        do {
                            Console.Clear();
                            Console.WriteLine("Gerar Relatório de Produtos");
                            Console.WriteLine("1. Produtos com estoque baixo");
                            Console.WriteLine("2. Produtos por faixa de preço");
                            Console.WriteLine("3. Valor total do estoque e de cada produto");
                            Console.WriteLine("0. Sair");
                            Console.Write("Opção: ");
                            try {
                                opcaoRelatorio = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            } catch (Exception e) {
                                Console.WriteLine(e.Message);
                                App.PressioneQualquerTecla();
                            }
                            switch (opcaoRelatorio){
                                case 1:
                                    try {
                                        // App.EstoqueBaixo(produtos);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                    break;
                                case 2:
                                    try {
                                        // App.ProdutosPorFaixaDePreco(produtos);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                    break;
                                case 3:
                                    try {
                                        // App.ValorTotalEstoque(produtos);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("Voltando...");
                                    App.PressioneQualquerTecla();
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida!");
                                    App.PressioneQualquerTecla();
                                    break;
                            }


                        } while (opcaoRelatorio != 0);
                        opcaoRelatorio = -1;
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        App.PressioneQualquerTecla();
                        break;
                }


            } while (opcao != 0);       
            
        }
    }
}