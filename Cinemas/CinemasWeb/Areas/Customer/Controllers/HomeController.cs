using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemasWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Pelicula> peliculaList = _unitOfWork.Pelicula.GetAll(includeProperties: "Pegi,Categoria");
            return View(peliculaList);
        }
        public IActionResult Details(int id)
        {
            Carrito cartObj = new() {
                Count = 1,
                PeliculaId = id,
                Pelicula = _unitOfWork.Pelicula.GetFirstOrDefault(u => u.Id == id, includeProperties: "Pegi,Categoria")
            };
            return View(cartObj);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}