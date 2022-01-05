using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreNHibernate.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public SupplierController(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public ActionResult Index() 
            => View(_supplierRepository.FindAll().ToList());

        public async Task<ActionResult> Details(long? id) 
            => await CheckIntegrityBeforViewAsync(id);

        // GET: Products/Create
        public ActionResult Create()
        {
            GetProductsMultiSelect();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Company.Supplier = supplier; // Required to save company entity
                supplier.SetSelectedProducts();

                await _supplierRepository.AddAsync(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            GetProductsMultiSelect();
            return await CheckIntegrityBeforViewAsync(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Company.Supplier = supplier; // Required to save company entity
                supplier.SetSelectedProducts();

                await _supplierRepository.UpdateAsync(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public async Task<ActionResult> Delete(long? id)
            => await CheckIntegrityBeforViewAsync(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _supplierRepository.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> CheckIntegrityBeforViewAsync(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var supplier = await _supplierRepository.FindByIdAsync(id.Value);
            if (supplier == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return View(supplier);
        }

        private void GetProductsMultiSelect()
        {
            var products = _productRepository.FindAll();
            ViewBag.Products = products;
        }
    }
}