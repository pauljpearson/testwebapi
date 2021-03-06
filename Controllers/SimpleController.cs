using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {


        private readonly ILogger<SimpleController> _logger;

        public SimpleController(ILogger<SimpleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string version = "v3";

            List<string> environmentVariables = new List<string>();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                environmentVariables.Add($"{de.Key} = {de.Value}");
            }

            string envVersion = Environment.GetEnvironmentVariable("TEST_WEBAPI_VERSION");
            if (envVersion != null)
            {
                version = envVersion;
            }

            return $"{version} {System.Environment.MachineName} {string.Join(',', environmentVariables)}";
        }
    }
}
