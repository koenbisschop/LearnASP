using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    class ItemChangedEventArgs : EventArgs
    {
        public string NieuweNaam { get; private set; }
        public ItemChangedEventArgs(string nieuweNaam)
        {
            NieuweNaam = nieuweNaam;
        }
    }
    static class LidRepository
    {
        private static List<Lid> _items = new List<Lid>();

        internal static List<Lid> Items { 
            get { 
                return _items; 
            } 
            private set { 
                _items = value; 
            } 
        }

        internal static Lid GetItem(int id) => Items.Find(l => l.Id == id);
        internal static void RemoveItem(int id)
        {
            Lid lid = GetItem(id);
            Items.Remove(lid);
            Persistence.Controller.RemoveLid(lid);
        }
        internal static  Int32 GetNextId()
        {
            return Items.Count == 0 ? 1 : Items.Max(l => l.Id)+1;
        }
        internal static void AddItem(Lid lid)
        {
            Items.Add(lid);
            Persistence.Controller.AddLid(lid);
        }
        internal static void ChangeItem(Lid lid)
        {
            Persistence.Controller.ChangeLid(lid);
        }
        //internal static void Items
        internal static void Load(List<Lid> items)
        {
            if (items != null)
                Items = items;
            else
                Items = new List<Lid>();
        }
    }
}
