using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace AppleDemo
{
    internal class ReportDemo
    {
        private readonly List<DataModel> dataModel;

        public ReportDemo(string filename)
        {
            // attempt to load the file
            var data = File.ReadAllText(filename);
            dataModel = JsonConvert.DeserializeObject<List<DataModel>>(data);
        }

        public void Run()
        {
            ShowWelcomeBanner();
            ShowAnswerNumber1();
            ShowAnswerNumber2();
            ShowAnswerNumber3();
            ShowGoodbyeBanner();
        }

        private void ShowAnswerNumber1()
        {
            //
            // question
            var bannerText = "Question #1";
            WriteBannerText(bannerText);

            Console.Out.WriteLine("Which department has the largest number ");
            Console.Out.WriteLine("of employees who like Pineapple on their pizzas?\r\n");

            var departmentsLikingPineappleToppingQuery = 
                (from item in dataModel
                group item by item.Department
                into departmentGroup
                select new
                {
                    Department = departmentGroup.Key,
                    PineappleCount = departmentGroup.Sum(x => x.Toppings.Contains("Pineapple") ? 1 : 0),
                }).OrderByDescending(item => item.PineappleCount);

            var topDepartmentQuery = departmentsLikingPineappleToppingQuery.First();


            //
            // answer
            WriteBannerText("Answer");
            Console.Out.WriteLine($"{topDepartmentQuery.Department} (count={topDepartmentQuery.PineappleCount})");


            // uncomment to show each department's respective counts
            //foreach (var item in departmentsLikingPineappleToppingQuery)
            //{
            //    Console.Out.WriteLine($"dept={item.Department}, count={item.PineappleCount}");
            //}
        }

        private void ShowAnswerNumber2()
        {
            //
            // question
            Console.Out.WriteLine("\r\n");

            WriteBannerText("Question #2", ConsoleColor.Black, ConsoleColor.Yellow);

            Console.Out.WriteLine(@"How many pizzas would you need to order to feed the
Engineering department, assuming a pizza feeds 4 people?
Ignore personal preferences.");

            Console.Out.WriteLine("");


            //
            // answer
            WriteBannerText("Answer:", ConsoleColor.Black, ConsoleColor.Yellow);
            
            var engineeringDepartmentEmployees =
                (from item in dataModel
                    where item.Department == "Engineering"
                    select item);

            var employeeCount = engineeringDepartmentEmployees.Count();

            Console.Out.WriteLine($"Total Engineering employees: {employeeCount}");

            decimal pizzaCountToOrder = 0;
            if (employeeCount > 0)
                pizzaCountToOrder = employeeCount / 4;
            else
                pizzaCountToOrder = 0;

            pizzaCountToOrder = Math.Ceiling(pizzaCountToOrder);

            if (pizzaCountToOrder == 0)
            {
                Console.Out.WriteLine("There are no employees in this sample, so no pizza is required.");
            }
            else
            {
                Console.Out.WriteLine($"We should plan to order {pizzaCountToOrder} pizza{(pizzaCountToOrder > 1 ? "s": "")}");
            }

            Console.Out.Write("\r\n\r\n");
        }

        private void ShowAnswerNumber3()
        {
            // Which pizza topping combination is the most popular
            // in each department and how many employees prefer it?
            WriteBannerText("Question #3", ConsoleColor.White, ConsoleColor.DarkBlue);

            Console.Out.WriteLine(@"Which pizza topping combination is the most popular 
in each department and how many employees prefer it?");

            Console.Out.WriteLine("");


            //
            // answer
            WriteBannerText("Answer:", ConsoleColor.White, ConsoleColor.DarkBlue);
            Console.Out.WriteLine("Sorry! I ran out of time and couldn't finish this last question. :-(");

        }

        private void WriteBannerText(string bannerText, 
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.DarkGreen)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.Out.WriteLine($" {bannerText} \r\n");

            Console.ResetColor();
        }

        private void ShowWelcomeBanner()
        {

            Console.Out.WriteLine($"Welcome to APPLE v{Assembly.GetExecutingAssembly().GetName().Version}!");
            Console.Out.WriteLine("(Advanced Proprietary Pizza Logistics Engine)\r\n\r\n");
        }

        private void ShowGoodbyeBanner()
        {
            Console.Out.WriteLine("\r\n\r\nThanks for using APPLE! We look forward to seeing you again soon.\r\n");
        }
    }
}