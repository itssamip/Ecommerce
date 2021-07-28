using Ecommerce.DataAccess.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            CategoryVM categoryVM = new CategoryVM()
            {
                Category = new Category(),
                MenuList = _unitOfWork.Menu.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };
            if (id == null)
            {
                // this is for create
                return View(categoryVM);

            }

            // this is for edit
            categoryVM.Category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (categoryVM.Category == null)
            {
                return NotFound();
            }

            return View(categoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoryVM categoryVM)
        {

            if (ModelState.IsValid)
            {

                if (categoryVM.Category.Id == 0)
                {
                    // this is for add
                    _unitOfWork.Category.Add(categoryVM.Category);
                }
                else
                {
                    //this is for update
                    _unitOfWork.Category.Update(categoryVM.Category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                IEnumerable<Menu> MenuLists = _unitOfWork.Menu.GetAll();
                categoryVM.MenuList = MenuLists.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

                if (categoryVM.Category.Id != 0)
                {
                    categoryVM.Category = _unitOfWork.Category.Get(categoryVM.Category.Id);
                }
            }


            return View(categoryVM);



        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var objFromDb = _unitOfWork.Category.GetAll(includeProperties: "Menu");
            return Json(new { data = objFromDb });

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });


            #endregion
        }
    }
}
