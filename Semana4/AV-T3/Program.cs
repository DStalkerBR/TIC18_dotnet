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
                    App.PressioneQualquerTecla();
                }   
                switch(opcao){
                    case 1:
                        try {
                            App.CadastraCliente(clientes);
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            App.PressioneQualquerTecla();
                        }
                    break;
                    case 2:
                        try {
                            App.CadastraAdvogado(advogados);
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                            App.PressioneQualquerTecla();
                        }
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
                                App.PressioneQualquerTecla();
                            }
                            switch(opcaoRelatorio){
                                case 1:
                                    try {
                                        App.RelatorioAdvogadosIdade(advogados);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                break;
                                case 2:
                                    try {
                                        App.RelatorioClientesIdade(clientes);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                break;
                                case 3:
                                    try {
                                        App.RelatorioClientesEstadoCivil(clientes);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                break;
                                case 4:
                                    try {
                                        App.RelatorioClientesOrdemAlfabetica(clientes);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                break;
                                case 5:
                                    try {
                                        App.RelatorioClientesProfissao(clientes);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
                                break;
                                case 6:
                                    try {
                                        App.RelatorioAniversariantes(clientes, advogados);
                                    } catch (Exception e) {
                                        Console.WriteLine(e.Message);
                                        App.PressioneQualquerTecla();
                                    }
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