using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace api_scores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string json;
            using (StreamReader r = new StreamReader("scores.json"))
            {
                json = r.ReadToEnd();
            }

            return json;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<Puntaje> puntaje)
        {
            if (puntaje != null)
            {
                var remove = puntaje.Count - 10;
                if (remove > 0)
                {
                    puntaje.RemoveRange(10, remove);
                }
                var json = JsonConvert.SerializeObject(puntaje);
                using (StreamWriter w = new StreamWriter("scores.json"))
                { w.WriteLine(json); }
            }            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
