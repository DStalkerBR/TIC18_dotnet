using Pessoa;

namespace dotNET_AV_T3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Advogado> advogados = App.CriaAdvogados();
            List<Cliente> clientes = App.CriaClientes();
            int opcao = -1;
            int opcaoRelatorio = -1;
            do {
                //menu
                Console.Clear();
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar advogado");
                Console.WriteLine("3 - Listar clientes");
                Console.WriteLine("4 - Listar advogados");
                Console.WriteLine("5 - Gerar Relatórios");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                try {
                    opcao = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }   
                switch(opcao){
                    case 1:
                        App.CadastraCliente(clientes);
                    break;
                    case 2:
                        App.CadastraAdvogado(advogados);
                    break;
                    case 3:
                        App.ListaClientes(clientes);
                    break;
                    case 4:
                        App.ListaAdvogados(advogados);
                    break;
                    case 5:
                        do {
                            Console.Clear();
                            Console.WriteLine("1. Advogados com idade entre dois valores");
                            Console.WriteLine("2. Clientes com idade entre dois valores");
                            Console.WriteLine("3. Clientes por estado civil");
                            Console.WriteLine("4. Clientes em ordem alfabética");
                            Console.WriteLine("5. Clientes por profissão");
                            Console.WriteLine("6. Advogados e Clientes aniversariantes");   
                            Console.WriteLine("0. Voltar");
                            Console.Write("Opção: ");
                            try {
                                opcaoRelatorio = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                            } catch (Exception e) {
                                Console.WriteLine(e.Message);
                            }
                            switch(opcaoRelatorio){
                                case 1:
                                    App.RelatorioAdvogadosIdade(advogados);
                                break;
                                case 2:
                                    App.RelatorioClientesIdade(clientes);
                                break;
                                case 3:
                                    App.RelatorioClientesEstadoCivil(clientes);
                                break;
                                case 4:
                                    App.RelatorioClientesOrdemAlfabetica(clientes);
                                break;
                                case 5:
                                    App.RelatorioClientesProfissao(clientes);
                                break;
                                case 6:
                                    App.RelatorioAniversariantes(advogados, clientes);
                                break;
                                case 0:
                                    Console.WriteLine("Voltando...");
                                break;
                                default:
                                    Console.WriteLine("Opção inválida");
                                break;
                            }
                        } while(opcaoRelatorio != 0);
                        opcaoRelatorio = -1;                    
                    break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                    break;

                }


            }while(opcao != 0);


        }
    }
}