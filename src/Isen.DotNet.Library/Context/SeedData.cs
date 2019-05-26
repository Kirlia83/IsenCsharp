using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Isen.DotNet.Library.Context
{
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICityRepository _cityRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IContractRepository _contractRepository;


        public SeedData(
            ApplicationDbContext dbContext,
            ICityRepository cityRepository,
            IPersonRepository personRepository,
            IPlayerRepository playerRepository,
            IClubRepository clubRepository,
            IContractRepository contractRepository)
        {
            _dbContext = dbContext;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _contractRepository = contractRepository;
        }

        public void DropCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public void AddCities()
        {
            // Ne rien faire s'il y a déjà des villes
            if (_dbContext.CityCollection.Any()) return;

            var cities = new List<City>
            {
                new City { Name = "Toulon", ZipCode = "83000" },
                new City { Name = "Marseille", ZipCode = "13000" },
                new City { Name = "Nice", ZipCode = "06000" },
                new City { Name = "Lyon", ZipCode = "69000" }
            };
            cities.ForEach(city => _cityRepository.Update(city));
            _cityRepository.SaveChanges();
        }

        public void AddPersons()
        {
            // Ne rien faire si non vide
            if(_dbContext.PersonCollection.Any()) return;

            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Miles",
                    LastName = "DAVIS",
                    DateOfBirth = new DateTime(1940,4, 12),
                    BornIn = _cityRepository.Single("Toulon")
                },
                new Person
                {
                    FirstName = "Bill",
                    LastName = "EVANS",
                    DateOfBirth = new DateTime(1946,2, 24),
                    BornIn = _cityRepository.Single("Nice")
                },
                new Person
                {
                    FirstName = "Charlie",
                    LastName = "PARKER",
                    DateOfBirth = new DateTime(1936,12, 14),
                    BornIn = _cityRepository.Single("Toulon")
                }
            };
            persons.ForEach(person => _personRepository.Update(person));
            _personRepository.SaveChanges();
        }
        public void AddPlayers()
        {
            // Ne rien faire si non vide
            if(_dbContext.PlayerCollection.Any()) return;

            var players = new List<Player>();                
                foreach(string line in File.ReadLines("data/player_data.csv"))
                {
                    if (!String.IsNullOrWhiteSpace(line)){
                        string[] parts = line.Split(';');
                        var player = new Player();
                        player.FirstName = parts[0];
                        player.LastName = parts[1];
                        player.DateOfBirth = DateTime.ParseExact(parts[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        players.Add(player);
                    }
                }
            players.ForEach(player => _playerRepository.Update(player));
            _playerRepository.SaveChanges();
        }
        public void AddClubs()
        {
            // Ne rien faire si non vide
            if(_dbContext.ClubCollection.Any()) return;

            var clubs = new List<Club>();                
                foreach(string line in File.ReadLines("data/club_data.csv"))
                {
                    if (!String.IsNullOrWhiteSpace(line)){
                        string[] parts = line.Split(';');
                        var club = new Club();
                        club.Name = parts[0];
                        club.Address = parts[1];
                        club.Logo = parts[2];
                        club.Latitude = parts[3];
                        club.Longitude = parts[4];
                        clubs.Add(club);
                    }
                }
            clubs.ForEach(club => _clubRepository.Update(club));
            _clubRepository.SaveChanges();
        }
        public void AddContracts()
        {
            // Ne rien faire si non vide
            if(_dbContext.ContractCollection.Any()) return;
            var contracts = new List<Contract>();                
                foreach(string line in File.ReadLines("data/contract_data.csv"))
                {
                    if (!String.IsNullOrWhiteSpace(line)){
                        string[] parts = line.Split(';');
                        var contract = new Contract();
                        contract.PlayerContract = _playerRepository.Single(parts[0]);
                        contract.ClubContract = _clubRepository.Single(parts[1]);
                        contract.BeginDate = DateTime.ParseExact(parts[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if(parts.Length == 4)
                        {
                            contract.EndDate = DateTime.ParseExact(parts[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        contracts.Add(contract);
                    }
                }
            contracts.ForEach(contract => _contractRepository.Update(contract));
            _contractRepository.SaveChanges();
        }

    }
}