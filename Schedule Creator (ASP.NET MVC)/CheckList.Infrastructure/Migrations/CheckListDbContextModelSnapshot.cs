﻿// <auto-generated />
using System;
using CheckList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckList.Infrastructure.Migrations
{
    [DbContext(typeof(CheckListDbContext))]
    partial class CheckListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheckList.Core.Models.Date", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("CheckList.Core.Models.GoalItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("GoalItems");
                });

            modelBuilder.Entity("CheckList.Core.Models.Motivation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("Motivations");
                });

            modelBuilder.Entity("CheckList.Core.Models.ScheduleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("ScheduleItems");
                });

            modelBuilder.Entity("CheckList.Core.Models.GoalItem", b =>
                {
                    b.HasOne("CheckList.Core.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");
                });

            modelBuilder.Entity("CheckList.Core.Models.Motivation", b =>
                {
                    b.HasOne("CheckList.Core.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");
                });

            modelBuilder.Entity("CheckList.Core.Models.ScheduleItem", b =>
                {
                    b.HasOne("CheckList.Core.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");
                });
#pragma warning restore 612, 618
        }
    }
}
