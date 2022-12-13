using NUnit.Framework;
using System.Collections.Generic;


namespace HomeTasks
{
    using System.Collections.Generic;

    public class HomeTask
    {

        #region ExtraTask

        int nextGreaterInt(int number)
        {
            string numberString = number.ToString();
            char[] charArray = numberString.ToCharArray();    // Transform the int to char array.
            int count = 1;

            if (charArray.Length == 1)                      //If char array length = 1 no swap can made -> return -1.
            {
                return -1;
            }

            int allDigitsSame = 0;

            for (int i = 0; i < charArray.Length - 1; i++)
            {

                if (charArray[i] != charArray[i + 1])       //If all digits the same then no swap can made -> return -1.
                {
                    allDigitsSame++;
                }

            }
            if (allDigitsSame == 0)
            {
                return -1;
            }

            int noGreater = 0;

            for (int i = 0; i < charArray.Length - 1; i++)      //If number already the greatest -> no swap can made -> return -1.
            {
                if (charArray[i] < charArray[i + 1])
                {
                    noGreater++;
                }
            }
            if (noGreater == 0)
            {
                return -1;
            }

            // If all above are false we can find the nextr greater number.

            for (int i = charArray.Length - 2; i >= 0; i--)
            {
                if (charArray[i] < charArray[i + 1])        //check from the rigth that we can find a digit that is less then the pervious digit.
                {
                    for (int j = charArray.Length - 1; j >= i; j--)     //if the above is true, check which is the number that we passed, greater
                                                                        //than the found number, but the smallest among wich we passed.
                    {
                        if (charArray[i] < charArray[j])
                        {
                            char temp = charArray[i];               //Swap the two number.
                            charArray[i] = charArray[j];
                            charArray[j] = temp;
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    count++;                    //count how many digits we passed from the right, because we 
                                                //need to order it, to find the smallest number which is bigger than the original number.
                }
            }

            var lastDigitsOrdered = charArray.TakeLast(count).OrderBy(c => c); //cut and order the last digits

            var firstDigits = charArray.SkipLast(count);        //cut the first digits

            var resultNumberArray = firstDigits.Concat(lastDigitsOrdered); //concat the first and the last digits of the new number.


            string result = (string.Join("", resultNumberArray));   //Cast it to string

            int nextGreaterNumber = Int32.Parse(result); //Cast the string to int.

            return nextGreaterNumber;   //Return the next greater number
        }
        #endregion

        #region ExtraTask Tests

        [Test]
        public void Test1()
        {
            int originalNumber = 31467321;
            int expectedResult = 31471236;

            int actualResult = nextGreaterInt(originalNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            int originalNumber = 111111;
            int expectedResult = -1;

            int actualResult = nextGreaterInt(originalNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test3()
        {
            int originalNumber = 5;
            int expectedResult = -1;

            int actualResult = nextGreaterInt(originalNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test4()
        {
            int originalNumber = 54321;
            int expectedResult = -1;

            int actualResult = nextGreaterInt(originalNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion
    }
}