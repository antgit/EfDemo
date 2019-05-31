using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WidgetsStorageDemo.Tests
{
    public class JsonContent : ByteArrayContent
    {
        public JsonContent(object obj) : base(ConvertToBytes(obj))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        private static byte[] ConvertToBytes(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(serialized);
        }
    }
}
