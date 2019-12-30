using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BOL;
using BLL;
using Newtonsoft.Json;
namespace RESTWebAPI.Controllers
{
    public class FlowersController : ApiController
    {
        // GET: api/Flowers
        public string Get()
        {
            List<Flower> flowers = FlowersManager.getAll();
            return JsonConvert.SerializeObject(flowers);
            
            
        }

        // GET: api/Flowers/5
        public Flower Get(int id)
        {
            return FlowersManager.get(id);
        }

        // POST: api/Flowers
        public string Post([FromBody]Flower value)
        {
            if (FlowersManager.add(value)) 
            {
                return "Flower added successfully :)";
            }
            return "Flower NOT added :(";
        }

        // PUT: api/Flowers/5
        [HttpPut]
        public string Put([FromBody]Flower value)
        {
            if (FlowersManager.update(value))
            {
                return "Flower updated successfully :)";
            }
            return "Flower NOT updated :(";
        }

        // DELETE: api/Flowers/5
        [HttpDelete]
        public string Delete(int id)
        {
            if (FlowersManager.delete(id))
            {
                return "Flower deleted successfully :(";
            }
            return "Flower NOT deleted ;)";
        }
    }
}
