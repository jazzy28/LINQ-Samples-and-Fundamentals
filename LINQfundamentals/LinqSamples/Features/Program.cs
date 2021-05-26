using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x ;//takes int and returns int
            Console.WriteLine(square(3));
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(2,3));

            //Action: similar to func, but always return void
            Action<int> write = x =>  Console.WriteLine(x);
            write(square(add(3, 5)));

            IEnumerable<Employee> developers = new Employee[] //collection (type: array) named: developers, represents department in the company
            {
                new Employee { Id = 1, Name = "Jasmine"},
                new Employee { Id = 2, Name = "Lily"}
            };
            IEnumerable<Employee> sales = new List<Employee>() //collection 2: list of employee
            {
                new Employee {Id = 3, Name = "Rose"}
            };

            /*foreach(var person in developers)
            {
               Console.WriteLine(person.Name);
            }*/

            //sales.GetEnumerator //both list and array implements an interface: IEnumerable of T interface. IEnumerable: v. imp interface for linq. used to build query features

            //count number of employees in dept
            /*Console.WriteLine(developers.Count());

            //fetch IEnumerator of an Employee
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name); //returns element of the current position
            }*/

            //LAMBDA Expressions
            /*foreach(var employee in developers.Where(NameStartsWithJ))
            {
                Console.WriteLine(employee.Name);
            }*/

            //lambda
            foreach (var employee in developers.Where(
               e =>e.Name.StartsWith("J")))
            {
                Console.WriteLine(employee.Name);
            }

        }

        

        private static bool NameStartsWithJ(Employee employee)
        {
            //throw new NotImplementedException();
            return employee.Name.StartsWith("J");
        }
    }
}
