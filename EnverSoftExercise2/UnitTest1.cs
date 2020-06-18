using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessInputData;

namespace EnverSoftExercise2
{
  

    [TestClass]
    public class UnitTest1
    {  
        ProcessInputFile process = new ProcessInputFile();
        List<string> TestOutput = new List<string>();
        List<string> Result = new List<string>();
        List<string> TestInput = new List<string>();


        [TestMethod]
        public void SortFullList()
        {
            List<string> outputNames = new List<string>();
            List<string> outputAddress = new List<string>();
            TestInput.Add("Matt Brown 12 Acton St");
            TestInput.Add("Heinrich Jones 31 Clifton Rd");
            TestInput.Add("Johnson Smith 22 Jones Rd");
            TestInput.Add("Tim Johnson 22 Jones Rd");

            outputAddress.Add("12 Acton St");
            outputAddress.Add("31 Clifton Rd");
            outputAddress.Add("22 Jones Rd");
            outputAddress.Add("22 Jones Rd");

            outputNames.Add("Johnson,2");
            outputNames.Add("Brown,1");
            outputNames.Add("Heinrich,1");
            outputNames.Add("Jones,1");
            outputNames.Add("Matt,1");
            outputNames.Add("Smith,1");
            outputNames.Add("Tim,1");

            var lists = process.ProcessInputString(TestInput);
            var resultNames = lists.Item1;
            var resultAddress = lists.Item2;

            CollectionAssert.AreEqual(outputNames, resultNames);
            CollectionAssert.AreEqual(outputAddress, resultAddress);
        }

        [TestMethod]
        public void TestSortAndOrderByStreetName()
        {
            TestInput.Add("22 Jones Rd");
            TestInput.Add("12 Acton St");
            TestInput.Add("22 Jones Rd");
            TestInput.Add("31 Clifton Rd");

            TestOutput.Add("12 Acton St");
            TestOutput.Add("31 Clifton Rd");
            TestOutput.Add("22 Jones Rd");
            TestOutput.Add("22 Jones Rd");

            Result = process.SortAndOrderByStreetName(TestInput);
            CollectionAssert.AreEqual(TestOutput, Result);


        }
        [TestMethod]
        public void TestSortAndOrderByCountDescThenByNameAsc()
        {
            TestInput.Add("Matt");
            TestInput.Add("Brown");
            TestInput.Add("Heinrich");
            TestInput.Add("Jones");
            TestInput.Add("Johnson");
            TestInput.Add("Smith");
            TestInput.Add("Tim");
            TestInput.Add("Johnson");

            TestOutput.Add("Johnson,2");
            TestOutput.Add("Brown,1");
            TestOutput.Add("Heinrich,1");
            TestOutput.Add("Jones,1");
            TestOutput.Add("Matt,1");
            TestOutput.Add("Smith,1");
            TestOutput.Add("Tim,1");

            Result = process.SortAndOrderByCountDescThenByNameAsc(TestInput);
            CollectionAssert.AreEqual(TestOutput, Result);
        }
    }
}
