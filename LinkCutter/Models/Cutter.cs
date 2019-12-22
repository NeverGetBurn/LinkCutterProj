using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkCutter.Models
{
    public class Cutter
    {
        static readonly string symbols = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GetShortLink()
        {
            var rnd = new Random();
            var shortLink = new StringBuilder(6);

            for(int i = 0; i < 6; i++)
            {
                shortLink.Append(symbols[rnd.Next(0,61)]);
            }

            return "https://link.cut/" + shortLink.ToString();
        }
    }
}
