using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
  public class Context : IdentityDbContext<AppUser,AppRole,int>
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Port=5432;Password=123456;Database=CoreBlogDb;Pooling=true; Integrated Security =true;");
      optionsBuilder.UseSqlServer("Server=DESKTOP-O3DVRF8\\SQLEXPRESS;User Id=DESKTOP-O3DVRF8\\oguzh;Password=;Database=CoreBlogDb;Pooling=true; Integrated Security =true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Match>()
        .HasOne(x => x.HomeTeam)
        .WithMany(y => y.HomeMatches)
        .HasForeignKey(z => z.HomeTeamId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<Match>()
        .HasOne(x => x.GuestTeam)
        .WithMany(y => y.AwayMatches)
        .HasForeignKey(z => z.GuestTeamId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<Message2>()
        .HasOne(x => x.SenderUser)
        .WithMany(y => y.WriterSender)
        .HasForeignKey(z => z.SenderId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      modelBuilder.Entity<Message2>()
        .HasOne(x => x.ReceiverUser)
        .WithMany(y => y.WriterReceiver)
        .HasForeignKey(z => z.ReceiverId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      base.OnModelCreating(modelBuilder);

      //HomeMatches --> WriterSender
      //AwayMatches --> WriterReceiver

      //HomeTeam --> SenderUser
      //GuestTeam -->ReceiverUser

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
    public DbSet<Message2> Message2s { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Admin> Admins { get; set; }
  }
}
