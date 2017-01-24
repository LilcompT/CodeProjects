using System;
using System.Collections.Generic;


namespace ConsoleApplication
{
    ///<summary>
    /// BankCore class contains methods which will enable user Authentication and the creation of new users.
    /// The class also operates the flow of the program in terms of how the user account can be created 
    /// and what operations are available to the user once they are authenticated into the bank system.
    ///</summary>
    public class BankCore
    {
        // List contains all the bank accounts, which take UserAccountManagement class as type
        private static List<UserAccountManagement> accountList = new List<UserAccountManagement>();
        // global userID to act a session ID which will act as a index when accessing the accountList
        private static int userID = 0;
        private enum LoginInput {userLogin = 1, userAdd, userExit};
        private enum AccountOptions {accountView = 1, accountDeposit, accountWidthraw, accountLogout};  

        public static void Main(string[] args)
        {
            BankCore Bc = new BankCore();

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("WELCOME TO THE BANK OF LEARNING");
            Console.WriteLine("---------------------------------");
            
            // Dummy accounts
            accountList.Add(new UserAccountManagement("bob", "12", 1));
            accountList.Add(new UserAccountManagement("james", "34", 2));

            // Initiates the Bank front-end
            Bc.BankFront();
        }

        ///<summary>
        /// BankFront Method is responsible for acting like a user interface, which will allow
        //  the user pick options regardings the operations that are currently available.
        ///</summary>
        private void BankFront()
        {
            // Holds user input
            int optionInput = 0;
            // Will contain the last index of the List, to be used when progressing from AddNewUser method.
            int lastIndex = 0;
        
            Console.WriteLine();
            Console.WriteLine("Please select an option");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Exsisting User");
            Console.WriteLine("2. New Member");
            Console.WriteLine("3. Exit\n");
            Console.Write("Option: ");
            optionInput = Int32.Parse(Console.ReadLine());
            
            /*  Option 1 will execute the Authentication mechinism, where if the condition is met
                then the user will be proceeded to the bank front-end.
                Else if the condition fails then then Login failure message will be displayed  
            */
            if(optionInput == 1)
            {
                if(Authentication() == true)
                {
                    DisplayMainInterface(userID);
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }
            /*
                If Option 2 is inputted then AddNewUser method will be executed, enabling the insertion
                of new users.
            */
            else if(optionInput == 2)
            {
                // Executes the AddNewUser enabling user account creationa and insertion into the accountList
                AddNewUser();
                // Retrives the last index of the accountList to enforce progression of the user account/program flow
                lastIndex = accountList.Count - 1;
                // Displays the user interface where the user case choose account operations
                DisplayMainInterface(lastIndex);
            }
            else if(optionInput ==  3)
            {
                //System exit
            }
        }
        ///<summary>
        /// Method AddNewUser enables the creation of new user bank accounts, where its account, name, password
        /// and account type can be defined. Consequentially the user account is directed added into the accountList 
        /// upon the retrival of user input.
        ///</summary>
        private void AddNewUser()
        {
            string userName = "";
            string passcode = "";
            int accountType = 0;

            Console.Write("\nEnter full name: ");
            userName = Console.ReadLine();
            Console.Write("\nEnter new passcode: ");
            passcode = Console.ReadLine();
            Console.Write("\nChoose Account Type");
            Console.Write("\n1. Create Current Account\t\t 2. Create Savings Account");
            Console.Write("\nOption: ");
            accountType = Int32.Parse(Console.ReadLine());

            // Creates a new UserAccountManagement object with the parameters of the user account info
            accountList.Add(new UserAccountManagement(userName, passcode, accountType));
        }

        ///<summary>
        /// Method Authentication processes the log-in mechinism for the user account based on the
        /// information provided. The method returns a boolean which can be used to determine whether
        /// if the user credentials match the present credentials in the accountList.
        ///</summary>
        public bool Authentication()
        {
           string loginName = "";
           string loginPass = "";
           int attempt = 0;
           int index = 0;
           
           Console.Write("Enter name: ");
           loginName = Console.ReadLine();
        
           Console.WriteLine();
           Console.Write("Enter passcode: ");
           loginPass = Console.ReadLine();
           
           // While loop to control the amount of attempts user can make
           while(attempt != 1)
           {
               // Traverses the accountList to seek the appropriate information, if exsisting
               foreach(UserAccountManagement user in accountList)
               {
                   if(loginName == user.UserName && loginPass == user.UserPasscode)
                   {    
                       // sets up the account index which will allocate the correct corrosponding account
                       userID = index;
                       Console.WriteLine("List index: " + userID);
                       // credentials are matched so return true
                       return true;
                   }

                   // Updates the index whilst Traversing the accountList
                   ++index;
               }
               // Updates the amount of attempts made by the users
               attempt++;
           }
           // Returns false if no corrosponding account matches are found based on the input provided
           return false;
        }

        ///<summary>
        /// Method DisplayMainInterface is responsible for presenting the account operates which the user
        /// can make on their account.
        ///</summary>
        private void DisplayMainInterface(int userID)
        {
            int OptionInput = 0;
            int ID = userID;
            double cashInput = 0.0;
            const int currentAccType = 1;
            const int savingAccType = 2;
            bool taskNotFinished = true;

            Console.WriteLine("1. View Account\t\t\t\t2. Deposit Cash");
            Console.WriteLine("3. Widthraw Cash\t\t\t4. Log Out");

            OptionInput = Int32.Parse(Console.ReadLine());
            while(taskNotFinished)
            {
                switch(OptionInput)
                {
                    case 1:
                        accountList[userID].ViewAccount();
                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 2:
                        Console.Write("\nAmount to Deposit: ");
                        cashInput = double.Parse(Console.ReadLine());
                        
                        if(accountList[userID].accountType == currentAccType)
                        {
                            accountList[userID].Deposit(cashInput, currentAccType);
                        }
                        else if(accountList[userID].accountType == savingAccType)
                        {
                            accountList[userID].Deposit(cashInput, savingAccType);
                        }
                        
                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 3:
                        Console.Write("\nAmount to Widthraw: ");
                        cashInput = double.Parse(Console.ReadLine());
                        
                        if(accountList[userID].accountType  == currentAccType)
                        {
                            accountList[userID].Withdraw(cashInput, currentAccType);
                        }
                        else if(accountList[userID].accountType == savingAccType)
                        {
                            accountList[userID].Withdraw(cashInput, savingAccType);
                        }

                        taskNotFinished = false;
                        DisplayMainInterface(userID);
                        break;
                    case 4:
                        BankFront();
                        taskNotFinished = false;
                        
                        break;
                }
            }
        }
    }
    public abstract class Account
    {
        // Widthrawal Method
        public abstract void Withdraw(double cashAmt, int accountType);
        // Deposit Method
        public abstract void Deposit(double cashAmt, int accountType);

