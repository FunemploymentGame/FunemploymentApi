using FunemploymentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunemploymentApi.Data
{
    public class FunemploymentDBContext : DbContext 
    {
        public FunemploymentDBContext(DbContextOptions<FunemploymentDBContext>options) : base(options)
        {
        }

        public DbSet<BehaviorQuestion> BehaviorQuestions { get; set; }
        public DbSet<TechnicalQuestion> TechnicalQuestions { get; set; } 
    }
}
