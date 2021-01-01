﻿using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.Dados.Mapeamentos
{
    public class ObjetivoMap : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(o => o.ObjetivoId);

            builder.Property(o => o.Nome).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Descricao).HasMaxLength(300).IsRequired();

            builder.HasMany(o => o.Alunos).WithOne(o => o.Objetivo);

            builder.ToTable("Objetivos");
        }
    }
}