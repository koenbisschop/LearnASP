using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedenbeheerDomain.Business;

namespace LedenbeheerDomain.Persistence
{
    internal static class Controller
    {
        private static string _connectionstring = "";
        private static string ConnectionString
        {
            get
            {
                if (_connectionstring == "")
                {
                    //ophalen en instellen
                    _connectionstring =
                    ConfigurationManager.ConnectionStrings["Ledenbeheer"].ConnectionString.ToString();
                }
                return _connectionstring;
            }
        }

        internal static List<Lid> GetLeden()
        {
            LidMapper mapper = new LidMapper(ConnectionString);
            return mapper.GetAllLedenFromDB();
        }

        internal static void AddLid(Lid lid)
        {
            LidMapper mapper = new LidMapper(ConnectionString);
            mapper.AddLidToDB(lid);
        }

        internal static void RemoveLid(Lid lid)
        {
            LidMapper mapper = new LidMapper(ConnectionString);
            mapper.RemoveLidFromDB(lid);
        }

        internal static void ChangeLid(Lid lid)
        {
            LidMapper mapper = new LidMapper(ConnectionString);
            mapper.ChangeLidInDB(lid);
        }

        internal static List<Bijdrage> GetBijdragen(Lid lid)
        {
            BijdragenMapper mapper = new BijdragenMapper(ConnectionString);
            return mapper.GetBijdragenFromDB(lid.Id);
        }

        internal static void AddBijdrage(Int32 lidId, Bijdrage bijdrage)
        {
            BijdragenMapper mapper = new BijdragenMapper(ConnectionString);
            mapper.AddBijdrageToDB(lidId, bijdrage);
        }

        internal static void UpdateBijdrage(Int32 lidId, Bijdrage bijdrage)
        {
            BijdragenMapper mapper = new BijdragenMapper(ConnectionString);
            mapper.UpdateBijdrageInDB(lidId, bijdrage);
        }
    }
}
