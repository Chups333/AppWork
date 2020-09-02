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
        public bool IsNew { get; } = false;
        public RobotLogsController() { }
        public RobotLogsController(DateTime logDataTime)
        {
            if (logDataTime < DateTime.Parse("01.01.1900") || logDataTime > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата.", nameof(logDataTime));
            }


            //Delete();

            RobotLogsList = GetRobotLogsData();
            

            CurrentRobotLogs = RobotLogsList.SingleOrDefault(u => u.LogDataTime == logDataTime);

            if (CurrentRobotLogs == null)
            {
                CurrentRobotLogs = new RobotLogs(logDataTime);
                RobotLogsList.Add(CurrentRobotLogs);
                IsNew = true;

            }

        }

        public void SetNewData(String logText)
        {
            if (string.IsNullOrWhiteSpace(logText))
            {
                throw new ArgumentNullException("Текст события не может быть пустыи или null", nameof(logText));
            }

            CurrentRobotLogs.LogText = logText;
            //Delete();
            Save();
        }

        public void DeleteOdinakobiy(List<RobotLogs> robotLogsList)
        {

        }

        private List<RobotLogs> GetRobotLogsData()
        {
            return Load<RobotLogs>() ?? new List<RobotLogs>();
        }


        public void Save()
        {
            Save(RobotLogsList);
        }

        public void Delete()
        {
            Delete(RobotLogsList);
        }

    }
}
