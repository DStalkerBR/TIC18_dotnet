namespace Banco;

public class SaldoInsuficienteException : Exception
{
    public double Saldo { get; }
    public double Valor { get; }

    public SaldoInsuficienteException(double saldo, double valor)
        : base($"Saldo insuficiente para sacar o valor de {valor}. Saldo atual: {saldo}")
    {
        Saldo = saldo;
        Valor = valor;
    }

}
