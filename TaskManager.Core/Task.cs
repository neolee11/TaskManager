using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager.Core
{
    public class Task
    {
        public List<Step> Steps { get; set; }
        public TaskStatus TaskStatus { get; set; }

        public Task()
        {
            Steps = new List<Step>();
        }
    }
}
