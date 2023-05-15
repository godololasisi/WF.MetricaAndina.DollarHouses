using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.MetricaAndina.StatusDollar.Application.Dtos;
using WF.MetricaAndina.StatusDollar.Domain;
using WF.MetricaAndina.StatusDollar.Infrastructure.Repositories;

namespace WF.MetricaAndina.StatusDollar.Application.UseCases
{
    public class GetOnlineExchangeHouses
    {
        private OnlineExchangeHouseRepository _onlineExchangeHouseRepository;
        public GetOnlineExchangeHouses() { }
        public async Task<List<OnlineExchangeHouseDto>> GetExchangeRateCurrently()
        {
            List<OnlineExchangeHouseDto> onlineExchangeHouseDto = new List<OnlineExchangeHouseDto>();
            _onlineExchangeHouseRepository = new OnlineExchangeHouseRepository();

            var onlineExchangeHouses = await _onlineExchangeHouseRepository.GetExchangeRateCurrentlyRepository();

            onlineExchangeHouseDto = GetOnlyExchangeHousesDto(onlineExchangeHouses);

            return onlineExchangeHouseDto;
        }
        public async Task<List<OnlineExchangeHouseDto>> SaveExchangeHouse(OnlineExchangeHouseDto _onlineExchangeHouseDto)
        {
            List<OnlineExchangeHouseDto> onlineExchangeHouseDto = new List<OnlineExchangeHouseDto>();
            List<OnlineExchangeHouse> onlineExchangeHouses = new List<OnlineExchangeHouse>();
            OnlineExchangeHouse _onlineExchangeHouse = new OnlineExchangeHouse();

            _onlineExchangeHouse = ConvertToOnlineExchangeHouseDomain(_onlineExchangeHouseDto, _onlineExchangeHouse);

            _onlineExchangeHouseRepository = new OnlineExchangeHouseRepository();

            onlineExchangeHouses = await _onlineExchangeHouseRepository.SaveExchangeHouseRepository(_onlineExchangeHouse);

            return GetOnlyExchangeHousesDto(onlineExchangeHouses);
        }

        private OnlineExchangeHouse ConvertToOnlineExchangeHouseDomain(
            OnlineExchangeHouseDto _onlineExchangeHouseDto,
            OnlineExchangeHouse _onlineExchangeHouse
            )
        {
            _onlineExchangeHouse.Title = _onlineExchangeHouseDto.Titulo;
            _onlineExchangeHouse.Rates.Buy.Cost = _onlineExchangeHouseDto.TipoCompra;
            _onlineExchangeHouse.Rates.Sale.Cost = _onlineExchangeHouseDto.TipoVenta;

            return _onlineExchangeHouse;
        }

        private List<OnlineExchangeHouseDto> GetOnlyExchangeHousesDto(
            List<OnlineExchangeHouse> onlineExchangeHouses
            )
        {
            List<OnlineExchangeHouseDto> onlineExchangeHousesDto = new List<OnlineExchangeHouseDto>();

            foreach (var item in onlineExchangeHouses)
            {
                onlineExchangeHousesDto.Add(
                    new OnlineExchangeHouseDto
                    {
                        Id = item.Id,
                        Titulo = item.Title,
                        TipoCompra = item.Rates.Buy.Cost,
                        TipoVenta = item.Rates.Sale.Cost
                    }
                ); ;
            }

            onlineExchangeHousesDto = onlineExchangeHousesDto.OrderByDescending(x => x.Id).ToList();

            return onlineExchangeHousesDto;
        }
    }
}
