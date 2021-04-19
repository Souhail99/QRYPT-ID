using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QryptIdApp.Models
{
    [Table("")]
    public class User
    {
        //Id data
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
        
        //App data
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
