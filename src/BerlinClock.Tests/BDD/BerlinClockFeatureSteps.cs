﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly TimeConverter _berlinClock = new TimeConverter();
        private string _theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(_berlinClock.ConvertTime(_theTime), theExpectedBerlinClockOutput);
        }

    }
}