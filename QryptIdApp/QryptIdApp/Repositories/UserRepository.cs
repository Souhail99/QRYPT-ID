using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using QryptIdApp.Models;
using System.Threading.Tasks;
using QRCoder;
using System.Security.Cryptography;
using System.Linq;

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
            var rsa_mbappe = new RSACryptoServiceProvider(2048);
            var pubKey = rsa_mbappe.ExportParameters(false);
            var privKey = rsa_mbappe.ExportParameters(true);
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
                IsAdmin = false,
                PublicKey = "<RSAKeyValue><Modulus>rHUdneiWO4N+lM8HVl/C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"



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
                IsAdmin = false,
                PublicKey = "<RSAKeyValue><Modulus>rHUdneiWO4N+lM8HVl/C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
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
                IsAdmin = false,
                PublicKey = "<RSAKeyValue><Modulus>rHUdneiWO4N+lM8HVl/C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
            });
            connection.Insert(new User
            {
                Id = 10487369,
                IsAdmin=true,
                Username = "admin",
                Password = "admin",
                PrivateKey= "< RSAKeyValue >< Modulus > rHUdneiWO4N + lM8HVl / C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp </ Modulus >< Exponent > AQAB </ Exponent >< P > 2fucySrIziU2YjvhPS4fsUUeuxIpjC4j </ P >< Q > yojozoeG775vAEgCqiGTswK / N3vHRFhD </ Q >< DP > by2n7 + qEdLACJuRHoz6tJ2sLm3pN + pNl </ DP >< DQ > iICht6CsFyUYFu5xrUyYCUxOqAxqjuuV </ DQ >< InverseQ > LCOfm37bxkzt4wqY30ouT6A / gVIkd9ab </ InverseQ >< D > lRRkttWR0P6Z1O + mqx767fpv1pZHjhwF7q3g54X2QGKIIaq1h4o4YSRHLnVrv / L1 </ D ></ RSAKeyValue >",
                PublicKey= "<RSAKeyValue><Modulus>rHUdneiWO4N+lM8HVl/C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
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
        private static UnicodeEncoding _encoder = new UnicodeEncoding();
        public  void RSA(User user)
        {
            
            var text = "Test1";
            Console.WriteLine("RSA // Text to encrypt: " + text);
            var enc = Encrypt(user);
            Console.WriteLine("RSA // Encrypted Text: " + enc);
            var dec = Decrypt(enc,user);
            Console.WriteLine("RSA // Decrypted Text: " + dec);
        }

        public string Decrypt(string data,User user)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString("< RSAKeyValue >< Modulus > rHUdneiWO4N + lM8HVl / C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp </ Modulus >< Exponent > AQAB </ Exponent >< P > 2fucySrIziU2YjvhPS4fsUUeuxIpjC4j </ P >< Q > yojozoeG775vAEgCqiGTswK / N3vHRFhD </ Q >< DP > by2n7 + qEdLACJuRHoz6tJ2sLm3pN + pNl </ DP >< DQ > iICht6CsFyUYFu5xrUyYCUxOqAxqjuuV </ DQ >< InverseQ > LCOfm37bxkzt4wqY30ouT6A / gVIkd9ab </ InverseQ >< D > lRRkttWR0P6Z1O + mqx767fpv1pZHjhwF7q3g54X2QGKIIaq1h4o4YSRHLnVrv / L1 </ D ></ RSAKeyValue >");
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public string Encrypt(User user)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString("<RSAKeyValue><Modulus>rHUdneiWO4N+lM8HVl/C5JdLpx3yQXmAe3R99ASrQbxoXDTRWKK2zzzY5POF2Bsp</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
            var dataToEncrypt = _encoder.GetBytes(user.Id.ToString());
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }







    }
}
