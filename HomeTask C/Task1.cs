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
    }
}
