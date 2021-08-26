using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsInsurance_Repo
{
    public class ClaimsRepo
    {
        private Queue<Claims> _QueueOfClaimsRepoItems = new Queue<Claims>();


        //Create
        public void AddNewClaim(Claims content)
        {
            _QueueOfClaimsRepoItems.Enqueue(content);
        }

        //Read
        public Queue<Claims> GetClaimsQueue()
        {
            return _QueueOfClaimsRepoItems;
        }

        //Update


        //Delete
        public bool RemoveClaimsFromQueue()
        {
            int initialCount = _QueueOfClaimsRepoItems.Count;
            _QueueOfClaimsRepoItems.Dequeue();

            if (initialCount > _QueueOfClaimsRepoItems.Count)
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
            foreach (Claims content in _QueueOfClaimsRepoItems)
            {
                if (content.ClaimsID == title)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
