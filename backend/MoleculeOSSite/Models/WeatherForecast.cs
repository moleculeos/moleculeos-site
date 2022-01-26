using System.Data.Entity;

namespace MoleculeOSSite;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public class MovieDBContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
}
