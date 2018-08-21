using GestContactMVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestContactMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IRepository<Contact, int> _ServiceClient;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _Nom, _Prenom, _Email;
        private DateTime? _DateNaiss;
        private ICommand _AddCommand;

        private ObservableCollection<OneContactViewModel> _Items;
        private OneContactViewModel _SelectedItem;

        

        public ObservableCollection<OneContactViewModel> Items
        {
            get
            {
                return _Items;
            }
        }

        public OneContactViewModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
                RaisePropertyChanged("Nom");
            }
        }

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }

        public DateTime? DateNaiss
        {
            get
            {
                return _DateNaiss;
            }

            set
            {
                _DateNaiss = value;
                RaisePropertyChanged("DateNaiss");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return _AddCommand ?? (_AddCommand = new RelayCommand(Add, CanAdd));
            }
        }

        public MainViewModel()
        {
            _Items = new ObservableCollection<OneContactViewModel>();
            _ServiceClient = ContactService.Instance;
            Mediator<OneContactViewModel>.Register(OnReceived);

            foreach (Contact c in _ServiceClient.Get())
            {
                Items.Add(new OneContactViewModel(c));
            }
        }

        private void OnReceived(OneContactViewModel sender, string Info)
        {
            if(Info == "Delete")
            {
                _Items.Remove(sender);
            }
        }

        private void Add()
        {
            Contact c = new Contact(Nom, Prenom, Email, DateNaiss.Value);

            c = _ServiceClient.Insert(c);

            Items.Add(new OneContactViewModel(c));

            Nom = null;
            Prenom = null;
            Email = null;
            DateNaiss = null;
        }

        private bool CanAdd()
        {
            string emailFormat = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return !string.IsNullOrWhiteSpace(Nom) &&
                !string.IsNullOrWhiteSpace(Prenom) &&
                !string.IsNullOrWhiteSpace(Email) &&
                Regex.Match(Email, emailFormat).Success &&
                DateNaiss.HasValue;
        }

        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
