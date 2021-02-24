using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Model
{
    public class Arma
    {
        public int Id { get; set; }
        public String nome { get; set; }
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }
    }
}
