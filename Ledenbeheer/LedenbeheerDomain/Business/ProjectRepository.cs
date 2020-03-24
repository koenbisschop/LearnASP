using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedenbeheerDomain.Business
{
    static class ProjectRepository
    {
        private static List<Project> _items = new List<Project>();

        internal static List<Project> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
            }
        }

        internal static Project GetItem(int id) => Items.Find(i => i != null && i.Id == id);
        internal static void RemoveItem(int id)
        {
            Project Project = GetItem(id);
            Items.Remove(Project);
            Persistence.Controller.RemoveProject(Project);
        }
        internal static Int32 GetNextId()
        {
            return Items.Count == 0 ? 1 : Items.Max(l => l.Id) + 1;
        }
        internal static void AddItem(Project Project)
        {
            Items.Add(Project);
            Persistence.Controller.AddProject(Project);
        }
        internal static void ChangeItem(Project Project)
        {
            Persistence.Controller.ChangeProject(Project);
        }
        //internal static void Items
        internal static void Load(List<Project> items)
        {
            if (items != null)
            {
                Items = items;
            }
            else
                Items = new List<Project>();
        }
    }
}
