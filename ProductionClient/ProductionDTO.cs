using System;

namespace ProductionClient
{
    internal class ProductionDTO
    {
        public int ResultId { get; set; }
        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
