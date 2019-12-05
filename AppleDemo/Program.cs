using System;
using System.IO;

namespace AppleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsageInstructions();
                Environment.Exit(1);
            }

            var filename = args[0].Trim();

            if (!File.Exists(filename))
            {
                ShowMissingOrInvalidFilepath();
                Environment.Exit(1);
            }

            try
            {
                var demo = new ReportDemo(filename);
                demo.Run();
            }
            catch (Exception e)
            {
                // log to error logger helper, such as NLog, log4net, etc. and exit gracefully
                Console.Out.WriteLine("Sorry! An unexpected error has occurred. Please review" +
                                      "the error logs for more information, or contact your administrator" +
                                      "for assistance.");
            }
        }

        private static void ShowMissingOrInvalidFilepath()
        {
            Console.Out.WriteLine(
                "The filename provided either does not exist or is not " +
                     "valid. Please check the file path and try again.");;
        }

        private static void ShowUsageInstructions()
        {
            Console.Out.WriteLine("Please specify a valid filename including path to load.");
        }
    }
}
