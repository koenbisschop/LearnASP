using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LedenbeheerDomain.Business
{
    public class Lid: Entity
    {
        public string Naam { get; internal set; }
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
        public Bijdrage NieuweBijdrage(DateTime datum, decimal bedrag, int projectId)
        {
            Bijdrage bijdrage = null;
            bijdrage = Bijdragen.Find(b => b.ProjectId == projectId);
            if (bijdrage != null)
            {
                bijdrage.Bedrag += bedrag;
                bijdrage.Datum = datum;
            }
            else
            {
                bijdrage = new Bijdrage(datum, bedrag, projectId);
                Bijdragen.Add(bijdrage);
            }
            return bijdrage;
        }

        public Boolean VerwijderBijdrage(DateTime datum)
        {
            Bijdrage bijdrage = null;
            bijdrage = Bijdragen.Find(b => b.Datum == datum);
            if (bijdrage != null)
                return Bijdragen.Remove(bijdrage);
            else
                return false;
        }

        public Boolean ReedsBijdrageVoor(int projectId)
        {
            return Bijdragen.Find(b => b.ProjectId == projectId) != null;
        }

        public Bijdrage VerhoogBijdrage(DateTime datum, decimal bedrag, int projectId)
        {
            Bijdrage bijdrage = null;
            bijdrage = Bijdragen.Find(b => b.ProjectId == projectId);
            if (bijdrage != null)
            {
                bijdrage.Bedrag += bedrag;
                bijdrage.Datum = datum;
            }
            return bijdrage;
        }
        public override string ToString()
        {
            string omschrijving = Naam + " leverde een totale bijdrage van " + Bijdrage.ToString("0.0") + "€";
            return omschrijving;
        }

        internal void Load(List<Bijdrage> bijdragen)
        {
            Bijdragen = bijdragen;
        }
    }
}