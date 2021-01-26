using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace DataBaseTest.Models
{
    [Table("")]
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public string Sexe { get; set; }
        public string Birthday { get; set; }
        public int Taille { get; set; }
        public string Expiration { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public string Adresse { get; set; }
        public string CodePin { get; set; }


    }
}
