namespace UnitTests
{
    public static class MyMath
    {
        public static int Add(int a, int b)
        { 
            return a + b;
        }

        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}