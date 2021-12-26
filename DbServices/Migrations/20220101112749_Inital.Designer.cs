﻿// <auto-generated />
using System;
using DbServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbServices.Migrations
{
    [DbContext(typeof(DbModel))]
    [Migration("20220101112749_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DevBoard.Shared.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentWorkId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentWorkId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("DevBoard.Shared.Work", b =>
                {
                    b.HasOne("DevBoard.Shared.Work", "ParentWork")
                        .WithMany()
                        .HasForeignKey("ParentWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentWork");
                });
#pragma warning restore 612, 618
        }
    }
}
