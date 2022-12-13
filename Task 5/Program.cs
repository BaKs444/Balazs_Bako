using NUnit.Framework;
using System.Collections.Generic;


namespace HomeTasks
{
    using System.Collections.Generic;

    public class HomeTask
    {

        #region Taks5

        string sortGuests(string guests)
        {
            guests = guests.ToUpper(); //Upper case the string of guests

            var listOfNames = new List<string>();

            listOfNames = guests.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)   //split the string to arrays by the semicolons.
                                .ToList();

            var newList = new List<string>();

            foreach (var name in listOfNames)      //Split the first name and last name by : and rearrange it.
            {
                string newName = name.Split(':')[1] + ", " + name.Split(':')[0];
                newList.Add(newName);
            }

            newList.Sort();    //Sort the new list alphabetical order.

            string result = "(" + string.Join(")(", newList) + ")"; //Join the list to a string in the requierd format.

            return result;
        }

        #endregion

        #region Task5 Tests

        [Test]
        public void Test1()
        {
            string guestList = "Fired:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expectedResult = "(CORWILL, ALFRED)(CORWILL, FIRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            string actualResult = sortGuests(guestList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            string guestList = "Albert:Einstein;Rene:Descartes;Isaac:Newton;Niels:Bohr;Robert:Brown";
            string expectedResult = "(BOHR, NIELS)(BROWN, ROBERT)(DESCARTES, RENE)(EINSTEIN, ALBERT)(NEWTON, ISAAC)";

            string actualResult = sortGuests(guestList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

    }
}