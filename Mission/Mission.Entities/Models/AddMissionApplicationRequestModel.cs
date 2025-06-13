using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models
{
    public class AddMissionApplicationRequestModel
    {
        public DateTime AppliedDate { get; set; }
        public int MissionId { get; set; }
        public int Sheet { get; set; }

        public bool Status { get; set; }

        public int UserId { get; set; }
    }
}
