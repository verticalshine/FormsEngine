using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FormsClient.Models;

namespace FormsClient.Services
{
    public class FormService
    {

        readonly string uri = "http://localhost:57617/api/Form/2";

        public async Task<FormDataInDto> GetFormAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<FormDataInDto>(
                    await httpClient.GetStringAsync(uri)
                );
            }
        }
    }
}
