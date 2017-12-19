﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_Demo_Client.Models
{
    public class MicroserviceResponseModel
    {
        public int TimeElapsedMs { get; set; }
        public object Data { get; set; }

        public int TotalBytes { get; set; }

        public int TotalKB
        {
            get { return this.TotalBytes / 1000; }
        }
    }
}