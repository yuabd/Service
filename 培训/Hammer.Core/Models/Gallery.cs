using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; /*for validiation*/

namespace Hammer.Core.Models
{
    public class Gallery
    {
        public int GalleryID { get; set; } /*primary key: "gallery" - class name*/
        [Required (ErrorMessage = "Required")]
        [MaxLength(50)]
        public string GalleryName { get; set; }
        [MaxLength(400, ErrorMessage="too large")]
        public string GalleryDescription { get; set; }
        [Required(ErrorMessage = "Required")]
        public int SortOrder { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateTaken { get; set; }
        public bool IsPublic { get; set; }

        //SEO

        [MaxLength(70, ErrorMessage="too large")]
        public string PageTitle { get; set; }
        [MaxLength(150, ErrorMessage="too large")]
        public string MetaDescription { get; set; }
        [MaxLength(100, ErrorMessage="too large")]
        public string MetaKeywords { get; set; }
        [MaxLength(60, ErrorMessage="too large")]
        public string Slug { get; set; }

        //  Navigation

        public virtual ICollection<GalleryDetail> GalleryDetails { get; set; }

        //  Extended

        [NotMapped]
        public string PictureFolder { get { return "/content/gallery/" + GalleryID.ToString(); } }
        [NotMapped]
        public string PictureFile { get { return Hammer.Core.Helpers.LabelHelper.GetGalleryPhoto(GalleryID); } }

    }           
}