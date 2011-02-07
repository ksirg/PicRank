using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicRank.Web.Models
{
    public class GameView
    {
        public int GameId { get; set; }

        public PictureView MainPicture { get; set; }
        public List<PictureView> Pictures { get; set; }

        public GameView()
        {
            Pictures = new List<PictureView>(10);
        }
    }
}