using System;
using SQLite;
using DataBaseTest.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTest.Repositories
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
            connection.Insert(new User {
                Id = 1,
                Nom = "Mbappé",
                Prenoms = "Kylian",
                Sexe = "M",
                Birthday = "20/12/1998 à Paris",
                Taille = 178,
                Expiration = "10/03/2025",
                Adresse = "12 rue Victor Hugo, 92200 Neuilly-sur-Seine",
                Photo = "mbappe.bmp",
                Signature = "mbappeSignature.bmp",
                CodePin = ""

            }) ;
            //ajout d'un 2e user : 
            connection.Insert(new User
            {
                Id = 2,
                Nom = "Macron",
                Prenoms = "Emmanuel",
                Sexe = "M",
                Birthday = "21/12/1977 à Amiens",
                Taille = 173,
                Expiration = "24/10/2028",
                Adresse = "55 Rue du Faubourg Saint-Honoré, 75008 Paris",
                Photo = "macron.bmp",
                Signature = "macronSignature.bmp",
                CodePin = ""

            }); ;
            connection.Insert(new User
            {
                Id = 3,
                Nom = "Mouly",
                Prenoms = "Vincent",
                Sexe = "M",
                Birthday = "27/05/2004 à Neuilly-sur-Seine",
                Taille = 187,
                Expiration = "05/06/2025",
                Adresse = "52 rue Rivay, 92300 Levallois-Perret",
                Photo = "vincent.bmp",
                Signature = "vincentSignature.bmp",
                CodePin = ""

            });
        }

       

        public List<User> GetUsers()
        {
            try
            {
                return connection.Table<User>().ToList(); 
            }
            catch(Exception ex)
            {
                StatusMessage = $"Imposssible de recuperer la liste des CNI.\n Erreur : {ex.Message}";
            }
            return new List<User>();
        }
    }
}
