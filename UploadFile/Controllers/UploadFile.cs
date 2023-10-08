using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFile : ControllerBase
    {
        [HttpPost(Name = "Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file == null || file?.Length == 0)
            {
                return BadRequest("file is invalid!");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads", file.FileName);
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return Ok("File uploaded");
        }
    }
}
