namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }

        public int Multiply(int a, int b)
        {
            return checked(a * b);
        }
    }
}
