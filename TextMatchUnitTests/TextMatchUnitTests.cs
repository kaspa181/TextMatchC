using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch;

namespace TextMatchingUnitTests
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void printResults_empty()
        {
            int[] arr = {0};
            TextMatching s = new TextMatching();
            string textMatching = s.PrintResults(arr);

            Assert.AreEqual(null, textMatching);
        }
        [TestMethod]
        public void printResults_validValues()
        {
            int[] arr = new int[] {1,2,3,4,5,6,7,8,9,-1};
            TextMatching s = new TextMatching();
            string textMatching = s.PrintResults(arr);

            Assert.AreEqual("1,2,3,4,5,6,7,8,9", textMatching);
        }
        [TestMethod]
        public void printResults_invalidValues()
        {
            int[] arr = new int[] { 1, 2, 3, -1, 5, 6, 7, 8, 9 };
            TextMatching s = new TextMatching();
            string textMatching = s.PrintResults(arr);

            Assert.AreEqual("1,2,3", textMatching);
        }
        [TestMethod]
        public void findMatch_empty() 
        {
            int FromIndex = 0;
            string text="", subtext="";
            TextMatching tm = new TextMatching();
            tm.FindMatch(FromIndex, text, subtext);

        }
        [TestMethod]
        public void findMatch_validValues()
        {
            int FromIndex = 0;
            string text= "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", subtext="Polly";
            int expectedValue = 1;
            TextMatching tm = new TextMatching();
            int actualValue = tm.FindMatch(FromIndex, text, subtext);

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void findMatch_inValidValues_subtext()
        {
            int FromIndex = 0;
            string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", subtext = "xzy";
            int expectedValue = -1;
            TextMatching tm = new TextMatching();
            int actualValue = tm.FindMatch(FromIndex, text, subtext);

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void findMatch_ValidValues_lastIndex()
        {
            int FromIndex = 0;
            string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea z", subtext = "z";
            int expectedValue = 94;
            TextMatching tm = new TextMatching();
            int actualValue = tm.FindMatch(FromIndex, text, subtext);

            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod]
        public void calc_validValues()
        {
            string text = "polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", subtext = "polly";
            int[] expectedValues = { 1, 26, 51,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            TextMatching tm = new TextMatching();
            int[] actualValues = tm.Calc(text, subtext);

            for (int i = 0; i < actualValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], actualValues[i]);
            }
            

        }
        //invalid values of calc is checked by findMatch tests.


    }
}
