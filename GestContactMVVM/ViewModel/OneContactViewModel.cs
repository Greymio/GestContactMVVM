using GestContactMVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestContactMVVM.ViewModel
{
    public class OneContactViewModel
    {
        private IRepository<Contact, int> _ServiceClient;

        private ICommand _DeleteCommand;
        private Contact _Entity;

        public OneContactViewModel(Contact Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException();

            _ServiceClient = ContactService.Instance;

            _Entity = Entity;
        }

        public int ID
        {
            get { return _Entity.ID; }
        }

        public string Nom
        {
            get { return _Entity.Nom; }
            set { _Entity.Nom = value; }
        }

        public string Prenom
        {
            get { return _Entity.Prenom; }
            set { _Entity.Prenom = value; }
        }

        public string Email
        {
            get { return _Entity.Email; }
            set { _Entity.Email = value; }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(Delete));
            }
        }

        public void Delete()
        {
            if(_ServiceClient.Delete(ID))
            {
                Mediator<OneContactViewModel>.Send(this, "Delete");
            }            
        }
    }
}
