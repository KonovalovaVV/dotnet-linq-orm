using System;

namespace DataAccess.DtoModels
{
    public class AssetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
