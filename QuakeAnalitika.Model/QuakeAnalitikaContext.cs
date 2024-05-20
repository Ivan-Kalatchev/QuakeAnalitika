using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace QuakeAnalitika.Model;

public class QuakeAnalitikaContext : DbContext
{

    /// <summary>
    /// Database path
    /// </summary>
    public string DbPath { get; }

    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }

    /// <summary>
    /// Default c-tor
    /// </summary>
    public QuakeAnalitikaContext()
    {
        var currentLocation = Assembly.GetExecutingAssembly();
        var path = Path.GetDirectoryName(currentLocation.Location);
        DbPath = Path.Join(path, "Data.db");
    }

    /// <summary>
    /// On configuring override
    /// </summary>
    /// <param name="options"></param>
    protected override async void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

}