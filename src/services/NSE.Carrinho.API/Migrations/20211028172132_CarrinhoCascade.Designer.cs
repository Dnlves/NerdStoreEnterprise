﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSE.Carrinho.API.Data;

namespace NSE.Carrinho.API.Migrations
{
    [DbContext(typeof(CarrinhoContext))]
    [Migration("20211028172132_CarrinhoCascade")]
    partial class CarrinhoCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NSE.Carrinho.API.Model.CarrinhoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("VoucherUtilizado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .HasDatabaseName("IDX_Cliente");

                    b.ToTable("CarrinhoCliente");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Model.CarrinhoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrinhoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Model.CarrinhoCliente", b =>
                {
                    b.OwnsOne("NSE.Carrinho.API.Model.Voucher", "Voucher", b1 =>
                        {
                            b1.Property<Guid>("CarrinhoClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Codigo")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("VoucherCodigo");

                            b1.Property<decimal?>("Percentual")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Percentual");

                            b1.Property<int>("TipoDesconto")
                                .HasColumnType("int")
                                .HasColumnName("TipoDesconto");

                            b1.Property<decimal?>("ValorDesconto")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ValorDesconto");

                            b1.HasKey("CarrinhoClienteId");

                            b1.ToTable("CarrinhoCliente");

                            b1.WithOwner()
                                .HasForeignKey("CarrinhoClienteId");
                        });

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Model.CarrinhoItem", b =>
                {
                    b.HasOne("NSE.Carrinho.API.Model.CarrinhoCliente", "CarrinhoCliente")
                        .WithMany("Itens")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrinhoCliente");
                });

            modelBuilder.Entity("NSE.Carrinho.API.Model.CarrinhoCliente", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
