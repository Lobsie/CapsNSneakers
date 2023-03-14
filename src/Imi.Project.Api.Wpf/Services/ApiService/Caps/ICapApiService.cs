using Imi.Project.Api.Wpf.ApiModels.Base;
using Imi.Project.Api.Wpf.ApiModels.Caps;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Imi.Project.Api.Wpf.Services.ApiService.Caps
{
    public interface ICapApiService
    {
        Task<BaseapiResponse<IEnumerable<CapResponseModel>>> GetAllCaps();
        Task DeleteCap(Guid id);
        Task<CapDetailResponseModel> GetCap(Guid id);
    }
}