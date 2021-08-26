using _02_KomodoClaimsInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    class ProgramUI
    {
        private readonly ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        public void SeedContent()
        {
            Console.WriteLine("Seeding content...");
            Claims c1 = new Claims("01", ClaimType.Home, "House was on fire and everyone died.", 120223.21m, new DateTime(2021, 4, 09), new DateTime(2021, 4, 11));
            Claims c2 = new Claims("02", ClaimType.Car, "Car crash resulting in total of vehicle.", 56000.00m, new DateTime(2021, 6, 24), new DateTime(2021, 7, 20));
            Claims c3 = new Claims("03", ClaimType.Theft, "Home theft resulting in all of posetions stollen", 13000.62m, new DateTime(1986, 2, 23), new DateTime(1986, 4, 20));
            _repo.AddNewClaim(c1);
            _repo.AddNewClaim(c2);
            _repo.AddNewClaim(c3);
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Menu:\n" +
                    "1. See all claims...\n" +
                    "2. Take care of next claim...\n" +
                    "3. Enter a new claim...\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;

                    case "2":
                        TakeCareOfNextClaim();
                        break;

                    case "3":
                        EnterANewClaim();
                        break;

                    case "5":
                        keepRunning = false;
                        break;

                    default:

                        Console.WriteLine("Please enter a valid selection...\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
            // number 1
            void SeeAllClaims()
            {
                Queue<Claims> claimClaim = _repo.GetClaimsQueue();
                foreach (Claims claim in claimClaim)
                {
                    Console.WriteLine($"ClaimID {claim.ClaimsID}" +
                        $"ClaimType {claim.ClaimsType}" +
                        $"ClaimDescription{claim.Description}" +
                        $"ClaimAmount{claim.ClaimAmount}" +
                        $"ClaimDateOfAccident{claim.DateOfIncident}" +
                        $"DateOfClaim{claim.DateOfClaim}" +
                        $"IsValid{claim.IsValid}");
                }
                Console.ReadKey();
            }
            // number 2
            void TakeCareOfNextClaim()
            {
                Console.Clear();
                Queue<Claims> claimsID = _repo.GetClaimsQueue();
                if (claimsID.Count() == 0)
                {
                    Console.WriteLine("No claims left..." +
                        "Press Any Key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Claims peek = claimsID.Peek();
                    Console.WriteLine("Looking at new claim...");
                    Console.WriteLine($"{peek.ClaimsID}" +
                        $"{peek.ClaimsType}" +
                        $"{peek.Description}" +
                        $"{peek.ClaimAmount}" +
                        $"{peek.DateOfIncident}" +
                        $"{peek.DateOfClaim}" +
                        $"{peek.IsValid}");
                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    string user = Console.ReadLine().ToLower();
                    if (user == "y")
                    {
                        Console.WriteLine("Do you want to permanantly delete this(y/n)?");
                        {
                            string player = Console.ReadLine().ToLower();
                            if (player == "y")
                            {
                                bool wasRemoved = _repo.RemoveClaimsFromQueue();
                                if (wasRemoved)
                                {
                                    Console.WriteLine("Was permanantly deleted...");
                                }
                                else
                                {
                                    Console.WriteLine("Unable to remove... ");
                                }
                            }
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine();
                }

            }
            // number 3
            void EnterANewClaim()
            {
                Console.Clear();
                Claims claim = new Claims();
                bool isValid = false;

                while (!isValid)
                {
                    Console.WriteLine("Claim ID: ");
                    string claimID = Console.ReadLine();
                    if (string.IsNullOrEmpty(claimID))
                    {
                        Console.WriteLine("Please Enter valid Claim ID...");
                    }
                    else
                    {
                        claim.ClaimsID = claimID;
                    }
                    break;
                }

                Console.Clear();
                Console.Write("Type: 1: Car\n" +
                    "2: Home\n" +
                    "3:Theft\n" +
                    "4: NA\n");
                Console.WriteLine("Enter Type #");
                string typeInput = Console.ReadLine();
                int typeID = int.Parse(typeInput);
                claim.ClaimsType = (ClaimType)typeID;

                Console.Clear();
                Console.WriteLine("Claim Amount : ");
                string claimAmount = Console.ReadLine();

                if (string.IsNullOrEmpty(claimAmount))
                {
                    Console.WriteLine("Please Enter Valid Amount...");
                }
                else
                {
                    claim.ClaimAmount = (decimal)Convert.ToDouble(claimAmount);
                }

                Console.Clear();
                Console.WriteLine("Enter Date Of Incident ex. yyyy/mm/dd...");
                string dateOfIncident = Console.ReadLine();

                if (string.IsNullOrEmpty(dateOfIncident))
                {
                    Console.WriteLine("Please Enter Valid Date...");
                }
                else
                {
                    claim.DateOfIncident = Convert.ToDateTime(dateOfIncident);
                }

                Console.Clear();
                Console.WriteLine("Enter Date of Claim ex.... yyyy/mm/dd.... Date of Claim Must Not Be > 30 Days From Date Of Incident.");
                string dateOfClaim = (Console.ReadLine());

                if (string.IsNullOrEmpty(dateOfClaim))
                {
                    Console.WriteLine("Please Enter Valid Date...");
                }
                else
                {
                    claim.DateOfClaim = Convert.ToDateTime(dateOfClaim);
                }

                Console.Clear();
                Console.WriteLine("Please Enter A Description Of Claim...");
                string claimDesription = Console.ReadLine();

                if (string.IsNullOrEmpty(claimDesription))
                {
                    Console.WriteLine("Please Enter Valid Description...");
                }
                else
                {
                    claim.Description = claimDesription;
                }

                _repo.AddNewClaim(claim);
                Console.Clear();
                Console.WriteLine("Claim Added...");

            }

        }
    }
}



