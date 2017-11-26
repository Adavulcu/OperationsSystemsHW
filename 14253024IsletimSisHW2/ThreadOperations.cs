using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _14253024IsletimSisHW2
{
    class ThreadOperations

    {
        private const string fcfs = "FCFS";
        private const string scf_pre = "SCF_PRE";
        private const string scf_none_pre = "SCF_NONE_PRE";
        private const string priorty = "PRIORTY";
        private const string rr_qua_3 = "RR_QUA_3";
        private const string rr_qua_4 = "RR_QUA_4";
        private const string rr_qua_8 = "RR_QUA_8";

        ArrayList pList;
        ArrayList scheduledList;
        TxtOperations txt = new TxtOperations();
    
        Thread thFcfs;
        Thread thScf_Pre;
        Thread thScf_Non_Pre;
        Thread thPriorty;
        Thread thQua_3;
        Thread thQua_4;
        Thread thQua_8;

        Stopwatch time;

        public void StartThreads()
        {
            
            // Thread ler oluşturulup başlatılıyor
            thFcfs = new Thread(new ThreadStart(FCFS));
            thScf_Pre = new Thread(new ThreadStart(SCF_PRE));
            thScf_Non_Pre = new Thread(new ThreadStart(SCF_NON_PRE));
            thPriorty = new Thread(new ThreadStart(PRIORTY_PRE));
            thQua_3 = new Thread(new ThreadStart(RR_QUA_3));
            thQua_4 = new Thread(new ThreadStart(RR_QUA_4));
            thQua_8 = new Thread(new ThreadStart(RR_QUA_8));
           
              thFcfs.Start();
              thFcfs.Join();      
              thScf_Pre.Start();
              thScf_Pre.Join();
              thScf_Non_Pre.Start();
              thScf_Non_Pre.Join();
              thPriorty.Start();
            thPriorty.Join();
            thQua_3.Start();
           thQua_3.Join();
            thQua_4.Start();
            thQua_4.Join();
            thQua_8.Start();


        }

        public void FCFS()
        {
            time = new Stopwatch();
            time.Start();        
            pList = new ArrayList();
            pList = txt.GetProcess();   // txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer      
            pList.Display("FCFS ALGORİTMASI");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(fcfs);// process dizisinin algoritma ile oluşturuldugu yer
            scheduledList.GantChart();
            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");


        }

        public void SCF_PRE()
        {
            time = new Stopwatch();
            time.Start();
          
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("SCF PREMTİVE ALGORİTMASI");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(scf_pre);// process dizisinin algoritma ile oluşturuldugu yer
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");
        }
        public void SCF_NON_PRE()
        {
            time = new Stopwatch();
            time.Start();
         
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("SCF NONE PREMTİVE ALGORİTMASI");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(scf_none_pre);// process dizisinin algoritma ile oluşturuldugu yer 
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");
        }

        public void PRIORTY_PRE()
        {
            time = new Stopwatch();
            time.Start();
          
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("PRİORİTY PREMTİVE ALGORİTMASI");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(priorty);// process dizisinin algoritma ile oluşturuldugu yer
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");
        }

        public void RR_QUA_3()
        {
            time = new Stopwatch();
            time.Start();
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("ROUND ROBİN ALGORİTMASI QUANtUM-3");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(rr_qua_3);// process dizisinin algoritma ile oluşturuldugu yer
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);

            Console.WriteLine("\n\n**********************************************************\n\n");
        }

        public void RR_QUA_4()
        {
            time = new Stopwatch();
            time.Start();
           
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("ROUND ROBİN ALGORİTMASI QUANtUM-4");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(rr_qua_4);// process dizisinin algoritma ile oluşturuldugu yer 
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");
        }

        public void RR_QUA_8()
        {
            time = new Stopwatch();
            time.Start();
          
            pList = new ArrayList();
            pList = txt.GetProcess();// txt den okunan verileri proces dizisine dönüştürülüp alındıgı yer 
            pList.Display("ROUND ROBİN ALGORİTMASI QUANtUM-8");
            scheduledList = new ArrayList();
            scheduledList = pList.Schedule(rr_qua_8);// process dizisinin algoritma ile oluşturuldugu yer
            scheduledList.GantChart();

            time.Stop();
            TimeSpan tp = time.Elapsed;
            string s = String.Format("{0:00}s:{1:00}ms", tp.Seconds, tp.Milliseconds);
            Console.WriteLine("\n\n\tTHREAD ÇALIŞTIRMA SÜRESİ:\t" + s);
            Console.WriteLine("\n\n**********************************************************\n\n");
        }

       
    }
}
