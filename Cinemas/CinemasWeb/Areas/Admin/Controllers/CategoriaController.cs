using Cinemas.DataAccess;
using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemasWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> objCatgoriaList = _unitOfWork.Category.GetAll();
            return View(objCatgoriaList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria obj)
        {
            if (obj.Name == obj.Orden.ToString())
            {
                ModelState.AddModelError("CustomError", "El orden no puede ser igual al Nombre");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Categoria creada correctamente";
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        //EDITAR
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoriaFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoriaFromDb == null)
                return NotFound();

            return View(categoriaFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria obj)
        {
            if (obj.Name == obj.Orden.ToString())
            {
                ModelState.AddModelError("CustomError", "El orden no puede ser igual al Nombre");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Categoria editada correctamente";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //DELETE
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoriaFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoriaFromDb == null)
                return NotFound();

            return View(categoriaFromDb);
        }
        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Categoria eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
