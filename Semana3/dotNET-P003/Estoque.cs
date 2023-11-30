namespace dotNET_P003.GerenciadorEstoque;
public class Estoque
{
    public Estoque()
    {
        this.Produtos = new List<Produto>();
    }

    public List<Produto> Produtos { get; set; }

    public void AdicionarProduto(Produto produto)
    {
        this.Produtos.Add(produto);
    }

    public void RemoverProduto(Produto produto)
    {
        this.Produtos.Remove(produto);
    }

    public Produto? ProcurarProduto(int codigo)
    {
        return this.Produtos.Find(p => p.Item.codigo == codigo);
    }
}