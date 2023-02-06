﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practice.Models;

#nullable disable

namespace Practice.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("ExamStudent", b =>
                {
                    b.Property<long>("ExamsExamId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentsStudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamsExamId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("ExamStudent");
                });

            modelBuilder.Entity("ExamSubject", b =>
                {
                    b.Property<long>("ExamsExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamsExamId", "SubjectsSubjectId");

                    b.HasIndex("SubjectsSubjectId");

                    b.ToTable("ExamSubject");
                });

            modelBuilder.Entity("Practice.Models.Exam", b =>
                {
                    b.Property<long>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamId");

                    b.ToTable("Exams");

                    b.HasData(
                        new
                        {
                            ExamId = 1L,
                            Score = 5,
                            StudentId = 1L,
                            SubjectId = 1
                        },
                        new
                        {
                            ExamId = 2L,
                            Score = 8,
                            StudentId = 2L,
                            SubjectId = 2
                        },
                        new
                        {
                            ExamId = 3L,
                            Score = 10,
                            StudentId = 3L,
                            SubjectId = 3
                        });
                });

            modelBuilder.Entity("Practice.Models.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1L,
                            Address = "Nam Dinh",
                            DateOfBirth = new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hoatdfk2001@gmail.com",
                            Name = "Mai Huy B"
                        },
                        new
                        {
                            StudentId = 2L,
                            Address = "Nam Dinh",
                            DateOfBirth = new DateTime(2001, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hoatdfk2001@gmail.com",
                            Name = "Mai Huy A"
                        },
                        new
                        {
                            StudentId = 3L,
                            Address = "Nam Dinh",
                            DateOfBirth = new DateTime(2001, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "hoatdfk2001@gmail.com",
                            Name = "Mai Huy C"
                        });
                });

            modelBuilder.Entity("Practice.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            Description = "this is a language",
                            EndDate = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "K203",
                            SubjectName = "C start it program"
                        },
                        new
                        {
                            SubjectId = 2,
                            Description = "this is a language",
                            EndDate = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "K204",
                            SubjectName = "PHP program"
                        },
                        new
                        {
                            SubjectId = 3,
                            Description = "this is a language",
                            EndDate = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectCode = "K205",
                            SubjectName = "JAVA  program"
                        });
                });

            modelBuilder.Entity("ExamStudent", b =>
                {
                    b.HasOne("Practice.Models.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practice.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamSubject", b =>
                {
                    b.HasOne("Practice.Models.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practice.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
