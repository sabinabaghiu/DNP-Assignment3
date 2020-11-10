using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdultsService
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<HttpStatusCode> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int Id);
    }
}