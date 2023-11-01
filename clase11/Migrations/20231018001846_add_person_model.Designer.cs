﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace clase7.Migrations
{
    [DbContext(typeof(VideoGameContext))]
    [Migration("20231018001846_add_person_model")]
    partial class add_person_model
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("clase7.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameConsoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMultiplayer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Release")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameConsoleId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("clase7.Models.GameConsole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameConsole");
                });

            modelBuilder.Entity("clase7.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SalePersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SalePersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("clase7.Models.Game", b =>
                {
                    b.HasOne("clase7.Models.GameConsole", "Console")
                        .WithMany("Games")
                        .HasForeignKey("GameConsoleId");

                    b.Navigation("Console");
                });

            modelBuilder.Entity("clase7.Models.Person", b =>
                {
                    b.HasOne("clase7.Models.Person", "SalePerson")
                        .WithMany()
                        .HasForeignKey("SalePersonId");

                    b.Navigation("SalePerson");
                });

            modelBuilder.Entity("clase7.Models.GameConsole", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
