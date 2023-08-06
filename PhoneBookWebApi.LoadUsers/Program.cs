using PhoneBookWebAPI.DAL.Repository;
using PhoneBookWebAPI.LoadUsers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ConsoleUsers");
            Console.WriteLine("Введите количество пользователей ");

            string user = Console.ReadLine();

            //получаем данные
            string url = $"https://randomuser.me/api/?results={user}";
            var service = new WebUsersApiService(url);
            var users = await service.GetUsersAsync();

            Console.WriteLine($"Получено {users.Count()} пользователей");

            //сохраняем данные в БД
            var repository = new UserRepository();
            int result = await repository.SaveUsersAsync(users);

            Console.WriteLine($"Сохранено {result.ToString()} пользователей в БД");

            Console.ReadLine();
        }
    }
}
