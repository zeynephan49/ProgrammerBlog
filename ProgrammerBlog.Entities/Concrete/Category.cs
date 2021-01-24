using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProgrammerBlog.Entities.Concrete
{
   public class Category:EntityBase,IEntity
    {
        public  string Name { get; set; } //Bu kategorinin bir ismi ve açıklaması olmalıdır.
        public string Description { get; set; }
        public ICollection<Article> Articles{ get; set; } //Article yerine post ta yazılabilir.
    }
}
