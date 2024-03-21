namespace AsyncEx;

class Program
{
    static async Task DoWorkAsync(string taskName)
    {
        for (int i = 0; i < 10; i++)
        {
            // Aguarda um tempo aleatório (simulando processamento)
            await Task.Delay(new Random().Next(100, 2000)); 

            // Calcula o progresso da tarefa de acordo com o número de iterações
            int progress = i + 1;

            // Exibe o progresso da tarefa no formato: "Tarefa 1 em andamento... [#####-------------------] 3/10"
            Console.WriteLine($"{taskName} em andamento... [{new string('#', progress)}{new string('-', 10 - progress)}] {i + 1}/{10}");
        }
        Console.WriteLine($"{taskName} concluída!");
    }

    static async Task Main(string[] args)
    {
        Task task1 = DoWorkAsync("Tarefa 1");
        Task task2 = DoWorkAsync("Tarefa 2");

        await Task.WhenAll(task1, task2);
        Console.WriteLine("Ambas as tarefas foram concluídas!");
    }
}