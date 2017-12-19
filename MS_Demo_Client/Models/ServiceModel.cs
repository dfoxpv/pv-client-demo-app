using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_Demo_Client.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Port { get; set; }
        public List<ServiceMethodModel> Methods { get; set; }
        public List<ServiceMethodModel> EncryptedMethods { get; set; }

        public ServiceModel()
        {
            EncryptedMethods = new List<ServiceMethodModel>();
        }
    }
}