﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoTask.Data;

#nullable disable

namespace TodoTask.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20220505095847_Todo2")]
    partial class Todo2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodosTask.Models.Entities.TodoList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ListId");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("TodosTask.Models.Entities.TodoWork", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoId"), 1L, 1);

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TodoListListId")
                        .HasColumnType("int");

                    b.HasKey("TodoId");

                    b.HasIndex("TodoListListId");

                    b.ToTable("TodoWorks");
                });

            modelBuilder.Entity("TodosTask.Models.Entities.TodoWork", b =>
                {
                    b.HasOne("TodosTask.Models.Entities.TodoList", null)
                        .WithMany("TodoW")
                        .HasForeignKey("TodoListListId");
                });

            modelBuilder.Entity("TodosTask.Models.Entities.TodoList", b =>
                {
                    b.Navigation("TodoW");
                });
#pragma warning restore 612, 618
        }
    }
}
