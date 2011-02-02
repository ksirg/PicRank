using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicRank.Web.Models;
using System.IO;
using Ionic.Zip;
using PicRank.Logic.Helpers;
using PicRank.Logic;

namespace PicRank.Web.Controllers
{
    public class DataSetsController : Controller
    {

        DataSetService dsService = new DataSetService();
        //
        // GET: /DataSets/

        public ActionResult Index()
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var picSet = (from ds in ctx.DataSets
                          orderby ds.Active descending, ds.Id 
                          select ds).ToList();
            return View(picSet);
        }

        //
        // GET: /DataSets/Details/5

        public ActionResult Details(int id)
        {
             PicRankDBDataContext ctx = new PicRankDBDataContext();
            
            var picSet = (from ds in ctx.DataSets
                         where ds.Id==id
                             select ds).SingleOrDefault();

            return View(picSet);
        }

        //
        // GET: /DataSets/Create

        [Authorize]
        public ActionResult Create()
        {
           
            return View();
        } 

        //
        // POST: /DataSets/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            DataSet picSet = new DataSet();
            var dataSetName =collection.Get("name");
            picSet.Name = dataSetName;

          

            try
            {
                if (string.IsNullOrEmpty(dataSetName))
                    ModelState.AddModelError("name", "Prosze podaj mi nazwę");

                if (!ModelState.IsValid)
                    return View(picSet);

                // TODO: Add insert logic here
                var datasetRepository = "DataSets";

                var virtulaDs = VirtualPathUtility.GetDirectory("~/");

                var destinationFolder = Path.Combine(Server.MapPath("~/"), datasetRepository);
                    //Server.MapPath(datasetRepository);
                //var ma = Server.MapPath("~/");

                var postedFile = Request.Files["datafile"];
                if (Path.GetExtension(postedFile.FileName) != ".zip")
                {
                    throw new NotSupportedException("Przyjmuję tylko pliki .zip");
                }

                var diskFolder = Path.Combine(destinationFolder, dataSetName);
                    //string.Format("{0}/{1}",destinationFolder,dataSetName);

                var fileName = Path.Combine(diskFolder, postedFile.FileName);
                    //string.Format("{0}/{1}", datasetFolder, postedFile.FileName);

                if (postedFile.ContentLength > 0)
                {
                    Directory.CreateDirectory(diskFolder);
                       
                    postedFile.SaveAs(fileName);

                    picSet.FolderPath = diskFolder;

                    List<Picture> pictures = new List<Picture>();
                    string zipToUnpack =fileName ;
                    string unpackDirectory = diskFolder;
                    using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
                    {
                        // here, we extract every entry, but we could extract conditionally
                        // based on entry name, size, date, checkbox status, etc.  
                    int picCount=0;
                        foreach (ZipEntry zipItem in zip1)
                        {
                            //zipItem.InputStream
                            
                            zipItem.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                            picCount++;
                            string zipItemFile = Path.Combine(unpackDirectory, zipItem.FileName);
                                //string.Format("{0}/{1}", unpackDirectory,zipItem.FileName);
                            var isImg = PictureHelpers.IsValidImage(zipItemFile);
                            if (!isImg)
                            {
                                System.IO.File.Delete(zipItemFile);
                                picCount--;
                                continue;
                            }


                            string picRelativePath = string.Format("{0}/{1}/{2}", datasetRepository, dataSetName, zipItem.FileName);
                                //Path.Combine( datasetRepository,dataSetName,zipItem.FileName);
                            picSet.Pictures.Add(new Picture { FullPath =picRelativePath , Name = zipItem.FileName });

                        }
                        picSet.PicCoutn = picCount;

                        PicRankDBDataContext ctx = new PicRankDBDataContext();
                        ctx.DataSets.InsertOnSubmit(picSet);
                        ctx.SubmitChanges();
                    }

                }
                return RedirectToAction("Details", new { id = picSet.Id });
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("datafile", ex.Message);
                return View(picSet);
            }
        }
        
        //
        // GET: /DataSets/Edit/5
 
        public ActionResult Edit(int id)
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var ds = (from t in ctx.DataSets
                      where t.Id == id
                      select t).SingleOrDefault();
            
            return View(ds);
        }

        //
        // POST: /DataSets/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                PicRankDBDataContext ctx = new PicRankDBDataContext();

                var ds = (from t in ctx.DataSets
                          where t.Id == id
                          select t).SingleOrDefault();


                ds.Name = collection["name"];
                ds.Active = Convert.ToBoolean(collection["active"]);

                ctx.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DataSets/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DataSets/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
