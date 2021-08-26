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
        public string ClaimsID { get; set; }
        public ClaimType ClaimsType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }
        public Claims () { }
        public Claims(string claimsID, ClaimType claimsType, string description, decimal claimsAmount, DateTime dateOfIncident, DateTime dateOfClaims )
        { 
            ClaimsID = claimsID;
            ClaimsType = claimsType;
            Description = description;
            ClaimAmount = claimsAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaims;

        }
        public bool IsValid
        {
            get
            {
                TimeSpan numberOfDays = DateOfClaim - DateOfIncident; //00:00:00
                double doubleName = numberOfDays.TotalDays;
                if (doubleName > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
