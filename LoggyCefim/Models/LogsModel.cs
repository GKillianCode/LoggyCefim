using LoggyCefim.Models;
using System;
using System.IO;

namespace LoggyCefim.Pages
{
    public class LogsModel
    {
        public static readonly string LOG_DATETIME_ALERT_SEPARATOR = "- ";

        string _path = "Path: /";
        string _content = "";
        int _nbAlertDebug = 0;
        int _nbAlertInfo = 0;
        int _nbAlertWarning = 0;
        int _nbAlertError = 0;

        public LogsModel() { }

        public LogsModel(string path, string content)
        {
            this._path = path;
            this._content = content;
        }

        private void reset()
        {
            _nbAlertDebug = 0;
            _nbAlertInfo = 0;
            _nbAlertWarning = 0;
            _nbAlertError = 0;
        }

        private int CountOccurrences(string terme)
        {
            int count = 0;

            using (StreamReader reader = new StreamReader(_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(terme))
                        count++;
                }
            }

            return count;
        }


        private void AnalyseContent()
        {
            if (_content != "")
            {
                reset();

                _nbAlertDebug = CountOccurrences(LogsModel.LOG_DATETIME_ALERT_SEPARATOR + AlertModel.ALERT_DEBUG);
                _nbAlertInfo = CountOccurrences(LogsModel.LOG_DATETIME_ALERT_SEPARATOR + AlertModel.ALERT_INFO);
                _nbAlertWarning = CountOccurrences(LogsModel.LOG_DATETIME_ALERT_SEPARATOR + AlertModel.ALERT_WARN);
                _nbAlertError = CountOccurrences(LogsModel.LOG_DATETIME_ALERT_SEPARATOR + AlertModel.ALERT_ERROR);

                Console.WriteLine(_nbAlertInfo);
            }
        }

        public string getPath() { return _path; }
        public string getContent() { return _content; }

        public void setPath(string path) { this._path = path; }
        public void setContent(string content)
        {
            this._content = content;
            AnalyseContent();
        }

        public int getNbAlertDebug() { return _nbAlertDebug; }
        public int getNbAlertInfo() { return _nbAlertInfo; }
        public int getNbAlertAlert() { return _nbAlertWarning; }
        public int getNbAlertError() { return _nbAlertError; }
    }
}
