using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeilvynApp.Core.Helpers
{
    public static class IconHelper
    {
        public static string ResolveIconResource(this string source)
        {
            if (source == "01d")
            {
                return "zero_one_d.png";
            }
            else if (source == "01n")
            {
                return "zero_one_n.png";
            }
            else if (source == "02d")
            {
                return "zero_two_d.png";
            }
            else if (source == "02n")
            {
                return "zero_two_n.png";
            }
            else if (source == "03d")
            {
                return "zero_three_d.png";
            }
            else if (source == "03n")
            {
                return "zero_three_n.png";
            }
            else if (source == "04d")
            {
                return "zero_four_d.png";
            }
            else if (source == "04n")
            {
                return "zero_four_n.png";
            }
            else if (source == "09d")
            {
                return "zero_nine_d.png";
            }
            else if (source == "09n")
            {
                return "zero_nine_n.png";
            }
            else if (source == "10d")
            {
                return "ten_d.png";
            }
            else if (source == "10n")
            {
                return "ten_n.png";
            }
            else if (source == "11d")
            {
                return "eleven_d.png";
            }
            else if (source == "11n")
            {
                return "eleven_n.png";
            }
            else if (source == "13d")
            {
                return "thirteen_d.png";
            }
            else if (source == "13n")
            {
                return "thirteen_n.png";
            }
            else if (source == "50d")
            {
                return "fifty_d.png";
            }
            else if (source == "50n")
            {
                return "fifty_n.png";
            }

            return source;
        }
    }
}
