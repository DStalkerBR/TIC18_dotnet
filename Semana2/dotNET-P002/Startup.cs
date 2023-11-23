namespace dotNET_P002;
public class Startup
{
    /// <summary>
    /// Cria uma nova tarefa com base nas informações fornecidas pelo usuário e a adiciona à lista de tarefas.
    /// </summary>
    /// <param name="tarefas">A lista de tarefas onde a nova tarefa será adicionada.</param>
    public static void CriarTarefa(Tarefas tarefas)
    {
        string titulo;
        string descricao;
        Console.Write("Digite o título da tarefa: ");
        titulo = Console.ReadLine();
        Console.Write("Digite a descrição da tarefa: ");
        descricao = Console.ReadLine();
        Console.Write("Digite a data de vencimento da tarefa: ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataDeVencimento))
        {
            Console.WriteLine("Data inválida!");
            return;
        }
        tarefas.adicionarTarefa(new Tarefa(titulo, descricao, DateTime.Now, dataDeVencimento));
    }

    /// <summary>
    /// Edita uma tarefa permitindo que o usuário modifique seu título, descrição e data de vencimento.
    /// </summary>
    /// <param name="tarefas">A lista de tarefas.</param>
    public static void EditarTarefa(Tarefas tarefas)
    {
        string titulo;
        string descricao;
        DateTime dataDeVencimento;
        Tarefa? tarefa;
        Tarefas? tarefasEncontradas = MenuObtemTarefa(tarefas, "Editar");
        int opEscolheTarefa;
        int opMenuEditarTarefa;

        if (tarefasEncontradas is not null)
        {
            Console.Clear();
            Console.WriteLine("<Tarefas Disponíveis>:");
            tarefasEncontradas.listarTarefas();
            Console.Write("Escolha uma opção para editar: ");
            opEscolheTarefa = int.Parse(Console.ReadLine());
            tarefa = tarefasEncontradas.getTarefa(opEscolheTarefa);
            if (tarefa is not null)
            {                
                do
                {
                    Console.Clear();
                    Console.WriteLine(tarefa.exibeFormatado());
                    Console.WriteLine("1 - Editar título");
                    Console.WriteLine("2 - Editar descrição");
                    Console.WriteLine("3 - Editar data de vencimento");
                    Console.WriteLine("0 - Voltar");
                    Console.Write("Escolha uma opção: ");
                    opMenuEditarTarefa = int.Parse(Console.ReadLine());
                    switch (opMenuEditarTarefa)
                    {
                        case 1:
                            Console.Write("Digite o novo título: ");
                            titulo = Console.ReadLine();
                            Console.WriteLine(tarefa.getTitulo() + " -> " + titulo);
                            tarefa.setTitulo(titulo);
                            break;
                        case 2:
                            Console.Write("Digite a nova descrição: ");
                            descricao = Console.ReadLine();
                            Console.WriteLine(tarefa.getDescricao() + " -> " + descricao);
                            tarefa.setDescricao(descricao);
                            break;
                        case 3:
                            Console.Write("Digite a nova data de vencimento: ");
                            if (!DateTime.TryParse(Console.ReadLine(), out dataDeVencimento))
                            {
                                Console.WriteLine("Data inválida!");
                                continue;
                            }
                            Console.WriteLine(tarefa.getDataDeVencimento() + " -> " + dataDeVencimento);
                            tarefa.setDataDeVencimento(dataDeVencimento);
                            break;
                        case 0:
                            continue;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                } while (opMenuEditarTarefa != 0);
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Marca uma tarefa como concluida
    /// </summary>
    /// <param name="tarefas">A lista de tarefas.</param>
    public static void marcarConcluida(Tarefas tarefas)
    {
        Tarefas? tarefasEncontradas = MenuObtemTarefa(tarefas, "Marcar como concluída");
        int opEscolheTarefa;     
        Tarefa? tarefa;   

        if (tarefasEncontradas is not null)
        {
            Console.WriteLine("<Tarefas encontradas>:");
            tarefasEncontradas.listarTarefas();
            Console.Write("Escolha uma opção: ");
            if (int.TryParse(Console.ReadLine(), out opEscolheTarefa))
            {
                tarefa = tarefasEncontradas.getTarefa(opEscolheTarefa);
                if (tarefa is not null){
                    tarefa.marcarConcluida();
                    Console.WriteLine("Tarefa " + tarefa.getTitulo() + " concluída!");
                }
                else
                {
                    Console.WriteLine("Tarefa inválida!");
                }                
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }        
    }

    /// <summary>
    /// Exclui uma tarefa da lista de tarefas.
    /// </summary>
    /// <param name="tarefas">A lista de tarefas.</param>
    public static void ExcluirTarefa(Tarefas tarefas)
    {
        Tarefas? tarefasEncontradas = MenuObtemTarefa(tarefas, "Excluir");
        int opEscolheTarefa;
        string confirmacao;
        
        if (tarefasEncontradas is not null)
        {
            Console.WriteLine("<Tarefas encontradas>:");
            tarefasEncontradas.listarTarefas();
            Console.Write("Escolha uma opção: ");
            if (int.TryParse(Console.ReadLine(), out opEscolheTarefa))
            {
                Console.WriteLine("Tem certeza que deseja excluir a tarefa? (S/N)");
                confirmacao = Console.ReadLine();
                if (confirmacao == "S" || confirmacao == "s")
                {
                    tarefas.removerTarefa(opEscolheTarefa);
                    Console.WriteLine("Tarefa excluída!");

                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
 
    }

    /// <summary>
    /// Pesquisa tarefas com base em uma palavra-chave e exibe as tarefas encontradas.
    /// </summary>
    /// <param name="tarefas">Objeto contendo a lista de tarefas.</param>
    public static void PesquisarTarefa(Tarefas tarefas)
    {     
        Console.Write("Digite uma palavra chave: ");
        string palavraChave = Console.ReadLine();
        Tarefas? tarefasEncontradas = tarefas.pesquisarTarefas(palavraChave);
        if (tarefasEncontradas is not null)
        {
            Console.WriteLine("<Tarefas encontradas>:");
            tarefasEncontradas.listarTarefas();
        }
        else
        {
            Console.WriteLine("Nenhuma tarefa encontrada!");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Exibe as estatísticas das tarefas.
    /// </summary>
    /// <param name="tarefas">Objeto contendo as tarefas.</param>
    public static void ExibeEstatisticas(Tarefas tarefas)
    {
        int tarefasConcluidas;
        Console.WriteLine("Quantidade de tarefas: " + tarefas.getQuantidade());
        tarefasConcluidas = tarefas.getQntConcluidas();
        Console.WriteLine("Quantidade de tarefas concluídas: " + tarefas.getQntConcluidas());
        Console.WriteLine("Quantidade de tarefas pendentes: " + (tarefas.getQuantidade() - tarefasConcluidas));
        Console.WriteLine("Tarefa mais antiga:\n" + tarefas.getTarefaAntiga().exibeFormatado());
        Console.WriteLine("Tarefa mais recente:\n " + tarefas.getTarefaRecente().exibeFormatado());
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Obtém uma tarefa com base na escolha do usuário.
    /// </summary>
    /// <param name="tarefas">Objeto contendo as tarefas disponíveis.</param>
    /// <returns>A tarefa selecionada ou null se o usuário escolher voltar.</returns>
    private static Tarefas? MenuObtemTarefa(Tarefas tarefas, string operacao){
        string palavraChave;
        int opMenuObterTarefa;
        do
        {
            Console.Clear();
            Console.WriteLine("<Obter tarefa para: " + operacao + ">");
            Console.WriteLine("1 - Pesquisar tarefa");
            Console.WriteLine("2 - Listar todas as tarefas");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");
            opMenuObterTarefa = int.Parse(Console.ReadLine());
            switch (opMenuObterTarefa)
            {
                case 1:
                    Console.Write("Pesquise a tarefa: ");
                    palavraChave = Console.ReadLine();
                    return tarefas.pesquisarTarefas(palavraChave);
                case 2:
                    return tarefas;
                case 0:
                    continue;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (opMenuObterTarefa != 0);
        return null;
    }

    public static void Main(string[] args)
    {
        Tarefas tarefas = new Tarefas();
        int opMenuPrincipal = -1;
        int opMenuListaTarefas;
        tarefas.adicionarTarefa(new Tarefa("Fazer compras", "Comprar mantimentos para a semana", DateTime.Now, DateTime.Now.AddDays(2)));
        tarefas.adicionarTarefa(new Tarefa("Estudar", "Estudar para a prova de Compiladores", DateTime.Now, DateTime.Now.AddDays(1)));
        tarefas.adicionarTarefa(new Tarefa("Limpar a casa", "Realizar a faxina completa", DateTime.Now, DateTime.Now.AddDays(5)));

        while (opMenuPrincipal != 0)
        {
            Console.Clear();
            Console.WriteLine("<Menu>:");
            Console.WriteLine("1 - Listar tarefas");
            Console.WriteLine("2 - Criar tarefa");
            Console.WriteLine("3 - Editar tarefa");
            Console.WriteLine("4 - Marcar tarefa como concluída");
            Console.WriteLine("5 - Excluir uma tarefa");
            Console.WriteLine("6 - Pesquisar tarefa por palavra chave");
            Console.WriteLine("7 - Estatisticas");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite uma opção: ");
            opMenuPrincipal = int.Parse(Console.ReadLine());
            switch (opMenuPrincipal)
            {
                case 1:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("<Lista de Tarefas>:");
                        Console.WriteLine("1 - Listar todas as tarefas");
                        Console.WriteLine("2 - Listar tarefas concluídas");
                        Console.WriteLine("3 - Listar tarefas não concluídas");
                        Console.WriteLine("0 - Voltar");
                        Console.Write("Digite uma opção: ");
                        opMenuListaTarefas = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (opMenuListaTarefas)
                        {
                            case 1:
                                Console.WriteLine("<Todas as tarefas>:");
                                tarefas.listarTarefas();
                                break;
                            case 2:
                                Console.WriteLine("<Tarefas concluídas>:");
                                tarefas.listarTarefas(true);
                                break;
                            case 3:
                                Console.WriteLine("<Tarefas Pendentes>:");
                                tarefas.listarTarefas(false);
                                break;
                            case 0:
                                continue;
                            default:
                                Console.WriteLine("Opção inválida!");
                                break;
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    } while (opMenuListaTarefas != 0);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("<Criar tarefa>:");
                    CriarTarefa(tarefas);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("<Editar tarefa>: ");
                    EditarTarefa(tarefas);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("<Marcar tarefa como concluída>:");
                    marcarConcluida(tarefas);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("<Excluir Tarefa>:");
                    ExcluirTarefa(tarefas);
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("<Pesquisar tarefa>:");
                    PesquisarTarefa(tarefas);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("<Estatísticas>:");
                    ExibeEstatisticas(tarefas);
                    break;
                case 0:
                    continue;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

    }
}
