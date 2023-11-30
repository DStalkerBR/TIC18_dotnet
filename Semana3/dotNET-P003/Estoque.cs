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

    // Crie funções que permitam a atualização da quantidade em estoque de um produto, levando em consideração entradas ou saídas. Faça o tratamento
    // lógico para lidar com casos em que a quantidade atual seja insuficiente para uma saída.

    public void AtualizarEstoque(Produto produto, int quantidade)
    {           
        produto.AtualizarQuantidade(quantidade);
    }
}