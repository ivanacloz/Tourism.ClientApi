using Microsoft.AspNetCore.Mvc;
using Tourism.Client.Business;
using Tourism.Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tourism.Client.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientController(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        [HttpGet("GetListClient")]
        public List<Ent_Client> GetListClient()
        {
         
            return _clientBusiness.GetClients();
           
        }

        [HttpGet("GetClient/{id}")]
        public string GetClient(int id)
        {
            return "value";
        }

       
        [HttpPut("CreateClient/{id}")]
        public void CreateClient(int id, [FromBody] string value)
        {
        }


        [HttpDelete("DeleteClient/{id}")]
        public void DeleteClient(int id)
        {
        }
    }
}
