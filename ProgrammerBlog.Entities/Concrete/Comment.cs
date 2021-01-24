using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Entities.Concrete
{
    public class Comment:EntityBase,IEntity //Yorum kısmının sahip olacağı özellikleri ekleyelim.
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; } //Bir yorumda bir makaleye sahip olmak zorundadır.
    }
}
