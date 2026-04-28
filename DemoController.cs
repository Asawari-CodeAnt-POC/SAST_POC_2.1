
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        // ❌ Critical Path Traversal Vulnerability
        [HttpGet("read")]
        public IActionResult ReadFile(string file)
        {
            string content = File.ReadAllText(file);
            return Ok(content);
        }
    }
}
