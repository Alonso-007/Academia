﻿using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.Dados.Mapeamentos
{
    public class CategoriaExercicioMap : IEntityTypeConfiguration<CategoriaExercicio>
    {
        public void Configure(EntityTypeBuilder<CategoriaExercicio> builder)
        {
            builder.HasKey(ce => ce.CategoriaExercicioId);

            builder.Property(ce => ce.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(ce => ce.Exercicios).WithOne(ce => ce.CategoriaExercicio).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("CategoriasExercicios");
        }
    }
}