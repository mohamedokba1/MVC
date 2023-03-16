﻿// <auto-generated />
using MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Migrations
{
    [DbContext(typeof(ITIEntity))]
    [Migration("20230314123407_EditInstructorImage")]
    partial class EditInstructorImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<int>("dept_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MVC.Models.CrsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_Id");

                    b.HasIndex("trainee_id");

                    b.ToTable("CrsResults");
                });

            modelBuilder.Entity("MVC.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeptManager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Crs_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("MVC.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraineeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("MVC.Models.Course", b =>
                {
                    b.HasOne("MVC.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC.Models.CrsResult", b =>
                {
                    b.HasOne("MVC.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Models.Trainee", "Trainee")
                        .WithMany()
                        .HasForeignKey("trainee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("MVC.Models.Instructor", b =>
                {
                    b.HasOne("MVC.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC.Models.Trainee", b =>
                {
                    b.HasOne("MVC.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC.Models.Department", b =>
                {
                    b.Navigation("Instructors");
                });
#pragma warning restore 612, 618
        }
    }
}
