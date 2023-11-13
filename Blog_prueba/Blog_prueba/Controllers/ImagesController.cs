using Blog_prueba.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blog_prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageURL = await imageRepository.UploadAsync(file);

            if(imageURL == null)
            {
                return Problem("Something went wrong :(", null, (int)HttpStatusCode.InternalServerError);
            }
            else
            {
                return new JsonResult(new { link = imageURL });
            }
        }
    }
}
