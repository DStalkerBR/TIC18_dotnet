namespace MercadoLinq;

public class Mercado
{
    public List<ItemMercado> Itens { get; set; }

    public Mercado()
    {
        Itens = new List<ItemMercado>();
    }

    public void AdicionarItem(string nome, Tipo tipo, double preco)
    {
        Itens.Add(new ItemMercado(nome, tipo, preco));
    }

    public void AdicionarItem(ItemMercado item)
    {
        Itens.Add(item);
    }

    public List<ItemMercado> GetHigiene()
    {
        return Itens.Where(x => x.Tipo == Tipo.Higiene).OrderByDescending(x => x.Preco).ToList();
    }

    public List<ItemMercado> GetItensGreaterThan5()
    {
        return Itens.Where(x => x.Preco >= 5).OrderBy(x => x.Preco).ToList();
    }

    public List<ItemMercado> GetComidaBebida()
    {
        return Itens.Where(x => x.Tipo == Tipo.Comida || x.Tipo == Tipo.Bebida).OrderBy(x => x.Nome).ToList();
    }

    public Dictionary<Tipo, int> GetQuantidadePorTipo()
    {
        return Itens.GroupBy(x => x.Tipo).ToDictionary(x => x.Key, x => x.Count());
    }

    public Dictionary<Tipo, (double max, double min, double media)> GetEstatisticasPorTipo()
    {
        return Itens.GroupBy(x => x.Tipo).ToDictionary(x => x.Key, x => (x.Max(y => y.Preco), x.Min(y => y.Preco), x.Average(y => y.Preco)));
    }

}
