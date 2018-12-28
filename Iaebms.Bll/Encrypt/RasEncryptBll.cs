using Iaebms.Tool.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Iaebms.Tool.Encrypt
{
    public class RasEncryptBll : RasEncryptInBll
    {
        public string getDataDecrypt(string strDecrypt)
        {
            RasEncryptIn re = new RasEncrypt();
            return re.getDataDecrypt(strDecrypt);
        }
    }
}
