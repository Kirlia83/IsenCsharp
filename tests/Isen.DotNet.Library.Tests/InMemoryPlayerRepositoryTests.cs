using System;
using Xunit;
using Isen.DotNet.Library.Lists;
using System.Collections.Generic;
using Isen.DotNet.Library.Repositories.InMemory;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Tests
{
    public class PlayerRepoFactory
    {
        public static IPlayerRepository Create() =>
            new InMemoryPlayerRepository();
    }
    public class InMemoryPlayerRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var playerRepo = PlayerRepoFactory.Create();
            
            var player1 = playerRepo.Single(1);
            Assert.True(player1.Id == 1);

            var noPlayer = playerRepo.Single(42);
            Assert.True(noPlayer == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var playerRepo = PlayerRepoFactory.Create();

            var toulon = playerRepo.Single("Sarah Bouhadi");
            Assert.True(toulon.Name == "Sarah Bouhadi");

            var fake = playerRepo.Single("Fake");
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();

            var Sarah = playerRepo.Single("Sarah Bouhadi");
            Sarah.FirstName = "Sarah";
            Sarah.LastName = "Bouhadi";
            Sarah.DateOfBirth = new DateTime(1986,10, 17);

            playerRepo.Update(Sarah);
            playerRepo.SaveChanges();

            var FinalCount = playerRepo.Context
                .ToList()
                .Count();

            var SarahUpdated = 
                playerRepo.Single(Sarah.Id);
            Assert.True(SarahUpdated.Name == "Sarah Bouhadi");
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();

            var Lola = new Player() 
            {
                FirstName = "Lola",
                LastName = "MA",
                DateOfBirth = new DateTime(1986,10, 17)
            };
            playerRepo.Update(Lola);
            playerRepo.SaveChanges();

            var FinalCount = playerRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var lolaCreated = playerRepo.Single("Lola MA");
            Assert.True(lolaCreated != null);
            Assert.True(!lolaCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var initialCount = playerRepo.Context
                .ToList()
                .Count();

            var toulon = playerRepo.Single("Sarah Bouhadi");
            playerRepo.Delete(toulon);
            playerRepo.SaveChanges();
            var finalCount = playerRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(playerRepo.Single("Sarah Bouhadi") == null);
        }

        [Fact]
        public void GetAll()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var contextCount = playerRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = playerRepo
                .GetAll()
                .ToList()
                .Count();

            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var playerRepo = PlayerRepoFactory.Create();
            var query = playerRepo
                .Find(c => c.Name.Contains("h"));
            var result = query.ToList();

            var countCitiesFromQuery = 0;
            foreach(var c in playerRepo.Context.ToList())
            {
                if(c.Name.Contains("h"))
                    countCitiesFromQuery++;
            }
            Assert.True(result.Count == countCitiesFromQuery);
        }
    }
}