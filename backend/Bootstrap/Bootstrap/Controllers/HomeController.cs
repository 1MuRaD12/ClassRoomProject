using Bootstrap.DAL;
using Bootstrap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                captions = await context.captions.ToListAsync(),
                cards = await context.cards.ToListAsync(),
                abouts = await context.abouts.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
