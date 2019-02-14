using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq; 

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudioContent())
            {
                db.Database.EnsureDeleted(); 
                db.Database.EnsureCreated(); 
            }
            
            using (var db = new StudioContent())
            {
                studio CenturyFox = new studio{

                    studioName = "20th Century Fox",
                    movies = new List <Movie>
                    {
                    new Movie {movieName = "Avatar", genre = "Action"},
                    new Movie {movieName = "Deadpool", genre = "Action"},
                    new Movie {movieName = "Apollo 13", genre = "Drama"}, 
                    new Movie {movieName = "The Martian", genre = "Sci-Fi"}

                    }
                };

                studio Universal = new studio {
                        studioName= "Universal Pictures"

                };
                db.Add(CenturyFox);
                db.Add(Universal);
                db.SaveChanges();
            
            }

            using (var db = new StudioContent())
            {
                Movie movies = new Movie {movieName = "Jurassic Park", genre = "Action"};

                db.Add (movies);
            }

            using (var db = new StudioContent())
            {
                
            }




        }
    }

}
