﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(ProgramContext))]
    [Migration("20230705185751_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("HymnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HymnId"));

                    b.Property<int>("ClosingHymn")
                        .HasColumnType("int");

                    b.Property<int>("IntermidiateHymn")
                        .HasColumnType("int");

                    b.Property<int>("OpeningHymn")
                        .HasColumnType("int");

                    b.Property<string>("Preformer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SacramentHymn")
                        .HasColumnType("int");

                    b.Property<string>("SpecialMusicalNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HymnId");

                    b.ToTable("Hymn", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleId"));

                    b.Property<string>("ClosingPrayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conducting")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningPrayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Presiding")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeopleId");

                    b.ToTable("People", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Sacrament", b =>
                {
                    b.Property<int>("SacramentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SacramentId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HymnId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SacramentId");

                    b.HasIndex("HymnId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Sacrament", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeakerId"));

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<string>("SpeakerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeakerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeakerId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Speaker", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Sacrament", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "Hymn")
                        .WithMany()
                        .HasForeignKey("HymnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hymn");

                    b.Navigation("People");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.People", "People")
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
