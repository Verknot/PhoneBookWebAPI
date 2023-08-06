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
            var result = new List<User>();
            Responce webUsers = null;

            try
            {
                // object? data = await _client.GetFromJsonAsync(_url, typeof(UserDTO));
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

            if (webUsers != null && webUsers.results.Count > 0)
            {
                foreach (var wc in webUsers.results)
                {

                    var user = new User
                    {
                        Name = new Name
                        {
                            Title = wc.name.title,
                            First = wc.name.first,
                            Last = wc.name.last
                        },
                        Birthday = new Birthday
                        {
                            Date = wc.dob.date,
                            age = wc.dob.age.ToString(),
                        },
                        email = wc.email,
                        PhoneNumber = wc.phone,
                      
                        Gender = wc.gender,
                        /*  Pictures = new Picture
                          {
                    //          Type = Enum.Parse(PictureType, wc.pictures.Type)
                          },*/

                    };
                    result.Add(user);
                }
            }

            return result;
        }
    }
}
