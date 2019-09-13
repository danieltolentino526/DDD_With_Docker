using Application.Interfaces.Notification;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Application.Notification
{
    public class Notification : INotifications
    {
        public Notification()
        {
            Notifications = new List<Domain.Notification.Notification>();
        }

        public List<Domain.Notification.Notification> Notifications { get; set; }

        public bool HasNotifications => Notifications.Any();

        public void AddNotification(string key, string message)
            => Notifications.Add(new Domain.Notification.Notification(key, message));

        public void AddNotifications(ValidationResult validationResult)
            => validationResult.Errors.ToList().ForEach(error => AddNotification(error.ErrorCode, error.ErrorMessage));
    }
}
