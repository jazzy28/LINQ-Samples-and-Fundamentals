using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{Title = "Mulan", Rating = 8.9f, Year=2018},
                new Movie{Title = "Barfi", Rating = 9.0f, Year=2017},
                new Movie{Title = "Gippi", Rating = 7.6f, Year=2015}
            };
            //lambda expression
            //var query = movies.Where(m => m.Year > 2015);

            //creating own filter operator
            var query = movies.Filter(m => m.Year > 2015);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }

        }
    }
}
