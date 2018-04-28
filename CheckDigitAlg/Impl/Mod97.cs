using System;
using System.Globalization;

namespace CheckDigitAlg.Impl
{
    public class Mod97 : ICheckDigitAlgorithm
    {
        public int CreateCheckDigit(string input)
        {
            var digits = ReplaceCharacters(input);
            var divided = (double)digits * 100;
            var rem = Math.IEEERemainder(divided, 97);
            return 98 - (int)Math.Round(rem, 0);
        }

        public bool IsValid(string input, int checkDigit)
        {
            return false;
        }

        internal long ReplaceCharacters(string input)
        {
            input = input.Trim();
            input = input.Replace(" ", string.Empty);
            input = input.Replace("-", string.Empty);
            if (long.TryParse(input, out var result))
            {
                return result;
            }
            throw new Exception("Invalid input");
        }
    }
}