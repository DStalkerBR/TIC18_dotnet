namespace dotNET_P002;

public class Tarefa{
    private int id;
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

    public Tarefa(int id, string titulo, string descricao, DateTime dataDeCriacao, DateTime dataDeVencimento){
        this.id = id;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.DataDeCriacao = dataDeCriacao;
        this.DataDeVencimento = dataDeVencimento;
        this.Concluida = false;
    }

    public int getId(){
        return this.id;
    }

    public void setId(int id){
        this.id = id;
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
        return "Id: " + this.id + "\nTítulo: " + this.Titulo + "\nDescrição: " + this.Descricao + "\nData de Criação: " + this.DataDeCriacao + "\nData de Vencimento: " + this.DataDeVencimento + "\nConcluída: " + Checkbox;
    }

    public string exibeFormatado(){
        string checkbox = this.Concluida ? "Sim" : "Não";

        return  "════════════════════════════════════\n" + 
            $"{"Id",-20}: {this.id}\n" +
            $"{"Título",-20}: {this.Titulo}\n" +
            $"{"Descrição",-20}: {this.Descricao}\n" +
            $"{"Data de Criação",-20}: {this.DataDeCriacao}\n" +
            $"{"Data de Vencimento",-20}: {this.DataDeVencimento}\n" +
            $"{"Concluída",-20}: {checkbox}" + 
            "\n═══════════════════════════════════";

    }
}

public class Tarefas{
    private List<Tarefa> tarefas;
    private int id;
    private int quantidade;

    public Tarefas(){
        this.tarefas = new List<Tarefa>();
        this.id = 0;
    }

    public void adicionarTarefa(Tarefa tarefa){
        this.id++;
        tarefa.setId(this.id);
        this.tarefas.Add(tarefa);
    }

    public void removerTarefa(Tarefa tarefa){
        this.tarefas.Remove(tarefa);
    }

    public void removerTarefa(int id){
        tarefas.RemoveAll(tarefa => tarefa.getId() == id);
    }

    public Tarefa? getTarefa(int id){
        return this.tarefas.Where(tarefa => tarefa.getId() == id).FirstOrDefault();
    }

    public void listarTarefas(){ 
        foreach(Tarefa tarefa in this.tarefas){
            Console.WriteLine(tarefa.exibeFormatado());
            Console.WriteLine();
        }
    }

    public void listarTarefas(bool status){
        if (status){
            foreach(Tarefa tarefa in this.tarefas){
                if(tarefa.getConcluida()){
                    Console.WriteLine(tarefa.exibeFormatado());
                    Console.WriteLine();
                }
            }
        } else {
            foreach(Tarefa tarefa in this.tarefas){
                if(!tarefa.getConcluida()){
                    Console.WriteLine(tarefa.exibeFormatado());
                    Console.WriteLine();
                }
            }
        }
    }

    public Tarefas? pesquisarTarefas(string palavraChave){
        palavraChave = palavraChave.ToLower();
        Tarefas tarefasEncontradas = new Tarefas();
        foreach(Tarefa tarefa in this.tarefas){
            if(tarefa.getTitulo().ToLower().Contains(palavraChave) || tarefa.getDescricao().ToLower().Contains(palavraChave)){
                tarefasEncontradas.adicionarTarefa(tarefa);
            }
        }
        return tarefasEncontradas.getQuantidade() > 0 ? tarefasEncontradas : null;
    }

    public int getQuantidade(){
        return this.tarefas.Count;
    }

    public int getQntConcluidas(){
        int qntConcluidas = 0;
        foreach(Tarefa tarefa in this.tarefas){
            if(tarefa.getConcluida()){
                qntConcluidas++;
            }
        }
        return qntConcluidas;
    }

    public Tarefa getTarefaAntiga(){
        return this.tarefas.OrderBy(tarefa => tarefa.getDataDeCriacao()).First();
    }

    public Tarefa getTarefaRecente(){
        return this.tarefas.OrderByDescending(tarefa => tarefa.getDataDeCriacao()).First();
    }
}