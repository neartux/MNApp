using System.Collections.Generic;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Ordenes;

namespace WisenetBackOfficeApp.Services
{
    interface IWisenetWebServices
    {
        Task<ResponseDistributor> FindDatosDistribuidorById(long idDistributor, string password);

        Task<ResponseTO> UpdateShippingInformation(DistributorTO distributorTO);

        Task<ResponseTO> UpdateBirthDateDistributor(long idDistributor, string birthDate);

        Task<ResponseTO> UpdateBillingInformation(DistributorTO distributorTO);

        Task<ResponseVenta> FindOrdersByDistributor(long idDistributor);

        Task<ResponseVentaDetalle> FindVentaById(long idVenta);

        Task<List<CatalogoTO>> FindUbicaciones(string url);
    }
}
