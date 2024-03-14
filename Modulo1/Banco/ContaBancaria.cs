namespace Banco;

public class ContaBancaria
{
    private double saldo;

    public ContaBancaria()
    {
        saldo = 0;
    }

    public ContaBancaria(double saldoInicial)
    {
        if (saldoInicial < 0)
        {
            throw new ValorInvalidoException(saldoInicial);
        }
        saldo = saldoInicial;
    }
    public double Saldo
    {
        get { return saldo; }
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException(valor);
        }
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException(valor);
        }
        else if (valor > saldo)
        {
            throw new SaldoInsuficienteException(saldo, valor);
        }
        saldo -= valor;
    }

    public void Transferir(double valor, ContaBancaria contaDestino)
    {
        if (valor <= 0)
        {
            throw new ValorInvalidoException(valor);
        }
        else if (valor > saldo)
        {
            throw new SaldoInsuficienteException(saldo, valor);
        }
        saldo -= valor;
        contaDestino.Depositar(valor);
    }
}
