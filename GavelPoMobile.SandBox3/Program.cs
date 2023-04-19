using GavelPoMobile.SandBox3.Data;
using GavelPoMobile.SandBox3.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GavelPoMobile.SandBox3 {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<GVLLOCALContext>(o => o.UseSqlServer(connString));
            builder.Services.AddScoped<GVLLOCALContextProcedures>();

            builder.Services.AddCors(options => {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                );
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) {
                app.UseCors("AllowAll");
            }

            #region Endpoints here...

            // UpdatePurchaseOrderStatus
            app.MapPut("api/order/", async ([FromServices] GVLLOCALContextProcedures db, UpdatePurchaseOrderStatusRequest request) => {
                var result = await db.UpdatePurchaseOrderStatusAsync(request.Oid, request.Status, request.Remarks);
                return Results.Ok(result);
            });

            // UpdatePOLineStatus

            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}