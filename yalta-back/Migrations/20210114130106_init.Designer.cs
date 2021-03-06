﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yalta.Models;

namespace Yalta.Migrations
{
    [DbContext(typeof(YaltaContext))]
    [Migration("20210114130106_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AreaPreferredPeriod", b =>
                {
                    b.Property<long>("AreasId")
                        .HasColumnType("bigint");

                    b.Property<long>("PreferredPeriodsId")
                        .HasColumnType("bigint");

                    b.HasKey("AreasId", "PreferredPeriodsId");

                    b.HasIndex("PreferredPeriodsId");

                    b.ToTable("AreaPreferredPeriod");
                });

            modelBuilder.Entity("Yalta.Models.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Label")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Yalta.Models.PreferredPeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Lower")
                        .HasColumnType("int");

                    b.Property<long>("ProfilId")
                        .HasColumnType("bigint");

                    b.Property<int>("Upper")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfilId");

                    b.ToTable("PreferredPeriod");
                });

            modelBuilder.Entity("Yalta.Models.Profil", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Profil");
                });

            modelBuilder.Entity("Yalta.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AreaPreferredPeriod", b =>
                {
                    b.HasOne("Yalta.Models.Area", null)
                        .WithMany()
                        .HasForeignKey("AreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yalta.Models.PreferredPeriod", null)
                        .WithMany()
                        .HasForeignKey("PreferredPeriodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yalta.Models.PreferredPeriod", b =>
                {
                    b.HasOne("Yalta.Models.Profil", "Profil")
                        .WithMany("PreferredPeriods")
                        .HasForeignKey("ProfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profil");
                });

            modelBuilder.Entity("Yalta.Models.Profil", b =>
                {
                    b.HasOne("Yalta.Models.User", "User")
                        .WithOne("Profil")
                        .HasForeignKey("Yalta.Models.Profil", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Yalta.Models.Profil", b =>
                {
                    b.Navigation("PreferredPeriods");
                });

            modelBuilder.Entity("Yalta.Models.User", b =>
                {
                    b.Navigation("Profil");
                });
#pragma warning restore 612, 618
        }
    }
}
