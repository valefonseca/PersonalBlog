using Blog_prueba.Data;
using Blog_prueba.Models.Domain;
using Blog_prueba.Models.ViewModels;
using Blog_prueba.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_prueba.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //mapeo de AddTagRequest a Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List() 
        {
            //se leen los tags con blogDbContext
            var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
            //var tag = blogDbContext.Tags.Find(id);
            //var tag = await blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            var tag = await tagRepository.GetAsync(id);

            if(tag != null) 
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }
            else
            {
                return View(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                //mostrar exito
            }
            else
            {

            }
            
            //mostrar fallo
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
            

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
           var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                //mostrar exito
                return RedirectToAction("List");
            }

            //mostrar fallo
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
            
        }
    }
}
