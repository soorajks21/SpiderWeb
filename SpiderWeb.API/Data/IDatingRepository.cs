using System.Collections.Generic;
using System.Threading.Tasks;
using SpiderWeb.API.Helpers;
using SpiderWeb.API.Models;

namespace SpiderWeb.API.Data
{
    public interface IDatingRepository
    {
         

         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T:class;

         Task<bool> SaveAll();

         Task<PageList<User>> GetUsers(UserParams UserParams);

         Task<User> GetUser(int id);

         Task<Photo> GetPhoto(int id);

         Task<Photo> GetMainPhotoForUser(int userId);
    }
}