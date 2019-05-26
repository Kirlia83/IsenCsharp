using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryClubRepository :
        BaseInMemoryRepository<Club>,
        IClubRepository
    {      
        public override List<Club> SampleData =>
            new List<Club>()
            {
                new Club
                {
                    Name = "Olympique lyonnais",
                    Address = "Parc OL, 10 avenue Simone Veil, 69150 Décines-Charpieu",
                    Logo = "https://fr.wikipedia.org/wiki/Olympique_lyonnais_(f%C3%A9minines)#/media/File:Olympique_lyonnais_(logo).svg",
                    Longitude = "4.9728",
                    Latitude = "45.769"
                },
                new Club
                {
                    Name = "En avant de Guingamp",
                    Address = "15, boulevard Clemenceau, 22202 Guingamp",
                    Logo = "https://fr.wikipedia.org/wiki/En_avant_de_Guingamp_(f%C3%A9minines)#/media/File:En_Avant_de_Guingamp_logo.svg",
                    Longitude = "-3.1439365",
                    Latitude = "48.5572897"
                },
                new Club
                {
                    Name = "Arsenal Women Football Club",
                    Address = "Highbury House, 75 Drayton Park, London N5 1BU",
                    Logo = "https://fr.wikipedia.org/wiki/Arsenal_Women_Football_Club#/media/File:Arsenal_FC.svg",
                    Longitude = "-0.106371",
                    Latitude = "51.556667"
                }
            };
    }
}