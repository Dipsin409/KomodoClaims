using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsInsurance_Repo
{

    //POCO
    //Plain Old C# Object 
    public enum ClaimType { }
    public class ClaimClass
    {

        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public string IsValid { get; set; }
        
        public ClaimClass () { }
        public ClaimClass(int claimID, string claimType, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, string isValid)
        {

            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        static void Main(string[] args)
        {
        }
    }
}
