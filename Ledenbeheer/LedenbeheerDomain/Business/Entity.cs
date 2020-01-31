using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    public class Entity
    {
        public Int32 Id { get; private set; }
        public Entity(Int32 id)
        {
            Id = id;
        }
        public override String ToString()
        {
            return Id.ToString();
        }
    }
}
