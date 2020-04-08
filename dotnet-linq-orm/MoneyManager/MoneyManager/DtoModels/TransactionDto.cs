using System;

namespace DataAccess.DtoModels
{
    public class TransactionDto
    {
        public string AssetName { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
