using Iaebms.Tool.Encrypt;
using Iaebms.Tool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iaebms.Tool.IaebmsBll
{
    public class RasEncryptToIaebmsTools
    {
        /// <summary>
        /// RAS 传输数据解密(解密js传输的内容)
        /// </summary>
        /// <param name="strDecrypt">要加密的数据字符串</param>
        /// <returns></returns>
        public string getDataDecrypt(string strDecrypt)
        {
            string privateKey = @"MIICXAIBAAKBgQDck/be/TJVV1tlC4TyKVbqRnAReAgdNukv9pPiVC2R3rKDXhNRj7Q6gz60PZAbw8OK22MtNzF9Z7C/mYIuPVYgb/fk3T1/C1UNW83qFDfwIifuuIy5bbm0ZMrJNX0gwTIbAedxSYjkuwGqSEYDj0g2sCnoUNyZcTqRd7Y7Y3NhSQIDAQABAoGBALf3RCeYntkkgZpVsCzUI6RC2QcIyCOtf3C8Q3y5XkRRqyr7VDtrEhLXEX379mvhqv3tmdrFNKZ1y6kRG8z65Q+dxgV46SSzjgeEI/QdYiCm3yJ6ba20x2dJA1quCDQdUhETRbbchanINcztgPhL3Db/UjnWxB54KnukbSWRap2BAkEA+mphPmE05xve15HV0gIzoB/H6XdrJoHSU6BtTXldJD9CrS70tfCAW5cmjEOeqpsg2Vc3O+KUrzyENpstIvYtmQJBAOF/PfsMndyqBeBUmecyhycN4fZYUCxDhX+uVZ+yL0zeK3tQekfNljh/WLWnejHriXEInPJ/DMxUS9Ke9Z98PzECQCRRg3MJpCOUrjgzpYBE43nowhTBRiAamgeY7+FZpcGZDzGQ6trsW6FtBaE4OW3i+9upw5AC56+WplJJJT252JkCQF8pPHXasC/0TICME1rfFuwjTq2QPV1ArXDhmF7Jam6s/3qNztzIZNG45C3c3JN+i8T41or7lOIR3OGolY1VeLECQHTup/DAZ0XMsbAlLwcBy+DIGexQ9LvkWVckcBASBk/0kViatkSVSlsyMjqCQh0/6rso0TFE0iBwJ16KvUc6KEo=";
            try
            {
                RasEncrypt re = new RasEncrypt();
                RSACryptoServiceProvider rsaCryptoServiceProvider = re.CreateRsaProviderFromPrivateKey(privateKey);
                byte[] res = rsaCryptoServiceProvider.Decrypt(Convert.FromBase64String(strDecrypt.Replace("%2B", "+")), false); //把+号，再替换回来
                return Encoding.UTF8.GetString(res);//
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }
    }
}
