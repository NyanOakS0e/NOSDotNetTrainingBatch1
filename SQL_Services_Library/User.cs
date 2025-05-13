using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SQL_Services_Shared
{

    // not work becauseEntity Framework Core interprets dbo.Users as a literal
    // table name — not as schema + table — so it tries to query a table literally called:

    //[Table("dbo.Users")] 


    [Table("Users")]
    // OR
    //[Table("Users", Schema = "dbo")]

    public class User
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }

    }

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    optionsBuilder.UseSqlServer(@"
                    Server=.;
                    Database=NOSDotNetTrainingBatch1;
                    User Id=sa;
                    Password=sasa@123;
                    TrustServerCertificate = true;");

                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("OnConfiguring" + e.Message);
                }


            }
        }
        public DbSet<User> Users { get; set; }
    }
}
