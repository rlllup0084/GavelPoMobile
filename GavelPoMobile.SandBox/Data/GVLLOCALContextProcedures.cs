﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using GavelPoMobile.SandBox.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GavelPoMobile.SandBox.Data
{
    public partial class GVLLOCALContext
    {
        private IGVLLOCALContextProcedures _procedures;

        public virtual IGVLLOCALContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new GVLLOCALContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IGVLLOCALContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetOrderByIdResult>(entity =>
            {
                entity.HasNoKey()
                .ToView(null)
                .Property(o => o.Total).HasColumnType("money").HasPrecision(2);
            });


            modelBuilder.Entity<GetOrdersResult>(entity =>
            {
                entity.HasNoKey()
                .ToView(null)
                .Property(o => o.Total).HasColumnType("money").HasPrecision(2);
            });


            modelBuilder.Entity<GetOrdersInfiniteResult>(entity =>
            {
                entity.HasNoKey()
                .ToView(null)
                .Property(o => o.Total).HasColumnType("money").HasPrecision(2);
            });


            modelBuilder.Entity<GetOrdersPaginationResult>(entity =>
            {
                entity.HasNoKey()
                .ToView(null)
                .Property(o => o.Total).HasColumnType("money").HasPrecision(2);
            });


            modelBuilder.Entity<GetPODetailsByIdResult>(entity =>
            {
                entity.HasNoKey().ToView(null);

                entity.Property(o => o.Total)
                    .HasColumnType("money")
                    .HasPrecision(2);
                entity.Property(o => o.Quantity)
                    .HasColumnType("money")
                    .HasPrecision(2);
                entity.Property(o => o.Cost)
                    .HasColumnType("money")
                    .HasPrecision(2);
            });

            modelBuilder.Entity<GetPOPastApprovalsResult>(entity =>
            {
                entity.HasNoKey()
                .ToView(null)
                .Property(o => o.Total).HasColumnType("money").HasPrecision(2);
            });
        }
    }

    public partial class GVLLOCALContextProcedures : IGVLLOCALContextProcedures
    {
        private readonly GVLLOCALContext _context;

        public GVLLOCALContextProcedures(GVLLOCALContext context)
        {
            _context = context;
        }

        public virtual async Task<GetOrderByIdResult> GetOrderByIdAsync(int? orderId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    Value = orderId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };

            var orderResult = await _context.SqlQueryAsync<GetOrderByIdResult>("EXEC @returnValue = [dbo].[GetOrderById] @orderId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

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
                    Value = orderId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };

            var detailsResult = await _context.SqlQueryAsync<GetPODetailsByIdResult>("EXEC @returnValue = [dbo].[GetPODetailsById] @genJournalId", sqlParamGenJournalId, cancellationToken);

            var details = detailsResult.ToList();

            return new GetOrderByIdResult
            {
                OID = order.OID,
                ReferenceNo = order.ReferenceNo,
                Status = order.Status,
                Remarks = order.Remarks,
                Total = order.Total,
                VendorOID = order.VendorOID,
                SourceNo = order.SourceNo,
                EntryDate = order.EntryDate,
                VendorName = order.VendorName,
                Details = details.Select(d => new GetPODetailsByIdResult
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

        public virtual async Task<GetOrdersResponse> GetOrdersAsync(int? page, int? pageSize, CancellationToken cancellationToken = default)
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
            var results = await _context.SqlQueryAsync<GetOrdersResult>("EXEC @returnValue = [dbo].[GetOrders] @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
            var totalPages = (int)parametertotalPages.Value;

            return new GetOrdersResponse
            {
                Page = page ?? 0,
                PageSize = pageSize ?? 0,
                TotalPages = totalPages,
                Results = results,
            };
        }

        public virtual async Task<GetOrdersInfiniteResponse> GetOrdersInfiniteAsync(int? status, int? page, int? pageSize, CancellationToken cancellationToken = default)
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

            var results = await _context.SqlQueryAsync<GetOrdersInfiniteResult>("EXEC [dbo].[GetOrdersInfinite] @status, @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
            var totalPages = (int)parametertotalPages.Value;

            return new GetOrdersInfiniteResponse
            {
                Page = page ?? 0,
                PageSize = pageSize ?? 0,
                TotalPages = totalPages,
                Results = results,
            };
        }


        public virtual async Task<GetOrdersPaginationResponse> GetOrdersPaginationAsync(int? status, int? page, int? pageSize, CancellationToken cancellationToken = default)
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
                parameterreturnValue,
            };

            var results = await _context.SqlQueryAsync<GetOrdersPaginationResult>("EXEC @returnValue = [dbo].[GetOrdersPagination] @status, @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
            var totalPages = (int)parametertotalPages.Value;

            return new GetOrdersPaginationResponse
            {
                Page = page ?? 0,
                PageSize = pageSize ?? 0,
                TotalPages = totalPages,
                Results = results,
            };
        }

        public virtual async Task<List<GetPODetailsByIdResult>> GetPODetailsByIdAsync(int? genJournalId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    Value = genJournalId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetPODetailsByIdResult>("EXEC @returnValue = [dbo].[GetPODetailsById] @genJournalId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<GetPOPastApprovalsResponse> GetPOPastApprovalsAsync(int? page, int? pageSize, CancellationToken cancellationToken = default)
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
            var results = await _context.SqlQueryAsync<GetPOPastApprovalsResult>("EXEC @returnValue = [dbo].[GetPOPastApprovals] @page, @pageSize, @totalPages OUTPUT", sqlParameters, cancellationToken);
            var totalPages = (int)parametertotalPages.Value;

            return new GetPOPastApprovalsResponse
            {
                Page = page ?? 0,
                PageSize = pageSize ?? 0,
                TotalPages = totalPages,
                Results = results,
            };
        }
    }
}
