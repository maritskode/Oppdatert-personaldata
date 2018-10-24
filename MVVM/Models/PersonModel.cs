using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVVM.Models
{
    public class PersonModel
    {
        //Fornavn
        public string Firstname { get; set; }
        
        //Mellomnavn
        public string Middlename { get; set; }
        
        //Etternavn
        public string Lastname { get; set; }
        
        //IDnummer
        public string IDnumber { get; set; }

        //ForeinKey - APB-ID - Administrator (1), Personal (2) elelr Bruker (3)
        public string APBIDnumber { get; set; }
    }
}
