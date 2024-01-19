using Microsoft.EntityFrameworkCore;

namespace TechMed.Model;

public class TechMedContext : DbContext {
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }

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

        modelBuilder.Entity<Atendimento>().ToTable("Atendimentos").HasKey(c => c.Id);
        modelBuilder.Entity<Exame>().ToTable("Exames").HasKey(e => e.Id);


        modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Medico)
                .WithMany(m => m.Atendimentos)
                .HasForeignKey(a => a.MedicoId);
        
        modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Paciente)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.PacienteId);

        modelBuilder.Entity<Atendimento>()
                .HasMany(a => a.Exames)
                .WithMany(e => e.Atendimentos);
    }

}

public abstract class Pessoa {
    public int Id { get; set; }
    public required string Nome { get; set; }
}

public class Medico : Pessoa {
    public required string Codigo { get; set; }
    public string? Especialidade { get; set; }
    public float? Salario { get; set; }
    public ICollection<Atendimento>? Atendimentos { get; }
    
}

public class Paciente : Pessoa {
    public required string Cpf { get; set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
    public ICollection<Atendimento>? Atendimentos { get; }


}

public class Atendimento {
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public DateTime Hora { get; set; }
    public int MedicoId { get; set; }
    public required Medico Medico { get; set;}
    public int PacienteId { get; set; }
    public required Paciente Paciente { get; set;}
    public double Valor { get; set; }
    public ICollection<Exame>? Exames { get; set;}
}

public class Exame {
    public int Id { get; set; }
    public required string Codigo { get; set; }
    public required string Local { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public double Preco { get; set; }
    public required ICollection<Atendimento> Atendimentos { get; set; }
} 
