using DALBase;
using DALIngredient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALSandwich
{
    public class DOSandwich
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MediumPrice { get; set; }
        public decimal? BigPrice { get; set; }
        public decimal? MaxiPrice { get; set; }

        public enum TypeSandwich { Poulet = 1, Boeuf = 2, Porc = 3, Poisson = 4, Fromage = 5, Monde = 6, Vegetation = 7 }
        public TypeSandwich Type { get; set; }
        public string TypeTraduction { get; set; }

        public List<EOIngredient> IngredientsList { get; set; }

        public DOSandwich()
        {
            IngredientsList = new List<EOIngredient>();
        }

        public DOSandwich(MySqlDataReader reader)
        {
            Id = DBTools.GetInt64(reader, "id");
            Name = DBTools.GetString(reader, "name");
            Code = DBTools.GetString(reader, "code");
            MediumPrice = DBTools.GetDecimalNull(reader, "medium_price");
            BigPrice = DBTools.GetDecimalNull(reader, "big_price");
            MaxiPrice = DBTools.GetDecimalNull(reader, "maxi_price");

            Type = (TypeSandwich)DBTools.GetInt32(reader, "type");
            TypeTraduction = GetTraductionType(Type);

            IngredientsList = new List<EOIngredient>();
        }

        private string GetTraductionType(TypeSandwich type)
        {
            switch (type)
            {
                case TypeSandwich.Poulet: return "Poulet";
                case TypeSandwich.Boeuf: return "Boeuf";
                case TypeSandwich.Porc: return "Porc";
                case TypeSandwich.Poisson: return "Poisson";
                case TypeSandwich.Fromage: return "Fromage";
                case TypeSandwich.Monde: return "Monde";
                case TypeSandwich.Vegetation: return "Végétation";
                default: return "La traduction de TypeSandwich n'existe pas";
            }
        }
    }
}


// Id 
// Name 
// Code 
// Price 