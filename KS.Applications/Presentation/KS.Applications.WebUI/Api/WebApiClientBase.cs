namespace KS.Applications.WebUI.Api
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using KS.Applications.Common;

    public abstract class WebApiClientBase
    {
        private readonly WebApiClientConfiguration _configuration;

        protected WebApiClientBase(WebApiClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The allocating method does not have dispose ownership; that is, the responsibility to dispose the object is transferred to another object or wrapper that's created in the method and returned to the caller")]
        protected virtual Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();
            if (!_configuration.GeneratedIdToken.IsNullOrEmpty())
            {
                msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.GeneratedIdToken);
            }

            return Task.Run(() => msg, cancellationToken);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The allocating method does not have dispose ownership; that is, the responsibility to dispose the object is transferred to another object or wrapper that's created in the method and returned to the caller")]
        protected virtual Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (m, ct, cn, e) => true,
            };

            return Task.Run(() => new HttpClient(handler), cancellationToken);
        }
    }
}
