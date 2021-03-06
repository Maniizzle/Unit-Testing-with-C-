using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameEngine.Test
{
   public class ExternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData 
        {
            get
            {
                string[] csvLines = File.ReadAllLines("TestData.csv");
                var testCases = new List<object[]>();
                foreach (var csvline in csvLines)
                {
                    IEnumerable<int> values = csvline.Split(',').Select(int.Parse);
                    object[] testCase = values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
