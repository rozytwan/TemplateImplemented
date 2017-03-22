using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DenimSACCOS.Models;

namespace DenimSACCOS.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            files = imageslist();
            //objHomeGallery.ImageList = files;
            //objHomeGallery = files;
            return View("../Home/Gallery",files);
        }
        List<DenimSACCOS.Models.Gallery> files;
        public List<DenimSACCOS.Models.Gallery> imageslist()
        {
            string folderPath = Server.MapPath("~/Gallery/");
            string[] filePaths = Directory.GetFiles(folderPath);
            files = new List<DenimSACCOS.Models.Gallery>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new DenimSACCOS.Models.Gallery
                {
                    ImageName = fileName.Split('.')[0].ToString(),
                    ImagePath = "../Gallery/" + fileName
                });
            }
            List<DenimSACCOS.Models.Gallery> objimg = files.ToList();
            return objimg;
        }




    }
}