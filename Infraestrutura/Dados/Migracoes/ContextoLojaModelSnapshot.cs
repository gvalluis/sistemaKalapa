﻿// <auto-generated />
using Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestrutura.Dados.Migracoes
{
    [DbContext(typeof(ContextoLoja))]
    partial class ContextoLojaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Core.Entidades.CategoriasProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProduto");
                });

            modelBuilder.Entity("Core.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(180);

                    b.Property<int>("IdCategoriaProduto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoDeProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoriaProduto");

                    b.HasIndex("IdTipoDeProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Core.Entidades.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoProdutos");
                });

            modelBuilder.Entity("Core.Entidades.Produto", b =>
                {
                    b.HasOne("Core.Entidades.CategoriasProduto", "CategoriaProduto")
                        .WithMany()
                        .HasForeignKey("IdCategoriaProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("IdTipoDeProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
