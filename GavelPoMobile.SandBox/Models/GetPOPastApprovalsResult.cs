﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GavelPoMobile.SandBox.Models
{
    public partial class GetPOPastApprovalsResult
    {
        public int OID { get; set; }
        public string SourceNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Vendor { get; set; }
        public string ReferenceNo { get; set; }
        public int? Status { get; set; }
        public string Remarks { get; set; }
        public decimal? Total { get; set; }
        public string AfterReopenAlterations { get; set; }
        public bool? IsReopened { get; set; }
    }
}
