using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF.MetricaAndina.StatusDollar.Application.Dtos;
using WF.MetricaAndina.StatusDollar.Application.UseCases;
using WF.MetricaAndina.StatusDollar.Domain;
using WF.MetricaAndina.StatusDollar.Infrastructure.Repositories;

namespace WF.MetricaAndina.StatusDollar
{
    public partial class Form1 : Form
    {
        private DataGridView dgv;
        private GetOnlineExchangeHouses _getOnlineExchangeHouses = new GetOnlineExchangeHouses();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv = new DataGridView();
            StyleDataGriedView(dgv);
            this.Controls.Add(dgv);
            Refresh();
        }
        private async void Refresh()
        {
            List<OnlineExchangeHouseDto> exchangeHouseListDto = await _getOnlineExchangeHouses.GetExchangeRateCurrently();

            dgv.DataSource = exchangeHouseListDto;
        }
        private void StyleDataGriedView(DataGridView dgv)
        {
            dgv.Location = new Point(90, 110);
            dgv.Width = 500;
            dgv.Height = 400;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<OnlineExchangeHouseDto> exchangeHouseListDto = new List<OnlineExchangeHouseDto>();
            OnlineExchangeHouseDto savedExchangeHouse = new OnlineExchangeHouseDto();
            savedExchangeHouse.Titulo = nameExchangeHouse.Text;
            savedExchangeHouse.TipoCompra = Convert.ToDecimal(buyExchangeType.Text);
            savedExchangeHouse.TipoVenta = Convert.ToDecimal(saleExchangeType.Text);

            exchangeHouseListDto = await _getOnlineExchangeHouses.SaveExchangeHouse(savedExchangeHouse);

            dgv.DataSource = exchangeHouseListDto;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buyExchangeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled= true;
        }

        private void saleExchangeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
