using DotNet8.PersonalityTestCard.Api.Repositories.Blog;
using DotNet8.PersonalityTestCard.Api.Repositories.Card;

namespace DotNet8.PersonalityTestCard.Api
{
	public static class ModularService
	{

		public static IServiceCollection AddService(this IServiceCollection services, WebApplicationBuilder builder)
		{
	
		}

		private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<ICardRepository, CardRepository>();
			return services;
		}

	}
}
