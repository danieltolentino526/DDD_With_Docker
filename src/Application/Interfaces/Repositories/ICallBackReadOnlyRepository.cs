using Domain.Entities.CallBack;
using System;
using System.Collections.Generic;

namespace Application.Interfaces.Repositories
{
    public interface ICallBackReadOnlyRepository
    {
        IEnumerable<CallBack> GetAll();

        CallBack Find(Guid id);

    }
}
