using dotNET_P003.GerenciadorEstoque;

namespace dotNET_P003;

public static class App
{

    /// <summary>
    /// Cria um estoque de produtos com alguns produtos já cadastrados.
    /// </summary>
    /// <returns> O estoque de produtos </returns>
    public static Estoque CriarEstoque()
    {
        Estoque estoque = new Estoque();
        estoque.AdicionarProduto(new Produto(1, "Coca-Cola", 12, 5.50));
        estoque.AdicionarProduto(new Produto(2, "Pepsi", 30, 5.00));
        estoque.AdicionarProduto(new Produto(3, "Fanta", 50, 4.50));
        estoque.AdicionarProduto(new Produto(4, "Guaraná", 29, 4.00));
        return estoque;
    }

    /// <summary>
    /// Realiza o cadastro de produtos no estoque.
    /// </summary>
    /// <param name="estoque">O objeto Estoque onde o produto será adicionado.</param>
    public static void CadastroProdutos(Estoque estoque)
    {
        int codigo;
        string? nome;
        int quantidade;
        double preco;
        Console.Clear();
        Console.WriteLine("Cadastro de Produtos");

        Console.Write("Código: ");
         if (!int.TryParse(Console.ReadLine(), out codigo))
        {
            throw new Exception("Código inválido!");
        }

        if (estoque.Produtos.Any(produto => produto.Item.codigo == codigo))
        {
            throw new Exception("Código já cadastrado!");
        }
        
   
        Console.Write("Nome: ");
        if (string.IsNullOrEmpty(nome = Console.ReadLine()))
        {
            throw new Exception("Nome inválido!");
        }

        Console.Write("Quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
        {
            throw new Exception("Quantidade inválida!");
        }

        Console.Write("Preço: ");
        if (!double.TryParse(Console.ReadLine(), out preco) || preco < 0)
        {
            throw new Exception("Preço inválido!");
        }

        estoque.AdicionarProduto(new Produto(codigo, nome, quantidade, preco));

        Console.WriteLine("Produto cadastrado com sucesso!");
        App.PressioneQualquerTecla();
    }

    /// <summary>
    /// Realiza a consulta de produtos no estoque com base no código informado.
    /// </summary>
    /// <param name="estoque">O objeto Estoque que contém os produtos.</param>
    public static void ConsultaProdutos(Estoque estoque){
        Console.Clear();
        Console.WriteLine("Consulta de Produtos");
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Produto? produto = estoque.ProcurarProduto(codigo);
        if (produto == null)
        {
            throw new Exception("Produto não encontrado");
        }
        else
        {
            Console.WriteLine($"Nome: {produto.Item.nome}");
            Console.WriteLine($"Quantidade: {produto.Item.quantidade}");
            Console.WriteLine($"Preço: {produto.Item.precoUnit}");
            App.PressioneQualquerTecla();
        }
    }

    /// <summary>
    /// Atualiza o estoque de um produto com base na movimentação informada.
    /// </summary>
    /// <param name="estoque">O objeto Estoque que contém os produtos.</param>
    public static void AtualizarEstoque(Estoque estoque){
        Console.Clear();
        Console.WriteLine("Atualizar Estoque");
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Produto? produto = estoque.ProcurarProduto(codigo);
        if (produto == null)
        {
            throw new Exception("Produto não encontrado");
        }
        Console.WriteLine("Tipo de movimentação: ");
        Console.WriteLine("1. Entrada ");
        Console.WriteLine("2. Saída ");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (opcao == 1)
        {
            estoque.AtualizarEstoque(produto, quantidade);
        }
        else if (opcao == 2)
        {
            estoque.AtualizarEstoque(produto, -quantidade);
        }
        else
        {
            throw new Exception("Opção inválida");
        }
        Console.WriteLine("Estoque atualizado com sucesso!");
        App.PressioneQualquerTecla();
    }

    /// <summary>
    /// Filtra e exibe os produtos com estoque abaixo de um limite especificado.
    /// </summary>
    /// <param name="estoque">O objeto Estoque contendo a lista de produtos.</param>
    public static void EstoqueBaixo(Estoque estoque){
        Console.Clear();
        Console.WriteLine("Produtos com estoque baixo");
        Console.Write("Digite o limite de estoque: ");
        int limite = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        if (limite < 0)
        {
            throw new Exception("Limite inválido");
        }

        IEnumerable<Produto> produtos;
        Func<Estoque, int, IEnumerable<Produto>> estoqueBaixo = (Estoque estoque, int limite) => estoque.Produtos.Where(produto => produto.Item.quantidade < limite);
        produtos = estoqueBaixo(estoque, limite);

        if (produtos.Count() == 0)
        {
            throw new Exception("Nenhum produto encontrado");
        }

        Console.WriteLine(string.Join("\n\n", produtos.Select(produto => produto.ToString())));

        App.PressioneQualquerTecla();
    }

    /// <summary>
    /// Filtra e exibe os produtos de um estoque de acordo com uma faixa de preço especificada.
    /// </summary>
    /// <param name="estoque">O estoque de produtos.</param>
    public static void ProdutosPorFaixaDePreco(Estoque estoque){
        Console.Clear();
        Console.WriteLine("Produtos por faixa de preço");
        Console.Write("Digite o preço mínimo: ");
        double minimo = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("Digite o preço máximo: ");
        double maximo = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (minimo < 0 || maximo < 0)
        {
            throw new Exception("Preço inválido");
        } else {
            if (minimo > maximo)
            {
                throw new Exception("Preço mínimo maior que preço máximo");
            }
        }

        IEnumerable<Produto> produtos;
        Func<Estoque, double, double, IEnumerable<Produto>> produtosPorFaixaDePreco = (Estoque estoque, double minimo, double maximo) => estoque.Produtos.Where(produto => produto.Item.precoUnit >= minimo && produto.Item.precoUnit <= maximo);
        produtos = produtosPorFaixaDePreco(estoque, minimo, maximo);

        if (produtos.Count() == 0)
        {
            throw new Exception("Nenhum produto encontrado");
        }

        Console.WriteLine(string.Join("\n\n", produtos.Select(produto => produto.ToString())));
        App.PressioneQualquerTecla();
    }

    /// <summary>
    /// Calcula o valor total do estoque e o valor total de cada produto.
    /// </summary>
    /// <param name="estoque"> O estoque de produtos </param>
    public static void ValorTotalEstoque(Estoque estoque){
        Console.Clear();
        Console.WriteLine("Valor total do estoque e de cada produto");
        
        double valorTotalEstoque;
        Func<Estoque, double> valorTotal = (Estoque estoque) => estoque.Produtos.Sum(produto => produto.Item.quantidade * produto.Item.precoUnit);
        valorTotalEstoque = valorTotal(estoque);

        Console.WriteLine("Valor total do estoque: ");
        Console.WriteLine(valorTotalEstoque);

        Console.WriteLine("Valor total de cada produto: ");
        IEnumerable<Produto> produtos;
        Func<Estoque, IEnumerable<Produto>> valorTotalPorProduto = (Estoque estoque) => estoque.Produtos.Select(produto => new Produto(produto.Item.codigo, produto.Item.nome, produto.Item.quantidade, produto.Item.quantidade * produto.Item.precoUnit));
        produtos = valorTotalPorProduto(estoque);

        if (produtos.Count() == 0)
        {
            throw new Exception("Nenhum produto encontrado");
        }

        Console.WriteLine(string.Join("\n\n", produtos.Select(produto => produto.ToString())));

        App.PressioneQualquerTecla();
    }

    /// <summary>
    /// Exibe uma mensagem na tela e aguarda a pressionar de qualquer tecla.
    /// </summary>
    public static void PressioneQualquerTecla()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

}
