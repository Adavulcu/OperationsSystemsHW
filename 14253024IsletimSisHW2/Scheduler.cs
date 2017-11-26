using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace _14253024IsletimSisHW2
{
   public  static class Scheduler
    {

        private const string FCFS = "FCFS";
        private const string SCF_PRE = "SCF_PRE";
        private const string SCF_NONE_PRE = "SCF_NONE_PRE";
        private const string PRIORTY = "PRIORTY";
        private const string RR_QUA_3 = "RR_QUA_3";
        private const string RR_QUA_4 = "RR_QUA_4";
        private const string RR_QUA_8 = "RR_QUA_8";
        private const string RR_QUA= "RR_QUA";

        static ArrayList scheduledList;
        static ArrayList processQueue;
       static int counter = 0;
       static int QuatumIndex = 0;// processQueue dizsinden cpu ya hangi indis teki processin alınacagını belirleyen degişken
        static int QuaCounter = 0;//Round Robin için quantım sayacı

        public static void Display(this ArrayList list ,string s)
        {
            Console.WriteLine("---------"+s+"----------");
            Console.WriteLine("Process ID    Arrival Time    Burst Time     Priority");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(((Process)list[i]).ProcessNo + "\t\t" +
                   ((Process)list[i]).ArrivalTime + "\t\t" +
                   ((Process)list[i]).BurstTime + "\t\t" +
                   ((Process)list[i]).Priority);
            }
        }

        public static ArrayList Schedule(this ArrayList list ,string s )
        {

            scheduledList = new ArrayList();//CPU ya alınan processlerin bilgisini tutan dizi
            counter = 0;
            int arrivalTime = 0;
            processQueue = new ArrayList();//process kuyrugu
            QuatumIndex = 0;
            while (true)
            {

                //process zaman arrival time ye eşitlenen processler kuyruga atılmıstır
                // her adımda QuaCounter 1 artırılır
                //her adımdan CPU nun 1 saniyesi için process secilir
                for (int i = 0; i < list.Count; i++)
                {
                    if (((Process)list[i]).ArrivalTime == arrivalTime)
                    {
                        processQueue.Add(list[i]);

                    }

                }
                if (processQueue.Count > 0)
                {
                    //bu metoda gönderilen her bir process dizisinin hangi algoritmaya göre işleneceginin
                    //belirlendigi yer
                    switch (s)
                    {
                        case FCFS:
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (((Process)list[i]).BurstTime != 0)
                                {
                                    AddProcessNo(scheduledList, ((Process)list[i]).ProcessNo, ((Process)list[i]).BurstTime);
                                  
                                    counter++;
                                }

                            }
                            break;
                        case SCF_PRE:
                            AddFromQue(processQueue, scheduledList, SCF_PRE);
                            break;
                        case SCF_NONE_PRE:
                            AddFromQue(processQueue, scheduledList, SCF_NONE_PRE);
                            break;
                        case PRIORTY:
                            AddFromQue(processQueue, scheduledList, PRIORTY);
                            break;
                        case RR_QUA_3:
                           
                            if  ( QuaCounter  == 3)
                            {
                                QuatumIndex = (QuatumIndex + 1) % processQueue.Count;
                                QuaCounter = 0;
                                
                            }
                            QuaCounter++;
                            AddFromQue(processQueue, scheduledList, RR_QUA);
                           
                            break;
                        case RR_QUA_4:
                            if (QuaCounter == 4)
                            {
                               
                                QuatumIndex = (QuatumIndex + 1) % processQueue.Count;
                                QuaCounter = 0;
                            }
                            QuaCounter++;
                            AddFromQue(processQueue, scheduledList, RR_QUA);
                           
                            break;
                        case RR_QUA_8:
                            if (QuaCounter == 8)
                            {
                                
                                QuatumIndex = (QuatumIndex + 1) % processQueue.Count;
                                QuaCounter = 0;
                            }
                            QuaCounter++;
                            AddFromQue(processQueue, scheduledList, RR_QUA);
                            break;
                        default:
                            return null;
                    }

                }

                if (counter == list.Count)
                    break;
                arrivalTime++;
            }
            return scheduledList;
        }

        public static void GantChart(this ArrayList list)
        {
            int counter = 0;
            
            Console.WriteLine("\n\n\t\tGANT CHART\n\n");
            Console.Write("|0|");
            for (int i = 0; i < list.Count; i++)
            {
                
                if (i>0 && !list[i].Equals(list[i-1]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  (" + "P" + list[i-1] + ")  ");
                    Console.ResetColor();
                    Console.Write("|" + counter + "|");
                }
                if(i==list.Count-1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  (" + "P" + list[i] + ")  ");
                    Console.ResetColor();
                    Console.Write("|" + (counter+1) + "|");
                }
                counter++;

            }

            

        }

        private static void AddProcessNo(ArrayList list,int no,double times)
        {
            //CPU ya girecek processin bilgisinin girildigi yer
            for (int i = 0; i < ((int)times); i++)
            {
                
                if(list.Count>0 && Convert.ToInt32( list[list.Count-1])!=no)// her bir contex swicth işlemi için harcanan zaman eklenmiştir
                    Thread.Sleep(1);
                list.Add(no);
            }
            
        }

        /// <summary>
        /// kuyruktaki processleri cpu y atar
        /// </summary>
        private static void AddFromQue(ArrayList PQ, ArrayList schList, string s)
        {
            //kuyruktaki processlerin hangi algoritmaya göre ve hangi processin CPU ya ekleneceginin belirlendigi yer
            switch (s)
            {


                case SCF_PRE:
                    double mbs = 0; //min burst time
                    int index = 0;

                    for (int i = 0; i < PQ.Count; i++)
                    {
                        if (PQ[i] != null)
                        {
                            mbs = ((Process)PQ[i]).BurstTime;
                            break;
                        }
                    }

                    for (int i = PQ.Count - 1; i >= 0; i--)//aynı burst time eşit processlerden ilk geleni cpu ya eklemek için diziyin tersten okudum
                    {
                        if (((Process)PQ[i]).BurstTime != 0 && ((Process)PQ[i]).BurstTime <= mbs)
                        {
                            mbs = ((Process)PQ[i]).BurstTime;
                            index = i;
                        }

                    }
                    AddProcessNo(schList, ((Process)PQ[index]).ProcessNo, 1);
                    ((Process)PQ[index]).BurstTime--;
                    if (((Process)PQ[index]).BurstTime == 0)
                    {
                        PQ.RemoveAt(index);
                        counter++;
                    }
                    break;


                case SCF_NONE_PRE:
                    index = 0;
                    mbs = 0;
                    for (int i = 0; i < PQ.Count; i++)
                    {
                        if (PQ[i] != null)
                            mbs = ((Process)PQ[i]).BurstTime;
                        for (int j = PQ.Count - 1; j >= 0; j--)//aynı burst time eşit processlerden ilk geleni cpu ya eklemek için diziyin tersten okudum
                        {
                            if (PQ[j] != null && ((Process)PQ[j]).BurstTime <= mbs)
                            {
                                mbs = ((Process)PQ[j]).BurstTime;
                                index = j;
                            }

                        }
                        AddProcessNo(scheduledList, ((Process)PQ[index]).ProcessNo, ((Process)PQ[index]).BurstTime);
                        PQ.RemoveAt(index);
                        counter++;
                    }
                    break;
                case PRIORTY:
                    int pri = 0; //priority
                    index = 0;
                    for (int i = 0; i < PQ.Count; i++)//herhangi bir priority secimi
                    {
                        if (PQ[i] != null)
                        {
                            pri = ((Process)PQ[i]).Priority;
                            break;
                        }
                    }
                    for (int i = 0; i < PQ.Count; i++)
                    {
                        if (((Process)PQ[i]).BurstTime != 0 && ((Process)PQ[i]).Priority < pri)
                        {
                            pri = ((Process)PQ[i]).Priority;
                            index = i;
                        }

                    }
                    AddProcessNo(schList, ((Process)PQ[index]).ProcessNo, 1);
                    ((Process)PQ[index]).BurstTime--;
                    if (((Process)PQ[index]).BurstTime == 0)
                    {
                        PQ.RemoveAt(index);
                        counter++;
                    }
                    break;
                case RR_QUA:


                    if (((Process)PQ[QuatumIndex]).BurstTime != 0)
                    {
                        AddProcessNo(schList, ((Process)PQ[QuatumIndex]).ProcessNo, 1);
                        ((Process)PQ[QuatumIndex]).BurstTime--;
                        if (((Process)PQ[QuatumIndex]).BurstTime == 0)
                        {
                            counter++;
                            if (PQ.Count > 1)
                            {
                                if (counter != 3)
                                {
                                    QuaCounter = 0;
                                    if (QuatumIndex >= PQ.Count)
                                        QuatumIndex = ((QuatumIndex + 1) % PQ.Count) - 1;
                                    else
                                        QuatumIndex = ((QuatumIndex + 1) % PQ.Count);
                                }
                            }

                        }
                    }


                    break;
            }


        }


    }
}
