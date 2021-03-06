// <auto-generated />
using System;
using CursoDeIngles.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoDeIngles.Migrations
{
    [DbContext(typeof(CursoContext))]
    partial class CursoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CursoDeIngles.Models.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_aluno", (string)null);
                });

            modelBuilder.Entity("CursoDeIngles.Models.Entities.Matricula", b =>
                {
                    b.Property<int>("TurmaId")
                        .HasColumnType("int")
                        .HasColumnName("id_turma");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int")
                        .HasColumnName("id_aluno");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("TurmaId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("tb_matricula", (string)null);
                });

            modelBuilder.Entity("CursoDeIngles.Models.Entities.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AnoLetivo")
                        .HasColumnType("datetime2")
                        .HasColumnName("anoLetivo");

                    b.Property<string>("Nivel")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nivel");

                    b.HasKey("Id");

                    b.ToTable("tb_turma", (string)null);
                });

            modelBuilder.Entity("CursoDeIngles.Models.Entities.Matricula", b =>
                {
                    b.HasOne("CursoDeIngles.Models.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoDeIngles.Models.Entities.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });
#pragma warning restore 612, 618
        }
    }
}
