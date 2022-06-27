﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace jimid.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220626122550_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Artiekel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kleur")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .HasColumnType("TEXT");

                    b.Property<int>("Planthoogte")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Potmaat")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Productgroep")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Artiekel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Kleur = "Rood",
                            Naam = "plan1",
                            Planthoogte = 3,
                            Potmaat = 4,
                            Productgroep = "Tulpen"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
