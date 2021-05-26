using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXml();
            QueryXml();
        }

        private static void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");

            var query = from element in document.Element("Cars").Elements("Car")
                        where element.Attribute("Combines").Value == "31"
                        select element.Attributes("Name").ToList();

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void CreateXml()
        {
            var records = ProcessFile("fuel.csv"); //this method should provide list of cars

            var document = new XDocument(); //working with xml
            var cars = new XElement("Cars"); //names

            foreach (var record in records)
            {

                var name = new XAttribute("Name", record.Name);
                var combined = new XAttribute("Combines", record.Combined);
                var car = new XElement("Car", name, combined); //functional construction



                cars.Add(car);
            }
            document.Add(cars);
            document.Save("fuel.xml");
        }

        //var query = cars.OrderByDescending(c => c.Combined)
        //.OrderBy(c => c.Name);
        //.ThenBy(c => c.Name);
        /* var query = 
         from car in cars
         where car.Manufacturer == "BMW" && car.Year == 2016
         orderby car.Combined descending, car.Name
          select car;

         var result = cars.Any(c => c.Manufacturer == "Ford");//checking if there is any kind of data related to ford
         var result1 = cars.All(c => c.Manufacturer == "Ford");//to check if all data is ford, returns true, if it finds that name
         Console.WriteLine(result);
         Console.WriteLine(result1);//false, not all
         foreach (var car in query.Take(10)) //take 10 samples
         {
             Console.WriteLine($"{car.Name} : {car.Combined}");

         }
     }*/

        private static List<Cars> ProcessFile(string path)
            {
                var query =
                    File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .Select(l => Cars.ParseFromCsv(l));
                //.ToCar();

                /*from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Cars.ParseFromCsv(line); //map from string to Car */

            return query.ToList();
            
          
        }

    }
   /* public static class CarExtensions
    {
        public static IEnumerable<Cars> ToCar(this IEnumerable<string> source)
        {
            foreach(var line in source) //PROJECTION
            {
                var columns = line.Split(',');
                yield return new Cars
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[6])
                };
            }
            
        }
    }*/
}
