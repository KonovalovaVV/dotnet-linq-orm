using System;

namespace DataAccess.DtoModels
{
    public class TransactionDto
    {
        public Guid CategoryId { get; set; }
        public Guid AssetId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
