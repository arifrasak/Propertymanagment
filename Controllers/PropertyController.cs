using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService propertyservice;
        public PropertyController(PropertyService propertyservice)
        {
            this.propertyservice = propertyservice;
        }
        [HttpGet]
        public IActionResult GetProperty()
        {
            DataTable property = propertyservice.ViePropertylist();
            return Ok(property);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("add-property")]
        public IActionResult AddProperty([FromBody] TB_PROPERTY property)
        {
            bool success = propertyservice.Addproperty();
            if(success)
            {
                return Ok(property);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("edit-property/{id}")]
        public IActionResult EditProperty(Guid id, [FromBody] TB_PROPERTY property)
        {
            bool success = propertyservice.Editproperty();
            if (success)
            {
                return Ok(property);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-bookings")]
        public IActionResult GetAllBookings()
        {
            try
            {
            DataTable property = propertyservice.ViePropertylist();
            return Ok(property);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
