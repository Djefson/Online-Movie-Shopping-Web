using Newtonsoft.Json;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin



        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }


        //public ActionResult Categories()
        //{
        //    List<Tbl_Category> allcategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
        //    return View(allcategories);
        //}
        //public ActionResult AddCategory()
        //{
        //    return UpdateCategory(0);
        //}

        //public ActionResult UpdateCategory(Int32 categoryId)
        //{
        //        CategoryDetail cd;

        //        if(categoryId != null) 
        //        {
        //            cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId)));
        //        }
        //        else{
        //            cd = new CategoryDetail();
        //        }
        //    return View("UpdateCategory", cd);
            
        //}
        //public ActionResult CategoryEdit(Int32 catId)
        //{
        //    return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(catId));
        //}
        //[HttpPost]
        //public ActionResult CategoryEdit(Tbl_Category tbl)
        //{
        //    _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
        //    return RedirectToAction("Categories");
        //}
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_product>().GetProduct());
        }
        public ActionResult ProductEdit(Int32 productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_product>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(Tbl_product tbl, HttpPostedFileBase file)
        {
            string pic=null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;
            //tbl.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_product>().Update(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Tbl_product tbl,HttpPostedFileBase file)
        {
            string pic=null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            tbl.CreateDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_product>().Add(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult Categories()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetCategories());
        }

        public ActionResult CategoriesEdit(int CategoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(CategoryId));
        }
        [HttpPost]
        public ActionResult CategoriesEdit(Tbl_Category tbl)
        {

            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
             return RedirectToAction("Categories");
        }


        public ActionResult CategoriesAdd()
        {
            return View( );
        }

        [HttpPost]
        public ActionResult CategoriesAdd(Tbl_Category tbl)
        {

            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(tbl);
            return RedirectToAction("Categories");
        }

    }
}