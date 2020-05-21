using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerrankChallenges.ChallengesSolutions
{
    public class TransactionStatements
    {
        private static HttpClient Client = new HttpClient();

        public static async Task<List<List<int>>> totalTransactions(int locationId, string transactionType)
        {
            var results = new List<List<int>>();

            var responses = await GetAllPagesFromResponse(transactionType);
            
            var userAndAmounts = responses
                .Where(r => r.Location.Id == locationId)
                .GroupBy(r => r.UserId)
                .Select(r => new UserAndAmount() { UserId = r.Key, Amount = r.Sum(s => ConvertAmountStringToFloat(s.Amount)) })
                .OrderBy(e => e.UserId)
                .ToList();

            if (userAndAmounts.Count == 0)
            {
                results.Add(new List<int>() { -1, -1 });
                return results;
            }

            userAndAmounts.ForEach(ua => 
            {
                var list = new List<int>();
                list.Add(ua.UserId);
                list.Add(ConvertAmountFloatToInt(ua.Amount));

                results.Add(list);
            });
            
            return results;
        }

        private static int ConvertAmountFloatToInt(float amount) 
        {
            return (int)Math.Floor(amount);
        }

        private static float ConvertAmountStringToFloat(string amount) 
        {
            var justNumber = amount.Substring(1).Replace(",", "");
            return float.Parse(justNumber);
        }

        private static async Task<List<TransactionDTO>> GetAllPagesFromResponse(string transactionType)
        {
            var responses = new List<TransactionDTO>();
            var response = await GetResponse(transactionType, page: 1);
            var totalPages = response.total_pages;
            responses.AddRange(response.Data);

            if (response == null)
                return null;

            for (int page = 2; page <= totalPages; page++)
            {
                response = null;
                response = await GetResponse(transactionType, page);
                responses.AddRange(response.Data);
            }

            return responses;
        }

        private static async Task<ResponseDTO> GetResponse(string transactionType, int page)
        {
            try
            {
                var url = string.Format("https://jsonmock.hackerrank.com/api/transactions/search?txnType={0}&page={1}", transactionType, page);

                var response = await Client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                var contentString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseDTO>(contentString);

            } catch (Exception)
            {
                return null;
            }
        }
    }

    public class UserAndAmount
    {
        public int UserId { get; set; }
        public float Amount { get; set; }
    }

    public class ResponseDTO
    {
        public string Page { get; set; }

        public int total_pages { get; set; }

        public Collection<TransactionDTO> Data { get; set; }
    }

    public class TransactionDTO
    {
        public int UserId { get; set; }
        public string Amount { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
    }
}
