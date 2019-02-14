using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq; 

namespace Lab_6
{
    class Program
    {

        // creating and deleting the database every time the program ran. 
        static void Main(string[] args)
        {
            using (var db = new StudioContent())
            {
                db.Database.EnsureDeleted(); 
                db.Database.EnsureCreated(); 
            }
            

            //adding movies to century fox  
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

                //adding century and Universal 
                studio Universal = new studio {
                        studioName= "Universal Pictures"

                };
                db.Add(CenturyFox);
                db.Add(Universal);
                db.SaveChanges();
            
            }
             
            // adding jurassic park to Universal 
            using (var db = new StudioContent())
            {
                Movie Add = new Movie {movieName = "Jurassic Park", genre = "Action"};
                studio updatedstudio = db.studios.Include(b => b.movies).Where (b => b.studioName =="Universal Pictures").First();
                updatedstudio.movies.Add(Add);
                db.SaveChanges();
            }

            //moving Apollo 13 to Universal 
            using (var db = new StudioContent())
            {
                Movie movies = db.movies.Where(p => p.movieName == "Apollo 13").First();
                movies.studio = db.studios.Where (b =>b.studioName == "Universal Pictures").First(); 
                db.SaveChanges(); 
        
            };
            // delete the instance of Deadpool
            using ( var db = new StudioContent())
            {
                Movie d = db.movies.Where(p => p.movieName == "Deadpool").First();
                db.Remove(d);
                db.SaveChanges(); 
            }

            // listing all movies and their studios
        using (var db = new StudioContent())        
        {
            var studios = db.studios.Include(b =>b.movies);
           foreach ( var b in studios ){

               Console.WriteLine (b);
               
               foreach(var p in b.movies)
               {
                Console.WriteLine("\t" + p);
               }
           }
        }


            




        }
    }

}
