using Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace Order.Application;

public static class ServiceRegistiration
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<GetAddressQueryHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<RemoveAddressCommandHandler>();

        services.AddScoped<GetOrderDetailQueryHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<RemoveOrderDetailCommandHandler>();
        services.AddMediatR(typeof(ServiceRegistiration).Assembly);
    }
}
