using static Bank_System_V_01.Program;
namespace Bank_System_V_01
{
    internal class Program
    {
        public struct Account
        {
            public string Name;
            public string Number;
            public double Balance;

        }
        static List<Account> accounts = new List<Account>();

        public static void showChoices()
        {
            Console.WriteLine("========== BANKING SYSTEM ==========\n\n");
            Console.WriteLine(" 1. Create Account ");
            Console.WriteLine(" 2. Deposit");
            Console.WriteLine(" 3. Withdraw");
            Console.WriteLine(" 4. Transfer Money");
            Console.WriteLine(" 5. Check Balance");
            Console.WriteLine(" 6. Account Information");
            Console.WriteLine(" 7. Transaction History");
            Console.WriteLine(" 8. Search Account");
            Console.WriteLine(" 9. Exit ");
            Console.WriteLine("\n");

        }

        public static bool checkAccountNumber(ref int m)
        {
            string accountNumber = Console.ReadLine();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Number == accountNumber)
                {
                    m = i;
                    return true;
                }
            }
            return false;
        }
        public static void CreateAccount()
        {
            Account account = new Account();

            Console.WriteLine("========== Create Account ==========\n");
            Console.Write("Enter your name: ");
            account.Name = Console.ReadLine();

            Console.Write("Enter account number: ");
            account.Number = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            account.Balance = Convert.ToDouble(Console.ReadLine());

            bool found = false;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Number == account.Number)
                {
                    found = true;
                    break;
                }
            }

            if (found)
                Console.WriteLine("\nAccount Number is Exists..");
            else
            {
                accounts.Add(account);
                Console.WriteLine("\nAccount created successfully!");
            }

            Console.WriteLine("\r\n====================================");

        }
        public static void Deposit()
        {
            Console.WriteLine("========== Deposit ==========\r\n");
            int m = -1;
            Console.Write("Account Number  : ");
            bool found = checkAccountNumber(ref m);
            if (found)
            {
                Console.Write("Enter amount:");
                double amount = Convert.ToDouble(Console.ReadLine());
                Account account = accounts[m];
                account.Balance += amount;
                accounts[m] = account;
                Console.WriteLine($"New balance: {accounts[m].Balance}");
            }
            else
                Console.WriteLine("Account is not Exists ...");

            Console.WriteLine("\r\n================================");
        }
        public static void Withdraw(ref Account Account)
        {
            Console.WriteLine("========== Withdraw ==========\r\n");
            int m = -1;
            Console.Write("Account Number  : ");
            bool found = checkAccountNumber(ref m);
            if (found)
            {
                Console.Write("Enter amount:");
                double amount = Convert.ToDouble(Console.ReadLine());
                Account account = accounts[m];
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    accounts[m] = account;
                    Console.WriteLine($"\nNew balance: {accounts[m].Balance}");
                }
                else
                    Console.WriteLine(" Insufficient balance!");
                Console.WriteLine("\r\n================================");
            }
        }
        public static void TransferMoney(ref Account Account)
        {
            Console.WriteLine("========== Transfer Money ==========\r\n");
            int x = -1, y = -1;
            Console.Write("Enter your account number:");
            bool found01 = checkAccountNumber(ref x);

            Console.Write("Enter receiver account number:");
            bool found02 = checkAccountNumber(ref y);

            if (found01 && found02)
            {
                Console.Write("Enter amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                Account account = accounts[x];
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    accounts[x] = account;
                    Console.WriteLine($"\nYour New Balance: {accounts[x].Balance}");
                }
                else
                    Console.WriteLine(" Insufficient balance!");
            }
            else if (!found01)
                Console.WriteLine("Your Account is not Exists ...");
            else if (!found02)
                Console.WriteLine("The Receiver Account is not Exists ...");

            Console.WriteLine("\r\n================================");
        }
        public static void CheckBalance(ref Account Account)
        {
            Console.WriteLine("5");
        }
        public static void Accountrmation(ref Account Account)
        {
            Console.WriteLine("6");
        }
        public static void TransactionHistory(ref Account Account)
        {
            Console.WriteLine("7");
        }
        public static void SearchAccount(ref Account Account)
        {
            Console.WriteLine("8");
        }
        public static void Exit()
        {
            Console.WriteLine("Thank you for using our Bank System!\r\n" +
                "Goodbye ");
            Console.WriteLine("\r\r\n====================================");
        }

        public static void ChoiseOpr(ref Account account, ref int n)
        {
            if (n == 1)
                CreateAccount();
            else if (n == 2)
                Deposit();
            else if (n == 3)
                Withdraw(ref account);
            else if (n == 4)
                TransferMoney(ref account);
            else if (n == 5)
                CheckBalance(ref account);
            else if (n == 6)
                Accountrmation(ref account);
            else if (n == 7)
                TransactionHistory(ref account);
            else if (n == 8)
                SearchAccount(ref account);
            else if (n == 9)
                Exit();
        }
        public static void StartProject()
        {
            Account account = new Account(); // initialize before use
            int oprNum;
            do
            {
                showChoices();
                Console.Write("Enter Choice [1-9] : ");
                oprNum = int.Parse(Console.ReadLine());
                Console.WriteLine("\r\n====================================\n");
                ChoiseOpr(ref account, ref oprNum);

            } while (oprNum != 9);

        }
        static void Main(string[] args)
        {
            StartProject();
        }
    }
}
