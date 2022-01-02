using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreNHibernate.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: Products
        public ActionResult Index() 
            => View(_productRepository.FindAll().ToList());

        // GET: Products/Details/5
        public async Task<ActionResult> Details(long? id) 
            => await CheckIntegrityBeforViewAsync(id);

        // GET: Products/Create
        public ActionResult Create()
        {
            GetViewBagCategories();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.AuditInsertion();

                await _productRepository.AddAsync(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(long? id)
            => await CheckIntegrityBeforViewAsync(id);

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.AuditUpdate();

                await _productRepository.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(long? id)
            => await CheckIntegrityBeforViewAsync(id);

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _productRepository.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> CheckIntegrityBeforViewAsync(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var product = await _productRepository.FindByIdAsync(id.Value);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            GetViewBagCategories(product.Category?.Id ?? 0);

            return View(product);
        }

        private void GetViewBagCategories(long selectedCategory = 0)
        {
            var categories = _categoryRepository.FindAll();
            var items = categories
                .Select(s => new SelectListItem 
                { 
                    Text = s.Name, 
                    Value = s.Id.ToString(), 
                    Selected = s.Id == selectedCategory 
                })
                .ToList();

            ViewBag.Categories = items;
        }
    }
}