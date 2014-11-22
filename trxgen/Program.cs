using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace trxgen
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRunType testRun = new TestRunType();
            ResultsType results = new ResultsType();
            List<UnitTestResultType> unitResults = new List<UnitTestResultType>();
            var unitTestResult = new UnitTestResultType();
            unitTestResult.outcome = "passed";
            unitResults.Add(unitTestResult);

            unitTestResult = new UnitTestResultType();
            unitTestResult.outcome = "failed";
            unitResults.Add(unitTestResult);

            results.Items = unitResults.ToArray();
            results.ItemsElementName = new ItemsChoiceType3[2];
            results.ItemsElementName[0] = ItemsChoiceType3.UnitTestResult;
            results.ItemsElementName[1] = ItemsChoiceType3.UnitTestResult;

            List<ResultsType> resultsList = new List<ResultsType>();
            resultsList.Add(results);
            testRun.Items = resultsList.ToArray();

            XmlSerializer x = new XmlSerializer(testRun.GetType());
            x.Serialize(Console.Out, testRun);
            x.Serialize(new XmlTextWriter("test.trx", Encoding.UTF8), testRun);

            if (args.Length < 2)
            {
                Usage();
                return;
            }

        }

        static void Usage()
        {
            var programName = System.AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine();
            Console.WriteLine(programName);

        }
    }
}
