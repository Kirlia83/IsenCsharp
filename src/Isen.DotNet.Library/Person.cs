using System;

namespace Isen.DotNet.Library.Person
{
    public class Person
    {
        public string FirstName { get; set;}

        public string LastName {get; set;}

        public DateTime DateOfBirth { get; set;}

        public Person(DateTime dateOfBirth): this(firstname, lastname)
        {
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname
        }
    }
}