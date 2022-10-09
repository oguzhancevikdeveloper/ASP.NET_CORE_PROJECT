﻿// <auto-generated />
using System;
using ASP.NET_CORE_PROJECT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ASP.NET_CORE_PROJECT.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221009195602_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AboutDetail1")
                        .HasColumnType("text");

                    b.Property<string>("AboutDetail2")
                        .HasColumnType("text");

                    b.Property<string>("AboutDetailIMage1")
                        .HasColumnType("text");

                    b.Property<string>("AboutDetailIMage2")
                        .HasColumnType("text");

                    b.Property<string>("AboutMapLocation")
                        .HasColumnType("text");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("boolean");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("BlogContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("BlogCreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("BlogStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("text");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("boolean");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CommentContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CommentName")
                        .HasColumnType("text");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("CommentTitle")
                        .HasColumnType("text");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ContactMail")
                        .HasColumnType("text");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("text");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("text");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("text");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("WriterAbout")
                        .HasColumnType("text");

                    b.Property<string>("WriterImage")
                        .HasColumnType("text");

                    b.Property<string>("WriterMail")
                        .HasColumnType("text");

                    b.Property<string>("WriterName")
                        .HasColumnType("text");

                    b.Property<string>("WriterPassword")
                        .HasColumnType("text");

                    b.HasKey("WriterId");

                    b.ToTable("Writers");
                });
#pragma warning restore 612, 618
        }
    }
}