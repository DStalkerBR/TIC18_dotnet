namespace MercadoLinq;

public enum Tipo
{
    Comida,
    Bebida,
    Higiene,
    Limpeza
}

public class ItemMercado
{
    public string Nome { get; set; }
    public Tipo Tipo { get; set; }
    public double Preco { get; set; }

    public ItemMercado(string nome, Tipo tipo, double preco)
    {
        Nome = nome;
        Tipo = tipo;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Tipo: {Tipo}, Preço: {Preco}";
    }

}
