using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly BookingService bookingservice;
        public BookingController(BookingService bookingservice)
        {
            this.bookingservice = bookingservice;
        }
        public BookingController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateBooking([FromBody] TB_BOOKING booking)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            booking.ID = Guid.NewGuid();
            booking.USERID = Guid.Parse(userIdClaim);
            booking.BOOKINGDATE = DateTime.Now;

            _context.TB_BOOKING.Add(booking);
            _context.SaveChanges();

            return Ok(new { message = "Booking created successfully", booking });
        }
        public IActionResult AddProperty([FromBody] TB_BOOKING booking)
        {
            bool success =bookingservice.AddBooking();
            if (success)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
