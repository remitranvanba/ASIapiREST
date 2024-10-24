﻿// <auto-generated />
using System;
using ASIapiREST.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ASIapiREST.Migrations
{
    [DbContext(typeof(SerieDBContext))]
    [Migration("20241020154650_NewAnnotations1")]
    partial class NewAnnotations1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer")
                        .HasColumnName("ser_id");

                    b.Property<int>("Note")
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.HasKey("UtilisateurId", "SerieId")
                        .HasName("pk_not");

                    b.HasIndex("SerieId");

                    b.ToTable("t_j_notation_not", "public");
                });

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Serie", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ser_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SerieId"));

                    b.Property<int?>("AnneeCreation")
                        .HasColumnType("integer")
                        .HasColumnName("ser_anneecreation");

                    b.Property<int?>("NbEpisodes")
                        .HasColumnType("integer")
                        .HasColumnName("ser_nbepisodes");

                    b.Property<int?>("NbSaisons")
                        .HasColumnType("integer")
                        .HasColumnName("ser_nbsaisons");

                    b.Property<string>("Network")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ser_network");

                    b.Property<string>("Resume")
                        .HasColumnType("text")
                        .HasColumnName("ser_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ser_titre");

                    b.HasKey("SerieId")
                        .HasName("pk_ser");

                    b.HasIndex("Titre");

                    b.ToTable("t_e_serie_ser", "public");
                });

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasMaxLength(5)
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("utl_datecreation")
                        .HasDefaultValueSql("now()");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasDefaultValue("France")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId")
                        .HasName("pk_utl");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("t_e_utilisateur_utl", "public");
                });

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("ASIapiREST.Models.EntityFramework.Serie", "SerieNotee")
                        .WithMany("NotesSerie")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_not_ser");

                    b.HasOne("ASIapiREST.Models.EntityFramework.Utilisateur", "UtilisateurNotant")
                        .WithMany("NotesUtilisateur")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_not_utl");

                    b.Navigation("SerieNotee");

                    b.Navigation("UtilisateurNotant");
                });

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Serie", b =>
                {
                    b.Navigation("NotesSerie");
                });

            modelBuilder.Entity("ASIapiREST.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("NotesUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
