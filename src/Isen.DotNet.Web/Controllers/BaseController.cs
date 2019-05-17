using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Models;
using System;
using System.Dynamic;

namespace Isen.DotNet.Web.Controllers
{
    public abstract class BaseController<T, TRepo> : Controller
        where T : BaseModel<T>
        where TRepo : IBaseRepository<T>
    {
        #region API
        
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public virtual JsonResult GetById(int id)
        {
            var entity = Repository.Single(id);
            if (entity == null) return Json(new { });
            return Json(entity.ToDynamic());
        }

        [HttpGet]
        [Route("api/[controller]")]
        public virtual JsonResult GetAll()
        {
            var all = Repository
                .GetAll()
                .Select(e => e.ToDynamic())
                .ToList();
            return Json(all);
        }
        #endregion

        protected readonly TRepo Repository;

        protected BaseController(TRepo repository)
        {
            Repository = repository;
        }

        public IActionResult Index() => View(Repository.GetAll());

        [HttpGet] //facultatif car par défaut
        public IActionResult Edit(int? id)
        {
            if(id == null) return View();
            return View(Repository.Single(id.Value));
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] T model)
        {
            Repository.Update(model);
            Repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Repository.Delete(id.Value);
                Repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}