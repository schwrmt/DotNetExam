﻿// <auto-generated />
using DBBL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DBBL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 12,
                            AttackModifier = 3,
                            AttackPerRound = 1,
                            Damage = "1d8",
                            DamageModifier = 1,
                            HitPoints = 32,
                            Name = "Frozen Frog"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 19,
                            AttackModifier = 8,
                            AttackPerRound = 1,
                            Damage = "2d12",
                            DamageModifier = 5,
                            HitPoints = 114,
                            Name = "Gorgon"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 13,
                            AttackModifier = 3,
                            AttackPerRound = 2,
                            Damage = "1d8",
                            DamageModifier = 3,
                            HitPoints = 77,
                            Name = "Big Chef"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}