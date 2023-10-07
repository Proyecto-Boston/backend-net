using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace WebBackSOAP
{
    public class SoapClientController : ControllerBase
    {
        [HttpGet]
        [Route("CallSoapMethod")]
        public IActionResult CallSoapMethod()
        {
            try
            {
                // Crea una instancia del cliente del servicio SOAP generado.
                using (var client = new ServiceClient())
                {
                    // Llama a un método del servicio SOAP.
                    var result = client.loginAsync;

                    // Procesa la respuesta y devuelve los datos necesarios.
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones adecuadamente.
                return BadRequest(ex.Message);
            }
        }
    }
}
