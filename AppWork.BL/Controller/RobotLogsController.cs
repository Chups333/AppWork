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
        private readonly User user;
        public List<RobotLogs> RobotLogsList { get; set; }
        public RobotLogs CurrentRobotLogs { get; set; }
        public RobotLogsController() { }
        public RobotLogsController(User user)
        {

            this.user = user ?? throw new ArgumentNullException(nameof(user));

            //Delete();

            RobotLogsList = GetRobotLogsData();

        }

        public void Add(DateTime logDataTime, string logText, User user)
        {
            CurrentRobotLogs = RobotLogsList.SingleOrDefault(u => u.LogDataTime == logDataTime && u.User == user);

            if (CurrentRobotLogs == null)
            {
                CurrentRobotLogs = new RobotLogs(logDataTime, logText, user);
                RobotLogsList.Add(CurrentRobotLogs);

            }
            Delete();
            Save();


            

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
