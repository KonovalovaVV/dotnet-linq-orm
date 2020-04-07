using System;

namespace MoneyManager.DTO
{
    public class AssetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
