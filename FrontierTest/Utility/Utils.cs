using FrontierTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FrontierTest.Utility
{
    public class Utils
    {
        // url will be in setting file
        readonly string url = "https://frontiercodingtests.azurewebsites.net/";

        public async Task<Tuple<bool, string, List<AccountModel>>> GetFrontierData()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync("api/accounts/getall");
                var sAccounts = await response.Content.ReadAsStringAsync();

                var Accounts = JsonConvert.DeserializeObject<List<AccountModel>>(sAccounts);
                return new Tuple<bool, string, List<AccountModel>>(false, "success,", Accounts);

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string, List<AccountModel>>(true, "failed:" + ex.Message, new List<AccountModel>());
            }


        }


    }
}