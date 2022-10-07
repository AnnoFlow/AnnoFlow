using AnnoFlow.Core.Persistence;
using AnnoFlow.Infrastructure.Persistence.InMemory;

namespace AnnoFlow.Api.Extensions.DependencyInjection
{
    public static class AnnoFlowServiceCollectionExtensions
    {
        public static IServiceCollection AddAnnoFlow(this IServiceCollection services)
        {
            services.AddAnnoFlowPersistence();

            return services;
        }

        private static IServiceCollection AddAnnoFlowPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IDatasetsRepository, InMemoryDatasetsRepository>();

            return services;
        }
    }
}