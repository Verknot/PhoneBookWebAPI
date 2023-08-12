using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBookWebAPI.DAL;
using PhoneBookWebAPI.DAL.Interfaces;
using PhoneBookWebAPI.DAL.Repository;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.LoadUsers.Repository;
using PhoneBookWebAPI.LoadUsers.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers
{
    public  class Program
    {
        private readonly LoadRepository _loadRepository;


       public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDataContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
              //  .LogTo(System.Console.WriteLine)
                .Options;

            var context = new AppDataContext(options);

            Console.WriteLine("ConsoleUsers");
            Console.WriteLine("Введите количество пользователей ");
            
            string user = Console.ReadLine();

            //получаем данные
            string url = $"https://randomuser.me/api/?results={user}";
            var service = new WebUsersApiService(url);
            var users = await service.GetUsersAsync();
            Console.WriteLine($"Получено {users.Count()} пользователей");

            //сохраняем данные в БД
             var repository = new LoadRepository(context);

            int result = await repository.SaveUsersAsync(users);
            Console.WriteLine($"Сохранено {result/2} пользователей в БД");

            Console.ReadLine();
        }
    }
}
