﻿using DotNet8.PersonalityTestCard.Api.Repositories.Blog;
using DotNet8.PersonalityTestCard.Api.Repositories.Card;
using DotNet8.PersonalityTestCard.DbService.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.PersonalityTestCard.Api
{
	public static class ModularService
	{

		public static IServiceCollection AddService(this IServiceCollection services, WebApplicationBuilder builder)
		{
			services.AddRepositoryServices()
			.AddDbContextService(builder)
			.AddMediatRService()
			.AddJsonServices();

			return services;
		}

		private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<ICardRepository, CardRepository>();
			return services;
		}

		private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
			}, ServiceLifetime.Transient);

			return services;
		}

		private static IServiceCollection AddMediatRService(this IServiceCollection services)
		{
			services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
			return services;
		}

		private static IServiceCollection AddJsonServices(this IServiceCollection services)
		{
			services.AddControllers().AddJsonOptions(opt =>
			{
				opt.JsonSerializerOptions.PropertyNamingPolicy = null;
			});

			return services;
		}
	}
}
