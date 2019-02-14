using System; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 

namespace Lab_6{

public class StudioContent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
        public DbSet<studio> studios { get; set; }

        public DbSet <Movie> movies {get; set; }

    } 

    public class studio{
        public int studioID {get; set; }
        public string studioName{get; set; }
        public List<Movie> movies {get; set;}

        public override string ToString() {
            return $"Studio {studioID} - {studioName}";
        }



    }

public class Movie{
    public int moviesId{get; set; }
    public string movieName {get; set; }
    public string genre{ get; set; }
    public int studioID {get; set; }
    public studio studio {get; set; }

    public override string ToString(){
        return $"movies {moviesId}- {movieName}";
    }

}
}