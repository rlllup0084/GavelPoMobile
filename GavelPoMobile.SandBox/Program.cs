using GavelPoMobile.SandBox.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GavelPoMobile.SandBox; 
public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();

        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<GVLLOCALContext>(o => o.UseSqlServer(connString));
        builder.Services.AddScoped<GVLLOCALContextProcedures>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) {
            app.UseCors("AllowAll");
        }

        #region Api codes here...

        // GetOrdersById
        app.MapGet("api/order/{id}", async ([FromServicesAttribute] GVLLOCALContextProcedures db, int id) =>
        {
            var op = new OutputParameter<int>();
            return await db.GetOrderByIdAsync(id, op);
        });

        // GetOrderInfinite
        app.MapGet("api/order/infinite/{status}", async ([FromServicesAttribute] GVLLOCALContextProcedures db, int status, int page, int pageSize) => {
            return await db.GetOrdersInfiniteAsync(status, page, pageSize);
        });

        // GetOrdersPagination
        app.MapGet("api/order/paged/{status}", async ([FromServicesAttribute] GVLLOCALContextProcedures db, int status, int page, int pageSize) => {
            return await db.GetOrdersPaginationAsync(status, page, pageSize);
        });

        // GetOrders
        app.MapGet("api/order", async ([FromServicesAttribute] GVLLOCALContextProcedures db, int page, int pageSize) => {
            return await db.GetOrdersAsync(page, pageSize);
        });

        // GetPODetailsById

        // GetPOPastApprovals

        #endregion

        app.UseHttpsRedirection();
        app.Run();
    }
}