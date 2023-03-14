using Microsoft.Extensions.Options;

namespace Assessment.XT.GLobal
{
    public class HeaderHandler : HttpClientHandler
    {
        private readonly IOptions<APIConfiguration> _config;
        public HeaderHandler(IOptions<APIConfiguration> config)
        {
            this._config = config;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-RapidAPI-Key", _config.Value.APIKey);
            request.Headers.Add("X-RapidAPI-Host", _config.Value.APIHost);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
