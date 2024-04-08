namespace Prog.Components.Utils
{
    public static class Utils
    {
        public static int CeilDivision(int value, int division)
        {
            return (value + division - 1) / division;
        }
    }
}