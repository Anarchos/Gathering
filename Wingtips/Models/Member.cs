using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography; //Used to do things... Secret things!

namespace Gathering.Models
{
    public class Member
    {
        [ScaffoldColumn(false)]
        public string User_Name { get; set; }       //Primary key. (Make sure you get the data type right!!!)

        [Required, StringLength(100), Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required, StringLength(100), Display(Name = "Last Name")]      //Try to include appropriate string lengths where possible (it saves RAMs!)
        public string Last_Name { get; set; }

        [Required, Display(Name = "DoB Day")]     //['Required,' I hope I don't need to explain what it does, but make sure to include them everywhere they're needed to prevent the rapture etc. 
        public int DoB_Day { get; set; }

        [Required, Display(Name = "DoB Month")]
        public int DoB_Month { get; set; }

        [Required, Display(Name = "DoB Year")]
        public int DoB_Year { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? PlatformID { get; set; }        //Foriegn keys are the best type of keys.

        public virtual Platform Platform { get; set; }  //If a class inherits from this one (or any other), it needs this line to stop the metaphorical shit hitting the metaphorical fan.

        public string Device { get; set; }

        //Maybe part of a different class

        public string Password { get; set; }


        //Functions! Functions everywhere! You could say it's time to get func(tion)y...

        private const int KeySize = 256;    //How many bits of junk we're making.

        private const int IterateDecoding = 1000;   //Try to think of a less terrible name for this.

        public static string EncryptPassword(string plainText, string passPhrase)
        {
            var rand1StringBytes = Generate256BitsOfStuff();    //256 bits of random ****.
            var rand2StringBytes = Generate256BitsOfStuff();    //Two * 256 bits of random ****. You'll see why!
            var unencryptedTextBytes = Encoding.UTF8.GetBytes(plainText);     //unencrypted plain text. I hope we're not getting marked on the conciseness of our variable declerations...
            using (var password = new Rfc2898DeriveBytes(passPhrase, rand1StringBytes, IterateDecoding))
            {
                var keyBytes = password.GetBytes(KeySize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = KeySize;       //There's no need to use more RAM than we need now is there?
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, rand2StringBytes))
                    {
                        using (var memoryStream = new MemoryStream())       //Using memory stream is a great way of keeping information volitile/difficult to intercept.
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(unencryptedTextBytes, 0, unencryptedTextBytes.Length);       //There's no point in encrypting characters that aren't there.
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = rand1StringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(rand2StringBytes).ToArray();       //Stores how we've encrypted everything in an array so we can decrypt it when needed.
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }   //End of encrypt method.

        private static byte[] Generate256BitsOfStuff()
        {
            var randomBytes = new byte[32]; //Change to 16 for 128bit.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);   //Fills the array with random bytes (a good name for a nerdy cereal don't you think? Or should I say, nerdy serial! Bah dom tish)
            }
            return randomBytes;
        }

        public static string DecryptPassword(string cipherText, string passPhrase)
        {
            var encryptTextBytesWithRand1and2 = Convert.FromBase64String(cipherText);
            // Get the rand1 bytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var rand1StringBytes = encryptTextBytesWithRand1and2.Take(KeySize / 8).ToArray();
            // Get the rand2 bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var rand2StringBytes = encryptTextBytesWithRand1and2.Skip(KeySize / 8).Take(KeySize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = encryptTextBytesWithRand1and2.Skip((KeySize / 8) * 2).Take(encryptTextBytesWithRand1and2.Length - ((KeySize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, rand1StringBytes, IterateDecoding))
            {
                var keyBytes = password.GetBytes(KeySize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, rand2StringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var unencryptedTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(unencryptedTextBytes, 0, unencryptedTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(unencryptedTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }   //end of unencrypt password

        /*/static void Main(string[] args)
        {
            Console.WriteLine("Please enter a password to use:");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter a string to encrypt:");
            string plaintext = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Your encrypted string is:");
            string encryptedstring = StringCipher.Encrypt(plaintext, password);
            Console.WriteLine(encryptedstring);
            Console.WriteLine("");

            Console.WriteLine("Your decrypted string is:");
            string decryptedstring = StringCipher.Decrypt(encryptedstring, password);
            Console.WriteLine(decryptedstring);
            Console.WriteLine("");

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        } /*/
    }


}