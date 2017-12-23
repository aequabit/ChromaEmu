using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using ChromaCheats_Csgo.Licensing;
using Newtonsoft.Json;

namespace ChromaEmu
{
    class RequestHandler
    {
        public Response Handle(string route, string data, bool exchange = false)
        {
            string decrypted = data;

            try
            {
                if (exchange)
                {
                    decrypted = ChromaFramework.Encryption.Rijndael.Decrypt(
                        data,
                        Properties.Settings.Default.key_exchange,
                        Properties.Settings.Default.iv_exchange
                    );
                }
                else
                {
                    decrypted = ChromaFramework.Encryption.Rijndael.Decrypt(
                        data,
                        Properties.Settings.Default.key,
                        Properties.Settings.Default.iv
                    );
                }

                Request request = JsonConvert.DeserializeObject<Request>(decrypted);

                Response._SecretWord = request.SecretWord;

                Logger.Log("Requested action: " + request.Action, "ccemu", ConsoleColor.Red);

                return (Response)this.GetType().GetMethod(request.Action).Invoke(this, new[] { request });
            }
            catch (Exception ex)
            {
                //Logger.Log(ex.Message + Environment.NewLine + ex.StackTrace);
                Logger.Log("Invalid data received: " + decrypted, "ccemu", ConsoleColor.Red);
                return Error();
            }
        }

        public Response Error()
        {
            return new Response("None", -1, "");
        }

        public Response IsBanned(Request request)
        {
            return new Response("IsBanned", 0, "False");
        }

        public Response QueryLoaderInfo(Request request)
        {
            return new Response("QueryLoaderInfo", 0, "loader.exe|2.3|");
        }

        public Response Login(Request request)
        {
            //if (request.Parameter != "Keine Zeit C++ zu lernen=Kann mir jemand C++ beibringen?|C#=Kacke")
                return new Response("Login", 0, 1);

            //return new Response("Login", 0, Properties.Settings.Default.key + "|" + Properties.Settings.Default.iv);
        }

        public Response HasSubs(Request request)
        {
            return new Response("HasSubs", 0, "True");
        }

        public Response QuerySubs(Request request)
        {
            return new Response("QuerySubs", 0, "Counter-Strike: Global Offensive - Lifetime|memeware - Meme Edition");
        }

        public Response QueryProductConfig(Request request)
        {
            var product = request.Parameter.Split(new string[] { "ProductName=" }, StringSplitOptions.None)[1];

            if (product == "Counter-Strike: Global Offensive - Lifetime")
                return new Response("QueryProductConfig", 0, "csgo_external.exe|None|None");
            else if (product == "memeware - Meme Edition")
                return new Response("QueryProductConfig", 0, "memeware.exe|None|None");
            else
                return Error();
        }

        public Response DownloadFile(Request request)
        {
            byte[] data = Helper.ExtractResource(
                request.Parameter.Split(new string[] { "File=" }, StringSplitOptions.None)[1]
            );

            if (data == null)
                return Error();

            return new Response("DownloadFile", 0, "")
            {
                Payload = data
            };
        }

        public Response GetValidUpgrades(Request request)
        {
            return new Response("GetValidUpgrades", 0, "8");
        }

        public Response LogException(Request request)
        {
            Logger.Log("LogException: " + request.Parameter, "ccemu", ConsoleColor.Red);

            return new Response("LogException", 0, "");
        }
    }
}
