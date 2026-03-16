using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace PracticingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IWebHostEnvironment _environment;
        public HomeController(IPersonService personService, IWebHostEnvironment environment)
        {
            _personService = personService;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PersonResponse> persons = _personService.GetAllPersons();
            return View(persons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            string? logoPath = null;
            if (request.Logo != null && request.Logo.Length > 0)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "img", "uploads");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Logo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.Logo.CopyTo(stream);
                }
                logoPath = "/img/uploads/" + uniqueFileName;
            }

            _personService.CreateCard(request, logoPath);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            PersonResponse? person = _personService.GetPersonById(id);
            if (person == null)
                return NotFound();

            return View(person);
        }
    }
}
