using MoneyManager.DTO;
using System;

namespace MoneyManager.Mappers
{
    public class TotalMapper
    {
        public static TotalDTO MapTotalDTO(decimal incomeValue, decimal expenceValue, DateTime date)
        {
            return new TotalDTO
            {
                TotalExpence = expenceValue,
                TotalIncome = incomeValue,
                Month = date.Month,
                Year = date.Year
            };
        }
    }
}
