﻿using DotNet8.PersonalityTestCard.Api.Repositories.Element;

namespace DotNet8.PersonalityTestCard.Api;

public static class ModularService
{

	#region AddService

	public static IServiceCollection AddService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddRepositoryServices()
		.AddDbContextService(builder)
		.AddMediatRService()
		.AddJsonServices();

		return services;
	}

	#endregion

	#region AddRepositoryServices

	private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
	{
		services
			.AddScoped<ICardRepository, CardRepository>()
			.AddScoped<IElementRepository, ElementRepository>();

		return services;
	}

	#endregion

	#region AddDbContextService

	private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<AppDbContext>(opt =>
		{
			opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
		}, ServiceLifetime.Transient);

		return services;
	}

	#endregion

	#region AddMediatRService

	private static IServiceCollection AddMediatRService(this IServiceCollection services)
	{
		services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
		return services;
	}

	#endregion

	#region AddJsonServices

	private static IServiceCollection AddJsonServices(this IServiceCollection services)
	{
		services.AddControllers().AddJsonOptions(opt =>
		{
			opt.JsonSerializerOptions.PropertyNamingPolicy = null;
		});

		return services;
	}

	#endregion
}
