using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MS_Demo_Client.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MS_Demo_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var serviceDropDownData = GetServiceDropDownData();

            var model = new HomeViewModel
            {
                ServiceListData = serviceDropDownData
            };

            return View(model);
        }

        public ActionResult EncryptionDemo()
        {
            var serviceDropDownData = GetServiceDropDownData();
            var servicesToInclude = new List<int> {3, 5};

            var model = new HomeViewModel
            {
                ServiceListData = serviceDropDownData.Where(x => servicesToInclude.Contains(x.Id)).ToList()
            };

            return View("EncyptionDemo", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Private Methods
        private List<ServiceModel> GetServiceDropDownData()
        {
            const string ServiceUrl = "http://10.25.232.179";
            //const string ServiceUrl = "http://localhost";

            var servicesList = new List<ServiceModel>
            {
                new ServiceModel
                {
                    Id = 1,
                    Methods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Retrieve Test Practice",
                            Path = "Test",
                            ServiceId = 1
                        }
                    },
                    Name = "Practice",
                    Port = 7500,
                    Url = ServiceUrl
                },
                new ServiceModel
                {
                    Id = 2,
                    Methods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Get Diagnoses Lookup List",
                            Path = "GetDiagnosesLookupList",
                            ServiceId = 2
                        },
                        new ServiceMethodModel
                        {
                            Name = "Get Diagnoses Lookup List By Desc",
                            Path = "GetDiagnosesLookupListByDesc/Secondary",
                            ServiceId = 2
                        }
                    },
                    Name = "Diagnoses",
                    Port = 7001,
                    Url = ServiceUrl
                },
                new ServiceModel
                {
                    Id = 3,
                    EncryptedMethods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Get Status (Encrypted)",
                            Path = "status/e",
                            ServiceId = 3
                        },
                        new ServiceMethodModel
                        {
                            Name = "Get Services List (Encrypted)",
                            Path = "services/e",
                            ServiceId = 3
                        }
                    },
                    Methods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Get Status",
                            Path = "status",
                            ServiceId = 3
                        },
                        new ServiceMethodModel
                        {
                            Name = "Get Services List",
                            Path = "services",
                            ServiceId = 3
                        }
                    },
                    Name = "Services",
                    Port = 8502,
                    Url = ServiceUrl
                },
                new ServiceModel
                {
                    Id = 4,
                    Methods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Get Log Book",
                            Path = "GetLogBook/1484&devtest",
                            ServiceId = 4
                        },
                        new ServiceMethodModel
                        {
                            Name = "Get Log Book With Details",
                            Path = "GetLogBookWithDetails/1484&devtest&true",
                            ServiceId = 4
                        }
                    },
                    Name = "LogBook",
                    Port = 8011,
                    Url = ServiceUrl
                },
                new ServiceModel
                {
                    Id = 5,
                    EncryptedMethods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Vaccine Group List (Encrypted)",
                            Path = "VaccineGroupList/e",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "Vaccine Production Name List (Encrypted)",
                            Path = "VaccineProductionNameList/e",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "Practice List (Encrypted)",
                            Path = "PracticeList/e",
                            ServiceId = 5
                        }
                    },
                    Methods = new List<ServiceMethodModel>
                    {
                        new ServiceMethodModel
                        {
                            Name = "Practice List",
                            Path = "PracticeList",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "Vaccine Group List",
                            Path = "VaccineGroupList",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "Vaccine Production Name List",
                            Path = "VaccineProductionNameList",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "CPT to CVX List",
                            Path = "CPTtoCVXList",
                            ServiceId = 5
                        },
                        new ServiceMethodModel
                        {
                            Name = "BCX List",
                            Path = "BCXList",
                            ServiceId = 5
                        }
                    },
                    Name = "List Manager",
                    Port = 9500,
                    Url = ServiceUrl
                }
            };

            return servicesList;
        }
        #endregion
    }
}