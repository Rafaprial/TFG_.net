using Cinemas.DataAccess;
using Cinemas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemasWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _db;
        public CategoriaController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> objCatgoriaList = _db.Categorias;
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
            if(obj.Name == obj.Orden.ToString())
            {
                ModelState.AddModelError("CustomError", "El orden no puede ser igual al Nombre");
            }
            if (ModelState.IsValid)
            {
                _db.Categorias.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Categoria creada correctamente";
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        //EDITAR
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null||id==0)
            return NotFound();

            var categoriaFromDb = _db.Categorias.Find(id);
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
                _db.Categorias.Update(obj);
                _db.SaveChanges();
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

            var categoriaFromDb = _db.Categorias.Find(id);
            if (categoriaFromDb == null)
                return NotFound();

            return View(categoriaFromDb);
        }
        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categorias.Find(id);
            
            if(obj == null) {
                return NotFound();
            }
            
            _db.Categorias.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoria eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
