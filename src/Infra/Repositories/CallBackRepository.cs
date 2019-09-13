using Application.Interfaces.Repositories;
using Domain.Entities.CallBack;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class CallBackRepository : ICallBackReadOnlyRepository, ICallBackWriteOnlyRepository
    {
        private readonly ApplicationContext context;

        public CallBackRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public int Add(CallBack callBack)
        {
            context.CallBack.Add(callBack);

            return context.SaveChanges();
        }

        public CallBack Find(Guid id)
        {
            return context.CallBack.Find(id);
        }

        public IEnumerable<CallBack> GetAll()
        {
            return context.CallBack.ToList();
        }

        public int Remove(CallBack callBack)
        {
            context.CallBack.Remove(callBack);

            return context.SaveChanges();
        }

        public int Update(CallBack callBack)
        {
            context.Entry(callBack).State = EntityState.Modified;

            return context.SaveChanges();
        }
    }
}
