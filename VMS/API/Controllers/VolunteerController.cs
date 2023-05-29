using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/volunteer
    public class VolunteerController : ControllerBase
    {
        private readonly DataContext _context;

        public VolunteerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetVolunteers()
        {
            var volunteers = await _context.Volunteers.ToListAsync();

            return volunteers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Volunteer>> GetVolunteerById(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return volunteer;
        }

    }
}