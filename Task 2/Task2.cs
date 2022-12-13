using NUnit.Framework;
using System.Collections.Generic;


namespace HomeTasks
{
    using System.Collections.Generic;

    public class HomeTask
    {
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
                    if ((i != j) && (chars[i] == chars[j] || Char.ToUpper(chars[i]) == chars[j] || Char.ToLower(chars[i]) == chars[j]))
                    {
                        repeted = true;                     //break from the iteration and move to the next letter
                        break;
                    }
                }
                if (repeted == false)                //we iterate through the string and not find any duplicants
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
        public void Test1()
        {
            string sentance = "abcdefghab";
            char expected = 'c';

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }

        [Test]
        public void Test2()
        {
            string sentance = "";
            char expected = default;

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }
        [Test]
        public void Test3()
        {
            string sentance = "aaaaaaa";
            char expected = default;

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }

        [Test]
        public void Test4()
        {
            string sentance = "AbcaBDC";
            char expected = 'D';

            Assert.AreEqual(First_Non_Repeating_Letter(sentance), expected);
        }
    }
}
        #endregion Task2