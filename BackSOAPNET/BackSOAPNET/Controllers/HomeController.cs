using BackSOAPNET.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Diagnostics;
using System.ServiceModel;
//using System.Web.Providers.Entities;

namespace BackSOAPNET.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SoapController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost:1802/app");
            var client = new ServiceReference1.ServiceClient(binding, endpoint);

            try
            {
                var response = await client.loginAsync(user.Email,null);
                return Ok(response);
            }
            catch (FaultException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            finally
            {
                if (client.State == CommunicationState.Faulted)
                {
                    client.Abort();
                }
                else
                {
                    client.Close();
                }
            }
        }
    }
    
}