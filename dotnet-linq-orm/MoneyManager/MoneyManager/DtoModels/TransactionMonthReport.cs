namespace DataAccess.DtoModels
{
    public class TransactionMonthReport
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
    }
}
