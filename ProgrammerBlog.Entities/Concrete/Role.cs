using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Entities.Concrete
{
    public class Role:EntityBase,IEntity
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } //Bir Role birden fazla kullanıcıya sahip olabilir.Fakat bir kullanıcı sadece bi role e sahip olabilir.

    }
}
