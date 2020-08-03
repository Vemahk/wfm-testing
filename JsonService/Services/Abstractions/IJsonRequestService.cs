using System.IO;
using Domain.Models;
using Domain.Models.Orders;

namespace JsonService.Services.Abstractions
{
    public interface IJsonRequestService
    {
        TObject GetWfmObjectFromJson<TObject>(Stream stream) where TObject : BaseWfmObject;
    }
}