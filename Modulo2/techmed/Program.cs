using TechMed.Model;

var db = new TechMedContext();

db.Medicos.RemoveRange(db.Medicos);
db.Pacientes.RemoveRange(db.Pacientes);
db.Atendimentos.RemoveRange(db.Atendimentos);
db.Exames.RemoveRange(db.Exames);

var medico = new Medico(){
    Nome = "Dr. Marquinho DJ",
    Codigo = "123",
    Especialidade = "Clínico Geral",
    Salario = 10000
};

var paciente = new Paciente(){
    Nome = "Fulano",
    Cpf = "123",
    Endereco = "Rua X",
    Telefone = "123"
};

var atendimento = new Atendimento(){
    Data = DateTime.Now,
    Hora = DateTime.Now,
    Medico = medico,
    Paciente = paciente,
    Valor = 0
};

var exame = new Exame(){
    Codigo = "123",
    Local = "Hospital",
    Nome = "Exame",
    Tipo = "Tipo",
    Preco = 100,
    Atendimentos = new List<Atendimento>(){ atendimento }
};

atendimento.Exames = new List<Exame>(){ exame };

db.Medicos.Add(medico);
db.Pacientes.Add(paciente);
db.Atendimentos.Add(atendimento);
db.Exames.Add(exame);


db.SaveChanges(); 

Console.WriteLine("--------Medicos--------");
db.Medicos.ToList().ForEach( m => {
    Console.WriteLine("Nome: " + m.Nome);
    Console.WriteLine("Codigo: " + m.Codigo);
    Console.WriteLine("Especialidade: " + m.Especialidade);
    Console.WriteLine("Salario: " + m.Salario);
    
} );


Console.WriteLine("--------Pacientes--------");
db.Pacientes.ToList().ForEach( p => {
    Console.WriteLine("Nome: " + p.Nome);
    Console.WriteLine("CPF: " + p.Cpf);
    Console.WriteLine("Endereco: " + p.Endereco);
    Console.WriteLine("Telefone: " + p.Telefone);
    Console.WriteLine("--------Exames do Paciente:--------");
    p.Atendimentos.ToList().ForEach( a => {
        a.Exames.ToList().ForEach( e => {
            Console.WriteLine("Codigo: " + e.Codigo);
            Console.WriteLine("Local: " + e.Local);
            Console.WriteLine("Nome: " + e.Nome);
            Console.WriteLine("Tipo: " + e.Tipo);
        });
    });
});

Console.WriteLine("--------Atendimentos--------");
db.Atendimentos.ToList().ForEach( a => {
    Console.WriteLine("Data: " + a.Data);
    Console.WriteLine("Hora: " + a.Hora);
    Console.WriteLine("Medico: " + a.Medico.Nome);
    Console.WriteLine("Paciente: " + a.Paciente.Nome);
    Console.WriteLine("Valor: " + a.Valor);
} );

Console.WriteLine("--------Exames--------");
db.Exames.ToList().ForEach( e => {
    Console.WriteLine("Codigo: " + e.Codigo);
    Console.WriteLine("Local: " + e.Local);
    Console.WriteLine("Nome: " + e.Nome);
    Console.WriteLine("Tipo: " + e.Tipo);
} );
