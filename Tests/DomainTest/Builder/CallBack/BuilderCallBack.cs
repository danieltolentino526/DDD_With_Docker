using Domain.Entities.CallBack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.Tests.Builder.CallBack
{
    public class BuilderCallBack
    {
        public Guid CallNumber;
        public string Description;
        public EntryType Status;

        public static BuilderCallBack New()
        {

            return new BuilderCallBack
            {
                CallNumber = Guid.NewGuid(),
                Description = "Error into Container Hang Fire",
                Status = EntryType.New
            };
        }

        public BuilderCallBack WithId(Guid id)
        {
            this.CallNumber = id;
            return this;
        }

        public BuilderCallBack WithDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public BuilderCallBack WithStatus(EntryType status)
        {
            this.Status = status;
            return this;
        }

        public Domain.Entities.CallBack.CallBack Build()
        => new Domain.Entities.CallBack.CallBack(CallNumber, Description, Status);
    }
}
