using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Converters
{
    public class JsonContent : StringContent
    {
        private const string MediaType = "application/json";

        public JsonContent(object request) :
            base(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaType)
        { }
    }
}
