using Ecommerce.DataAccess.Repo.IRepo;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Menu menu = new Menu();

            if(id == null)
            {
                // this is for create 
                return View(menu);
            }

             menu = _unitOfWork.Menu.Get(id.GetValueOrDefault());
            if(menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Menu menu)
        {
            if (ModelState.IsValid)
            {
                if(menu.Id == 0)
                {
                    _unitOfWork.Menu.Add(menu);
                }

                else
                {
                    _unitOfWork.Menu.Update(menu);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(menu);

        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = _unitOfWork.Menu.GetAll();

            return Json(new { data = obj });

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Menu.Get(id);
            if(obj == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }

            _unitOfWork.Menu.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successfull" });
        }


        #endregion
    }

}
