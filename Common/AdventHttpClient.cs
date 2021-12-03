using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    public static class AdventHttpClient
    {
        private static readonly string personalCookie = "_ga=GA1.2.1588363362.1638359760; _gid=GA1.2.1593312382.1638455511; " +
                                "session=53616c7465645f5f7c287a765bc34d08aae3c4d3699da7857f0cc64e25ee9cbe7b8f399788e5a906828a6c4d0de2dbf6";

        private static readonly HttpClient Client = new HttpClient();

        public static async Task<string> getInputDataFromUrl(string url)
        {
            Client.DefaultRequestHeaders.Add("cookie", personalCookie);
            return await Client.GetStringAsync(url);
        }
    }
}