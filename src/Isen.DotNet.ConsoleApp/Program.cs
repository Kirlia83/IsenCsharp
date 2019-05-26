using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Library.Context;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var hello = new Hello("Camille");
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
            */
            /* var inLinePerson = new Player()
            {
                Id = 2,
                LastName = "Arbousset",
                FirstName = "Camille",
                DateOfBirth = new DateTime(1997, 10, 31),
            };

            Console.WriteLine(inLinePerson);
            */
            var player = new Player()
                {
                    FirstName = "Sarah",
                    LastName = "Bouhadi",
                    DateOfBirth = new DateTime(1986,10, 17)
                };
                Console.WriteLine(player);
            var club = new Club()
            {
                Name = "Olympique lyonnais",
                    Address = "Parc OL, 10 avenue Simone Veil, 69150 Décines-Charpieu",
                    Logo = "https://fr.wikipedia.org/wiki/Olympique_lyonnais_(f%C3%A9minines)#/media/File:Olympique_lyonnais_(logo).svg",
                    Longitude = "4.9728",
                    Latitude = "45.769"
            };
            Console.WriteLine(club);
        }
        
    }
}
