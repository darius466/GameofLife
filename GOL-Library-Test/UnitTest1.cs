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
            Assert.AreEqual(0, g.getOne());
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
            Assert.AreEqual(1, g.getTwo());
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
            Assert.AreEqual(0, g.getThree());
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
            Assert.AreEqual(1, g.getFour());
        }



    }
}
