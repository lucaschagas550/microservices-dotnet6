﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProduct();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);
                if (response != null) return RedirectToAction("ProductIndex");
            }

            return View(product);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var product = await _productService.FindById(id);
            if (product != null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);
                if (response != null) return RedirectToAction("ProductIndex");
            }

            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _productService.FindById(id);
            if (product != null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel product)
        {
            var response = await _productService.DeleteProductById(product.Id);
            if (response != null) return RedirectToAction("ProductIndex");

            return View(response);
        }
    }
}
