using System;

namespace MoneyManager.DTO
{
    public class TransactionDTO
    {
        public string AssetName { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
