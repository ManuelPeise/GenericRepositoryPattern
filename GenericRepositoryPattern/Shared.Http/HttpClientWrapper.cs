using Newtonsoft.Json;
using Shared.Http.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Shared.Http
{
    public class HttpClientWrapper<T> : IHttpClientWrapper<T> where T : class, new()
    {
        private bool disposedValue;

        public HttpClientWrapper() { }

        public async Task<T?> GetAsync(string controller, List<string> parameters)
        {
            var urlExtension = string.Join("/", parameters);

            using (var client = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage
                {
                    Version = HttpVersion.Version20,
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(controller + urlExtension)
                };

                using (var response = await client.SendAsync(requestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        return await Task.FromResult(JsonConvert.DeserializeObject<T>(content));
                    }
                }
            }

            return default;
        }

        public async Task<bool> Post(string controller, string endpoint, T model)
        {
            var url = $"{controller}{endpoint}";

            using (var client = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage
                {
                    Version = HttpVersion.Version20,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = JsonContent.Create(model, typeof(T))
                };

                var response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(response.IsSuccessStatusCode);
                }
                else
                {
                    return false;
                }
            }
        }

        #region private menbers



        #endregion

        #region dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                // TODO: Große Felder auf NULL setzen
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
