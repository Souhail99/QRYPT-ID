using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using QryptIdApp.Models;
using System.Threading.Tasks;
using QRCoder;

namespace QryptIdApp.Repositories
{
    public class UserRepository
    {
        private SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public UserRepository(string dbPath)
        {
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<User>();
            //ajout d'un user : Mbappé
            connection.Insert(new User
            {
                Id = 1,
                Nom = "Mbappé",
                Prenoms = "Kylian",
                Sexe = "M",
                Birthday = "20/12/1998 à Paris 19ème",
                Taille = 178,
                Photo = "mbappe.jpg",

                Expiration = "10/03/2025",
                Adresse = "12 rue Victor Hugo, 92200 Neuilly-sur-Seine",
                Signature = "mbappeSignature.bmp",

                Username = "kmbappe",
                Password = "pass",
                IsAdmin = false

            });
            ;
            //ajout d'un 2e user : 
            connection.Insert(new User
            {
                Id = 2,
                Nom = "Macron",
                Prenoms = "Emmanuel",
                Sexe = "M",
                Birthday = "21/12/1977 à Amiens",
                Taille = 173,
                Photo = "macron.jpg",

                Expiration = "24/10/2028",
                Adresse = "55 Rue du Faubourg Saint-Honoré, 75008 Paris",
                Signature = "macronSignature.bmp",

                Username = "emacron",
                Password = "pass",
                IsAdmin = false
            });
            connection.Insert(new User
            {
                Id = 3,
                Nom = "Mouly",
                Prenoms = "Vincent",
                Sexe = "M",
                Birthday = "27/05/2004 à Neuilly-sur-Seine",
                Taille = 189,
                Photo = "vincent.jpg",

                Expiration = "24/10/2028",
                Adresse = "55 Rue du Faubourg Saint-Honoré, 75008 Paris",
                Signature = "macronSignature.bmp",

                Username = "vmouly",
                Password = "pass",
                IsAdmin = false
            });
            connection.Insert(new User
            {
                Id = 10487369,
                IsAdmin=true,
                Username = "admin",
                Password = "admin",
            });
        }



        public List<User> GetUsers()
        {
            try
            {
                return connection.Table<User>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Imposssible de recuperer la liste des CNI.\n Erreur : {ex.Message}";
            }
            return new List<User>();
        }

        public User LoginValidate(string userName1, string pwd1)
        {
            var data = connection.Table<User>();
            var d1 = data.Where(x => x.Username == userName1 && x.Password == pwd1).FirstOrDefault();
            
            if (d1 != null)
            {
                return d1;
            }
            else
                return null;
        }



        
    }
}
