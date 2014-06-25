using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Core;

namespace log4netTest
{


    class log4netTest
    {
        private static readonly ILog log =
                LogManager.GetLogger(typeof(log4netTest));
        static void Main(string[] args)
        {
            var myFileAdapter = new FileAppender();
            myFileAdapter.Layout = new SimpleLayout();
            myFileAdapter.File = "myLog.txt";
            myFileAdapter.Threshold = Level.All;
            myFileAdapter.AppendToFile = false;
            myFileAdapter.ActivateOptions();

            BasicConfigurator.Configure(myFileAdapter);

            log.Info("This is a test log. We will print 5 info logs and 2 fatal logs.");
            char[] letters = new char[5] { 'a', 'b', 'c', 'd', 'e' };
            for (int i = 0; i < letters.Length+2; i++)
            {
                try
                {
                    log.Info("This is test " + letters[i]);
                }
                catch (IndexOutOfRangeException e)
                {
                    log.Fatal("A expected exception was thrown:" + e.Message);
                }
            }
        }
    }
}
