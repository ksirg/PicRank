using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicRank.Web.Models
{
    public class MainPicWithList
    {
        public PictureView MainPicture { get; set; }
        public List<PictureView> Pictures { get; set; }

        public MainPicWithList()
        {
            Pictures = new List<PictureView>(10);
        }
    }
}