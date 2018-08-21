using System;

namespace GestContactMVVM.Model.Client
{
    public class Contact
    {
        private int _ID;
        private string _Nom;
        private string _Prenom;
        private string _Email;
        private DateTime _DateNaiss;

        public int ID
        {
            get
            {
                return _ID;
            }

            private set
            {
                _ID = value;
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
            }
        }

        public DateTime DateNaiss
        {
            get
            {
                return _DateNaiss;
            }

            private set
            {
                _DateNaiss = value;
            }
        }

        public Contact(string Nom, string Prenom, string Email, DateTime DateNaiss)
        {
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Email = Email;
            this.DateNaiss = DateNaiss;
        }

        public Contact(int ID, string Nom, string Prenom, string Email, DateTime DateNaiss) : this(Nom, Prenom, Email, DateNaiss)
        {
            this.ID = ID;
        }
    }
}
