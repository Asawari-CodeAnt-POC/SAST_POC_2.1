using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        // ✅ Fixed Path Traversal Vulnerability
        [HttpGet("read")]
        public IActionResult ReadFile(string file)
        {
            // Restrict all reads to a safe directory
            string safeDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SafeFiles");

            // Prevent directory traversal by stripping path info
            string safeFileName = Path.GetFileName(file);

            // Build secure path
            string safePath = Path.Combine(safeDirectory, safeFileName);

            // Validate file exists
            if (!System.IO.File.Exists(safePath))
            {
                return NotFound("File not found");
            }

            string content = System.IO.File.ReadAllText(safePath);

            return Ok(content);
        }
    }
}
