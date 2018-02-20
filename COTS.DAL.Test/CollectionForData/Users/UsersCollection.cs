using COTS.DAL.Entities;
using COTS.DAL.Test.CollectionForData.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COTS.DAL.Test.CollectionForData.Users
{
    public static class UsersCollection
    {
        public static List<User> Get()
        {
            var roles = UserRolesCollection.Get();
            var cinemas = CinemasCollection.Get();
            return new List<User>()
            {
                new User("admin", "admin", null, roles[0].Id, new UserDetails("Админ", "Админов", "Мега Админ")),
                
                //mpx_skaymall
                new User("JaySkyMall_A", "adminQWERTY", cinemas[0].Id, roles[0].Id, new UserDetails("Иван", "Марданов", "Типо Директор :)")),
                new User("JaySkyMall_W", "workerQWERTY", cinemas[0].Id, roles[1].Id, new UserDetails("Марьяна", "Марданова", "Сотрудник зала и жена директора")),

                //florence
                new User("JayFlorence_A", "adminQWERTY", cinemas[3].Id, roles[0].Id, new UserDetails("Алексей", "Лексев", "Генеральный менеджер")),
                new User("JayFlorence_W", "workerQWERTY", cinemas[3].Id, roles[1].Id, new UserDetails("Степан", "Грицко", "Cантехник кинотеатра")),
            };
        }
    }
}
