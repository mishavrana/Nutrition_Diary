﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using NutritionDiary.DTOs;
using NutritionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionDiary.DbContexts
{
    public class ToDiaryDbContext : DbContext
    {
        public ToDiaryDbContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<WeekDTO> Weeks { get; set; }
    }
}
