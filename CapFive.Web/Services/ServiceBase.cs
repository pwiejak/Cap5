using System.Diagnostics;
using System.Net.Http.Json;

namespace CapFive.Web.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient _httpClient;

        public ServiceBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> GetSingleResource<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);

            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }

        protected async Task<IEnumerable<T>> GetResources<T>(string url)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<T>>(url);
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }

        protected async Task<T> SaveResource<T>(T resource, string url)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(url, resource);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }

        protected async Task<T> PostResource<T>(T? resource, string url)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, resource);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }

        protected async Task<TResult> Post<TBody, TResult>(TBody body, string url)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<TBody>(url, body);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TResult>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            catch (Exception e)
            {
                Debugger.Log(1, "exception", e.Message);
                throw;
            }
        }
    }
}
