using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Shared.Entities.Abstract
{
   public abstract class EntityBase //Verdiğimiz temel değerlerin diğer sınıflarda değişikliğe uğramasını isteyebilirz.Bu sebeple abstract olarak atandı.
    {
        public virtual int Id { get; set; } //Entitiylerin id ye ihtiyacı var
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; //override edilmesini istiyosak virtual yaparız
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false; //Birşey oluşturduğumuzda silindimi sorusuna hayır cevabını verecek
        public virtual bool IsActive { get; set; } = true; //İlk entity oluşturulduğunda active olacak.Herhangi bir entity içinde false olarak çekilebilir.Bu makale veya bu kullanıcı aktifmi değilmi sorusuna evet cevabını verecek.
        public virtual string CreatedByName { get; set; } = "Admin"; //Bizim blogumuzda bir kayıt ol kısmı olmayacağından string olarak belirledik.Yorum yapma durumundan ötürüdür.Kullanıcı birşeyi beğendiyse hemen yorum atabilmeli.Bu sebeple string olarak atadık.herhangi bir nesne oluşturulduğunda Createdbyname veya ModifiedByName kısımları Admin olarak gelsin
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; } //Entitylerle ilgili Admin panelinde not tutmak istiyebiliriz.Bir kullanıcı,yorum,makale ile ilgilide olabilir.
    }
}
