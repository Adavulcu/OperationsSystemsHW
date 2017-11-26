using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14253024IsletimSisHW2
{

    class TxtOperations
    {
        // bu class txt dosyasından veri okuyup her satırı process nesnesine
        //dönüstürerek bir arrayliste aktarmak için oluşturulumuştur
        Process p;
        ArrayList pList;
        public  ArrayList GetProcess()
        {
            string dp = @"process.txt";
            
            FileStream fs = new FileStream(dp, FileMode.Open, FileAccess.Read);
            
            StreamReader sw = new StreamReader(fs);
          
            string line = sw.ReadLine();
            pList = new ArrayList();
            while (line != null)
            {                          
                pList.Add(LineToProcess(line)); // her bir satır procese dönüştürülmek üzere buradan gerekli metoda gönderilmiştir
               // Console.WriteLine(line);
                line = sw.ReadLine();
            }        
            sw.Close();
            fs.Close();
            return pList;
        }

        public Process LineToProcess(string str)//process nesnesini oluşturan metot
        {
            try
            {
                String[] split = str.Split('\t');
                p = new Process(Convert.ToInt32(split[0]), Convert.ToDouble(split[1]),
                   Convert.ToDouble(split[2]), Convert.ToInt32(split[3]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return p;
        }
    }
}
