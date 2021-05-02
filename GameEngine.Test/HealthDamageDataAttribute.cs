using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace GameEngine.Test
{
    public class HealthDamageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //yield return new object[] { 0, 100 };
            //yield return new object[] { 1, 99 };
            //yield return new object[] { 50, 50 };
            //yield return new object[] { 101, 1 };

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
