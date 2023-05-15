using System;
using System.Collections.Generic;
using System.Text;

namespace WF.MetricaAndina.StatusDollar.Domain
{
    public class OnlineExchangeHouse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Rate Rates { get; set; } = new Rate();
    }
    public class Rate
    {
        public Buy Buy { get; set; } = new Buy();
        public Sale Sale { get; set; } = new Sale();
    }
    public class Buy : Costs
    {
    }
    public class Sale : Costs
    {
    }
    public class Costs
    {
        public decimal Cost { get; set; }
    }
}
