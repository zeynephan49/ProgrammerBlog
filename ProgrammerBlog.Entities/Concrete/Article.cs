using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Entities.Concrete
{
    public class Article:EntityBase,IEntity //Bir makalede olması gereken içerikleri sınıfımıza ekleyelim.
    {
        public string  Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; } //küçük resim 
        public DateTime Date { get; set; } //Makalenin oluşturulma tarihi olacaktır.Kullanıcının veya adminin kendi oluştururken girdiği bir tarih olacaktır.CreatedDateden farklı olarak.(paylaşıldığı Tarih)
        public int ViewsCount { get; set; } //Makalenin okunma ve yorum sayısını tutmak içindir.
        public int CommentCount { get; set; } //Kaç kez okunduğunu veya kaç kez yorum yapıldığını kullanıcıya göstermek içindir.
        public string SeoAuthor { get; set; } //Makaleyi kim yazdıysa meta tekniklerini ekleyeceğimiz bölüm
        public string SeoDescription { get; set; } //Makaleyi meta tagleriyle ggogle,yahoo gibi sitelere bildiriyor olacağız.
        public string  SeoTags { get; set; } //Etiketleri header kısmına gömüyor olacağız.
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } //Bir makalenin bir kategorisi olabilir demiş olduk burda.Ve bir makaleyi paylaşan bir tane user olmalı dedik.
        public ICollection<Comment> Comments { get; set; } //Bir makale birden fazla yoruma sahip olabilir. 
    }
}
