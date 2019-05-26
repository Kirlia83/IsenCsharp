using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPlayerRepository :
        BaseInMemoryRepository<Player>,
        IPlayerRepository
    {   
        
        // Pattern d'Injection de Dépendance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryPlayerRepository()
        {
        }

        public override List<Player> SampleData =>
            new List<Player>()
            {
                new Player
                {
                    FirstName = "Sarah",
                    LastName = "Bouhadi",
                    DateOfBirth = new DateTime(1986,10, 17)
                },
                new Player
                {
                    FirstName = "Solène",
                    LastName = "Durand",
                    DateOfBirth = new DateTime(1994,11, 20)
                },
                new Player
                {
                    FirstName = "Pauline",
                    LastName = "Peyraud-Magnin",
                    DateOfBirth = new DateTime(1992,3, 17)
                }
            };
    }
}