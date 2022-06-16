using Bootstrap.DAL;
using Bootstrap.Exists;
using Bootstrap.Models;
using Bootstrap.Utilities;
using Bootstrap.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace Bootstrap.Areas.adminpanel.Controllers
{
    [Area("adminpanel")]
    public class CardController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment web;

        public CardController(AppDbContext context, IWebHostEnvironment web)
        {
            this.context = context;
            this.web = web;
        }
        public async Task<IActionResult> Index()
        {

            HomeVM homeVM = new HomeVM
            {
                cards = await context.cards.ToListAsync()
            };
            return View(homeVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Card card)
        {
            if (!ModelState.IsValid) return View();
            if (card.Photo != null)
            {
                if (card.Photo.IsExist(1))
                {
                    ModelState.AddModelError("Photo", "Please choos mb ");
                    return View();
                }

                string filestream = await card.Photo.FileCreate(web.WebRootPath, @"assets\image\");


                card.Image = filestream;
                await context.cards.AddAsync(card);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please Chosse File");
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            Card card = await context.cards.FirstOrDefaultAsync(d => d.Id == id);
            if (card == null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Card card, int id)
        {
            if (!ModelState.IsValid) return View();

            Card exsist = await context.cards.FirstOrDefaultAsync(d => d.Id == id);
            if (exsist == null) return NotFound();
            if (card.Photo != null)
            {
                if (card.Photo.IsExist(1))
                {
                    ModelState.AddModelError("Photo", "Please choos mb ");
                    return View();
                }

                string filestream = await card.Photo.FileCreate(web.WebRootPath, @"assets\image\");

                exsist.Image = filestream;

                string path = web.WebRootPath + @"assets\image\" + card.Image;

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(filestream);
                }

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ModelState.AddModelError("Photo", "Please Choose image");
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            Card card = await context.cards.FirstOrDefaultAsync(d => d.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> Deleted(int id)
        {
            Card card = await context.cards.FirstOrDefaultAsync(d => d.Id == id);
            if (card == null) return NotFound();

            context.cards.Remove(card);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detiel(int id)
        {
            Card card = await context.cards.FirstOrDefaultAsync(d => d.Id == id);
            if (card == null) return NotFound();

            return View(card);
        }
    }
}
