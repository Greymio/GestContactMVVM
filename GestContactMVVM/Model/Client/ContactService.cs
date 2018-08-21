using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = GestContactMVVM.Model.Global;

namespace GestContactMVVM.Model.Client
{
    public class ContactService : IRepository<Contact, int>
    {
        private static ContactService _Instance;

        IRepository<G.Contact, int> _ServiceGlobal;

        public static ContactService Instance
        {
            get
            {
                return _Instance ?? (_Instance = new ContactService());
            }
        }

        private ContactService()
        {
            _ServiceGlobal = new G.ContactService();
        }

        public IEnumerable<Contact> Get()
        {
            List<Contact> Items = new List<Contact>();

            foreach (G.Contact c in _ServiceGlobal.Get())
            {
                Items.Add(c.ToClient());
            }

            return Items;
        }

        public Contact Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Contact Insert(Contact Entity)
        {
            G.Contact c = _ServiceGlobal.Insert(Entity.ToGlobal());
            return c.ToClient();
        }

        public bool Update(int ID, Contact Entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int ID)
        {
            return _ServiceGlobal.Delete(ID);
        }
    }
}
