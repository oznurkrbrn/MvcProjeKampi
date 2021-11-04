using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class İstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wr = new WriterManager(new EFWriterDal());



        // GET: İstatistik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryCountList()
        {
            var categoryvalues = cm.GetList().Count();
            ViewBag.TotalCategoryCount = categoryvalues;
            var headeristatistik = hm.GetList().Count(x => x.Category.CategoryID == 2);
            ViewBag.headeristatistik = headeristatistik;
            var writeristatistik = wr.GetList().Count(x => x.WriterName=="a");
            ViewBag.writeristatistik = writeristatistik;
            var maxcategortyistatistik = hm.GetList().Max(x => x.Category.CategoryName);
            ViewBag.maxcategortyistatistik = maxcategortyistatistik;
            var trueistatistik = cm.GetList().Count(x => x.CategoryStatus == true);
            var falseistatistik = cm.GetList().Count(x => x.CategoryStatus == false);
            ViewBag.resultistatistik = trueistatistik- falseistatistik;
            return View();
        }
    }
}