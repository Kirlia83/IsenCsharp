using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryContractRepository :
        BaseInMemoryRepository<Contract>,
        IContractRepository
    {   
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;
        
        // Pattern d'Injection de Dépendance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryContractRepository(
            IPlayerRepository playerRepository,
            IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }

        public override List<Contract> SampleData =>
            new List<Contract>()
            {
                new Contract
                {
                    PlayerContract = _playerRepository.Single("Sarah Bouhadi"),
                    ClubContract = _clubRepository.Single("Olympique lyonnais"),
                    BeginDate = new DateTime(2009),
                    Name = "Contrat"
                },
                new Contract
                {
                    PlayerContract = _playerRepository.Single("Sarah Bouhadi"),
                    ClubContract = _clubRepository.Single("En avant de Guingamp"),
                    BeginDate = new DateTime(2006),
                    EndDate = new DateTime(2009),
                    Name = "Contrat"
                },
                new Contract
                {
                    PlayerContract = _playerRepository.Single("Sarah Bouhadi"),
                    ClubContract = _clubRepository.Single("Arsenal Women Football Club"),
                    BeginDate = new DateTime(2005),
                    EndDate = new DateTime(2006),
                    Name = "Contrat"
                }
            };
    }
}