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
            var tp = new OutputParameter<int?>();
            var rv = new OutputParameter<int>();
            return await db.GetOrdersInfiniteAsync(status, page, pageSize, tp, rv);
        });

        // GetOrdersPagination

        // GetOrders

        // GetPODetailsById

        // GetPOPastApprovals

        #endregion

        app.UseHttpsRedirection();
        app.Run();
    }
}