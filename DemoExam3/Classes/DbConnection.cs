using System.Windows;
using DemoExam3.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam3.Classes
{
    public class DbConnection : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mebel> Mebels { get; set; }

        public DbConnection()
        {
            try
            {
                Database.EnsureCreated();
                Categories.Load();
                Mebels.Load();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3307;uid=root;pwd=;database=mebelsproduction",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

    }
}
