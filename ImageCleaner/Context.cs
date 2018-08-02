using ImageCleaner.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCleaner
{
    public class Context : DbContext
    {
        public Context()
            : base()
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = (string)JObject.Parse(File.ReadAllText("appsettings.json"))["ConnectionStrings"]["DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }

    }

}
