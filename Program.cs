using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ConsoleJSONParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = File.ReadAllText("input.json");
            //Sample json in escaped form - unescape it
            var jsonString = Regex.Unescape(inputFile);

            //jsonString - our json from web api

            //Deserialize to object
            var result = JsonConvert.DeserializeObject<List<RIS.Models.VWModels.VMRISWorklist>>(jsonString);

            //Test deserialized data as printing each value=property of object
            foreach(var item in result)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(item))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(item);
                    Console.WriteLine("{0}={1}", name, value);
                }
                Console.WriteLine("\n\n");
            }
            Console.ReadLine();
        }
    }
}
