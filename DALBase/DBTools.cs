using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALBase
{
    public static class DBTools
    {

        public static bool GetBoolean(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetBoolean(field);
            }
            else
                return false;
        }
        public static string GetString(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetString(field);
            }
            else
                return String.Empty;
        }

        public static int GetInt32(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetInt32(field);
            }
            else
                throw new ArgumentException("Parameter cannot be null", "field");
        }
        public static int? GetInt32Null(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetInt32(field);
            }
            else
                return null;
        }


        public static long GetInt64(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetInt64(field);
            }
            else
                throw new ArgumentException("Parameter cannot be null", "field");
        }
        public static long? GetInt64Null(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetInt64(field);
            }
            else
                return null;
        }

        public static decimal GetDecimal(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetDecimal(field);
            }
            else
                throw new ArgumentException("Parameter cannot be null", "field");
        }
        public static decimal? GetDecimalNull(MySqlDataReader r, String field)
        {
            if (!r.IsDBNull(r.GetOrdinal(field)))
            {
                return r.GetDecimal(field);
            }
            else
                return null;
        }
        
    }
}
