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
            //DeleteList();

            RobotLogsList = GetRobotLogsData();

            CurrentRobotLogs = RobotLogsList.SingleOrDefault(u => u.LogDataTime == logDataTime);

            if (CurrentRobotLogs == null)
            {
                CurrentRobotLogs = new RobotLogs(logDataTime);
                RobotLogsList.Add(CurrentRobotLogs);
                IsNew = true;
            }


        }

        public void Set(string logText, string userName)
        {
            if (logText is null)
            {
                throw new ArgumentNullException(nameof(logText));
            }

            CurrentRobotLogs.LogText = logText;
            CurrentRobotLogs.UserName = userName;
            Save();
        }


        private List<RobotLogs> GetRobotLogsData()
        {
            return Load<RobotLogs>() ?? new List<RobotLogs>();
        }

        private void Save()
        {
            Save(CurrentRobotLogs);

        }

        public void DeleteList()
        {
            DeleteList(RobotLogsList);
        }

    }
}
