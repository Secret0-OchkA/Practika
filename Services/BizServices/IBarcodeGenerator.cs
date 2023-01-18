using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BizServices
{
    public interface IBarcodeGenerator
    {
        string GenerateCode(string numbers);
    }

    public class BarcodeGenerator : IBarcodeGenerator
    {
        private readonly string barcode = "abcdefghij";
        private readonly string firstNumb = "klmnopqrst";
        private readonly string separator = ":";

        public string GenerateCode(string numbers)
        {
            if (numbers.IsNullOrEmpty()) return string.Empty;

            StringBuilder result = new StringBuilder();
            result.Append(toMainChar(numbers[0]));
            result.Append(separator);
            for (int i = 1; i < numbers.Length; i++)
            {
                result.Append(toBarcodeChar(numbers[i]));

                if (numbers.Length / 2 == i)
                    result.Append(separator);
            }
            result.Append(separator);

            return result.ToString();
        }

        private char toBarcodeChar(char charecter)
        {
            switch (charecter)
            {
                case '0': return 'a';
                case '1': return 'b';
                case '2': return 'c';
                case '3': return 'd';
                case '4': return 'e';
                case '5': return 'f';
                case '6': return 'g';
                case '7': return 'h';
                case '8': return 'i';
                case '9': return 'j';
            }

            throw new ArgumentException();
        }
        private char toMainChar(char charecter)
        {
            switch (charecter)
            {
                case '0': return 'k';
                case '1': return 'l';
                case '2': return 'm';
                case '3': return 'n';
                case '4': return 'o';
                case '5': return 'p';
                case '6': return 'q';
                case '7': return 'r';
                case '8': return 's';
                case '9': return 't';
            }

            throw new ArgumentException();
        }
    }
}
