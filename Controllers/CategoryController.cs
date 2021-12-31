using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreNHibernate.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public ActionResult Index() 
            => View(_categoryRepository.FindAll().ToList());

        public async Task<ActionResult> Details(long? id) 
            => await CheckIntegrityBeforViewAsync(id);

        // GET: Products/Create
        public ActionResult Create() 
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddAsync(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<ActionResult> Edit(long? id)
            => await CheckIntegrityBeforViewAsync(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<ActionResult> Delete(long? id)
            => await CheckIntegrityBeforViewAsync(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _categoryRepository.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> CheckIntegrityBeforViewAsync(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var category = await _categoryRepository.FindByIdAsync(id.Value);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return View(category);
        }
    }
}