using System;
using System.Collections.Generic;

namespace CC2020.Services
{
    public class States
    {
        public string State;

        public string Value;
    }

    public class StateService
    {
        public List<States> GetList()
        {
            var states = new List<States>
            {
                new States { State = "Victoria", Value = "VIC"},
                new States { State = "Queensland", Value = "QLD"},
                new States { State = "New South Wales", Value = "NSW"},
                new States { State = "South Australia", Value = "SA"},
                new States { State = "Australian Capital Territory", Value = "ACT"},
                new States { State = "Tasmania", Value = "TAS"},
                new States { State = "Northern Territory", Value = "NT"},
                new States { State = "Western Australia", Value = "WA"}
            };

            return states;
        }
    }
}
