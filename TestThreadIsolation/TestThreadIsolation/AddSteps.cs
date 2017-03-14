﻿using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestCalculator;

namespace TestThreadIsolation
{
    [Binding]
    public class AddSteps
    {
        private static ICalculator _calculator;

        [BeforeFeature("Database")]
        public static void BeforeDatabase()
        {
            _calculator = new DatabaseCalculator();
        }

        [BeforeFeature("Memory")]
        public static void BeforeMemory()
        {
            _calculator = new MemoryCalculator();
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _calculator.Clear();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _calculator.EnterNumber(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0,_calculator.Result);
            Console.WriteLine(_calculator.GetType());
        }
    }
}
