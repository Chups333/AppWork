using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class RobotLogs
    {
        public int Id { get; set; }
        public DateTime LogDataTime { get; set; }
        public string LogText { get; set; }

        public RobotLogs() { }

        public RobotLogs(DateTime logDataTime, string logText)
        {
            #region Проверка
            if (logDataTime < DateTime.Parse("01.01.1900") || logDataTime > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата.", nameof(logDataTime));
            }
            if (string.IsNullOrWhiteSpace(logText))
            {
                throw new ArgumentNullException("Текст события не может быть пустыи или null", nameof(logText));
            }
            #endregion

            LogText = logText;
            LogDataTime = logDataTime;

        }

        public RobotLogs(DateTime logDataTime)
        {
            #region Проверка
            if (logDataTime < DateTime.Parse("01.01.1900") || logDataTime > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата.", nameof(logDataTime));
            }
            
            #endregion
   
            LogDataTime = logDataTime;
        }


        public override string ToString()
        {
            return LogDataTime.ToString() + " -++ " + LogText; 
        }

    }
}
