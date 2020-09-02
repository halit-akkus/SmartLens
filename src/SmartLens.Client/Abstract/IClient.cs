using SmartLens.Entities.Results;
using System.Threading.Tasks;

namespace SmartLens.Client
{
   public interface IClient
    {
        Task SendData(IResult result);
    }
}
