using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen : INamable
    {
        int Age { get; set; }
    }
}
