using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Calculator.Tests")]

namespace Calculator
{
    public class BankTool
    {
        internal static bool IsValidIban(string iban)
        {
            // Entfernen von Leerzeichen und Umwandeln in Großbuchstaben
            iban = iban.Replace(" ", "").ToUpper();

            // Prüfen, ob die IBAN die richtige Länge hat
            if (iban.Length < 4)
                return false;

            // Prüfen, ob die ersten vier Zeichen Buchstaben sind
            if (!Regex.IsMatch(iban.Substring(0, 2), @"^[A-Z]+$"))
                return false;

            // Prüfen, ob die folgenden beiden Zeichen Ziffern sind
            if (!Regex.IsMatch(iban.Substring(2, 2), @"^[0-9]+$"))
                return false;

            // IBAN umsortieren und in Zahl umwandeln
            string rearrangedIban = iban.Substring(4) + iban.Substring(0, 4);
            StringBuilder numericIban = new StringBuilder();

            foreach (char c in rearrangedIban)
            {
                if (char.IsDigit(c))
                    numericIban.Append(c);
                else
                    numericIban.Append((c - 'A' + 10).ToString());
            }

            // IBAN-Validierung: Modulo-97-Prüfung
            int remainder = 0;
            foreach (char digit in numericIban.ToString())
            {
                remainder = (remainder * 10 + (digit - '0')) % 97;
            }

            return remainder == 1;
        }
    }
}
