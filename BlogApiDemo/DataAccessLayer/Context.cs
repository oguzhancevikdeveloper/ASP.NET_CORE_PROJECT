using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer
{
  public class Context : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Port=5432;Password=123456;Database=CoreBlogDb;Pooling=true; Integrated Security =true;");
      optionsBuilder.UseSqlServer("Server=DESKTOP-O3DVRF8\\SQLEXPRESS;User Id=DESKTOP-O3DVRF8\\oguzh;Password=;Database=CoreBlogApiDb;Pooling=true; Integrated Security =true;");
    }
    public DbSet<Employee> Employees { get; set; }
  }
}
 