﻿// <auto-generated />
using System;
using Academia.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Academia.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20201230152003_criacaoBD")]
    partial class criacaoBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Academia.Dominio.Models.Administrador", b =>
                {
                    b.Property<int>("AdministradoresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdministradoresId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FrequenciaSemanal")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ObjetivoId")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("ObjetivoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Academia.Dominio.Models.CategoriaExercicio", b =>
                {
                    b.Property<int>("CategoriaExercicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaExercicioId");

                    b.ToTable("CategoriasExercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Exercicio", b =>
                {
                    b.Property<int>("ExercicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoriaExercicioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ExercicioId");

                    b.HasIndex("CategoriaExercicioId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Ficha", b =>
                {
                    b.Property<int>("FichaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("FichaId");

                    b.HasIndex("AlunoId");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("Academia.Dominio.Models.ListaExercicio", b =>
                {
                    b.Property<int>("ListaExercicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Carga")
                        .HasColumnType("int");

                    b.Property<int>("ExercicioId")
                        .HasColumnType("int");

                    b.Property<int>("FichaId")
                        .HasColumnType("int");

                    b.Property<int>("Frequencia")
                        .HasColumnType("int");

                    b.Property<int>("Repeticoes")
                        .HasColumnType("int");

                    b.HasKey("ListaExercicioId");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("FichaId");

                    b.ToTable("ListasExercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Objetivo", b =>
                {
                    b.Property<int>("ObjetivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ObjetivoId");

                    b.ToTable("Objetivos");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Aluno", b =>
                {
                    b.HasOne("Academia.Dominio.Models.Objetivo", "Objetivo")
                        .WithMany("Alunos")
                        .HasForeignKey("ObjetivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academia.Dominio.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objetivo");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Exercicio", b =>
                {
                    b.HasOne("Academia.Dominio.Models.CategoriaExercicio", "CategoriaExercicio")
                        .WithMany("Exercicios")
                        .HasForeignKey("CategoriaExercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaExercicio");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Ficha", b =>
                {
                    b.HasOne("Academia.Dominio.Models.Aluno", "Aluno")
                        .WithMany("Fichas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Academia.Dominio.Models.ListaExercicio", b =>
                {
                    b.HasOne("Academia.Dominio.Models.Exercicio", "Exercicio")
                        .WithMany("ListaExercicios")
                        .HasForeignKey("ExercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academia.Dominio.Models.Ficha", "Ficha")
                        .WithMany("ListaExercicios")
                        .HasForeignKey("FichaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercicio");

                    b.Navigation("Ficha");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Aluno", b =>
                {
                    b.Navigation("Fichas");
                });

            modelBuilder.Entity("Academia.Dominio.Models.CategoriaExercicio", b =>
                {
                    b.Navigation("Exercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Exercicio", b =>
                {
                    b.Navigation("ListaExercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Ficha", b =>
                {
                    b.Navigation("ListaExercicios");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Objetivo", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("Academia.Dominio.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
