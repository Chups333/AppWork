using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class RobotLogsController : MyControllerBase
    {
        public List<RobotLogs> RobotLogsList { get; set; }
        public RobotLogs CurrentRobotLogs { get; set; }
       
        public RobotLogsController(DateTime logDataTime, String logText)
        {
            if (logDataTime < DateTime.Parse("01.01.1900") || logDataTime > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата.", nameof(logDataTime));
            }
            if (string.IsNullOrWhiteSpace(logText))
            {
                throw new ArgumentNullException("Текст события не может быть пустыи или null", nameof(logText));
            }
            
            RobotLogsList = GetRobotLogsData();

            CurrentRobotLogs = RobotLogsList.SingleOrDefault(u => u.LogDataTime == logDataTime && u.LogText==logText);

            if (CurrentRobotLogs == null)
            {
                CurrentRobotLogs = new RobotLogs(logDataTime,logText);
                RobotLogsList.Add(CurrentRobotLogs);
                Save();
                
            }
        }

        private List<RobotLogs> GetRobotLogsData()
        {
            return Load<RobotLogs>() ?? new List<RobotLogs>();
        }

        
        public void Save()
        {
            Save(RobotLogsList);
        }

    }
}
