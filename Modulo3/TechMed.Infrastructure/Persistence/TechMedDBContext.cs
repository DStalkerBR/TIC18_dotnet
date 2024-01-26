using Microsoft.EntityFrameworkCore;
using TechMed.Core.Entities;

namespace TechMed.Infrastructure.Persistence;

public class TechMedDBContext : DbContext
{
    DbSet<Medico> Medicos { get; set; }
    DbSet<Paciente> Pacientes { get; set; }
    DbSet<Atendimento> Atendimentos { get; set; }
    DbSet<Exame> Exames { get; set; }
    
    public TechMedDBContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        var stringConexao = "server=localhost;user id=dotnet;password=tic2023;database=techmeddb";
        var serverVersion = ServerVersion.AutoDetect(stringConexao);
        optionsBuilder.UseMySql(stringConexao, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medico>().ToTable("Medicos");
        modelBuilder.Entity<Paciente>().ToTable("Pacientes");
        modelBuilder.Entity<Atendimento>().ToTable("Atendimentos");
        modelBuilder.Entity<Exame>().ToTable("Exames");

        modelBuilder.Entity<Medico>().HasKey(m => m.MedicoId);
        modelBuilder.Entity<Paciente>().HasKey(p => p.PacienteId);
        modelBuilder.Entity<Atendimento>().HasKey(a => a.AtendimentoId);
        modelBuilder.Entity<Exame>().HasKey(e => e.ExameId);

        modelBuilder.Entity<Atendimento>()
            .HasOne(a => a.Medico)
            .WithMany(m => m.Atendimentos)
            .HasForeignKey(a => a.MedicoId);

        modelBuilder.Entity<Atendimento>()
            .HasOne(a => a.Paciente)
            .WithMany(p => p.Atendimentos)
            .HasForeignKey(a => a.PacienteId);

        modelBuilder.Entity<Exame>()
            .HasOne(e => e.Atendimento)
            .WithMany(a => a.Exames)
            .HasForeignKey(e => e.AtendimentoId);
    }

}
