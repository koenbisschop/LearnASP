using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    public class Controller
    {
        private static Boolean _isLoaded=false;
        public Controller()
        {
            if (!_isLoaded)
            {
                LidRepository.Load(Persistence.Controller.GetLeden());
                foreach (Lid lid in LidRepository.Items)
                {
                    lid.Load(Persistence.Controller.GetBijdragen(lid));
                }
            }
        }
        public List<Lid> GetLeden()
        {
            return LidRepository.Items;
        }
        public Lid GetLid(Int32 id)
        {
            return LidRepository.GetItem(id);
        }
        public Lid AddLid(string naam)
        {
            Int32 id = LidRepository.GetNextId();
            Lid lid = new Lid(id, naam);
            LidRepository.AddItem(lid);
            return lid;
        }
        public void RemoveLid(Int32 id)
        {
            LidRepository.RemoveItem(id);
        }
        public void ChangeLid(Int32 id, string nieuweNaam)
        {
            Lid lid = LidRepository.GetItem(id);
            lid.Naam = nieuweNaam;
            LidRepository.ChangeItem(lid);
        }
        public void NieuweBijdrage(string naam, decimal bedrag)
        {
            Lid lid = LidRepository.Items.Find(l => l.Naam == naam);
            if (lid == null)
            {
                Int32 id = LidRepository.GetNextId();
                lid = new Lid(id, naam);
                LidRepository.AddItem(lid);
            }
            Bijdrage bijdrage;
            if (lid.ReedsBijdrageOp(DateTime.Today))
            {
                bijdrage = lid.WijzigBijdrage(DateTime.Today, bedrag);
                Persistence.Controller.UpdateBijdrage(lid.Id, bijdrage);
            }
            else
            {
                bijdrage = lid.NieuweBijdrage(DateTime.Today, bedrag);
                Persistence.Controller.AddBijdrage(lid.Id, bijdrage);
            }
        }
        public void NieuweBijdrage(Int32 lidId, DateTime datum, decimal bedrag)
        {
            Lid lid = LidRepository.GetItem(lidId);
            Bijdrage bijdrage = lid.NieuweBijdrage(datum, bedrag);
            Persistence.Controller.AddBijdrage(lid.Id, bijdrage);
        }
        public void WijzigBijdrage(Int32 lidId, DateTime datum, decimal bedrag )
        {
            Lid lid = LidRepository.GetItem(lidId);
            Bijdrage bijdrage = lid.Bijdragen.Find(b => b.Datum == datum);
            bijdrage.Bedrag = bedrag;
            Persistence.Controller.UpdateBijdrage(lid.Id, bijdrage);
        }
    }
}
