namespace Fonitor.Handlers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Web;

	public class RequireHttpsMessageHandler : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
		{
			if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
			{
				var forbiddenResponse = request.CreateResponse(HttpStatusCode.Forbidden);
				forbiddenResponse.ReasonPhrase = "SSL Required";

				return Task.FromResult<HttpResponseMessage>(forbiddenResponse);
			}

			return base.SendAsync(request, cancellationToken);
		}
	}
}