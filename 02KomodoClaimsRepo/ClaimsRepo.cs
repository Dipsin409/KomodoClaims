using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsInsurance_Repo
{
    public class ClaimsRepo
    {
        private List<ClaimClass> _listOfClaimsRepoItems = new List<ClaimClass>();


        //Create
        public bool CreateClaim(ClaimClass content)
        {
            int startingCount = _listOfClaimsRepoItems.Count;
            _listOfClaimsRepoItems.Add(content);
            bool wasadded = _listOfClaimsRepoItems.Count > startingCount;
            return wasadded;
        }


        //Read

        //Update

        //Delete
    }
}
