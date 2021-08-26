using _02_KomodoClaimsInsurance_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void SetTitle_SHouldSetCorrectString()
        {
            Claims content = new Claims();

         //   content.ClaimType = "Your Mom";

            string expected = "Your Mom";
           // string actual = content.ClaimType;

           // Assert.AreEqual(expected, actual);
        }
    }
}
