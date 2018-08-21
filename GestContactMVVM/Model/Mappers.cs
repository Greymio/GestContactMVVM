using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = GestContactMVVM.Model.Global;
using C = GestContactMVVM.Model.Client;

namespace GestContactMVVM.Model
{
    public static class Mappers
    {
        public static C.Contact ToClient(this G.Contact Entity)
        {
            return new C.Contact(Entity.ID, Entity.Nom, Entity.Prenom, Entity.Email, Entity.DateNaiss);
        }

        public static G.Contact ToGlobal(this C.Contact Entity)
        {
            return new G.Contact()
            {
                ID = Entity.ID,
                Nom = Entity.Nom,
                Prenom = Entity.Prenom,
                Email = Entity.Email,
                DateNaiss = Entity.DateNaiss
            };
        }
    }
}
