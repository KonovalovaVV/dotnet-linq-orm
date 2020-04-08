using DataAccess.DtoModels;
using System;

namespace DataAccess.Mappers
{
    public class TotalMapper
    {
        public static TotalDto MapToTotalDto(decimal incomeValue, decimal expenceValue, DateTime date)
        {
            return new TotalDto
            {
                TotalExpence = expenceValue,
                TotalIncome = incomeValue,
                Month = date.Month,
                Year = date.Year
            };
        }
    }
}
