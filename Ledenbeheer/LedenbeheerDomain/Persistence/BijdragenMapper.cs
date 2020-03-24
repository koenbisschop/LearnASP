using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedenbeheerDomain.Business;
using MySql.Data.MySqlClient;

namespace LedenbeheerDomain.Persistence
{
    class BijdragenMapper
    {
        private string _conString = "";
        internal BijdragenMapper(string connectionString)
        {
            _conString = connectionString;
        }
        internal List<Bijdrage> GetBijdragenFromDB(Int32 lidId)
        {
            List<Bijdrage> _bijdragen = new List<Bijdrage>();
            //ophalen van de evaluaties die volgens compositie in dit vak horen
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                "SELECT * FROM tblbijdragen WHERE lidid = @lidid"
                , con);
            cmd.Parameters.AddWithValue("lidid", lidId);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int pid=0;
                try
                {
                    pid = Convert.ToInt32(dr["projectid"]);
                }
                catch  { }
                Bijdrage _bijdrage = new Bijdrage(
                    Convert.ToDateTime(dr["datum"]),
                    Convert.ToDecimal(dr["bedrag"]),
                    pid
                    );
                _bijdragen.Add(_bijdrage);
            }
            con.Close();
            return _bijdragen;
        }

        internal void AddBijdrageToDB(Int32 lidId, Bijdrage bijdrage)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO tblbijdragen (lidid, datum, bedrag, projectid)" +
                " VALUES (@lidid, @datum, @bedrag, @projectid)"
                , con);
            cmd.Parameters.AddWithValue("lidid", lidId);
            cmd.Parameters.AddWithValue("datum", bijdrage.Datum);
            cmd.Parameters.AddWithValue("bedrag", bijdrage.Bedrag);
            cmd.Parameters.AddWithValue("projectid", bijdrage.ProjectId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void UpdateBijdrageInDB(Int32 lidId, DateTime oudeDatum, Bijdrage bijdrage)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                "UPDATE tblbijdragen SET bedrag = @bedrag, projectid=@projectid, datum=@datum " +
                " WHERE lidid=@lidid AND datum=@datum"
                , con);
            cmd.Parameters.AddWithValue("lidid", lidId);
            cmd.Parameters.AddWithValue("datum", oudeDatum);
            cmd.Parameters.AddWithValue("nieuweDatum", bijdrage.Datum);
            cmd.Parameters.AddWithValue("bedrag", bijdrage.Bedrag);
            if (bijdrage.ProjectId != 0)
                cmd.Parameters.AddWithValue("projectid", bijdrage.ProjectId);
            else
                cmd.Parameters.AddWithValue("projectid", DBNull.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void DeleteBijdrageInDB(Int32 lidId, DateTime datum)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
            "DELETE FROM tblbijdragen " +
            " WHERE lidid=@lidid AND datum=@datum"
            , con);
            cmd.Parameters.AddWithValue("lidid", lidId);
            cmd.Parameters.AddWithValue("datum", datum);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
