using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace Isen.DotNet.Library.Models
{
    public class Club : BaseModel<Club>
    {
        public override int Id { get;set; }
        public override string Name { get;set; }
        public string Address { get;set; }
        public string Logo { get;set; }
        public string Longitude { get;set; }

        public string Latitude { get;set; }

        public List<Contract> ContractCollection { get; set; } =
            new List<Contract>();

        [NotMapped]
        public override string Display => 
            $"{base.Display}|Address={Address}|Longitude={Longitude}|Latittute={Latitude}";

        public override void Map(Club copy)
        {
            base.Map(copy);
            Address = copy.Address;
            Longitude = copy.Longitude;
            Latitude = copy.Latitude;
            Logo = copy.Logo;
            ContractCollection = copy.ContractCollection;
        }

        public override dynamic ToDynamic()
        {
            var baseDynamic = base.ToDynamic();
            baseDynamic.adresse = Address;
            baseDynamic.latitude = Latitude;
            baseDynamic.longitude = Longitude;
            ContractCollection.Sort((x, y) => DateTime.Compare(x.BeginDate.Value, y.BeginDate.Value));
            List<Contract> actuel = new List<Contract>();
            List<Contract> ancien = new List<Contract>();
            foreach (var contract in ContractCollection)
            {
                if(contract.EndDate == null)
                {
                    actuel.Add(contract);
                }
                else
                {
                    ancien.Add(contract);
                }
            }
            baseDynamic.contrats_en_cours = actuel
                .Select(e => e.ToDynamic())
                .ToList();
            baseDynamic.anciens_contrats = ancien
                .Select(e => e.ToDynamic())
                .ToList();
            return baseDynamic;
        }
    }
}