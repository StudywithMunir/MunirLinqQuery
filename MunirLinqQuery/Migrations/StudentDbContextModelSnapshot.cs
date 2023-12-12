﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MunirLinqQuery.Data;

#nullable disable

namespace MunirLinqQuery.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnrolledStudent", b =>
                {
                    b.Property<int>("enrollseid")
                        .HasColumnType("int");

                    b.Property<int>("studentssid")
                        .HasColumnType("int");

                    b.HasKey("enrollseid", "studentssid");

                    b.HasIndex("studentssid");

                    b.ToTable("EnrolledStudent");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Class", b =>
                {
                    b.Property<int>("cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cid"));

                    b.Property<int?>("Enrolledeid")
                        .HasColumnType("int");

                    b.Property<int>("facultyfid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomNo")
                        .HasColumnType("int");

                    b.HasKey("cid");

                    b.HasIndex("Enrolledeid");

                    b.HasIndex("facultyfid");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Enrolled", b =>
                {
                    b.Property<int>("eid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eid"));

                    b.Property<int>("cid")
                        .HasColumnType("int");

                    b.Property<int>("sid")
                        .HasColumnType("int");

                    b.HasKey("eid");

                    b.ToTable("Enrolled");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Faculty", b =>
                {
                    b.Property<int>("fid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fid"));

                    b.Property<int?>("Studentsid")
                        .HasColumnType("int");

                    b.Property<int>("depid")
                        .HasColumnType("int");

                    b.Property<int>("enrolleid")
                        .HasColumnType("int");

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fid");

                    b.HasIndex("Studentsid");

                    b.HasIndex("enrolleid");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Student", b =>
                {
                    b.Property<int>("sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sid"));

                    b.Property<int?>("Classcid")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("marks")
                        .HasColumnType("int");

                    b.Property<string>("sname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sid");

                    b.HasIndex("Classcid");

                    b.ToTable("std");
                });

            modelBuilder.Entity("EnrolledStudent", b =>
                {
                    b.HasOne("MunirLinqQuery.Data.Enrolled", null)
                        .WithMany()
                        .HasForeignKey("enrollseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunirLinqQuery.Data.Student", null)
                        .WithMany()
                        .HasForeignKey("studentssid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Class", b =>
                {
                    b.HasOne("MunirLinqQuery.Data.Enrolled", null)
                        .WithMany("classes")
                        .HasForeignKey("Enrolledeid");

                    b.HasOne("MunirLinqQuery.Data.Faculty", "faculty")
                        .WithMany("classes")
                        .HasForeignKey("facultyfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("faculty");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Faculty", b =>
                {
                    b.HasOne("MunirLinqQuery.Data.Student", null)
                        .WithMany("faculty")
                        .HasForeignKey("Studentsid");

                    b.HasOne("MunirLinqQuery.Data.Enrolled", "enroll")
                        .WithMany()
                        .HasForeignKey("enrolleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("enroll");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Student", b =>
                {
                    b.HasOne("MunirLinqQuery.Data.Class", null)
                        .WithMany("students")
                        .HasForeignKey("Classcid");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Class", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Enrolled", b =>
                {
                    b.Navigation("classes");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Faculty", b =>
                {
                    b.Navigation("classes");
                });

            modelBuilder.Entity("MunirLinqQuery.Data.Student", b =>
                {
                    b.Navigation("faculty");
                });
#pragma warning restore 612, 618
        }
    }
}
