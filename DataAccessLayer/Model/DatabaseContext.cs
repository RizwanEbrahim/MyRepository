using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataAccessLayer.Model;

namespace DataAccessLayer.Model
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext() : base(nameOrConnectionString: "Default") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            /* modelBuilder
                .Entity<Course>()
                  .HasIndex(u => u.code)
                     .IsUnique();*/
        }
        public DbSet<Answer>Answers { get; set; }
        public DbSet<Question>Questions { get; set; }

        //public System.Data.Entity.DbSet<PresantaionLayer.Models.AnswerView> AnswerViews { get; set; }

        // public System.Data.Entity.DbSet<PresantaionLayer.Models.AnswerView> AnswerViews { get; set; }

        // public System.Data.Entity.DbSet<PresantaionLayer.Models.AnswerView> AnswerViews { get; set; }
    }

}

