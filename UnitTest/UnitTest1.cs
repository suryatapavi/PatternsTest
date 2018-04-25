using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScopeAR;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Character_Space()
        {
            //Assemble
            Characters Ch = new Characters();
            string expected = "  ";
            //Actual 
            string actualRes = Ch.Space(2);
            //Assert
            Assert.AreEqual(expected, actualRes);
        }

        [TestMethod]
        public void Test_Character_Star()
        {
            //Assemble
            Characters Ch = new Characters();
            string expected = "***";
            //Actual 
            string actualRes = Ch.Star(3);
            //Assert
            Assert.AreEqual(expected, actualRes);
        }

        [TestMethod]
        public void Test_Character_Newline()
        {
            //Assemble
            Characters Ch = new Characters();
            string expected = "\n\n\n\n";
            //Actual 
            string actualRes = Ch.Newline(4);
            //Assert
            Assert.AreEqual(expected, actualRes);
        }

        [TestMethod]
        public void Test_Pattern_Tree()
        {
            //Assemble
            treePattern tree = new treePattern(2);
            string expected = " * \n***\n";
            //Actual
            tree.SetPattern();
            string actualRes = tree._pattern.ToString();
            //Assert
            Assert.AreEqual(expected, actualRes);
        }

        [TestMethod]
        public void Test_Pattern_Cross()
        {
            //Assemble
            crossPattern cross = new crossPattern(3);
            string expected = "*   *\n  *  \n*   *\n";
            //Actual
            cross.SetPattern();
            string actualRes = cross._pattern.ToString();
            //Assert
            Assert.AreEqual(expected, actualRes);
        }
    }
}
