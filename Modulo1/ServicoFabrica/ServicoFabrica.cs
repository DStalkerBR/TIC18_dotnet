namespace ServicoFabrica
{
    public class ServicoFabrica<T> where T : IServico, new()
    {
        public T NovaInstancia()
        {
            return new T();
        }
    }
    public class Manutencao : IServico
    {
        public void Executar()
        {
            Console.WriteLine("Executando manutenção...");
        }
    }

    public class Relatorio : IServico
    {
        public void Executar()
        {
            Console.WriteLine("Gerando relatório...");
        }
    }

    public class Teste
    {
        public void Testar()
        {
            Console.WriteLine("Testando...");
        }
    }
    
}