using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Shared.Data.Abstract 
{
    
      public interface IEntityRepository<T> where T:class,IEntity,new() //ekleyeceğimiz tüm methodlar assenkrondur.Bu sebeple Task ile başlıyoruz.
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[]includeProperties); //var kullanici = repository.GetAsync(k=>k.Id==15); Get methodu çağırma olarak düşünelim.Örneğin bana bir makale getir veya kullanıcı getir dediğimizde; hangi makale veya hangi kullanıcıyı getireceğini söylemek için Expression,derdimizi anlattığımız bölüm ise predicate hangi kullanıcıyı istiyosak onu yazdığımız kısımdır.Bir makaleyi hangi kullanıcı yazdı bunu öğrenmek istiyorsak;tekrar bir expression ekleyip T object ekleriz,bu array olmalıdır çünkü makalenin yorumlarınıda yüklemek isteriz ve bunun yanında kullanıcıyıda yüklemek isteyebiliriz
           
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties); //2 veya daha fazla entity yani bir liste ihtiyacımız olursa.Predicate null verilir çünkü  makalelerin hepsinide yüklemek isteyebiliriz sadece c# kategorisine ait makaleleride yüklemek isteyebilirz.Predicate değeri null gelirse bizler tüm kategorileri,kullanıcıları,makaleleri vs yükleriz.Eğer null gelmezse bizlere gelen filtreye göre bunları ekliyor olacağız.
        Task AddAsync(T entity); //Kategori eklemek için Add metodu
        Task UpdateAsync(T entity); //Kullanıcı güncellemek için Update metodu
        Task DeleteAsync(T entity); //Yorum silmek için delete metodu
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Böyle birşey varmı sorusu için Any methodu kullandık.Örneğin Zeynep isimli bir kullanıcı varmı? var result = _userRepository.AnyAsync(u=>u.FirsName=="Zeynep");
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        

        
    }
} 
