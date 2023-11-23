#region 1. Tuplas
Func<string, int, (string, int)> nomeIdade = (nome, idade) => (nome, idade);
Console.WriteLine("Nome Completo: " + nomeIdade("John Smith", 35));
#endregion 

#region 2. Expressao Lambda
//Defina uma expressão lambda que recebe dois números como parâmetros 
// e retorna a soma dos quadrados desses números. Em
// seguida, chame a expressão lambda com alguns valores diferentes e 
/// exiba os resultados.
Func<int, int, int> somaQuadrados = (num1, num2) => num1*num1 + num2*num2;
Console.WriteLine($"Soma dos Quadrados de 3 e 4: {somaQuadrados(3, 4)}");
Console.WriteLine($"Soma dos Quadrados de 5 e 7: {somaQuadrados(5, 7)}");
Console.WriteLine($"Soma dos Quadrados de 2 e 3: {somaQuadrados(2, 3)}");
#endregion

#region 3. LINQ com Lista
// Crie uma lista de objetos simples, por exemplo, representando 
// pessoas com propriedades como "Nome" e "Idade". Em seguida,
// use LINQ para filtrar a lista e obter todas as pessoas com 
// idade superior a 30.
List<(string, int)> listaPessoas = new List<(string,int)>();
listaPessoas.Add(("John Smith", 21));
listaPessoas.Add(("Mario Romario", 32));
listaPessoas.Add(("Ana Mariana", 31));
listaPessoas.Add(("Sergio Strelec", 30));
Console.WriteLine($"Idade superior a 30: {string.Join(", ", listaPessoas.Where(x => x.Item2 > 30))}");
#endregion

#region 4. LINQ com Array
// Crie um array de números inteiros. Use LINQ 
// para selecionar apenas os números pares e 
// ordene-os de forma decrescente.
int [] inteiros = {5, 3, 6, 2, 1, 4, 9, 10, 7, 8};
Console.WriteLine($"Numeros Pares: {string.Join(", ", inteiros.Where(x => x % 2 == 0).Order())}");

#endregion 

#region 5. Combinação de Tuplas, Expressões Lambda e LINQ
// Crie uma lista de tuplas, onde cada tupla contém o nome de uma pessoa 
// e a sua altura em centímetros. Utilize uma expressão
// lambda e LINQ para calcular a altura média das pessoas na lista

List<(string, double)> nomeAltura = new List<(string, double)>();
nomeAltura.Add( ("John Smith", 1.64) );
nomeAltura.Add( ("Jose Carlos", 1.75) );
nomeAltura.Add( ("Maria Menezes", 1.90) );
nomeAltura.Add( ("Maninho Baixinho", 1.30) );
Func<List<(string, double)>, double> calculaMedAlt = (nomeAltura) => nomeAltura.Sum(x => x.Item2) / nomeAltura.Count;
double alturaMedia = calculaMedAlt(nomeAltura);
Console.WriteLine($"Altura média da lista de pesoas: {alturaMedia:0.00}");
#endregion