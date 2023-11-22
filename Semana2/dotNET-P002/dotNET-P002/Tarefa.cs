namespace dotNET_P002;

class Tarefa{
  private string Titulo;
  private string Descricao;
  private DateTime DataDeCriacao;
  private DateTime DataDeVencimento;
  private bool Concluida;

    public Tarefa(string titulo, string descricao, DateTime dataDeCriacao, DateTime dataDeVencimento){
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.DataDeCriacao = dataDeCriacao;
        this.DataDeVencimento = dataDeVencimento;
        this.Concluida = false;
    }

    public string getTitulo(){
        return this.Titulo;
    }

    public string getDescricao(){
        return this.Descricao;
    }

    public DateTime getDataDeCriacao(){
        return this.DataDeCriacao;
    }

    public DateTime getDataDeVencimento(){
        return this.DataDeVencimento;
    }

    public bool getConcluida(){
        return this.Concluida;
    }

    public void setTitulo(string titulo){
        this.Titulo = titulo;
    }

    public void setDescricao(string descricao){
        this.Descricao = descricao;
    }

    public void setDataDeVencimento(DateTime dataDeVencimento){
        this.DataDeVencimento = dataDeVencimento;
    }   

    public void setConcluida(bool concluida){
        this.Concluida = concluida;
    }

    public void marcarConcluida(){
        this.Concluida = true;
    }

    public void desmarcarConcluida(){
        this.Concluida = false;
    }

    public string toString(){
        string Checkbox = this.Concluida ? "Sim" : "Não";
        return "Título: " + this.Titulo + "\nDescrição: " + this.Descricao + "\nData de Criação: " + this.DataDeCriacao + "\nData de Vencimento: " + this.DataDeVencimento + "\nConcluída: " + Checkbox;
    }
}
