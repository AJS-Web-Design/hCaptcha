using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AJSWebDesign.HCaptcha
{
    public class HCaptchaApi : IHCaptchaApi
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public async Task<HCaptchaVerifyResponse> Verify(string secret, string token, string remoteIp)
        {
            // create post data
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("secret", secret),
                new KeyValuePair<string, string>("response", token),
                new KeyValuePair<string, string>("remoteip", remoteIp)
            };

            // request api
            HttpResponseMessage response = await HttpClient.PostAsync(
                // hCaptcha wants URL-encoded POST
                "https://hcaptcha.com/siteverify", new FormUrlEncodedContent(postData));

            response.EnsureSuccessStatusCode();

            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            return JsonConvert.DeserializeObject<HCaptchaVerifyResponse>(jsonString.Result);
        }
    }
}
