﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using projeto_integrador.Data;

namespace projeto_integrador.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220503212428_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("projeto_integrador.Models.UsuarioContratante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DescricaoEmpresa")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EnderecoEmpresa")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeEmpresa")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NumeroContato")
                        .HasColumnType("integer");

                    b.Property<string>("UrlFotoEmpresa")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UsuarioContratante");
                });
#pragma warning restore 612, 618
        }
    }
}
