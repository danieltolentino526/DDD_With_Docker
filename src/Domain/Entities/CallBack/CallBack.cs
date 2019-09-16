using Domain.Validator;
using System;

namespace Domain.Entities.CallBack
{
    public class CallBack : Entity
    {
        public string Description { get; private set; }
        public EntryType Status { get; set; }

        public CallBack(Guid id, string description, EntryType status)
        {
            this.Id = id;
            this.Description = description;
            this.Status = Status;

            Validate(this, new CallBackValidator());
        }
    }

    public enum EntryType
    {
        New = 1,
        Close = 2,
        Assign = 3
    }
}
