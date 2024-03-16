namespace ServicoFabrica;

public class Program {
    public static void Main() {
        var fabrica = new ServicoFabrica<Manutencao>();
        IServico servico = fabrica.NovaInstancia();
        servico.Executar();

        var fabrica2 = new ServicoFabrica<Relatorio>();
        IServico servico2 = fabrica2.NovaInstancia();
        servico2.Executar();

        /* 
        Error CS0311: O tipo "ServicoFabrica.Teste" não pode ser usado como parâmetro de tipo 
        "T" no tipo ou método genérico "ServicoFabrica<T>". Não há conversão de referência 
        implícita de "ServicoFabrica.Teste" em "ServicoFabrica.IServico"

        ServicoFabrica<Teste> fabrica3 = new ServicoFabrica<Teste>();
        Teste teste = fabrica3.NovaInstancia();
        teste.Testar(); 
        */     

    }
}