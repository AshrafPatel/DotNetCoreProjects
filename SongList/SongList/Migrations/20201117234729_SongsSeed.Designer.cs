﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongList.Models;

namespace SongList.Migrations
{
    [DbContext(typeof(SongContext))]
    [Migration("20201117234729_SongsSeed")]
    partial class SongsSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SongList.Models.Genre", b =>
                {
                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = (byte)1,
                            Name = "Hip-Hop"
                        },
                        new
                        {
                            GenreId = (byte)2,
                            Name = "Metal"
                        },
                        new
                        {
                            GenreId = (byte)3,
                            Name = "Punk"
                        },
                        new
                        {
                            GenreId = (byte)4,
                            Name = "Techno"
                        });
                });

            modelBuilder.Entity("SongList.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte?>("GenreId")
                        .IsRequired()
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("SongId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongId = 1,
                            GenreId = (byte)2,
                            Name = "Take Control",
                            Rating = 5,
                            Year = 2020
                        },
                        new
                        {
                            SongId = 2,
                            GenreId = (byte)4,
                            Name = "Dr. Stone",
                            Rating = 4,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("SongList.Models.Song", b =>
                {
                    b.HasOne("SongList.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}