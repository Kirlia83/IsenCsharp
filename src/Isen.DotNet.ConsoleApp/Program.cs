using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = new Hello("Camille");
            var message = hello.Greet();
            Console.WriteLine(message);

            var list = new MyCollection<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            var enumerator = list.Values.GetEnumerator();
            while(enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);


            var toulon = new City()
            {
                Id = 1,
                Name = "Toulon",
                ZipCode = "83000"
            };
            var nice = new City()
            {
                Id = 2,
                Name = "Nice",
                ZipCode = "060000"
            };
            var jd = new Person()
            {
                Id = 1,
                FirstName = "John", 
                LastName = "Doe", 
                DateOfBirth = new DateTime(1964,12,24),
                BornIn = nice,
            };
            Console.WriteLine(jd);
            var unborn = new Person()
            {
                FirstName = "The", 
                LastName = "Unborn"
            };
            Console.WriteLine(unborn);

            var inLinePerson = new Person()
            {
                Id = 2,
                LastName = "Arbousset",
                FirstName = "Camille",
                DateOfBirth = new DateTime(1997, 10, 31),
                BornIn = toulon,
            };
            Console.WriteLine(inLinePerson);
            
        }
    }
}
