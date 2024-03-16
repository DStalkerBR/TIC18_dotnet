namespace Banco;
public class ValorInvalidoException : Exception
{
    public double Valor { get; }

    public ValorInvalidoException(double valor)
        : base($"O valor {valor} é inválido. Deve ser maior que zero.")
    {
        Valor = valor;
    }
}