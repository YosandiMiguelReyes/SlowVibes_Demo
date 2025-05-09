

using System;
using System.Windows.Forms;
using SlowVibesDemo.Data.DTO.Core;

namespace SlowVibesDemo.Data.DTO.entities
{
    public class SalesHistory : Base
    {
        public DateTime SaleDate {  get; set; }
        public int Profit { get; set; }
        public int ReinvestmentAmount { get; set; }
    }
}
