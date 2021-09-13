﻿// <auto-generated />
using System;
using API_FeriadoAnbima.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_FeriadoAnbima.Migrations
{
    [DbContext(typeof(FeriadoAnbimaContext))]
    [Migration("20210830203131_criacaoTBFeriado")]
    partial class criacaoTBFeriado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_FeriadoAnbima.Model.Feriado", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LogDeRaspagemRequisicaoID")
                        .HasColumnType("int");

                    b.Property<int>("ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<string>("diaDaSemana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DiaDaSemana");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("ID");

                    b.HasIndex("LogDeRaspagemRequisicaoID");

                    b.ToTable("feriado");
                });

            modelBuilder.Entity("API_FeriadoAnbima.Model.LogDeRaspagemRequisicao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("anoSolicitado")
                        .HasColumnType("int")
                        .HasColumnName("AnoSolicitado");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<string>("descrição")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<string>("enderecoHttps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EnderecoHttps");

                    b.Property<bool>("isSucess")
                        .HasColumnType("bit")
                        .HasColumnName("IsSucess");

                    b.HasKey("ID");

                    b.ToTable("TB_LogDeRaspagemRequisicao");
                });

            modelBuilder.Entity("API_FeriadoAnbima.Model.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descrição");

                    b.Property<string>("Log")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Log");

                    b.Property<int?>("LogDeRaspagemRequisicaoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LogDeRaspagemRequisicaoID");

                    b.ToTable("status");
                });

            modelBuilder.Entity("API_FeriadoAnbima.Model.Feriado", b =>
                {
                    b.HasOne("API_FeriadoAnbima.Model.LogDeRaspagemRequisicao", "LogDeRaspagemRequisicao")
                        .WithMany("feriados")
                        .HasForeignKey("LogDeRaspagemRequisicaoID");

                    b.Navigation("LogDeRaspagemRequisicao");
                });

            modelBuilder.Entity("API_FeriadoAnbima.Model.Status", b =>
                {
                    b.HasOne("API_FeriadoAnbima.Model.LogDeRaspagemRequisicao", "LogDeRaspagemRequisicao")
                        .WithMany("status")
                        .HasForeignKey("LogDeRaspagemRequisicaoID");

                    b.Navigation("LogDeRaspagemRequisicao");
                });

            modelBuilder.Entity("API_FeriadoAnbima.Model.LogDeRaspagemRequisicao", b =>
                {
                    b.Navigation("feriados");

                    b.Navigation("status");
                });
#pragma warning restore 612, 618
        }
    }
}
