using CustomerModels.Models;
using CustomerUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly HttpClient _httpClient;

        public CustomersController(IHttpClientFactory httpClientFactory, ILogger<CustomersController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5129/"); // Update with actual URL if different
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Customer List";
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>("api/Customers");
            return View(customers);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Add Customer";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("api/Customers", customer);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ViewData["Title"] = "Edit Customer";
                var response = await _httpClient.GetAsync($"api/Customers/{id}");

                // Ensure the response is successful before deserializing
                response.EnsureSuccessStatusCode();

                var customer = await response.Content.ReadFromJsonAsync<Customer>();
                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError("", "Failed to retrieve customer. Please try again later.");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync($"api/Customers/{customer.Id}", customer);
                    response.EnsureSuccessStatusCode(); // Ensure success

                    return RedirectToAction(nameof(Index));
                }
                catch (HttpRequestException ex)
                {
                    // Log the exception or handle it appropriately
                    _logger.LogError(ex, "Error updating customer");
                    ModelState.AddModelError("", "Failed to update customer. Please try again later.");
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ViewData["Title"] = "Delete Customer";
                var response = await _httpClient.GetAsync($"api/Customers/{id}");
                response.EnsureSuccessStatusCode(); // Ensure success

                var customer = await response.Content.ReadFromJsonAsync<Customer>();
                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                _logger.LogError(ex, "Error retrieving customer for delete");
                ModelState.AddModelError("", "Failed to retrieve customer for delete. Please try again later.");
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Customer customer)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Customers/{customer.Id}");
                response.EnsureSuccessStatusCode(); // Ensure success

                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it appropriately
                _logger.LogError(ex, "Error deleting customer");
                ModelState.AddModelError("", "Failed to delete customer. Please try again later.");
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
