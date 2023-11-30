using dotNET_P003.GerenciadorEstoque;

namespace dotNET_P003;

public static class App
{

public static Estoque CriarEstoque(){
    Estoque produtos = new Estoque();
    produtos.AdicionarProduto(new Produto(1, "Coca-Cola", 12, 5.50));
    produtos.AdicionarProduto(new Produto(2, "Pepsi", 30, 5.00));
    produtos.AdicionarProduto(new Produto(3, "Fanta", 50, 4.50));
    produtos.AdicionarProduto(new Produto(4, "Guaraná", 29, 4.00));
    return produtos;
}

public static void CadastroProdutos(Estoque produtos)
{
    int codigo;
    string? nome;
    int quantidade;
    double preco;
    Console.WriteLine("Cadastro de Produtos");

    Console.Write("Código: ");
    if (!int.TryParse(Console.ReadLine(), out codigo))
    {
        throw new Exception("Código inválido!");
    }

    Console.Write("Nome: ");
    if (string.IsNullOrEmpty(nome = Console.ReadLine()))
    {
        throw new Exception("Nome inválido!");
    }

    Console.Write("Quantidade: ");
    if (!int.TryParse(Console.ReadLine(), out quantidade))
    {
        throw new Exception("Quantidade inválida!");
    }

    Console.Write("Preço: ");
    if (!double.TryParse(Console.ReadLine(), out preco))
    {
        throw new Exception("Preço inválido!");
    }

    produtos.AdicionarProduto(new Produto(codigo, nome, quantidade, preco));

    Console.WriteLine("Produto cadastrado com sucesso!");
}


}
