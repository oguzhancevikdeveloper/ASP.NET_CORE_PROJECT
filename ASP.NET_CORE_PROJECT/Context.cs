using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Writer> Writers { get; set; }
  }
}
