using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ledenbeheer
{
    public class Lid
    {
        public string Naam { get; set; }
        public decimal Bijdrage { get; set; }
        public Lid(string naam, decimal bijdrage)
        {
            Naam = naam;
            Bijdrage = bijdrage;
        }
        public override string ToString()
        {
            return Naam + " leverde een bijdrage van " + Bijdrage.ToString("0.0") + "€";
        }
    }
}