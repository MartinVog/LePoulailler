using DALBase;
using DALIngredient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALSandwich
{
    public class EOSandwich
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? MediumPrice { get; set; }
        public decimal? BigPrice { get; set; }
        public decimal? MaxiPrice { get; set; }
        public int Type { get; set; }

        public List<EOIngredient> IngredientsList { get; set; }

        public EOSandwich()
        {
            Id = -1;
            Code = Guid.NewGuid().ToString();

            IngredientsList = new List<EOIngredient>();
        }

        public EOSandwich(MySqlDataReader reader)
        {
            Id = DBTools.GetInt64(reader, "id");
            Name = DBTools.GetString(reader, "name");
            Code = DBTools.GetString(reader, "code");
            MediumPrice = DBTools.GetDecimalNull(reader, "price");
            BigPrice = DBTools.GetDecimalNull(reader, "price");
            MaxiPrice = DBTools.GetDecimalNull(reader, "price");
            Type = DBTools.GetInt32(reader, "type");

            IngredientsList = new List<EOIngredient>();
        }
    }
}




// Id 
// Name 
// Code 
// Price 