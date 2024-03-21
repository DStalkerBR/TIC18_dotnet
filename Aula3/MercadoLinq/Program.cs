using MercadoLinq;

Mercado mercado = new Mercado();
mercado.AdicionarItem("Arroz", Tipo.Comida, 3.90);
mercado.AdicionarItem("Azeite", Tipo.Comida, 2.50);
mercado.AdicionarItem("Macarrão", Tipo.Comida, 3.90);
mercado.AdicionarItem("Cerveja", Tipo.Bebida, 22.90);
mercado.AdicionarItem("Refrigerante", Tipo.Bebida, 5.50);
mercado.AdicionarItem("Shampoo", Tipo.Higiene, 7.00);
mercado.AdicionarItem("Sabonete", Tipo.Higiene, 2.40);
mercado.AdicionarItem("Cotonete", Tipo.Higiene, 5.70);
mercado.AdicionarItem("Sabão em pó", Tipo.Limpeza, 8.20);
mercado.AdicionarItem("Detergente", Tipo.Limpeza, 2.60);
mercado.AdicionarItem("Amaciante", Tipo.Limpeza, 6.40);

Console.WriteLine("\nItens de higiene em ordem decrescente de preço:");
mercado.GetHigiene().ForEach(x => Console.WriteLine(x));
Console.WriteLine("\nItens com preço maior ou igual a 5:");
mercado.GetItensGreaterThan5().ForEach(x => Console.WriteLine(x));
Console.WriteLine("\nItens de comida e bebida em ordem alfabética:");
mercado.GetComidaBebida().ForEach(x => Console.WriteLine(x));
Console.WriteLine("\nQuantidade de itens por tipo:");
foreach (var item in mercado.GetQuantidadePorTipo())
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
Console.WriteLine("\nEstatísticas por tipo (máximo, mínimo e média de preço):");
foreach (var item in mercado.GetEstatisticasPorTipo())
{
    Console.WriteLine($"{item.Key}: Máximo: {item.Value.max}, Mínimo: {item.Value.min}, Média: {Math.Round(item.Value.media, 2)}");
}