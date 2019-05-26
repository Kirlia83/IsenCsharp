using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Isen.DotNet.Library.Models
{
    public class Contract : BaseModel<Contract>
    {
        public override int Id { get;set; }
        public Player PlayerContract { get;set; }
        public int? PlayerId { get; set; }
        public Club ClubContract { get; set; }
        public int? ClubId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public override String Name { get; set; }

        public Contract()
        {
            
        }

        public override string Display => 
            $"{base.Display}|Player={PlayerContract}|Club={ClubContract}|DateDebut={BeginDate}|DateFin={EndDate}";

        public override void Map(Contract copy)
        {
            base.Map(copy);
            PlayerContract = copy.PlayerContract;
            PlayerId = copy.PlayerId;
            ClubContract = copy.ClubContract;
            ClubId = copy.ClubId;
            BeginDate = copy.BeginDate;
            EndDate = copy.EndDate;
        }

        public string DisplayForPlayer()
        {
            var begin =BeginDate.HasValue? BeginDate.Value.ToString("yyyy") : "";
            var end =EndDate.HasValue? EndDate.Value.ToString("yyyy") : "en cours";
            return $"{ClubContract.Name} : {begin} - {end}";
        }
            
        
        public string DisplayForClub()
        {
            var begin =BeginDate.HasValue? BeginDate.Value.ToString("yyyy") : "";
            var end =EndDate.HasValue? EndDate.Value.ToString("yyyy") : "en cours";
            return $"{PlayerContract.Name} : {begin} - {end}";
        }
        public override dynamic ToDynamic()
        {
            dynamic response = new ExpandoObject();
            response.id = Id;
            response.joueuse = PlayerContract.ToDynamic();
            response.joueuseId = PlayerId;
            response.dateDeDebut = BeginDate;
            response.dateDeFin = EndDate;
            return response;
        }
    }
}