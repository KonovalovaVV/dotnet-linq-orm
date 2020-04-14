using System;

namespace DataAccess.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
