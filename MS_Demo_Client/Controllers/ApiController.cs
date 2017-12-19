using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using MS_Demo_Client.Models;
using NancyUtilities;
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
            int totalBytes = 0;

            using (var wc = new WebClient())
            {
                returnResult = wc.DownloadString(url);
                convertedResult = JsonConvert.DeserializeObject(returnResult);
                totalBytes = (returnResult.Length * sizeof(Char));
            }

            stopWatch.Stop();

            var returnObj = new MicroserviceResponseModel
            {
                TimeElapsedMs = stopWatch.Elapsed.Milliseconds,
                Data = convertedResult,
                TotalBytes = totalBytes
            };

            return Content(JsonConvert.SerializeObject(returnObj), "application/json");
        }

        [HttpPost]
        public ActionResult DecryptServiceResponse(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new Exception("No encrypted data provided.");
            }

            var crypto = new Cryptography();

            var decryptedResults = crypto.Decrypt(data);

            var returnObj = new MicroserviceResponseModel
            {
                TimeElapsedMs = 0,
                Data = JsonConvert.DeserializeObject(decryptedResults),
                TotalBytes = ((decryptedResults.Length) * sizeof(Char))
            };

            return Content(JsonConvert.SerializeObject(returnObj), "application/json");
        }
    }
}