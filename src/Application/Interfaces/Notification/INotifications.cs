using FluentValidation.Results;
using System.Collections.Generic;

namespace Application.Interfaces.Notification
{
    public interface INotifications
    {
        List<Domain.Notification.Notification> Notifications { get; set; }

        bool HasNotifications { get; }

        void AddNotification(string key, string message);

        void AddNotifications(ValidationResult validationResult);
    }
}
