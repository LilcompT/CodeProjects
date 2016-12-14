using System;

namespace SocialNetworkExperiment
{
    public class SocialNetworkMain
    {
        public static void Main(string[] args)
        {
            // Variables Declaration
            bool userSession = false;

            // Object Creation
            SocialNetworkMain sn = new SocialNetworkMain();
            
            if(sn.SigninMech() == true)
            {
                userSession = true;
            }

            while(userSession == true)
            {
                // Display User Feed
            }
        }

        private bool SigninMech()
        {
            string userName = "bob";
            string input = "";
            int attempt;

            Console.Write("Enter Username: ");
            input = Console.ReadLine();

            for(attempt = 2; attempt != 0; attempt--)
            {
                if(input == userName)
                {
                    Console.WriteLine("Login Successful");
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect, you have " + attempt + " remaining");
                    Console.Write("Enter Username: ");
                    input = Console.ReadLine();    
                }
            }

            return false;
        }
    }
    public class UserFeedback
    {

    }
}
