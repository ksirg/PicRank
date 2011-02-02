using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicRank.Web.Models;

namespace PicRank.Web.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var pictures = ctx.RandomPictures(1+8);

            MainPicWithList mainPicList = new MainPicWithList();

            bool hasMain = false;
            foreach (var item in pictures)
            {
                if (!hasMain)
                {
                    mainPicList.MainPicture= new PictureView() { Id = item.Id, FullPath = item.FullPath };
                    hasMain = true;
                }else
                    mainPicList.Pictures.Add(new PictureView() { Id = item.Id, FullPath = item.FullPath });
            }


            return View(mainPicList);
        }


        //
        // GET: /Game/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Game/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Game/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Game/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Game/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Game/Delete/5

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
