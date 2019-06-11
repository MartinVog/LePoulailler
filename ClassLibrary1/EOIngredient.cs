using System;
using System.Collections.Generic;
using System.Text;
using DALBase;
using MySql.Data.MySqlClient;

namespace DALIngredient
{
    public class EOIngredient
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal MediumPrice { get; set; }
        public decimal? BigPrice { get; set; }
        public decimal? MaxiPrice { get; set; }

        public long PlatId { get; set; }

        public EOIngredient()
        {
            Id = -1;
            Code = Guid.NewGuid().ToString();
        }


        public EOIngredient(MySqlDataReader reader,string platName)
        {
            Id = DBTools.GetInt64(reader, "id");
            Name = DBTools.GetString(reader, "name");
            Code = DBTools.GetString(reader, "code");
            MediumPrice = DBTools.GetDecimal(reader, "medium_price");
            BigPrice = DBTools.GetDecimalNull(reader, "big_price");
            MaxiPrice = DBTools.GetDecimalNull(reader, "maxi_price");

            PlatId = DBTools.GetInt64(reader, platName+"_id");
        }
    }
}


// Id 
// Name 
// Code 
// MediumPrice 
// BigPrice 
// MaxiPrice 