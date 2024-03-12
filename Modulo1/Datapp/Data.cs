namespace Model;
public class Data
{
    public const int FORMATO_12H = 12;
    public const int FORMATO_24H = 24;
    private int dia;
    private int mes;
    private int ano;
    private int hora;
    private int minuto;
    private int segundo;

    public int Dia { get => dia; }
    public int Mes { get => mes; }
    public int Ano { get => ano; }
    public int Hora { get => hora; }
    public int Minuto { get => minuto; }
    public int Segundo { get => segundo; }

    public Data(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
        this.hora = -1;
        this.minuto = -1;
        this.segundo = -1;
    }

    public Data(int dia, int mes, int ano, int hora, int minuto, int segundo)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
        this.hora = hora;
        this.minuto = minuto;
        this.segundo = segundo;
    }

    public void Imprimir(int formatoHora)
    {
        if (hora == -1)
        {
            Console.WriteLine($"{dia:D2}/{mes:D2}/{ano:D4}");
        }
        else
        {
            if (formatoHora == 12)
            {
                Console.WriteLine($"{dia:D2}/{mes:D2}/{ano:D4} {(hora % 12 == 0 ? 12 : hora % 12):D2}:{minuto:D2}:{segundo:D2} {(hora < 12 ? "AM" : "PM")}");
            }
            else
            {
                Console.WriteLine($"{dia:D2}/{mes:D2}/{ano:D4} {hora:D2}:{minuto:D2}:{segundo:D2}");
            }
        }
    }

}
