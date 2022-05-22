using Cinemas.DataAccess;
using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemasWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PegiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PegiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Pegi> objPegiList = _unitOfWork.Pegi.GetAll();
            return View(objPegiList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pegi obj)
        {
            if (obj.Name == obj.EdadMax.ToString())
            {
                ModelState.AddModelError("CustomError", "El orden no puede ser igual al Nombre");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Pegi.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Pegi creada correctamente";
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

            var PegiFromDb = _unitOfWork.Pegi.GetFirstOrDefault(u => u.Id == id);
            if (PegiFromDb == null)
                return NotFound();

            return View(PegiFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pegi obj)
        {
            if (obj.Name == obj.EdadMax.ToString())
            {
                ModelState.AddModelError("CustomError", "El orden no puede ser igual al Nombre");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Pegi.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Pegi editada correctamente";
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

            var PegiFromDb = _unitOfWork.Pegi.GetFirstOrDefault(u => u.Id == id);

            if (PegiFromDb == null)
                return NotFound();

            return View(PegiFromDb);
        }
        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Pegi.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Pegi.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Pegi eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
