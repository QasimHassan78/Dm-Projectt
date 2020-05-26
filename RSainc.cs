using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSA_FOR_DM
{
    class RSainc
    {

        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters publickey;
        private RSAParameters privatekey;
        public RSainc()
        {

            privatekey = csp.ExportParameters(true);
            publickey = csp.ExportParameters(false);



        }


        public string publickeystring()
        {

            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, publickey);
            return sw.ToString();

        }
        public string incript(string plaintext)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publickey);
            var data = Encoding.Unicode.GetBytes(plaintext);
            var cypher = csp.Encrypt(data, false);

            return Convert.ToBase64String(cypher);



        }



        public string Decript(string ciphertext)
        {

            var databytes = Convert.FromBase64String(ciphertext);
            csp.ImportParameters(privatekey);
            var plaintext = csp.Decrypt(databytes, false);

            return Encoding.Unicode.GetString(plaintext);
        }




    }
}
