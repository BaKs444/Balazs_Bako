using NUnit.Framework;
using System.Collections.Generic;


namespace HomeTasks
{
    using System.Collections.Generic;

    public class HomeTask
    {
        #region Task3

        int digital_Root(int numberToAdd)
        {
            int[] arrayOfDigits = numberToAdd.ToString().Select(c => Convert.ToInt32(c) - 48).ToArray();
            int sumOfDigits = 0;

            foreach (int digit in arrayOfDigits)
            {
                sumOfDigits = sumOfDigits + digit;
            }

            if (sumOfDigits >= 10)
            {
                return digital_Root(sumOfDigits);
            }
            else
            {
                return sumOfDigits;
            }
        }

        #endregion

        #region Task3 Tests
        [Test]
        public void Test1()
        {
            int expectedResult = 7;
            int actualResult = digital_Root(16);


            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            int expectedResult = 2;
            int actualResult = digital_Root(493193);


            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test3()
        {
            int expectedResult = 6;
            int actualResult = digital_Root(132189);


            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion
    }
}