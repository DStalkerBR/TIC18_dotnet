using System.Xml.Schema;

namespace Pessoa;
public class Advogado : Pessoa
{
    private string cna;

    public string Cna {
        get { return cna; }
        set { 
            if (value == null) throw new Exception("CNA não pode ser nulo");
            cna = value;
        }
    }
}
