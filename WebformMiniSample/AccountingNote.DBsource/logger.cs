using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBsource
{
    public  class logger
    {
        public static void WriteLog(Exception ex)
        {
            string Msg=
                $@"                  ":
            System.IO.File.AppendAllText("D:\\logs\\logs.log", ex.ToString());
            throw ex;
        }
    }
}
