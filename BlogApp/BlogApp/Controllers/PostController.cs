using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postrepository;

        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postrepository)
        {
            _postrepository = postrepository;
        
            

        }

         public async Task<IActionResult> Index(string tag)
        {
            var posts = _postrepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }
            
            return View(
                new PostViewModel
                {
                    Posts = await posts.ToListAsync()
                   
                });
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postrepository.Posts.FirstOrDefaultAsync(p=>p.Url==url));
        }

        
    }
}