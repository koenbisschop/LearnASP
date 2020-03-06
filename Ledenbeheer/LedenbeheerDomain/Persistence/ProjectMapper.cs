using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LedenbeheerDomain.Business;

namespace LedenbeheerDomain.Persistence
{
    class ProjectMapper
    {
        private string _conString = "";
        internal ProjectMapper(string connectionString)
        {
            _conString = connectionString;
        }
        internal List<Project> GetAllProjectenFromDB()
        {
            List<Project> _Projecten = new List<Project>();
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject;", con);
            try
            {
                con.Open();
            }
            catch (MySqlException mySqlExc)
            {
                if (mySqlExc.ErrorCode == -2147467259) //connection niet beschikbaar
                    return _Projecten;
            }
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //alle spelers ophalen uit de database
            while (dataReader.Read() == true)
            {
                Project Project = new Project(
                        Convert.ToInt32(dataReader["id"]),
                        dataReader["omschrijving"].ToString()
                    );
                _Projecten.Add(Project);
            }
            con.Close();
            return _Projecten;
        }

        internal void AddProjectToDB(Project Project)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO tblProject (id, omschrijving) " +
                    " VALUES( @id, @omschrijving)",
                    con
                );
            cmd.Parameters.AddWithValue("id", Project.Id);
            cmd.Parameters.AddWithValue("omschrijving", Project.Omschrijving);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void RemoveProjectFromDB(Project Project)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM tblProject " +
                    " WHERE id=@id",
                    con
                );
            cmd.Parameters.AddWithValue("id", Project.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void ChangeProjectInDB(Project Project)
        {
            MySqlConnection con = new MySqlConnection(_conString);
            MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tblProject " +
                    " SET omschrijving=@omschrijving WHERE id=@id",
                    con
                );
            cmd.Parameters.AddWithValue("id", Project.Id);
            cmd.Parameters.AddWithValue("omschrijving", Project.Omschrijving);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
