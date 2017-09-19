using Microsoft.EntityFrameworkCore;
using NetworkConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace NetworkConfigurator.DataManager
{
    public class PeopleContext :DbContext
    {
        DbSet<Person> people { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:viewnet2.database.windows.net,1433;Initial Catalog=viewnet2;Persist Security Info=False;User ID=webappuser;Password=Mmd44035;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Persist Security Info=True;");
        }

        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {
        }
        public PeopleContext() { }
    }
}
