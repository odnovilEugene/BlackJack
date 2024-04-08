// See https://aka.ms/new-console-template for more information

using Prog.Components.Core;

namespace Prog
{
    public class Prog
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.Loop();
        }
    }
}