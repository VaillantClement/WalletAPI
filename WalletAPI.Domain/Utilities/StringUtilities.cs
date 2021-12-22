using System;
using System.Text;

namespace WalletAPI.Domain.Utilities
{
    public static class StringUtilities
    {
        public static string Create16DigitString()
        {
            Random RNG = new Random();
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }
    }
}