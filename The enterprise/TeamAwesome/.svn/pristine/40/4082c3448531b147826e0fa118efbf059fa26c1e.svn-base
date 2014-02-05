using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Helpers;
using Model.DomainModel;

namespace DataAccess
{
    public static class AI
    {

        public static int New(string prefix)
        {
            string filename = prefix + "_AI.bin";

            BinaryHelper<packAI> binaryHelper = new BinaryHelper<packAI>();

            if (!binaryHelper.FileExists(filename) )
            {
               binaryHelper.SaveObject(new packAI()
               {
                   Number = 0
               }, filename);
            }
            packAI pack = binaryHelper.LoadObject(filename);

            pack.Number++;
            binaryHelper.SaveObject(pack,filename);
            return pack.Number;

        }
    }

    [Serializable()]
    public class packAI
    {
        public int Number { get; set; }
    }
}
