using System;

namespace Isen.DotNet.Library.Models
{
    public class City : BaseModel
    {
        public override int Id{get; set;}
        public override string Name{get; set;}
        public string ZipCode{get; set;}
        public override string Display
        {
            get
            {
                var baseDisplay = base.Display;
                baseDisplay += $"| ZipCode = {ZipCode}";
                return baseDisplay;
            }
        }
    }
}