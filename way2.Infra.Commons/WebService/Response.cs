using System;
using System.IO;
using System.Net;

namespace way2.Infra.Commons.WebService
{
    public class Response
    {
        public string ObterResposta(int indice)
        {
            string url = string.Format("http://teste.way2.com.br/dic/api/words/{0}", indice);

            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                request.Timeout = 10000;
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
