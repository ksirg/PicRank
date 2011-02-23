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

            var pictures = ctx.RandomPictures(1 + 12);

            GameView gameView = new GameView();

            Game game = new Game();

            game.GameDate = DateTime.Now;


            bool hasMain = false;
            foreach (var item in pictures)
            {
                if (!hasMain)
                {
                    gameView.MainPicture = new PictureView() { Id = item.Id, FullPath = item.FullPath };
                    //game main picture
                    game.BasePicId = gameView.MainPicture.Id;
                    hasMain = true;
                }
                else
                {
                    //game participants
                    game.GameParticipants.Add(new GameParticipant() { PictureId = item.Id });

                    gameView.Pictures.Add(new PictureView() { Id = item.Id, FullPath = item.FullPath });
                }

            }

            ctx.Games.InsertOnSubmit(game);
            ctx.SubmitChanges();

            gameView.GameId = game.Id;

            //only for test
            //if (gameView.MainPicture == null)
            //    gameView.MainPicture = new PictureView() { FullPath = @"http://picrank.eastgroup.pl/PicturesSets/pierscionki/image_2702399.jpg", Id = 123 };
            //for (int i = 0; i < 10; i++)
            //{
            //    gameView.Pictures.Add(gameView.MainPicture);
            //}

            return View(gameView);
        }


        public ActionResult Win(int gameId, int winnerId)
        {

            PicRankDBDataContext ctx = new PicRankDBDataContext();

            var game = (from g in ctx.Games
                        where g.Id == gameId
                        select g).SingleOrDefault(); ;

            game.IsFinished = true;

            var participant = (from p in ctx.GameParticipants
                               where p.GameId == gameId && p.PictureId == winnerId
                               select p).SingleOrDefault();

            participant.IsWinner = true;

            ctx.SubmitChanges();

            return RedirectToAction("Play"); //View(mainPicList);
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
