using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOS_DreamDictionary_WebAPI.Services
{
    public class DreamDictionary
    {
        public Blogheader[] BlogHeader { get; set; }
        public BlogDetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
    }

    public class BlogDetail
    {
        [Key]
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string? BlogContent { get; set; }
    }
}
