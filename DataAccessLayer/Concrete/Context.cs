using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
  public class Context : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Port=5432;Password=123456;Database=CoreBlogDb;Pooling=true; Integrated Security =true;");
      optionsBuilder.UseSqlServer("Server=DESKTOP-O3DVRF8\\SQLEXPRESS;User Id=DESKTOP-O3DVRF8\\oguzh;Password=;Database=CoreBlogDb;Pooling=true; Integrated Security =true;");
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<BlogRayting> BlogRaytings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
  }
}
