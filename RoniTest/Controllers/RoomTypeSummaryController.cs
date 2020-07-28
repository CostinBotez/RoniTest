using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoniTest.Data;
using RoniTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoniTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeSummaryController : ControllerBase
    {
        private readonly TestDbContext _context;
        
        public RoomTypeSummaryController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/<RoomTypeSummaryController>
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            var result = await _context.RoomTypes
                .Join(
                    _context.Jobs,
                    roomType => roomType.ID,
                    job => job.RoomType.ID,
                    (roomType, job) => new
                    {
                        Id = roomType.ID,
                        Name = roomType.Name,
                        Status = job.Status
                    }
                )
                .GroupBy(s => new { s.Name, s.Status })
                .Select(s => new
                {
                    Name = s.Key.Name,
                    Status = s.Key.Status,
                    Count = s.Count()
                })
                .OrderBy(s => s.Name)
                .ToListAsync();
            return result;
        }

    }
}
