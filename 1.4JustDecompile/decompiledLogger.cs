using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;

namespace log4netTest
{
    internal class log4netTest
    {
        private readonly static ILog log;

        static log4netTest()
        {
            log4netTest.log = LogManager.GetLogger(typeof(log4netTest));
        }

        public log4netTest()
        {
        }

        private static void Main(string[] args)
        {
            FileAppender fileAppender = new FileAppender();
            fileAppender.set_Layout(new SimpleLayout());
            fileAppender.set_File("myLog.txt");
            fileAppender.set_Threshold(Level.All);
            fileAppender.set_AppendToFile(false);
            fileAppender.ActivateOptions();
            BasicConfigurator.Configure(fileAppender);
            log4netTest.log.Info("This is a test log. We will print 5 info logs and 2 fatal logs.");
            char[] chrArray = new char[] { 'a', 'b', 'c', 'd', 'e' };
            for (int i = 0; i < (int)chrArray.Length + 2; i++)
            {
                try
                {
                    log4netTest.log.Info(string.Concat("This is test ", chrArray[i]));
                }
                catch (IndexOutOfRangeException indexOutOfRangeException1)
                {
                    IndexOutOfRangeException indexOutOfRangeException = indexOutOfRangeException1;
                    log4netTest.log.Fatal(string.Concat("A expected exception was thrown:", indexOutOfRangeException.Message));
                }
            }
        }
    }
}