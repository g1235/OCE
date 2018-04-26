using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeCoreExer.UnitTests
{
    class ItunesService_Tests
    {

        [TestCase("abba", 10)]
        [TestCase("Pink Floid", 10)]
        [TestCase("", 0)]
        public void Check_ItunesService_Results_For_Variouse_Inputs(string input, int ExpectedRetCount)
        {
            ItunesService its = new ItunesService();
            var res=its.Fetch10RndSongs(input);

            Assert.AreEqual(res.Count(), ExpectedRetCount);
        }
    }
}
