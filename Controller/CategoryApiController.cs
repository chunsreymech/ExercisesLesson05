using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExercisesLesson05.Data;

namespace ExercisesLesson05.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryApiController : ControllerBase
    {
        private readonly StoreDbContext _context;

        // Constructor ទទួលយក DbContext តាមរយៈ DI
        public CategoryApiController(StoreDbContext context)
        {
            _context = context;
        }

        // Endpoint សម្រាប់ទាញទិន្នន័យទាំងអស់ជាទម្រង់ JSON
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            // .ToList() នឹងបញ្ជាទៅ Database ឱ្យ Select ទិន្នន័យទាំងអស់ពី Table
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
    }
}