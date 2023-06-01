using _1stBlog.Data;
using _1stBlog.Models.Domain;
using _1stBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _1stBlog.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogDbContext blogDbContext;

        public AdminTagsController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            blogDbContext.Tags.Add(tag);
            blogDbContext.SaveChanges();

            return View("Add");
        }

        [HttpGet]
        public IActionResult List()
        {
            //read tags
            var tags = blogDbContext.Tags.ToList();

            return View(tags);
        }
    }
}
