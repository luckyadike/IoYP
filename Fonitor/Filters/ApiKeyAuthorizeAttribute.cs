namespace Fonitor.Filters
{
	using Fonitor.Services;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http.Controllers;
	using System.Web.Http.Filters;

	public class APIKeyAuthorizeAttribute : ActionFilterAttribute
	{
		private const string APIKeyHeaderName = "Key";

		public override void OnActionExecuting(HttpActionContext filterContext)
		{
			// Get API key provider.
			var provider = filterContext.ControllerContext.Configuration
				.DependencyResolver.GetService(typeof(IAPIKeyProvider)) as IAPIKeyProvider;

			// Get key header data.
			IEnumerable<string> keys;
			filterContext.Request.Headers.TryGetValues(APIKeyHeaderName, out keys);

			// Check for key.
			if (keys == null || keys.FirstOrDefault() != provider.GetAPIKey())
			{
				filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			}

			base.OnActionExecuting(filterContext);
		}
	}
}