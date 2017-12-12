using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestUtil
{
   

    public class REST
    {
        private string baseUri;

        public REST(string bu)
        {
            baseUri = bu;
        }

        //get the RESTFul App...
        // getRestData("/about/");
        //  Takes in the restful call ("/about/") - then returns the string of JSON
        #region getRestData
        public string getJSON(string uri)
        {
           // string baseUri = "http://ist.rit.edu/api";
            //connect to the api
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUri + uri);
            try
            {
                WebResponse res = req.GetResponse();
                using (Stream resStream = res.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                //what to do when it all goes wrong...
                WebResponse err = ex.Response;
                using (Stream resStream = err.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }

        }
        #endregion

        public string getXML()
        {
            return "";
        }
    }
}
