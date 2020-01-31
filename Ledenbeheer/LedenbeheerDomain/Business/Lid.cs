using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LedenbeheerDomain.Business
{
    public class Lid: Entity
    {
        public string Naam { get; private set; }
        public List<Bijdrage> Bijdragen { get; private set; }
        public Lid(Int32 id, string naam): base(id)
        {
            Naam = naam;
            Bijdragen = new List<Bijdrage>();
        }
        public decimal Bijdrage
        {
            get
            {
                decimal totaal = 0.0M;
                foreach (Bijdrage b in Bijdragen)
                    totaal += b.Bedrag;
                return totaal;
            }
        }
        public Bijdrage NieuweBijdrage(DateTime datum, decimal bedrag)
        {
            Bijdrage bijdrage = null;
            bijdrage = Bijdragen.Find(b => b.Datum == datum);
            if (bijdrage != null)
                bijdrage.Bedrag += bedrag;
            else
            {
                bijdrage = new Bijdrage(datum, bedrag);
                Bijdragen.Add(bijdrage);
            }
            return bijdrage;
        }

        public Boolean ReedsBijdrageOp(DateTime datum)
        {
            return Bijdragen.Find(b => b.Datum == datum) != null;
        }

        public Bijdrage WijzigBijdrage(DateTime datum, decimal bedrag)
        {
            Bijdrage bijdrage = null;
            bijdrage = Bijdragen.Find(b => b.Datum == datum);
            if (bijdrage != null)
                bijdrage.Bedrag = bedrag;
            return bijdrage;
        }
        public override string ToString()
        {
            string omschrijving = Naam + " leverde een bijdrage van " + Bijdrage.ToString("0.0") + "€";
            return omschrijving;
        }

        internal void Load(List<Bijdrage> bijdragen)
        {
            Bijdragen = bijdragen;
        }
    }
}