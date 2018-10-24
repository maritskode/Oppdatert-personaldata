using Caliburn.Micro;
using FirstMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVVM.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private string _address;
        private string _zipcode;
        private string _areaOrCity;
        private string _email;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        //Vanligvis henter vi inn personer fra databasen her, men vi forenkler 
        //og henter fra en enkel liste her.
        public ShellViewModel()
        {
             People.Add(new PersonModel { Firstname = "Kari", Middlename = "Elise", Lastname = "Hansen" , IDnumber = "1", APBIDnumber = "1" });
             People.Add(new PersonModel { Firstname = "Billy", Middlename = "Henry", Lastname = "Jones" , IDnumber = "2", APBIDnumber = "2" });
             People.Add(new PersonModel { Firstname = "Turid", Middlename = null, Lastname = "Jakobsen" , IDnumber = "3", APBIDnumber = "3" });
             People.Add(new PersonModel { Firstname = "Harry", Middlename = null, Lastname = "Vidarsen" , IDnumber = "4", APBIDnumber = "3" });
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                NotifyOfPropertyChange(() => Firstname);
            }
        }

        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
                NotifyOfPropertyChange(() => Middlename);
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }

        public string Fullname
        {
            get { return $"{ Firstname } { Middlename } { Lastname }"; }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                _zipcode = value;
                NotifyOfPropertyChange(() => Zipcode);
            }
        }

        public string AreaOrCity
        {
            get
            {
                return _areaOrCity;
            }
            set
            {
                _areaOrCity = value;
                NotifyOfPropertyChange(() => AreaOrCity);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        //Lager en sammenkoblet samling av PersonModel
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        //Når en enkelt person er blitt valgt, skal denne bli 
        //sortert ut som SelectedPerson, og Notify gjør at vi 
        //får beskjed når utvelgelsen er gjort.
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        //Vi lar knappen ClearAllText fungere slik at den kun kan trykkes på
        //når det er noe tekst å fjerne i tekstfeltene.
        public bool CanClearAllText(string firstname, string middlename, string lastname, 
            string address, string zipcode, string areaOrCity, string email)
        {
            //Vil returnere om alle tekstfeltene som står til innfylling er tom eller ikke.
            //Hvis alle tekstfeltene er tom, så returneres 
            //false og knappen ClearAllText skal ikke være aktiv eller kunne fungere.
            if (string.IsNullOrWhiteSpace(firstname) && string.IsNullOrWhiteSpace(middlename) 
                && string.IsNullOrWhiteSpace(lastname) && string.IsNullOrWhiteSpace(address) 
                && string.IsNullOrWhiteSpace(zipcode) && string.IsNullOrWhiteSpace(areaOrCity) 
                && string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Funksjon for å slette teksten i feltene Firstname og Lastname.
        //Funksjonen tar teksten som blir skrevet inn, som innparameter - ikke for å bruke
        //parameterne selv, men for å gjøre dem tilgjengelig for public bool CanClearText
        //slik at denne funksjonen også får tilgang til teksten som blir skrevet inn.
        public void ClearAllText(string firstname, string middlename, string lastname, 
            string address, string zipcode, string areaOrCity, string email)
        {
            //IDnumber = "";
            Firstname = "";
            Middlename = "";
            Lastname = "";
            Address = "";
            Zipcode = "";
            AreaOrCity = "";
            Email = "";
        }

        //Vi lar knappen SaveAndClearAllAddress fungere slik at den kun kan trykkes på
        //når det er tekst i alle tre typene adresse-tekstfelt.
        public bool CanSaveAndClearAllAddress(string address, string zipcode, string areaOrCity)
        {
            //Vil returnere true om alle adressefeltene som står til innfylling er fylt ut.
            //Hvis noen av de tre adressefeltene er tom, så returneres 
            //false og knappen SaveAndClearAllAddress skal ikke være aktiv eller kunne fungere.
            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(zipcode) || string.IsNullOrWhiteSpace(areaOrCity))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Funksjon for å lagre og deretter slette teksten i de tre postadresse-feltene.
        //Funksjonen tar teksten som blir skrevet inn, som innparameter, for å gjøre 
        //dem tilgjengelig for public bool CanSaveAndClearAllAddress
        public void SaveAndClearAllAddress(string address, string zipcode, string areaOrCity)
        {
            //*** NBNB ****
            //Her må vi legge inn save-funksjon!!
            //*** NBNB ****

            //Tøm postadresse-feltene, slik at det er mulig å skrive inn flere postadresser
            Address = "";
            Zipcode = "";
            AreaOrCity = "";
        }
        //Vi lar knappen SaveAndClearEmail fungere slik at den kun kan trykkes på
        //når det er tekst i alle tre typene adresse-tekstfelt.
        public bool CanSaveAndClearEmail(string email)
        {
            //Vil returnere true om alle adressefeltene som står til innfylling er fylt ut.
            //Hvis noen av de tre adressefeltene er tom, så returneres 
            //false og knappen ClearAllAddress skal ikke være aktiv eller kunne fungere.
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Funksjon for å lagre og deretter slette teksten i emailfeltet.
        //Funksjonen tar teksten som blir skrevet inn, som innparameter for å gjøre den 
        //tilgjengelig for public bool CanSaveAndClearEmail.
        public void SaveAndClearEmail(string email)
        {
            //*** NBNB ****
            //Her må vi legge inn save-funksjon!!
            //*** NBNB ****

            //Tøm emailadresse-feltet, slik at det er mulig å skrive inn flere emailadresser
            Email = "";
        }

        //Vi lar knappen SaveAndClearAllText fungere slik at den kun kan trykkes på
        //når det er noe informasjon å lagre i firstname og lastname tekstfeltene.
        public bool CanSaveAndClearAllText(string firstname, string lastname)
        {
            //Vil returnere om firstname og lastname tekstfeltene som står til innfylling er tom eller ikke.
            //Hvis en eller begge av disse to obligatoriske feltene er tom, så returneres 
            //false og knappen SaveAndClearAllText skal ikke være aktiv eller kunne fungere.
            if (string.IsNullOrWhiteSpace(firstname) && string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Funksjon for å slette teksten i feltene Firstname og Lastname.
        //Funksjonen tar teksten som blir skrevet inn, som innparameter - ikke for å bruke
        //parameterne selv, men for å gjøre dem tilgjengelig for public bool CanClearText
        //slik at denne funksjonen også får tilgang til teksten som blir skrevet inn.
        public void SaveAndClearAllText(string firstname, string middlename, string lastname,
            string address, string zipcode, string areaOrCity, string email)
        {

            //*** NBNB ****
            //Her må vi legge inn save-funksjon!!
            //*** NBNB ****

            //IDnumber = "";
            Firstname = "";
            Middlename = "";
            Lastname = "";
            Address = "";
            Zipcode = "";
            AreaOrCity = "";
            Email = "";
        }

        public void CloseButton()
        {
            TryClose();
        }


    }
}
