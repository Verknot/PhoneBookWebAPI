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
            Logger logger = new Logger("C:\\С# Projects\\PhoneBook\\PhoneBookWebAPI\\PhoneBookWebApi.LoadUsers\\Logs.txt");

            Console.WriteLine("ConsoleUsers");
            Console.WriteLine("Введите количество пользователей ");
            
            string user = Console.ReadLine();
            logger.WriteMessage($"Загрузить {user}");

            //получаем данные
            string url = $"https://randomuser.me/api/?results={user}";
            var service = new WebUsersApiService(url);
            var users = await service.GetUsersAsync();
            logger.WriteMessage($"Получить {users}");
            Console.WriteLine($"Получено {users.Count()} пользователей");

            //сохраняем данные в БД
            var repository = new UserRepository();
            int result = await repository.SaveUsersAsync(users);
            logger.WriteMessage($"Успешно {user}");
            Console.WriteLine($"Сохранено {result/2} пользователей в БД");

            Console.ReadLine();
        }
    }
}
