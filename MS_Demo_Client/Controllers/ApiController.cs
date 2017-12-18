using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MS_Demo_Client.Models;
using Newtonsoft.Json;

namespace MS_Demo_Client.Controllers
{
    public class ApiController : Controller
    {
        [HttpPost]
        public ActionResult CallMicroService(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "http://10.25.232.179:8001/PracticeList";
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var returnResult = string.Empty;
            object convertedResult = null;

            using (var wc = new WebClient())
            {
                returnResult = wc.DownloadString(url);
                convertedResult = JsonConvert.DeserializeObject(returnResult);
            }

            stopWatch.Stop();

            var returnObj = new MicroserviceResponseModel
            {
                TimeElapsedMs = stopWatch.Elapsed.Milliseconds,
                Data = convertedResult
            };

            return Content(JsonConvert.SerializeObject(returnObj), "application/json");
        }
    }
}