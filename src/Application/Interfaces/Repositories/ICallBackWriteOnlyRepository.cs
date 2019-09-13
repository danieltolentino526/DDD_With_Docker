
using Domain.Entities.CallBack;

namespace Application.Interfaces.Repositories
{
    public interface ICallBackWriteOnlyRepository
    {
        int Add(CallBack callBack);

        int Update(CallBack callBack);

        int Remove(CallBack callBack);
    }
}
