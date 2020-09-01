using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class CountZayavok //Exercise
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int LogZayavokId { get; set; }
        public virtual LogZayavok LogZayavok { get; set; }


        public CountZayavok() { }

        public CountZayavok(int count, LogZayavok logZayavok)
        {
            Count = count;
            LogZayavok = logZayavok ?? throw new ArgumentNullException(nameof(logZayavok));
        }
    }
}
