using Iaebms.Tool.Encrypt;
using Iaebms.Tool.IaebmsBll;
using Iaebms.Tool.IaebmsModels;
using Iaebms.Tool.Interface;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IAEBMS.Controllers
{
    public class LoginController : Controller
    { 
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Info()
        {
            ResultData rd = new ResultData();
            var stream = HttpContext.Request.InputStream;
            string json = new System.IO.StreamReader(stream).ReadToEnd();
            JavaScriptSerializer Serializers = new JavaScriptSerializer();
            LoginrRsult lr = Serializers.Deserialize<LoginrRsult>(json);
            string result = "";
            RasEncryptToIaebmsTools reib = new RasEncryptToIaebmsTools();
            result = reib.getDataDecrypt(lr.result);
            JObject jo = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            LoginInfo li = new LoginInfo();
            li.um=jo["um"].ToString();
            li.pd = jo["pd"].ToString();


            rd.resultData = new JavaScriptSerializer().Serialize(li);
            rd.code = 1;
            rd.status = "00001";

            LoginController lc = new LoginController();
            string prk = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCQhK6NRyqiEYuIa94cL9zxRPxtcZMPRwUK2khBNCddIaOvrR2ismfekJsVJIlIQFMVA0OeR9xvD5m4S6+OLyTSi/S0AHX3tQHeNS+0J1b2bwQCwa9BFWQQCBlPPhPNSjMaHifPHVHJBNUQo5zdc0zGvFDWyZzS0AAKc98FjumbrwIDAQAB";
            RasEncrypt re = new RasEncrypt();
            string cprk = re.RSAPublicKeyJava2DotNet(prk);
            string results = re.RSAEncrypt(cprk, new JavaScriptSerializer().Serialize(rd));
            //LoginrRsult lr2 = new LoginrRsult();
            //lr2.result = a;
            return results;

           
            
            //return new JavaScriptSerializer().Serialize(rd); ;
        }

        
    }

    public class LoginrRsult {
        public string result { get; set; }
    }

    public class LoginInfo {
        public string um { get; set; }
        public string pd { get; set; }
    }

}
