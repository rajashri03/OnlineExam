﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.AppContext;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositoryLayer.Entities.CourseEntity", b =>
                {
                    b.Property<int>("Courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coursename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("Courseid");

                    b.HasIndex("userid");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.QuestionEntity", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("QuestionId");

                    b.HasIndex("courseid");

                    b.HasIndex("userid");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.SetExamEntity", b =>
                {
                    b.Property<long>("examsetupid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<string>("endTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("examdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("examdiscription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exampassmarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examstarttime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examtotalmarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("singleQuestionmarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectid")
                        .HasColumnType("int");

                    b.Property<int>("totalquestion")
                        .HasColumnType("int");

                    b.HasKey("examsetupid");

                    b.HasIndex("courseid");

                    b.HasIndex("subjectid");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.StudentEntity", b =>
                {
                    b.Property<int>("studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<string>("userType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentid");

                    b.HasIndex("courseid");

                    b.ToTable("StudentInfo");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.SubjectEntity", b =>
                {
                    b.Property<int>("Subjectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Courseid")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("Subjectid");

                    b.HasIndex("userid");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.UserEntity", b =>
                {
                    b.Property<long>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RepositoryLayer.Entities.CourseEntity", b =>
                {
                    b.HasOne("RepositoryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Entities.QuestionEntity", b =>
                {
                    b.HasOne("RepositoryLayer.Entities.CourseEntity", "courses")
                        .WithMany()
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Entities.SetExamEntity", b =>
                {
                    b.HasOne("RepositoryLayer.Entities.CourseEntity", "courses")
                        .WithMany()
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Entities.SubjectEntity", "subjects")
                        .WithMany()
                        .HasForeignKey("subjectid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Entities.StudentEntity", b =>
                {
                    b.HasOne("RepositoryLayer.Entities.CourseEntity", "courses")
                        .WithMany()
                        .HasForeignKey("courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Entities.SubjectEntity", b =>
                {
                    b.HasOne("RepositoryLayer.Entities.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
