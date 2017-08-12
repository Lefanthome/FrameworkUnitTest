using FUnitTest;
using FUnitTest.Attributes;

namespace SeleniumTest
{
    [FTestClass]
    public class ClassTest
    {
        [FTestMethod]
        public void IsTrueOKTest()
        {
            FUnitCore.IsTrue(2 > 1);
        }

        [FTestMethod]
        public void IsTrueKOTest()
        {
            FUnitCore.IsTrue(1 > 2);
        }

        [FTestMethod]
        public void EgaliteOKTest()
        {
            FUnitCore.IsEquality(true, 1 == 1);
        }

        [FTestMethod]
        public void EgaliteKOTest()
        {
            FUnitCore.IsEquality(true, 2 == 1);
        }
    }
}
