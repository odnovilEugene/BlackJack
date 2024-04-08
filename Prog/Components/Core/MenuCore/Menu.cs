namespace Prog.Components.Core.MenuCore
{
    public class Menu
    {
        public List<Option> Options { get; private set;}
        public int Selected { get; private set; }

        public Menu() 
        {
            Options = new();
        }

        public void ChangeOptions(List<Option> options)
        {
            Options = options;
        }

        public void Navigate(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                if (Selected + 1 < Options.Count)
                {
                    Selected++;
                }
            }
            if (key == ConsoleKey.UpArrow)
            {
                if (Selected - 1 >= 0)
                {
                    Selected--;
                }
            }
            
            // Handle different action for the option
            if (key == ConsoleKey.Enter)
            {
                Options[Selected].Selected.Invoke();
                Selected = 0;
            }
        }

        private void WriteMenu(Option selectedOption)
        {
            foreach (Option option in Options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }
}