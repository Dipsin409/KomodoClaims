using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsInsurance_Repo
{
    public class ClaimsRepo
    {
        private List<Claims> _listOfClaimsRepoItems = new List<Claims>();


        //Create
        public void AddNewClaim(Claims content)
        {
            _listOfClaimsRepoItems.Add(content);
        }

        //Read
        public List<Claims> GetClaimsList()
        {
            return _listOfClaimsRepoItems;
        }

        //Update
        public bool UpdateExistingClaims(string originalTitle, Claims newContent)
        {
            // find content
            Claims oldContent = GetClaimByType(originalTitle);

            //update content
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.Description = newContent.Description;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;

                return true;

            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveClaimsFromList(string title)
        {
            Claims content = GetClaimByType(title);

            if (content == null)
            {
                return false;
            }
            int initialCount = _listOfClaimsRepoItems.Count;
            _listOfClaimsRepoItems.Remove(content);

            if (initialCount > _listOfClaimsRepoItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper Method
        private Claims GetClaimByType(string title)
        {
            foreach (Claims content in _listOfClaimsRepoItems)
            {
                if (content.ClaimType == title)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
