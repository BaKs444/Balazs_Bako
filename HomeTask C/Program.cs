using NUnit.Framework;
using System.Collections.Generic;

namespace HomeTasks
{
    using System.Collections.Generic;
    public class HomeTask
    {
        #region Task1

        //The GetIntegersFromList method takes a List<object> that could held any
        //data types, than return a List<int> which contains just the integer
        //data from the original list.
        List<int> GetIntegersFromList(List<object> list)
        {
            var sortedList = new List<int>();
            foreach (var item in list)
            {
                if (item is int)
                {
                    sortedList.Add((int)item);
                }
            }
            return sortedList;
        }
        #endregion

        #region Task1 Tests

        [Test]
        public void Test1()
        {
            var list = new List<object>() { 1, 2, "alma", };

            var actualList = GetIntegersFromList(list);
            var expectedList = new List<int>() { 1, 2 };

            Assert.AreEqual(expectedList, actualList);
        }
        [Test]
        public void Test2()
        {
            var list = new List<object>() { 1, 2, "alma", "banán", 4, 12, 0, 'a' };

            var actualList = GetIntegersFromList(list);
            var expectedList = new List<int>() { 1, 2, 4, 12, 0 };

            Assert.AreEqual(expectedList, actualList);
        }
        #endregion Task1

        #region Task2
        //Function that returns the first non-repeated character.
        char First_Non_Repeating_Letter(string sentance)
        {
            bool repeted = false;
            char[] chars = sentance.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                repeted = false;                            // we break because it is changed to 'true' so we declare again it 'false'
                for (int j = 0; j < chars.Length; j++)
                {
                    if ((i != j) && (chars[i] == chars[j]))
                    {
                        repeted = true;                     //break from the iteration and move to the next letter
                        break;
                    }
                }
                if (repeted == false)                //we iterate throug the string and not find any duplicants
                {
                    return chars[i];                //so we can return char in index 'i'
                }
            }
            char None = default;
            return None;
        }
        #endregion

        #region Task2 Tests

        [Test]
        public void Test3()
        {
            string sentance = "abcdefghab";
            char expected = 'c';

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }

        [Test]
        public void Test4()
        {
            string sentance = "";
            char expected = default;

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }
        [Test]
        public void Test5()
        {
            string sentance = "aaaaaaa";
            char expected = default;

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }
        #endregion Task2

        #region Task3

        int digital_Root(int number)
        {
            int addNumbers(int numberToAdd) //A function that convert to array, and sum the digits.
            {
                int[] arrayOfDigits = numberToAdd.ToString().Select(c => Convert.ToInt32(c) - 48).ToArray(); //Convert the number int into an array of ints.
                int sumOfDigits = 0; //To contain the sum of Digits and return it.

                foreach (int digit in arrayOfDigits) //Add the digits and return it.
                {
                    sumOfDigits = sumOfDigits + digit;
                }
                return sumOfDigits;
            }

            while (number >= 10) //Check that te number is greater or equal to 10 -> at least 2 digits, so have to add the digits again.
            {
                number = addNumbers(number);
            }

            return number;  //return the 1 digit sum.
        }

        #endregion

        #region Task3 Tests
        [Test]
        public void Test6()
        {
            int expectedResult = 7;
            int actualResult = digital_Root(16);


            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test7()
        {
            int expectedResult = 2;
            int actualResult = digital_Root(493193);


            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test8()
        {
            int expectedResult = 6;
            int actualResult = digital_Root(132189);


            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

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
        public void Test9()
        {
            int expectedResult = 4;
            int[] array = new int[] { 1, 3, 6, 2, 2, 0, 4, 5 };

            int actualResult = countPairsEqualTarget(5, array);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test10()
        {
            int target = 2;
            int[] array = new int[] { 1, 1, 1, 1, 1, 1 };

            int expectedResult = 15;
            int actualResult = countPairsEqualTarget(target, array);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test11()
        {
            int target = 0;
            int[] array = new int[] { 2, 3, 4, 5 };

            int expectedResult = 0;
            int actualResult = countPairsEqualTarget(target, array);

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Taks5
        string sortGuests(string guests)
        {
            guests = guests.ToUpper();

            var listOfNames = new List<string>();

            listOfNames = guests.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            var newList = new List<string>();

            foreach (var name in listOfNames)
            {
                string newName = name.Split(':')[1] + ", " + name.Split(':')[0];
                newList.Add(newName);
            }

            newList.Sort();

            string result = "(" + string.Join(")(", newList) + ")";

            return result;
        }

        #endregion

        #region Task5 Tests

        [Test]
        public void Test12()
        {
            string guestList = "Fired:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expectedResult = "(CORWILL, ALFRED)(CORWILL, FIRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            string actualResult = sortGuests(guestList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test13()
        {
            string guestList = "Albert:Einstein;Rene:Descartes;Isaac:Newton;Niels:Bohr;Robert:Brown";
            string expectedResult = "(BOHR, NIELS)(BROWN, ROBERT)(DESCARTES, RENE)(EINSTEIN, ALBERT)(NEWTON, ISAAC)";

            string actualResult = sortGuests(guestList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

    }
}
