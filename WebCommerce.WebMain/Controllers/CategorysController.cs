using Microsoft.AspNetCore.Mvc;
using WebCommerce.DbDatas.Repos.UOWs;
using WebCommerce.Models;

namespace WebCommerce.WebMain.Controllers
{
    public class CategorysController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategorysController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult CategoryList()
        {
            var categoryList = _unitOfWork.CategoryRepo.GetAll();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult CategoryUpsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryUpsert(Category category,IFormFile? file)
        {
           


            if(ModelState.IsValid )
            {
                if (file != null)
                {
                    string fileExtantion = Path.GetExtension(file.FileName);
                    string newFileName = "Image"+Guid.NewGuid().ToString().Substring(0,4)+fileExtantion;

                    
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string fileDestination = Path.Combine(webRootPath, @"Images\CategoryImg");

                    using (FileStream fileStream = new FileStream(Path.Combine(fileDestination,newFileName),FileMode.Create)) 
                    {
                       file.CopyTo(fileStream);
                    }
                   
                }



                if (category.Id == null || category.Id == 0)
                {
                    _unitOfWork.CategoryRepo.AddData(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Add Successfully ";

                }
                else
                {
                    _unitOfWork.CategoryRepo.EditData(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Edit Successfully ";
                }

               return RedirectToAction("CategoryList");
            }
            return NotFound(ModelState);
        }
    }
}
