using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace ChromaCheats_Csgo.Licensing
{
    [Serializable]
    public class Response
    {
        public string Action;

        public int ErrorCode;

        public object Result;

        public int Timestamp;

        public string SecretWord;

        [JsonIgnoreAttribute]
        public byte[] Payload;

        [JsonIgnoreAttribute]
        public static string _SecretWord = GetSecretWord();

        public Response(string action, int errorcode, object result)
        {
            this.Action = action;
            this.ErrorCode = errorcode;
            this.Result = result;
            this.Timestamp = Response.time();
            this.SecretWord = GetSecretWord();
        }

        public static string GetSecretWord()
        {
            return _SecretWord;
            //return ChromaEmu.Helper.MD5("68"/*DateTime.Today.ToString("ddd") + "r4zah4tsb3wies3ns4lt"*/);
        }

        private static int time()
        {
            TimeSpan utcNow = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)utcNow.TotalSeconds;
        }
    }
}