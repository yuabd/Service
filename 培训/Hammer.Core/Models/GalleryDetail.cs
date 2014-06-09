using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models
{
    public class GalleryDetail
    {
        [Key, Column(Order = 1)]
        public int GalleryID { get; set; }
        [Key, Column(Order = 2)]
        [MaxLength(50)]
        public string PictureFile { get; set; }
        [MaxLength(50)]
        public string PictureTitle { get; set; }
        public int SortOrder { get; set; }

        //  Navigation

        public virtual Gallery Gallery { get; set; }

        //extended
        [NotMapped]
        public string PictureFolder { get { return "/content/gallery/" + GalleryID.ToString(); } }

    }
}