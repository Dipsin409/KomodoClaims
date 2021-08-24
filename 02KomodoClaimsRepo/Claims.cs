using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsInsurance_Repo
{

    //POCO
    //Plain Old C# Object 
    public enum ClaimType { Car = 1, Home, Theft}
    public class Claims
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }
        public Claims () { }
        public Claims(int claimID, string claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        { 
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }
        public bool IsValid
        {
            get
            {
                int numberOfDays = Convert.ToInt32(DateOfClaim - DateOfIncident);
                if (numberOfDays >30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
