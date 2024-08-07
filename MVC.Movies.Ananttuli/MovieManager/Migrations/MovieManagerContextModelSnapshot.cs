﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManager.Data;

#nullable disable

namespace MovieManager.Migrations
{
    [DbContext(typeof(MovieManagerContext))]
    partial class MovieManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieManager.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieManager.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieManager.Models.MovieActor", b =>
                {
                    b.Property<int>("MovieActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieActorId"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("MovieActorId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("MovieManager.Models.MovieGenre", b =>
                {
                    b.Property<int>("MovieGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieGenreId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MovieManager.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MovieManager.Models.MovieActor", b =>
                {
                    b.HasOne("MovieManager.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieManager.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MovieManager.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieManager.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieManager.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManager.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("MovieManager.Models.Movie", b =>
                {
                    b.Navigation("MovieActors");

                    b.Navigation("MovieGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
