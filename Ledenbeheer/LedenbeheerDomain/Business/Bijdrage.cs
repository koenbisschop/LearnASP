using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    public class Bijdrage
    {
        public DateTime Datum { get; private set; }
        public decimal Bedrag { get; internal set; }
        public int ProjectId { get; internal set; }
        public Bijdrage(DateTime datum, decimal bedrag, int projectId)
        {
            Datum = datum;
            Bedrag = bedrag;
            ProjectId = projectId;
        }
        public Project Project
        {
            get
            {
                return ProjectRepository.GetItem(ProjectId);
            }
        }
    }
}
