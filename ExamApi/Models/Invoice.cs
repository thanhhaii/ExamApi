using System;
using System.Collections.Generic;

#nullable disable

namespace ExamApi.Models
{
    public partial class Invoice
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Payment { get; set; }
        public double? Total { get; set; }
        public DateTime? Created { get; set; }
        public bool? Status { get; set; }
    }
}
