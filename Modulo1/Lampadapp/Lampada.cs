namespace Model;
public class Lampada
{
    private bool ligada;

    public Lampada(bool estadoInicial)
    {
        this.ligada = estadoInicial;
    }

    public void Ligar()
    {
        this.ligada = true;
    }

    public void Desligar()
    {
        this.ligada = false;
    }

    public void Imprimir()
    {
        Console.WriteLine("Lampada " + (this.ligada ? "ligada" : "desligada"));
    }

}
