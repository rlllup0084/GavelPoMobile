﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GavelPoMobile.SandBox.Models
{
    public partial class GetOrdersResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<GetOrdersResult> Results { get; set; }
    }
}
