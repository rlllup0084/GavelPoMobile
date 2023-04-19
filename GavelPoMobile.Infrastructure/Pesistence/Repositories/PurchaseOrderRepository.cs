using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.Common.Models;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Aggregates.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GavelPoMobile.Infrastructure.Pesistence.Repositories;
public class PurchaseOrderRepository : IPurchaseOrderRepository
{

    private readonly GavelPoMobileDbContext _dbContext;

    public PurchaseOrderRepository(GavelPoMobileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PurchaseOrder> GetPurchaseOrderById(int? Id, CancellationToken cancellationToken = default)
    {
        var parameterreturnValue = new SqlParameter
        {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "orderId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };

        var orderResult = await _dbContext.SqlQueryAsync<PurchaseOrder>("EXEC @returnValue = [dbo].[GetOrderById] @orderId", sqlParameters, cancellationToken);

        var order = orderResult.Select(r => r).FirstOrDefault();

        if (order == null)
        {
            return null;
        }

        var sqlParamGenJournalId = new[]
        {
                new SqlParameter
                {
                    ParameterName = "genJournalId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };

        var detailsResult = await _dbContext.SqlQueryAsync<PurchaseOrderDetail>("EXEC @returnValue = [dbo].[GetPODetailsById] @genJournalId", sqlParamGenJournalId, cancellationToken);

        var details = detailsResult.ToList();

        return new PurchaseOrder
        {
            OID = order.OID,
            ReferenceNo = order.ReferenceNo,
            Status = order.Status,
            Remarks = order.Remarks,
            Total = order.Total,
            SourceNo = order.SourceNo,
            EntryDate = order.EntryDate,
            Vendor = order.Vendor,
            PurchaseOrderDetails = details.Select(d => new PurchaseOrderDetail
            {
                OID = d.OID,
                SourceNo = d.SourceNo,
                GenJournalID = d.GenJournalID,
                Description = d.Description,
                Quantity = d.Quantity,
                UOM = d.UOM,
                Cost = d.Cost,
                CostCenter = d.CostCenter,
                RequestedBy = d.RequestedBy,
                Total = d.Total,
                LineApprovalStatus = d.LineApprovalStatus,
                Remarks = d.Remarks
            }).ToList()
        };
    }

    public async Task<PagedPurchaseOrders> GetAllPurchaseOrders(int? page, int? pageSize, CancellationToken cancellationToken = default)
    {
        var parametertotalPages = new SqlParameter
        {
            ParameterName = "totalPages",
            Direction = System.Data.ParameterDirection.InputOutput,
            Value = 0,
            SqlDbType = System.Data.SqlDbType.Int,
        };
        var parameterreturnValue = new SqlParameter
        {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "page",
                    Value = page ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "pageSize",
                    Value = pageSize ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
            parametertotalPages,
            parameterreturnValue,
        };
        var results = await _dbContext.SqlQueryAsync<PurchaseOrder>("EXEC @returnValue = [dbo].[GetOrders] @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
        var totalPages = (int)parametertotalPages.Value;

        return new PagedPurchaseOrders(page ?? 0, pageSize ?? 0, totalPages, results);
    }

    public async Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetailsById(int? purchaseOrderId, CancellationToken cancellationToken = default)
    {
        var parameterreturnValue = new SqlParameter
        {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "genJournalId",
                    Value = purchaseOrderId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
        var results = await _dbContext.SqlQueryAsync<PurchaseOrderDetail>("EXEC @returnValue = [dbo].[GetPODetailsById] @genJournalId", sqlParameters, cancellationToken);


        return results;
    }

    public async Task<PagedPurchaseOrders> GetPurchaseOrdersByStatus(int? status, int? page, int? pageSize, CancellationToken cancellationToken = default)
    {
        var parametertotalPages = new SqlParameter
        {
            ParameterName = "totalPages",
            Direction = System.Data.ParameterDirection.InputOutput,
            Value = 0,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "status",
                    Value = status ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "page",
                    Value = page ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "pageSize",
                    Value = pageSize ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parametertotalPages,
            };

        var results = await _dbContext.SqlQueryAsync<PurchaseOrder>("EXEC [dbo].[GetOrdersInfinite] @status, @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
        var totalPages = (int)parametertotalPages.Value;

        return new PagedPurchaseOrders(page ?? 0, pageSize ?? 0, totalPages, results);
    }

    public async Task<PurchaseOrder> UpdatePurchaseOrderStatus(int? Id, int? Status, string Remarks, CancellationToken cancellationToken = default) {
        var parameterreturnValue = new SqlParameter {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "Oid",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Status",
                    Value = Status ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Remarks",
                    Size = 1000,
                    Value = Remarks ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };

        await _dbContext.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdatePurchaseOrderStatus] @Oid, @Status, @Remarks", sqlParameters, cancellationToken);

        var parameterreturnValue2 = new SqlParameter {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters2 = new[]
        {
                new SqlParameter
                {
                    ParameterName = "orderId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue2,
            };

        var orderResult = await _dbContext.SqlQueryAsync<PurchaseOrder>("EXEC @returnValue = [dbo].[GetOrderById] @orderId", sqlParameters2, cancellationToken);

        var order = orderResult.Select(r => r).FirstOrDefault();

        if (order == null) {
            return null;
        }

        var sqlParamGenJournalId = new[]
        {
                new SqlParameter
                {
                    ParameterName = "genJournalId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };

        var detailsResult = await _dbContext.SqlQueryAsync<PurchaseOrderDetail>("EXEC @returnValue = [dbo].[GetPODetailsById] @genJournalId", sqlParamGenJournalId, cancellationToken);

        var details = detailsResult.ToList();

        return new PurchaseOrder {
            OID = order.OID,
            ReferenceNo = order.ReferenceNo,
            Status = order.Status,
            Remarks = order.Remarks,
            Total = order.Total,
            SourceNo = order.SourceNo,
            EntryDate = order.EntryDate,
            Vendor = order.Vendor,
            PurchaseOrderDetails = details.Select(d => new PurchaseOrderDetail {
                OID = d.OID,
                SourceNo = d.SourceNo,
                GenJournalID = d.GenJournalID,
                Description = d.Description,
                Quantity = d.Quantity,
                UOM = d.UOM,
                Cost = d.Cost,
                CostCenter = d.CostCenter,
                RequestedBy = d.RequestedBy,
                Total = d.Total,
                LineApprovalStatus = d.LineApprovalStatus,
                Remarks = d.Remarks
            }).ToList()
        };
    }

    public async Task<PurchaseOrderDetail> GetPurchaseOrderDetailByLineId(int? Id, CancellationToken cancellationToken = default) {
        var parameterreturnValue = new SqlParameter {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "LineId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
        var detailResult = await _dbContext.SqlQueryAsync<PurchaseOrderDetail>("EXEC @returnValue = [dbo].[GetPODetailsByLineId] @LineId", sqlParameters, cancellationToken);

        return detailResult.FirstOrDefault();
    }

    public async Task<PurchaseOrderDetail> UpdatePurchaseOrderDetailStatus(int? Id, int? Status, string? Remarks, CancellationToken cancellationToken = default) {
        var parameterreturnValue = new SqlParameter {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters = new[]
        {
                new SqlParameter
                {
                    ParameterName = "Oid",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Status",
                    Value = Status ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Remarks",
                    Size = 200,
                    Value = Remarks ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };

        await _dbContext.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdatePOLineStatus] @Oid, @Status, @Remarks", sqlParameters, cancellationToken);

        var parameterreturnValue2 = new SqlParameter {
            ParameterName = "returnValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int,
        };

        var sqlParameters2 = new[]
        {
                new SqlParameter
                {
                    ParameterName = "LineId",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue2,
            };
        var detailResult = await _dbContext.SqlQueryAsync<PurchaseOrderDetail>("EXEC @returnValue = [dbo].[GetPODetailsByLineId] @LineId", sqlParameters2, cancellationToken);

        return detailResult.FirstOrDefault();
    }
}
