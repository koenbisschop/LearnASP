using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedenbeheerDomain.Business;
using MySql.Data.MySqlClient;

namespace LedenbeheerDomain.Persistence
{
    class LidMapper
    {
        private string _conString = "";
        internal LidMapper(string connectionString)
        {
            _conString = connectionString;
        }
        internal List<Lid> GetAllLedenFromDB()
        {
            List<Lid> _leden = new List<Lid>();
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblLid;", con);
            try
            {
                con.Open();
            }
            catch (MySqlException mySqlExc)
            {
                if (mySqlExc.ErrorCode == -2147467259) //connection niet beschikbaar
                    return _leden;
            }
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //alle spelers ophalen uit de database
            while (dataReader.Read() == true)
            {
                Lid lid = new Lid(
                        Convert.ToInt32(dataReader["id"]),
                        dataReader["naam"].ToString()
                    );
                _leden.Add(lid);
            }
            con.Close();
            return _leden;
        }

        internal void AddLidToDB(Lid lid)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO tblLid (id, naam) " +
                    " VALUES( @id, @naam)",
                    con
                );
            cmd.Parameters.AddWithValue("id", lid.Id);
            cmd.Parameters.AddWithValue("naam", lid.Naam);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void RemoveLidFromDB(Lid lid)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM tblLid " +
                    " WHERE id=@id",
                    con
                );
            cmd.Parameters.AddWithValue("id", lid.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void ChangeLidInDB(Lid lid)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tblLid " +
                    " SET naam=@naam WHERE id=@id",
                    con
                );
            cmd.Parameters.AddWithValue("id", lid.Id);
            cmd.Parameters.AddWithValue("naam", lid.Naam);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

}

