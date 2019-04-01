using System;

namespace Isen.DotNet.Library.Models
{
    public abstract class BaseModel
    {
        public virtual int Id{get; set;}
        public virtual string Name {get; set;}

        public virtual string Display =>
            $"Id={Id}| Name = {Name} [{this.GetType()}]";

        public override string ToString()
        {
            return Display;
        }
    }
}