
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhoneBookWebAPI.DAL;
using PhoneBookWebAPI.Domain.Entity;
using PhoneBookWebAPI.Domain.Responce;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.LoadUsers.Service
{
    public class WebUsersApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _url;

        public WebUsersApiService(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(nameof(url));
            }
            
            _url = url;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {

            Responce webUsers = null;

            try
            {
                using (var response = await _client.GetAsync(_url))
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    webUsers = await JsonSerializer.DeserializeAsync<Responce>(stream);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            return webUsers.resultst;
         }

     }
}
