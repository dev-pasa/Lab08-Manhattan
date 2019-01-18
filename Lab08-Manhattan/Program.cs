using System;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using Lab08_Manhattan.Classes;

namespace Lab08_Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConversion();
        }

        static void JsonConversion()
        {
            string filePath = "../../../../data.json";
            string data = "";

           // Check file exists
           // FileAttributes attributes = File.GetAttributes(filePath);
           //
           // switch (attributes)
           // {
           //     case FileAttributes.Directory:
           //         if (Directory.Exists(filePath))
           //             Console.WriteLine("This directory exists.");
           //         else
           //             Console.WriteLine("This directory does not exist.");
           //         break;
           //     default:
           //         if (File.Exists(filePath))
           //             Console.WriteLine("This file exists.");
           //         else
           //             Console.WriteLine("This file does not exist.");
           //         break;
           // }
           
            
        using (StreamReader sr = File.OpenText(filePath))
        {
            data = sr.ReadToEnd();
        }

        //deserialize JSON and box the into features that are linked together. 
        var jsonData = JsonConvert.DeserializeObject<MainObject>(data);
        var lambdaNeighborhood = jsonData.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood); ;

            //output all the neighborhoods
            var allNeighborhood = from allhoods in lambdaNeighborhood
                                  select allhoods;

            Console.WriteLine("All the neighborhoods in Manhattan");
            foreach(var location in allNeighborhood)
            {
               Console.WriteLine(location);
            }
            nextSteps("Take all the null neighborhoods from the result and put them in order.");

            Console.WriteLine("All the null neighborhoods are out from this result");
            //remove all the nulls from the data
            var noNullQuery = (from hoods in lambdaNeighborhood
                                 orderby hoods
                                 where hoods != ""
                                 select hoods);

            foreach (var noNullVals in noNullQuery)
            {
                Console.WriteLine(noNullVals);
            }
            nextSteps("Take all the duplicates out from the result.");

            Console.WriteLine("All the duplicates are out from this result");
            //output out all the distinct neighborhoods 
            var distinctNeighborhoods = (from allhoods in lambdaNeighborhood
                                 orderby allhoods
                                select allhoods).Distinct();

            foreach( var distinctVals in distinctNeighborhoods)
            {
                Console.WriteLine(distinctVals);
            }
            nextSteps("Writing all the previous work in a single query");

            // do all the previous steps in one query
            Console.WriteLine("All the outputs in a single query");
            var allInOneQuery = (from hoods in lambdaNeighborhood
                                 orderby hoods
                                 where hoods != ""
                                 select hoods).Distinct();

            foreach(var allQueryVals in allInOneQuery)
            {
                Console.WriteLine(allQueryVals);
            }
            nextSteps("distinct Neighborhood using Lambda");

            //filter out all the neighborhoods that do not have any names
            Console.WriteLine("This is the output without LINQ");
            var lambdaNewVals = lambdaNeighborhood.Where(hood => hood != "").Distinct().OrderBy(hood => hood);

            foreach (var newVals in lambdaNewVals)
            {
                Console.WriteLine(newVals);
            }
        }

        public static void nextSteps(string toDo)
        {
            Console.WriteLine($" #### We will now find {toDo} #######");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
        }
    }
}
