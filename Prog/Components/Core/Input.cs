namespace Prog.Components.Core
{
    public static class Input
    {

        public static int AwaitNumber()
        {
            int number = -1;

            string input;

            do
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    return number;
                }
            } while (!Int32.TryParse(input, out number));

            return number;
        }

        public static int AwaitNumber(int amountLeft)
        {
            int number = -1;

            string input;

            do
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    return number;
                }
            } while (!Int32.TryParse(input, out number) || number > amountLeft);

            return number;
        }

        public static ConsoleKey AwaitKey()
        {
            ConsoleKey key = Console.ReadKey().Key;

            return key;
        }
    }
}