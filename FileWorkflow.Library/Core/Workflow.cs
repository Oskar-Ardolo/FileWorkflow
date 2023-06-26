using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorkflow.Library.Core
{
    public class Workflow
    {
        public string Name { get; set; }
        public string UID { get; set; }
        public List<Step> Steps { get; set; }
    }
}
