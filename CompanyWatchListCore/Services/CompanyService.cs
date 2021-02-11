using CompanyWatchListCore.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CompanyWatchListCore.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseAddress;
        private readonly string _apiKey;
        public CompanyService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _baseAddress = config.GetSection("AlphaVantageBaseUrl").Value;
            _apiKey = config.GetSection("AlphaVantageApiKey").Value;
        }
        public async Task<IEnumerable<CompanySearchResultModel>> SearchCompanies(string keywords)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseAddress);
            var queryString = new Dictionary<string, string>()
            {
                { "function", "SYMBOL_SEARCH" },
                { "keywords", keywords },
                { "apikey", _apiKey },
                { "datatype", "json" }
            };
            var requestUri = QueryHelpers.AddQueryString(_baseAddress, queryString);
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri(requestUri));
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<CompanySearchResultModel>>(JObject.Parse(content).SelectToken("bestMatches").ToString());
            return result;
        }
    }
}
