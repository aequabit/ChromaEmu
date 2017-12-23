using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ChromaCheats_Csgo.Licensing
{
    [Serializable]
    public class Request
    {
        public string Dispatcher;

        public string Action;

        public string Parameter;

        public string SecretWord;

        public string Timestamp;

        public Request(string dispatcher, string action, string parameter)
        {
            this.Dispatcher = dispatcher;
            this.Action = action;
            this.Parameter = parameter;
            this.SecretWord = secretword();
            this.Timestamp = Request.time().ToString();
        }

        private static string secretword()
        {
            return ChromaEmu.Helper.MD5("67"/*DateTime.Today.ToString("ddd") + "r4zah4tsb3wies3ns4lt"*/);
        }

        private static int time()
        {
            TimeSpan utcNow = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)utcNow.TotalSeconds;
        }
    }
}