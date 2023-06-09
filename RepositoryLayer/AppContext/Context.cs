﻿using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.AppContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StudentEntity> StudentInfo { get; set; }
        public DbSet<CourseEntity> courses { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<SetExamEntity> Exams { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
    }
    }
