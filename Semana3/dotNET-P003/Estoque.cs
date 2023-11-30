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
}