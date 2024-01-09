using Microsoft.EntityFrameworkCore;

namespace TechMed.Model;

public class TechMedContext : DbContext {
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }

    public TechMedContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var stringConexao = "server=localhost;user id=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(stringConexao);
        optionsBuilder.UseMySql(stringConexao, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medico>().ToTable("Medicos").HasKey(m => m.Id);
        modelBuilder.Entity<Medico>().Property(m => m.Nome).HasColumnType("varchar(100)");
        modelBuilder.Entity<Medico>().Property(m => m.Codigo).HasColumnType("varchar(10)").IsRequired();
        modelBuilder.Entity<Medico>().Property(m => m.Salario).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Paciente>().ToTable("Pacientes").HasKey(p => p.Id);
        modelBuilder.Entity<Paciente>().Property(p => p.Cpf).HasColumnType("varchar(11)");
        modelBuilder.Entity<Paciente>().Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();

    }

}

public abstract class Pessoa {
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Medico : Pessoa {
    public string Codigo { get; set; }
    public string Especialidade { get; set; }
    public float Salario { get; set; }

    public Medico(string nome, string codigo, string especialidade, float salario)
    {
        Nome = nome;
        Codigo = codigo;
        Especialidade = especialidade;
        Salario = salario;
    }
}

public class Paciente : Pessoa {
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }

    public Paciente(string nome, string cpf, string endereco, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Endereco = endereco;
        Telefone = telefone;
    }
}
