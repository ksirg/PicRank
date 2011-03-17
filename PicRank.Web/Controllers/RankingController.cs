using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicRank.Web.Models;

namespace PicRank.Web.Controllers
{
    public class RankingController : Controller
    {
        //
        // GET: /Ranking/

        public ActionResult Index()
        {
            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var basePictures = ctx.GetPicForRanking(20);

            List<PictureView> pic = new List<PictureView>();
            foreach (var item in basePictures)
            {
                pic.Add(new PictureView() { Id = item.Id, FullPath = item.FullPath });
            }

            ViewBag.SimpleRankingMsg = TempData["SimpleRankingMsg"];

            return View(pic);
        }

        //
        // GET: /Ranking/Details/5

        public ActionResult Ranking(int id)
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var basePictures = (from r in ctx.Rankings
                                join
                                p in ctx.Pictures on r.PicId equals p.Id
                                where r.BasePicId == id
                                orderby r.Score descending
                                select new { PicRank = r, Pic = p }).Take(20);

            var mainPic = (from p in ctx.Pictures
                           where p.Id == id
                           select p).SingleOrDefault();

            MainPicWithList ranking = new MainPicWithList();
            ranking.MainPicture = new PictureView() { FullPath = mainPic.FullPath, Id = mainPic.Id };

            foreach (var item in basePictures)
            {
                ranking.Pictures.Add(new PictureView()
                {
                    Id = item.Pic.Id,
                    FullPath = item.Pic.FullPath,
                    RankingScore = item.PicRank.Score.Value
                });
            }
            return View(ranking);

        }

        //
        // GET: /Ranking/Create

        public ActionResult Create()
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();
            
            ctx.SimpleRanking();

            TempData["SimpleRankingMsg"]= "Simple Ranking Created";
            return RedirectToAction("Index");
            //return View();
        }

        //
        // POST: /Ranking/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Ranking/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ranking/Edit/5

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
        // GET: /Ranking/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ranking/Delete/5

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
