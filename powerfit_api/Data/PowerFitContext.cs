using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using powerfit_api.Models;

namespace powerfit_api.Data;

public partial class PowerFitContext : DbContext
{
    public PowerFitContext(DbContextOptions<PowerFitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<AlunoModalidade> AlunosModalidades { get; set; }

    public virtual DbSet<Instrutor> Instrutores { get; set; }

    public virtual DbSet<Modalidade> Modalidades { get; set; }

    public virtual DbSet<Plano> Planos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.AlunoId).HasName("PRIMARY");

            entity.ToTable("alunos");

            entity.HasIndex(e => e.AlunoEmail, "aluno_email").IsUnique();

            entity.HasIndex(e => e.PlanoId, "plano_id");

            entity.Property(e => e.AlunoId)
                .HasColumnType("int(11)")
                .HasColumnName("aluno_id");
            entity.Property(e => e.AlunoDataNascimento)
                .HasColumnType("date")
                .HasColumnName("aluno_data_nascimento");
            entity.Property(e => e.AlunoEmail)
                .HasMaxLength(120)
                .HasColumnName("aluno_email");
            entity.Property(e => e.AlunoNome)
                .HasMaxLength(120)
                .HasColumnName("aluno_nome");
            entity.Property(e => e.AlunoTelefone)
                .HasMaxLength(20)
                .HasColumnName("aluno_telefone");
            entity.Property(e => e.PlanoId)
                .HasColumnType("int(11)")
                .HasColumnName("plano_id");

            entity.HasOne(d => d.Plano).WithMany(p => p.Alunos)
                .HasForeignKey(d => d.PlanoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("alunos_ibfk_1");
        });

        modelBuilder.Entity<AlunoModalidade>(entity =>
        {
            entity.HasKey(e => e.AlunoModalidadeId).HasName("PRIMARY");

            entity.ToTable("alunos_modalidades");

            entity.HasIndex(e => new { e.AlunoId, e.ModalidadeId }, "aluno_id").IsUnique();

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.AlunoModalidadeId)
                .HasColumnType("int(11)")
                .HasColumnName("aluno_modalidade_id");
            entity.Property(e => e.AlunoId)
                .HasColumnType("int(11)")
                .HasColumnName("aluno_id");
            entity.Property(e => e.AlunoModalidadeDataInscricao)
                .HasColumnType("date")
                .HasColumnName("aluno_modalidade_data_inscricao");
            entity.Property(e => e.ModalidadeId)
                .HasColumnType("int(11)")
                .HasColumnName("modalidade_id");

            entity.HasOne(d => d.Aluno).WithMany(p => p.AlunosModalidades)
                .HasForeignKey(d => d.AlunoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("alunos_modalidades_ibfk_1");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.AlunosModalidades)
                .HasForeignKey(d => d.ModalidadeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("alunos_modalidades_ibfk_2");
        });

        modelBuilder.Entity<Instrutor>(entity =>
        {
            entity.HasKey(e => e.InstrutorId).HasName("PRIMARY");

            entity.ToTable("instrutores");

            entity.HasIndex(e => e.InstrutorCref, "instrutor_cref").IsUnique();

            entity.Property(e => e.InstrutorId)
                .HasColumnType("int(11)")
                .HasColumnName("instrutor_id");
            entity.Property(e => e.InstrutorCref)
                .HasMaxLength(20)
                .HasColumnName("instrutor_cref");
            entity.Property(e => e.InstrutorEspecialidade)
                .HasMaxLength(80)
                .HasColumnName("instrutor_especialidade");
            entity.Property(e => e.InstrutorNome)
                .HasMaxLength(120)
                .HasColumnName("instrutor_nome");
            entity.Property(e => e.InstrutorTelefone)
                .HasMaxLength(20)
                .HasColumnName("instrutor_telefone");
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.ModalidadeId).HasName("PRIMARY");

            entity.ToTable("modalidades");

            entity.HasIndex(e => e.InstrutorId, "instrutor_id");

            entity.HasIndex(e => e.ModalidadeNome, "modalidade_nome").IsUnique();

            entity.Property(e => e.ModalidadeId)
                .HasColumnType("int(11)")
                .HasColumnName("modalidade_id");
            entity.Property(e => e.InstrutorId)
                .HasColumnType("int(11)")
                .HasColumnName("instrutor_id");
            entity.Property(e => e.ModalidadeHorario)
                .HasMaxLength(40)
                .HasColumnName("modalidade_horario");
            entity.Property(e => e.ModalidadeNome)
                .HasMaxLength(80)
                .HasColumnName("modalidade_nome");

            entity.HasOne(d => d.Instrutor).WithMany(p => p.Modalidades)
                .HasForeignKey(d => d.InstrutorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("modalidades_ibfk_1");
        });

        modelBuilder.Entity<Plano>(entity =>
        {
            entity.HasKey(e => e.PlanoId).HasName("PRIMARY");

            entity.ToTable("planos");

            entity.HasIndex(e => e.PlanoNome, "plano_nome").IsUnique();

            entity.Property(e => e.PlanoId)
                .HasColumnType("int(11)")
                .HasColumnName("plano_id");
            entity.Property(e => e.PlanoDuracaoMeses)
                .HasColumnType("int(11)")
                .HasColumnName("plano_duracao_meses");
            entity.Property(e => e.PlanoNome)
                .HasMaxLength(50)
                .HasColumnName("plano_nome");
            entity.Property(e => e.PlanoValor)
                .HasPrecision(8)
                .HasColumnName("plano_valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
