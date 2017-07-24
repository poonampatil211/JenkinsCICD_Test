using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Travel.Connectors.Hotel.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get(string test)
        {
            //testData();
            return new string[] { "value1", "value2 3 5 6"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value1234";
        }

        // POST api/values
        [HttpPost]
        public string Post()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }
            return requestBody;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put()
        {
            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(HttpContext.Request.Body))
            {
                requestBody = streamReader.ReadToEnd();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                HttpContext.Request.Body = new MemoryStream(requestData);
            }
            return requestBody;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int  Delete(int id)
        {
            return id;
        }

        public string t = null;
        public string testData()
        {
            int? nullable = null;
            UseValue(nullable.Value); // Noncompliant
            return t;
        }

        private void UseValue(int value)
        {
            throw new NotImplementedException();
        }

        public int Foo
        {
            get
            {
                throw new Exception(); // Noncompliant
            }
            set
            {

                // do set ...
            }
        }

    }
}

