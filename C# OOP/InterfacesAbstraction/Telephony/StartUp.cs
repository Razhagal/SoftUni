using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            ICallable stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (IsPhoneNumberValid(phoneNumbers[i]) && phoneNumbers[i].Length == 7)
                {
                    stationaryPhone.CallPhone(phoneNumbers[i]);
                }
                else if (IsPhoneNumberValid(phoneNumbers[i]) && phoneNumbers[i].Length == 10)
                {
                    smartphone.CallPhone(phoneNumbers[i]);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                smartphone.BrowseWebPage(urls[i]);
            }
        }

        private static bool IsPhoneNumberValid(string number)
        {
            bool isValidPhoneNumber = number.All(c => char.IsDigit(c));
            return isValidPhoneNumber;
        }
    }
}
