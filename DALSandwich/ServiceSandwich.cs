using DALIngredient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALSandwich
{
    public class ServiceSandwich
    {
        public MySqlConnection Connexion { get; private set; }
        public ServiceSandwich(MySqlConnection connexion)
        {
            Connexion = connexion;
        }

        /// <summary>
        /// Ajoute une nouvelle ligne sandwich
        /// </summary>
        /// <param name="sandwich">sandwich editable</param>
        public void SaveNewSandwich(EOSandwich sandwich)
        {
            using (var command = Connexion.CreateCommand())
            {
                command.CommandText = @"insert into sandwich (name,code,medium_price,big_price,maxi_price,type)
                                        values(@Name,@Code,@MediumPrice,@BigPrice,@MaxiPrice,@Type);SELECT LAST_INSERT_ID();";

                command.Parameters.AddWithValue("Name", sandwich.Name);
                command.Parameters.AddWithValue("Code", sandwich.Code);
                command.Parameters.AddWithValue("MediumPrice", sandwich.MediumPrice);
                command.Parameters.AddWithValue("BigPrice", sandwich.BigPrice);
                command.Parameters.AddWithValue("MaxiPrice", sandwich.MaxiPrice);
                command.Parameters.AddWithValue("Type", sandwich.Type);

                sandwich.Id = Convert.ToInt64(command.ExecuteScalar());
            }
        }

        /// <summary>
        /// Modifie la ligne du sandwich
        /// </summary>
        /// <param name="sandwich">sandwich editable</param>
        public void SaveUpdateSandwich(EOSandwich sandwich)
        {
            using (var command = Connexion.CreateCommand())
            {
                command.CommandText = "update sandwich set name=@Name, code=@Code, medium_price=@MediumPrice, big_price=@BigPrice, maxi_price=@MaxiPrice, type=@Type where id = @Id;";

                command.Parameters.AddWithValue("Id", sandwich.Id);
                command.Parameters.AddWithValue("Name", sandwich.Name);
                command.Parameters.AddWithValue("Code", sandwich.Code);
                command.Parameters.AddWithValue("MediumPrice", sandwich.MediumPrice);
                command.Parameters.AddWithValue("BigPrice", sandwich.BigPrice);
                command.Parameters.AddWithValue("MaxiPrice", sandwich.MaxiPrice);
                command.Parameters.AddWithValue("Type", sandwich.Type);
                command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Supprime de la base de donnée un sandwich et toutes ses références commandes et ingrédients
        /// </summary>
        /// <param name="sandwichId">Id du sandwich</param>
        public void SaveDeleteSandwich(long sandwichId)
        {
            using (var command = Connexion.CreateCommand())
            {
                command.CommandText += $"delete from sandwich_ingredient where sandwich_id =@Id";
                command.CommandText += $"delete from commande_sandwich where sandwich_id =@Id";
                command.CommandText += "delete from sandwich where id = @Id";

                command.Parameters.AddWithValue("Id", sandwichId);
                command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Retourne toutes les sandwich en base de donnée
        /// </summary>
        /// <returns>dictionnaire > key = sandwichId, value = sandwich</returns>
        public Dictionary<long, DOSandwich> GetAllSandwich()
        {
            var ret = new Dictionary<long, DOSandwich>();

            using (var command = Connexion.CreateCommand())
            {
                command.CommandText = @"SELECT id,name,code,medium_price,big_price,maxi_price,type from sandwich;";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var n = new DOSandwich(reader);
                    ret.Add(n.Id, n);
                }
            }

            //Fill Ingredient
            var ingredientsDico = GetAllIngredientBySandwichIds(ret.Keys.ToList());
            foreach (var sandwich in ret.Values)
            {
                if (ingredientsDico.ContainsKey(sandwich.Id))
                    sandwich.IngredientsList = ingredientsDico[sandwich.Id];
            }

            return ret;
        }

        /// <summary>
        /// renvoie un sandwich éditable
        /// </summary>
        /// <param name="sandwichId">Id du sandwich à éditer</param>
        /// <returns></returns>
        public EOSandwich GetEditableSandwichById(long sandwichId)
        {
            var ret = new EOSandwich();

            using (var command = Connexion.CreateCommand())
            {
                command.CommandText = @"SELECT id,name,code,price,type from sandwich where id=@Id;";
                command.Parameters.AddWithValue("Id", sandwichId);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ret = new EOSandwich(reader);
                }
            }

            //Fill Ingredient
            var ingredientsDico = GetAllIngredientBySandwichIds(new List<long>() { ret.Id });
            if (ingredientsDico.ContainsKey(ret.Id))
                ret.IngredientsList = ingredientsDico[ret.Id];

            return ret;
        }

        /// <param name="sandwichIdsList">liste de sandwich id</param>
        /// <returns>dictionnaire > key = sandwichId, value = liste d'ingrédient</returns>
        private Dictionary<long, List<EOIngredient>> GetAllIngredientBySandwichIds(List<long> sandwichIdsList)
        {
            var ret = new Dictionary<long, List<EOIngredient>>();

            using (var command = Connexion.CreateCommand())
            {
                command.CommandText = $"select * from sandwich_ingredient si,ingredient i where i.id = si.ingredient_id and sandwich_id in ({ string.Join(",", sandwichIdsList)})";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var n = new EOIngredient(reader, "sandwich");

                    if (!ret.ContainsKey(n.PlatId))
                        ret.Add(n.PlatId, new List<EOIngredient>());

                    ret[n.PlatId].Add(n);
                }
            }

            return ret;
        }
    }
}

// Query sql : liste des ingrédient sans doublon parmis une liste de sandwich_id
//SELECT* FROM ingredient i where exists(select* from sandwich_ingredient where sandwich_id in ({ string.Join(",", sandwichIdsList)}) and ingredient_id = i.id)