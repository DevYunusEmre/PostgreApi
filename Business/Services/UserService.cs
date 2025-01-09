using Business.Entities;
using Marten;
using Marten.Internal.Sessions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService
    {
        private readonly IDocumentSession _session;

        public UserService(IDocumentSession session)
        {
            _session = session;
        }

        public string AddUser(User user)
        {
            _session.Store(user);
            _session.SaveChanges();
             
            if (_session.Query<User>().FirstOrDefault(x => x.Id == user.Id) is not null)
                return "Kullanıcı başarıyla eklendi.";
            return "Kullanıcı eklenirken bir hata oluştu.";

        }

        public string GetUser(int userId)
        {

            var user = _session.Query<User>().FirstOrDefault(x => x.Id == userId);
            if (user == null) return "Kullanıcı bulunamadı.";

            return JsonConvert.SerializeObject(user);
        }


        public string DeleteUserById(int userId)
        {
            User user = _session.Query<User>().FirstOrDefault(x => x.Id == userId);

            if (user == null) return "Kullanıcı bulunamadı";

            _session.Delete(user);
            _session.SaveChanges();
            return $"Id'si {userId} olan kullanıcı başarıyla silindi.";
        }


        public List<User> GetAllUsers()
        {
            List<User> users = _session.Query<User>().ToList();
            return users;
        }





    }
}
