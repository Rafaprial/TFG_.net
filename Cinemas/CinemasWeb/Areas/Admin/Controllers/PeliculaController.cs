using Cinemas.DataAccess;
using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using Cinemas.Models.ViewmModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemasWeb.Areas.Admin.Controllers;
    [Area("Admin")]
    public class PeliculaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PeliculaController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
           
            return View();
        }


        //EDITAR
        //GET
        public IActionResult Upsert(int? id)
        {
            PeliculaVM peliculaVM = new()
            {
                pelicula = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PegiList = _unitOfWork.Pegi.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };


            if (id == null || id == 0) 
            {
                return View(peliculaVM);
            }
            else
            {
            //Editar
            peliculaVM.pelicula = _unitOfWork.Pelicula.GetFirstOrDefault(u => u.Id == id);
            return View(peliculaVM);
        }


/*            return View(peliculaVM); INACCESIBLE*/
        }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(PeliculaVM obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var upload = Path.Combine(wwwRootPath, @"images/peliculas");
                var extension = Path.GetExtension(file.FileName);

                if (obj.pelicula.ImageUrl != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, obj.pelicula.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.pelicula.ImageUrl = @"\images\peliculas\" + fileName + extension;
            }
            if (obj.pelicula.Id == 0)
            {
                _unitOfWork.Pelicula.Add(obj.pelicula);
            }
            else
            {
                _unitOfWork.Pelicula.Update(obj.pelicula);
            }

            _unitOfWork.Save();
            TempData["success"] = "Pelicula Añadida correctamente";
            return RedirectToAction("Index");
        }

        return View(obj);
    }



    #region APIS

    [HttpGet]
    public IActionResult GetAll()
    {
        var peliculaList = _unitOfWork.Pelicula.GetAll(includeProperties: "Categoria,Pegi");
        return Json(new { data = peliculaList });
    }

    //Post
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Pelicula.GetFirstOrDefault(u => u.Id == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error al borrar" });
        }
        var oldImage = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImage))
        {
            System.IO.File.Delete(oldImage);
        }

        _unitOfWork.Pelicula.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Pelicula Borrada Correctamente" });

    }
    #endregion
}
