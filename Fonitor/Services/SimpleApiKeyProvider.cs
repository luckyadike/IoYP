namespace Fonitor.Services
{
	public class SimpleAPIKeyProvider : IAPIKeyProvider
	{
		private const string APIKey = "iL0UCJtAwwq8nVjvUJoVkM9CjFhyycLp";

		public string GetAPIKey()
		{
			return APIKey;
		}
	}
}