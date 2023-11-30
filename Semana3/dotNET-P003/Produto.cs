namespace dotNET_P003.GerenciadorEstoque;

public class Produto
{
    public Produto(int codigo, string nome, int quantidade, double precoUnit)
    {
        this.Item = (codigo, nome, quantidade, precoUnit);
    }

    public (int codigo, string nome, int quantidade, double precoUnit) Item { get; set; }
}

