using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Model
{
    public class Batalha
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }


        // Para criar a relação Many to Many é necessário que crie um model para conter a relação entre
        // as duas tabelas e em cada model especifico inclui uma lista referenciando a este model
        // que ao realizar uma busca para o model especifico será retornado a lista de model do model secundário.
        // public List<HeroiBatalha> HeroisBatalhas { get; set; }

    }
}
