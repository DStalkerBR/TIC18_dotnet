using TechMed.Model;

var db = new TechMedContext();

//var medico = new Medico("Dr. House", "123", "Clínico Geral", 10000);
var medico = new Medico("Dr. Marquinho DJ", "456", "Clínico Geral", 5000);
//var paciente = new Paciente("João da Silva","12345678901",  "Rua 1, 123", "12345678");

db.Medicos.Add(medico);
//db.Pacientes.Add(paciente);

db.SaveChanges();

db.Medicos.ToList().ForEach(m => Console.WriteLine(m.Nome));
