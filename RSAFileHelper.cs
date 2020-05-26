using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_FOR_DM
{
    class RSAFileHelper
    {
        

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters publickey;
        private RSAParameters privatekey;
        public RSAFileHelper()
        {

            privatekey = csp.ExportParameters(true);
            publickey = csp.ExportParameters(false);



        }

       
        public void EncryptFile(string filePath)
        {
           
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            

           
            csp.ImportParameters(publickey);

            byte[] bytesPlainTextData = File.ReadAllBytes(filePath);

           
            var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
           
            string encryptedText = Convert.ToBase64String(bytesCipherText);
            File.WriteAllText(filePath, encryptedText);
        }
        public void DecryptFile(string filePath)
        {
           
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();

                csp.ImportParameters(privatekey);
          
            string encryptedText;
            using (StreamReader reader = new StreamReader(filePath)) { encryptedText = reader.ReadToEnd(); }
           byte [] bytesCipherText = Convert.FromBase64String(encryptedText);   

            
            byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);  

            File.WriteAllBytes(filePath, bytesPlainTextData);
        }
    }
}
