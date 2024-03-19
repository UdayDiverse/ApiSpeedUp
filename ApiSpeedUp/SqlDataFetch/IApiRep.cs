using ApiSpeedUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSpeedUp.SqlDataFetch
{
    public interface IApiRep
    {
        Task<List<ApiExecutionTime>> GetAllList();

        Task<int> getcount(string org);

        Task<List<Distinct_Organization>> GetAllorg();
    }
}
