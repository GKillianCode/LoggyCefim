using System;

namespace LoggyCefim.ViewModels
{
    public class LogItemViewModel
    {
        readonly DateTime dateTime;
        readonly string alertType;
        readonly string processus;
        readonly string description;

        LogItemViewModel(DateTime dateTime, string alertType, string processus, string description)
        {
            this.dateTime = dateTime;
            this.alertType = alertType;
            this.processus = processus;
            this.description = description;
        }

        public DateTime DateTime { get { return dateTime; } }
        public string AlertType { get { return alertType; } }
        public string Processus { get { return processus; } }
        public string Description { get { return description; } }
    }
}
