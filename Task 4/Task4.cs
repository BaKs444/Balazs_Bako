using NUnit.Framework;
using System.Collections.Generic;


namespace HomeTasks
{
    using System.Collections.Generic;

    public class HomeTask
    {
        #region Task4


        int countPairsEqualTarget(int target, int[] array)  //Method with target number and the array.
        {
            int count = 0;  //count the pairs

            for (int i = 0; i < array.Length; i++)          //Count the pairs from the start of the list thats sum equals the target number.
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)      //If pair found increase count.
                    {
                        count++;
                    }
                }

            }
            return count;                                   //return the number of pairs.
        }

        #endregion

        #region Task4 Tests

        [Test]
        public void Test1()
        {
            int expectedResult = 4;
            int[] array = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };

            int actualResult = countPairsEqualTarget(5, array);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            int target = 2;
            int[] array = new int[] { 1, 1, 1, 1, 1, 1 };

            int expectedResult = 15;
            int actualResult = countPairsEqualTarget(target, array);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test3()
        {
            int target = 0;
            int[] array = new int[] { 2, 3, 4, 5 };

            int expectedResult = 0;
            int actualResult = countPairsEqualTarget(target, array);

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

    }
}

