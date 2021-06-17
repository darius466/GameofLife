using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace StringLibraryTest
{   
    [TestClass]
    public class UnitTest1
    {
        // dotnet test GOL-Library-Test/GOL-Library-Test.csproj 
        [TestMethod]
        public void ruleOne() 
        {
            StringLibrary g = new StringLibrary();
            int runs = 2;
            int i = 0;

            while(i < runs) {
                g.growNextTest();
                i++;
            }
            Assert.AreEqual(0, g.getOne()); //the value of the cell at this grid coordinate should be 0 after one generation 
        }

        [TestMethod]
        public void ruletwo() 
        {
            StringLibrary g = new StringLibrary();
            int runs = 2;
            int i = 0;

            while(i < runs) {
                g.growNextTest();
                i++;
            }
            Assert.AreEqual(1, g.getTwo()); //the value of the cell at this grid coordinate should be 1 after one generation 
        }

        [TestMethod]
        public void ruleThree() 
        {
            StringLibrary g = new StringLibrary();
            int runs = 2;
            int i = 0;

            while(i < runs) {
                g.growNextTest();
                i++;
            }
            Assert.AreEqual(0, g.getThree()); //the value of the cell at this grid coordinate should be 0 after one generation 
        }

        [TestMethod]
        public void ruleFour() 
        {
            StringLibrary g = new StringLibrary();
            int runs = 2;
            int i = 0;

            while(i < runs) {
                g.growNextTest();
                i++;
            }
            Assert.AreEqual(1, g.getFour()); //the value of the cell at this grid coordinate should be 1 after one generation 
        }



    }
}
