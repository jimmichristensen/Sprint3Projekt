using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DomainModel;

namespace DataAccess.Controller
{
    class PrintDataAccessController
    {

        public void CreatePrintFile(Filter filter)
        {
             string path = @"c:\simatek\test2.txt";


             using (StreamWriter sw = File.CreateText(path)) 
             {
                 sw.WriteLine("Fil-id");
                 sw.WriteLine("Id-3d-text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine("Filtertyp");
                 sw.WriteLine("DYSEFILTER");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine("Ftp");
                 sw.WriteLine("+");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 foreach (QuestionGroup qg in filter.QuestionGroups)
                 {
                     foreach (Question q in qg.Questions)
                     {
                         if (q.Value != null)
                         {
                             sw.WriteLine(q.PrintTitle);
                             sw.WriteLine(q.Value.Value);
                             sw.WriteLine("");
                             sw.WriteLine("");
                         }
                   
                     }
                 }

                 sw.WriteLine("Text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine(filter.Name);
                 sw.WriteLine("");
                 sw.WriteLine("");      
                 sw.WriteLine("Text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine(filter.FilterType);
                 sw.WriteLine("");
                 sw.WriteLine(""); 
                 sw.WriteLine("Text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine(filter.Order);
                 sw.WriteLine("");
                 sw.WriteLine(""); 
                 sw.WriteLine("Text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine(filter.Customer);
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine("Text");
                 sw.WriteLine("");
                 sw.WriteLine("");
                 sw.WriteLine(filter.MachineNr);
                 sw.WriteLine("");
                 sw.WriteLine("");

                
             }	

        }

    }
}
