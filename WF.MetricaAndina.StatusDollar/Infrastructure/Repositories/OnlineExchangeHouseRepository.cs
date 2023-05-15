﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WF.MetricaAndina.StatusDollar.Application.Constants;
using WF.MetricaAndina.StatusDollar.Domain;

namespace WF.MetricaAndina.StatusDollar.Infrastructure.Repositories
{
    public class OnlineExchangeHouseRepository
    {
        public async Task<List<OnlineExchangeHouse>> GetExchangeRateCurrentlyRepository()
        {
            var data = ExchangeHouses();
            return JsonConvert.DeserializeObject<List<OnlineExchangeHouse>>(data);
        }
        public async Task<List<OnlineExchangeHouse>> SaveExchangeHouseRepository(OnlineExchangeHouse _onlineExchangeHouse)
        {
            List<OnlineExchangeHouse> onlineExchangeHouses= new List<OnlineExchangeHouse>();
            onlineExchangeHouses = await GetExchangeRateCurrentlyRepository();

            _onlineExchangeHouse.Id = GetLastId(onlineExchangeHouses);

            onlineExchangeHouses.Add(_onlineExchangeHouse);

            string newData = ExchangeHouses(onlineExchangeHouses);
            
            return JsonConvert.DeserializeObject<List<OnlineExchangeHouse>>(newData);
        }
        private string ExchangeHouses(List<OnlineExchangeHouse> newData = null)
        {
            var data = "[{\"id\":\"8\",\"title\":\"Western Union\",\"height\":\"40\",\"width\":\"128\",\"img\":\"img/logo/western-union.svg\",\"description\":\"Contamos con mas de 150 años de experiencia  Ven y unete a la nueva forma de cambiar tus Dólares con nosotros\",\"color\":\"#000\",\"site\":\"https://westernunionperu.pe/cambiodemoneda?utm_source=ced\u0026utm_content=listado\",\"path\":\"western-union\",\"order\":\"1\",\"bank\":\"BCP, BANBIF, Pichincha, Scotiabank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.679\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 5:30 pm\",\"Saturdays\":\"\",\"Sundays\":\"\"}},{\"id\":\"14\",\"title\":\"Cambix\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/cambix.svg\",\"description\":\"\",\"color\":\"#4628AD\",\"site\":\"https://cambix.com.pe/?utm_medium=referral\u0026utm_source=cuantoestaeldolar\u0026utm_campaign=conversion\u0026utm_content=lead\u0026utm_term=lista\r\n\",\"path\":\"cambix\",\"order\":\"2\",\"bank\":\"Banco de Comercio, Todos los bancos (interbancario)\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.675\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"8 am - 6 pm\",\"Saturdays\":\"8 am - 6 pm\",\"Sundays\":\"8 am - 6 pm\"}},{\"id\":\"10\",\"title\":\"Dollar House\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/dollar-house-v2.svg\",\"description\":\"Compra y vende dólares al tipo de cambio más bajo del mercado\",\"color\":\"#fe8e01\",\"site\":\"https://dollarhouse.pe/?utm_source=ced\",\"path\":\"dollar-house\",\"order\":\"3\",\"bank\":\"BCP, Interbak\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.666\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"10 am - 1pm\",\"Sundays\":\"\"}},{\"id\":\"16\",\"title\":\"Tu Cambista\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/tu-cambista.svg\",\"description\":\"\",\"color\":\"#efc52e\",\"site\":\"https://tucambista.pe/?utm_source=ced\u0026utm_medium=paid\u0026utm_campaign=pricelist\",\"path\":\"tu-cambista\",\"order\":\"4\",\"bank\":\"BCP, Interbank, Banbif\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.668\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"8 am - 8 pm\",\"Saturdays\":\"9 am - 3 pm\",\"Sundays\":\"\"}},{\"id\":\"7\",\"title\":\"CambiaFX\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/cambiafx_v2.svg\",\"description\":\"Cambia tus dólares al mejor tipo de cambio\",\"color\":\"#6362fb\",\"site\":\"https://cambiafx.pe/?utm_source=display\u0026utm_medium=banner\u0026utm_campaign=Cuanto_esta_el_Dolar\u0026utm_content=boton_cambiar\",\"path\":\"cambia-fx\",\"order\":\"5\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.671\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 7pm\",\"Saturdays\":\"10 am - 1 pm\",\"Sundays\":\"\"}},{\"id\":\"17\",\"title\":\"Instakash\",\"height\":\"25\",\"width\":\"117\",\"img\":\"img/logo/instakash_v2.svg\",\"description\":\"\",\"color\":\"#496e84\",\"site\":\"https://instakash.net/?utm_source=ced\",\"path\":\"instakash\",\"order\":\"6\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.642\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.677\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"9 am - 7 pm\",\"Sundays\":\"\"}},{\"id\":\"20\",\"title\":\"cambiosol\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/cambiosol.svg\",\"description\":\"\",\"color\":\"#1e29ae\",\"site\":\"https://cambiosol.pe/?utm_source=ced\",\"path\":\"cambiosol\",\"order\":\"7\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.650\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 6 pm\",\"Saturdays\":\"9 am a 1 pm\",\"Sundays\":\"\"}},{\"id\":\"21\",\"title\":\"Cambio Mundial\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/cambiomundial-2.svg\",\"description\":\"\",\"color\":\"#02a702\",\"site\":\"https://www.cambiomundial.com/?utm_source=ced\",\"path\":\"cambiomundial\",\"order\":\"8\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.650\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 6 pm\",\"Saturdays\":\"9 am - 1:00 pm\",\"Sundays\":\"\"}},{\"id\":\"23\",\"title\":\"Perú dolar\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/perudolar.svg\",\"description\":\"\",\"color\":\"#1e29ae\",\"site\":\"https://perudolar.pe/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"perudolar\",\"order\":\"9\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 4 pm\",\"Saturdays\":\"-\",\"Sundays\":\"\"}},{\"id\":\"27\",\"title\":\"Yanki\",\"height\":\"52\",\"width\":\"138\",\"img\":\"img/logo/yanki.svg\",\"description\":\"\",\"color\":\"#19d375\",\"site\":\"https://yanki.pe?utm_source=CED\u0026utm_medium=paid\u0026utm_campaign=diciembre\",\"path\":\"yanki\",\"order\":\"10\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":-0.007,\"signal\":\"negative\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.679\",\"variation\":0.005,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"9 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"51\",\"title\":\"Dichikash\",\"height\":\"32\",\"width\":\"147\",\"img\":\"img/logo/dichikash.svg\",\"description\":\"\",\"color\":\"#0B2057\",\"site\":\"https://dichikash.com/?utm_source=ced\",\"path\":\"dichikash\",\"order\":\"11\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.654\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.669\",\"variation\":0.001,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 7pm\",\"Saturdays\":\"9 am - 7 pm\",\"Sundays\":\"\"}},{\"id\":\"44\",\"title\":\"sr Cambio\",\"height\":\"48\",\"width\":\"150\",\"img\":\"img/logo/sr-cambio.png\",\"description\":\"\",\"color\":\"#3aa229\",\"site\":\"https://srcambio.pe/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"sr-cambio\",\"order\":\"12\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0.005,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 6pm\",\"Saturdays\":\"9 am - 1pm\",\"Sundays\":\"\"}},{\"id\":\"49\",\"title\":\"Okane\",\"height\":\"48\",\"width\":\"100\",\"img\":\"img/logo/okane.svg\",\"description\":\"\",\"color\":\"#000e8d\",\"site\":\"https://www.okanecambioonline.com/?utm_source=ced\",\"path\":\"okane\",\"order\":\"13\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.650\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 6pm\",\"Saturdays\":\"9 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"52\",\"title\":\"Money House\",\"height\":\"42\",\"width\":\"115\",\"img\":\"img/logo/money_house.svg\",\"description\":\"\",\"color\":\"#2780e3\",\"site\":\"https://www.moneyhouse.com.pe/?utm_source=ced\",\"path\":\"moneyhouse\",\"order\":\"14\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.652\",\"variation\":0.002,\"signal\":\"positive\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.669\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"8 am - 7 pm \",\"Saturdays\":\"9 am - 1 pm\",\"Sundays\":\"\"}},{\"id\":\"43\",\"title\":\"Securex\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/securex-2.svg\",\"description\":\"\",\"color\":\"#2375e1\",\"site\":\"https://securex.pe/?utm_source=cuantoestaeldólar\u0026utm_medium=CPM\u0026utm_campaign=Feb_botonctd_W8_\u0026utm_content=ppl\",\"path\":\"securex\",\"order\":\"15\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.677\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"9 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"35\",\"title\":\"inka money\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/inkamoney.svg\",\"description\":\"\",\"color\":\"#8500ff\",\"site\":\"https://inkamoney.com/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"inkamoney\",\"order\":\"16\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.645\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 6:30 pm\",\"Saturdays\":\"9 am - 1 pm\",\"Sundays\":\"\"}},{\"id\":\"28\",\"title\":\"DLS Money\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/dlsmoney.svg\",\"description\":\"\",\"color\":\"#f29221\",\"site\":\"https://dlsmoney.com/?utm_source=ced\u0026utm\r\n_medium=listado\",\"path\":\"dlsmoney\",\"order\":\"17\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.650\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0.001,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"9 AM - 1pm\",\"Sundays\":\"\"}},{\"id\":\"29\",\"title\":\"Hir Power\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/hirpower.svg\",\"description\":\"\",\"color\":\"#24692e\",\"site\":\"https://hirpower.com/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"hirpower\",\"order\":\"18\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"8 am - 8 pm\",\"Saturdays\":\"8 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"26\",\"title\":\"Roblex\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/roblex.svg\",\"description\":\"\",\"color\":\"#041a90\",\"site\":\"https://roblex.pe/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"roblex\",\"order\":\"19\",\"bank\":\"BCP, Interbank Yape\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.670\",\"variation\":0.005,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 6:30 pm\",\"Saturdays\":\"9 am - 1:30 pm\",\"Sundays\":\"\"}},{\"id\":\"46\",\"title\":\"Adolfo exchange\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/adol.svg\",\"description\":\"\",\"color\":\"#6DBE46\",\"site\":\"https://adolfoexchange.com/?utm_source=ced\",\"path\":\"adolfo-exchange\",\"order\":\"20\",\"bank\":\"BCP, Interbank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.635\",\"variation\":-0.005,\"signal\":\"negative\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.675\",\"variation\":0.008,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 7 pm\",\"Saturdays\":\"9 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"4\",\"title\":\"TKambio\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/tkambio.svg\",\"description\":\"TKambio, es una plataforma que busca mejorar la forma en que se realizan las operaciones                     de cambio de moneda actualmente, optimizando los tiempos y minimizando los peligros que implican el                     traslado de dinero.\",\"color\":\"#52c1ff\",\"site\":\"https://www.tkambio.com/?utm_source=cuantoestaeldolar.pe\u0026utm_medium=referral\u0026utm_campaign=web_home\",\"path\":\"tkambio\",\"order\":\"21\",\"bank\":\"BCP, Interbank\r\n\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.644\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.675\",\"variation\":0.003,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9am - 7pm\",\"Saturdays\":\"9 am - 2 pm\",\"Sundays\":\"\"}},{\"id\":\"19\",\"title\":\"Cambi\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/cambi-2.svg\",\"description\":\"\",\"color\":\"#08a2b4\",\"site\":\"https://cambi.pe/?utm_source=ced\",\"path\":\"cambi\",\"order\":\"22\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.647\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.671\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"9 am - 6 pm\",\"Saturdays\":\"9 am a 1 pm\",\"Sundays\":\"\"}},{\"id\":\"47\",\"title\":\"Rissan\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/Rissan.svg\",\"description\":\"\",\"color\":\"#045c1c\",\"site\":\"https://rissanpe.com/?utm_source=ced\u0026utm_medium=listado\",\"path\":\"rissan\",\"order\":\"23\",\"bank\":\"BCP\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":-0.01,\"signal\":\"negative\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.675\",\"variation\":0.007,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 6pm\",\"Saturdays\":\"9 am - 1pm\",\"Sundays\":\"\"}},{\"id\":\"48\",\"title\":\"vip capital\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/vip-capital.png\",\"description\":\"\",\"color\":\"#6e34aa\",\"site\":\"https://vipcapital.com.pe/?utm_source=ced\",\"path\":\"vip-capital\",\"order\":\"24\",\"bank\":\"BCP, Interbank, Scotiabank\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.635\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.678\",\"variation\":0.008,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 6pm\",\"Saturdays\":\"9 am - 1pm\",\"Sundays\":\"\"}},{\"id\":\"50\",\"title\":\"Hay Cambio\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/hay-cambio.svg\",\"description\":\"\",\"color\":\"#CC2D18\",\"site\":\"https://haycambio.com/?utm_source=ced\",\"path\":\"haycambio\",\"order\":\"25\",\"bank\":\"BCP, BBVA\r\n\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.649\",\"variation\":0.001,\"signal\":\"positive\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.671\",\"variation\":0.001,\"signal\":\"positive\"}},\"schedule\":{\"M-F\":\"9 am - 6 pm\",\"Saturdays\":\"9 am - 1 pm\",\"Sundays\":\"\"}},{\"id\":\"3\",\"title\":\"Rextie\",\"height\":\"48\",\"width\":\"128\",\"img\":\"img/logo/rextie.png\",\"description\":\"Rextie es una casa de cambio que opera por internet y está registrada en la SBS. Rextie te da el mejor precio para cambiar dólares de una forma segura y rápida\",\"color\":\"#000096\",\"site\":\"https://www.rextie.com/rextie-empresas/registro/?utm_source=cuantocuestaeldolar_listado\u0026utm_medium=cpc\u0026utm_campaign=rextie_business_cuantocuestaeldolar\u0026utm_id=rextie_business\u0026utm_term=rextie_business_\",\"path\":\"rextie\",\"order\":\"27\",\"bank\":\"BCP, Interbank, Pichincha, BANBIF\",\"rates\":{\"buy\":{\"currency\":\"PEN\",\"cost\":\"3.640\",\"variation\":0,\"signal\":\"equals\"},\"sale\":{\"currency\":\"PEN\",\"cost\":\"3.675\",\"variation\":0,\"signal\":\"equals\"}},\"schedule\":{\"M-F\":\"8 am - 8 pm\",\"Saturdays\":\"9 am - 3 pm\",\"Sundays\":\"\"}}]";

            if (newData != null)
                data = JsonConvert.SerializeObject(newData);

            return data;
        }
        private int GetLastId(List<OnlineExchangeHouse> _onlineExchangeHouses)
        {
            int newId = (_onlineExchangeHouses.OrderByDescending(x => x.Id).ToList()).Select(x => x.Id).FirstOrDefault();

            return newId + Constant.One;
        }
    }
}