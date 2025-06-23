using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public void CallPhone(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void BrowseWebPage(string pageUrl)
        {
            bool isValidUrl = !pageUrl.Any(c => char.IsDigit(c));
            if (isValidUrl)
            {
                Console.WriteLine($"Browsing: {pageUrl}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}
