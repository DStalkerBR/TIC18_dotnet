var lista = new List<double> { 3, 7, 2, 4, 6 };
var novaLista = lista.ConvertAll(x => x / 2);
novaLista.ForEach(x => Console.WriteLine(x));