using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robotdammsugare_Sawubona_Claes_R;

namespace UnitTestsVacuum
{
    [TestClass]
    public class UnitTest_ProofOfConcept
    {
        [TestMethod]
        public void ParseMap_WhenStringLacksM_ShouldReturnNull()
        {
            string input = "[W1, N1, E1, E1, S1, S1, W1, W1, N1, E1]; S: 0,0; : -1,1,-1,1";

            var result = InputParser.ParseMap(input);

            Assert.AreEqual(null, result);
        }
    }
}