        public abstract void ViewAccount();
    }
    class UserAccountManagement : Account
    {
       private  string name;
       private string passcode;
       private int accType;
       private double currentBalance = 1000.00;
       private double savingBalance = 900.00;

       public UserAccountManagement()
       {

       }
       public  UserAccountManagement(string name, string passcode, int accType)
       {
           this.name = name;
           this.passcode = passcode;
           this.accType = accType;
       }

       public override void Deposit(double cashAmt, int accountType)
       {
           if(accountType == 1)
           {
               currentBalance += cashAmt; 
           }
           else if(accountType == 2)
           {
               savingBalance += cashAmt;
           }
       }
       public override void Withdraw(double cashAmt, int accountType)
       {
           if(accountType == 1)
           {
               currentBalance -= cashAmt;
           }
           else if(accountType == 2)
           {
               savingBalance -= cashAmt;
           }
       }
       public override void ViewAccount()
       {   
           if(accType == 1)
           {
               Console.WriteLine("Name: {0} Account Type: {1} Balanace Remaining: {2}", name, accType, currentBalance);
           }
           else if(accType == 2)
           {
               Console.WriteLine("Name: {0} Account Type: {1} Balanace Remaining: {2}", name, accType, savingBalance);
           }
       }
       public string UserName
       {
           get
           {
               return name;
           }
       }
       public string UserPasscode
       {
           get
           {
               return passcode;
           }
       }
       public int accountType
       {
           get
           {
               return accType;
           }
       }
    }
}
