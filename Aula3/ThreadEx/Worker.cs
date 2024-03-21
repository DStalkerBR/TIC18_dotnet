namespace ThreadEx;

public class Worker
{
    private static int _id = 0;

    public int Id { get; private set; }

    public Worker()
    {
        Id = _id++;
    }
    public void Work()
    {
        Console.WriteLine($"Worker.Work() iniciado. ID: {Id}");
        for (int i = 0; i < 20; i++)
        {
            Thread.Sleep(1000); // Aguarda 1 segundo (simulando processamento)
            
            // Verificação de nonce (número aleatório)
            int nonce = new Random().Next(100000);
            if (nonce % 8 == 0) // Condição arbitrária para sucesso na mineração
            {
                Console.WriteLine($"Bloco {i} minerado com sucesso! Nonce encontrado: {nonce}. ID do Worker: {Id}");
                continue; 
            }
            
            Console.WriteLine($"Tentando realizar mineração do bloco {i}... Nonce atual: {nonce}. ID do Worker: {Id}");
        } 
        
        Console.WriteLine($"Worker.Work() finalizado. ID: {Id}");
    }

}
