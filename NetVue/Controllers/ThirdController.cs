using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetVue.Controllers
{
    public class ThirdController : BaseController
    {
        [Route("biying/image")]
        public string Image()
        {
            string result = callAPI("https://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&nc=1626857662422&pid=hp", "POST", "application/json", "");
            JObject code = JsonConvert.DeserializeObject<JObject>(result);
            return "https://cn.bing.com/" + code?["images"]?[0]?["url"];
        }
    }
}