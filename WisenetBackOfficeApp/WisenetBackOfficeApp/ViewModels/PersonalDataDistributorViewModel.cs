using System;
using WisenetBackOfficeApp.Helpers;
using WisenetBackOfficeApp.Helpers.Utils;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.ViewModels
{
    class PersonalDataDistributorViewModel
    {
        private DistributorTO _Distributor;
        public PersonalDataDistributorViewModel()
        {
            var _AppManager = AppManager.Instance;
            _Distributor = _AppManager.GetDistributor();

            FechaNacimiento = DateUtil.UnixDateToDateTime(_Distributor.FechaNacimiento);

            FechaInscripcion = DateUtil.UnixDateToDateTime(_Distributor.FechaRegistro);
        }

        public DistributorTO Distributor
        {
            get { return _Distributor; }
            set { _Distributor = value; }
        }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaInscripcion { get; set; }
    }
}
