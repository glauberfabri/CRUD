using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.Models
{
    public partial class CRUDDBContext : DbContext
    {
        public CRUDDBContext()
        {
        }

        public CRUDDBContext(DbContextOptions<CRUDDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cadastro> Cadastros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //            optionsBuilder.UseSqlServer("Server=NEWSHADOW;Database=CRUDDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro>(entity =>
            {
                entity.HasKey(e => e.Cnpj);

                entity.ToTable("Cadastro");

                entity.Property(e => e.Cnpj)
                    .ValueGeneratedNever()
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeContato)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Fantasia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Razao_Social");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
