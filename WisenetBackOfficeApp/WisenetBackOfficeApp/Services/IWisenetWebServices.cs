using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.Services
{
    interface IWisenetWebServices
    {
        Task<ResponseDistributor> FindDatosDistribuidorById(long idDistributor, string password);

        Task<ResponseTO> UpdateShippingInformation(DistributorTO distributorTO);

        Task<ResponseTO> UpdateBirthDateDistributor(long idDistributor, string birthDate);

        Task<List<CatalogoTO>> FindUbicaciones(string url);
    }
}
