using Microsoft.Extensions.DependencyInjection;
using Order.Application.Interfaces;
using Order.Persistence.Context;
using Order.Persistence.Repositories;

namespace Order.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services)
    {
        services.AddDbContext<OrderContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
    }
}