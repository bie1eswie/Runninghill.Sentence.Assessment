﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Runninghill.Sentence.Assessment.Infrastructure.Data;

#nullable disable

namespace Runninghill.Sentence.Assessment.Infrastructure.Migrations
{
    [DbContext(typeof(RunninghillSentenceAssessmentContext))]
    [Migration("20240327032226_add_Created_On_column")]
    partial class add_Created_On_column
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Runninghill.Sentence.Assessment.Domain.Entities.UserSentence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("Runninghill.Sentence.Assessment.Domain.Entities.WordGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WordGroups");
                });

            modelBuilder.Entity("Runninghill.Sentence.Assessment.Domain.Entities.WordItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("WordGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WordType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordGroupId");

                    b.ToTable("WordItems");
                });

            modelBuilder.Entity("Runninghill.Sentence.Assessment.Domain.Entities.WordItem", b =>
                {
                    b.HasOne("Runninghill.Sentence.Assessment.Domain.Entities.WordGroup", "WordGroup")
                        .WithMany("Items")
                        .HasForeignKey("WordGroupId")
                        .IsRequired()
                        .HasConstraintName("FK_WordItem_WordGroup");

                    b.Navigation("WordGroup");
                });

            modelBuilder.Entity("Runninghill.Sentence.Assessment.Domain.Entities.WordGroup", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
