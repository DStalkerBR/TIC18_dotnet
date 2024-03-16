namespace Banco
{
    public class Program
    {
        public static void Main()
        {
            var conta1 = new ContaBancaria();
            var conta2 = new ContaBancaria();

            try
            {
                conta1.Depositar(500);
                conta1.Sacar(200);
                conta1.Transferir(300, conta2);
                conta1.Transferir(1000, conta2);
                conta2.Sacar(1000);
                conta1.Depositar(-100);
            }
            catch (ValorInvalidoException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Valor inválido: {e.Valor}");
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Saldo disponível: {e.Saldo}");
            }
        }
    }
}