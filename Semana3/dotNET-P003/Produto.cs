namespace dotNET_P003.GerenciadorEstoque;

public class Produto
{
    public Produto(int codigo, string nome, int quantidade, double precoUnit)
    {
        Item = (codigo, nome, quantidade, precoUnit);
    }

    public (int codigo, string nome, int quantidade, double precoUnit) Item { get;  set; }

    // função pra atualizar nome
    public void AtualizarNome(string nome)
    {
        this.Item = (this.Item.codigo, nome, this.Item.quantidade, this.Item.precoUnit);
    }

    // função pra atualizar quantidade
    public void AtualizarQuantidade(int quantidade)
    {
        if ((this.Item.quantidade + quantidade) < 0)
        {
            throw new Exception("Quantidade insuficiente em estoque");
        }
        else
        {
            this.Item = (this.Item.codigo, this.Item.nome, this.Item.quantidade + quantidade, this.Item.precoUnit);
        }
    }

    // função pra atualizar preço
    public void AtualizarPreco(double precoUnit)
    {
        if (precoUnit < 0)
        {
            throw new Exception("Preço inválido");
        }
        else
        {
            this.Item = (this.Item.codigo, this.Item.nome, this.Item.quantidade, precoUnit);
        }
    }

    public override string ToString()
    {
        return $"Código: {this.Item.codigo}\nNome: {this.Item.nome}\nQuantidade: {this.Item.quantidade}\nPreço: {this.Item.precoUnit:C2}";
    }
}

