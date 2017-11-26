using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024IsletimSisHW2
{
    class Process
    {
        int processNo;
        double arrivalTime;
        double burstTime;
        int priority;

        public Process(int processNo, double arrivalTime, double burstTime, int priority)
        {
            ProcessNo = processNo;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            Priority = priority;
        }

        public int ProcessNo { get => processNo; set => processNo = value; }
        public double ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public double BurstTime { get => burstTime; set => burstTime = value; }
        public int Priority { get => priority; set => priority = value; }
    }
}
