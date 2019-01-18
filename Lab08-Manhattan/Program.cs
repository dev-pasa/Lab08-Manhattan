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
            Console.WriteLine("Hello World!");
            JsonConversion();
        }

        static void JsonConversion()
        {
            string filePath = "../../../../data.json";
            string data = "";

            using (StreamReader sr = File.OpenText(filePath))
            {
                data = sr.ReadToEnd();
            }

            //deserialize JSON and convert to FeatureCollection
            MainObject jsonData = JsonConvert.DeserializeObject<MainObject>(filePath);


            var lambdaNeigh = jsonData.Features;

            foreach (var item in lambdaNeigh)
            {
                Console.WriteLine(item);
            }

        }
    }
}
