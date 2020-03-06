using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    public class Project: Entity
    {
        public string Omschrijving { get; internal set; }
        public Project(int id, string omschrijving):base(id)
        {
            Omschrijving = omschrijving;
        }
        public override string ToString()
        {
            return Omschrijving;
        }
    }
}
