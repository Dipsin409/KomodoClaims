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
        public int claimNumber { get; private set; }
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool continueToRun = true;

            while (continueToRun)
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

                    case "4":
                        Exit();
                        break;
                    case "exit":
                    case "EXIT":
                    case "5":
                        continueToRun = false;
                        break;

                    default:

                        Console.WriteLine("Please enter a valid selection...\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
