using System;
using System.Collections.Generic;
using System.Text;

namespace WF.MetricaAndina.StatusDollar.Application.Dtos
{
    public class OnlineExchangeHouseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal TipoCompra { get; set; }
        public decimal TipoVenta { get; set; }
    }
}
