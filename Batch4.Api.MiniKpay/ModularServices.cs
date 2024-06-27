using System.Data;
using System.Data.SqlClient;
using Batch4.Api.MiniKpay.Features.TransactionHistory;
using Batch4.Api.MiniKpay.Features.Transfer;

namespace Batch4.Api.MiniKpay;

public static class ModularServices
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services.AddDataAccess();
        services.AddBusinessLogic();
        services.AddDbConnection(builder);
        return services;
    }

    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<DA_Transfar>();
        services.AddScoped<DA_TransactionHistory>();
        return services;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<BL_Transfar>();
        services.AddScoped<BL_TransactionHistory>();
        return services;
    }

    public static IServiceCollection AddDbConnection(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
        services.AddScoped<IDbConnection>(n => new SqlConnection(connectionString));
        return services;
    }
}
