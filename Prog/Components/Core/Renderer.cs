
using static Prog.Components.Utils.Utils;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;
using Prog.Components.Core.MenuCore;

namespace Prog.Components.Core
{
    public class Renderer
    {
        private static readonly int Width = 50;
        private int Col { get; set; }
        private int Row { get; set; }
        private Game Game { get; set; }

        private StyleSheet StyleSheet { get;}

        private static readonly Formatter[] SuitFormatter = new Formatter[]
        {
            new Formatter(Enum.GetName(Suit.Diamonds), Color.Red),
            new(Enum.GetName(Suit.Clubs), Color.Black),
            new(Enum.GetName(Suit.Hearts), Color.Red),
            new(Enum.GetName(Suit.Spades), Color.Black),
        };
        
        public Renderer(Game game)
        {
            Game = game;
            Col = Console.CursorLeft;
            Row = Console.CursorTop;

            StyleSheet = new StyleSheet(Color.White);
            StyleSheet.AddStyle(Enum.GetName(Suit.Diamonds), Color.Red);
            StyleSheet.AddStyle(Enum.GetName(Suit.Clubs), Color.Black);
            StyleSheet.AddStyle(Enum.GetName(Suit.Hearts), Color.Red);
            StyleSheet.AddStyle(Enum.GetName(Suit.Spades), Color.Black);
        }

        public void RenderGame()
        {
            ResetCol();
            RenderAmounts();
            RenderBlank();
            RenderBlank();
            ResetCol();
            RenderOptions();
            RenderBlank();
            RenderBlank();
            RenderTotals();
            RenderBlank();
            RenderBlank();
            RenderHands();
            RenderBlank();
        }

        private void RenderOptions()
        {
            int selected = Game.Menu.Selected;

            foreach (Option option in Game.Menu.Options)
            {
                if (option == Game.Menu.Options[selected])
                {
                    WriteAt($">{option.Name}", CeilDivision(Width, 2) - CeilDivision(option.Name.Length, 2), 1, Color.White);
                } else {
                    WriteAt(option.Name, CeilDivision(Width, 2) - CeilDivision(option.Name.Length, 2), 1, Color.White);
                }
                ResetCol();
            }
        }

        private void RenderTotals()
        {
            string playerTotal = Game.Player.Hand.TotalValue.ToString();
            WriteAt(playerTotal, CeilDivision(Width, 20), 0, Color.White);

            ResetCol();

            string dealerTotal = Game.Dealer.Hand.TotalValue.ToString();
            WriteAt(dealerTotal, CeilDivision(Width, 20) * 16 - 1 - dealerTotal.Length, 0, Color.White);
        }

        private void RenderHands()
        {
            int tempRow = Row;

            if (Game.Player.Hand.Cards.Size != 0)
            {
                Node<Card>? top = Game.Player.Hand.Cards.Top;
                while (top != null)
                {
                    ResetCol();
                    string cardString = top.Element.ToString();
                    WriteAtStyled(cardString, 0, 1, Color.White);
                    top = top.Next;
                }
                
            } else
            {
                ResetCol();
                string str = "Empty";
                WriteAtStyled(str, 0, 1, Color.White);
            }

            Row = tempRow;

            if (Game.Dealer.Hand.Cards.Size != 0)
            {
                Node<Card>? top = Game.Dealer.Hand.Cards.Top;
                while (top != null)
                {
                    ResetCol();
                    string cardString = top.Element.ToString();
                    WriteAtStyled(cardString, Width - cardString.Length, 1, Color.White);
                    top = top.Next;
                }
                
            } else 
            {
                ResetCol();
                string str = "Empty";
                WriteAtStyled(str, Width - str.Length, 1, Color.White);
            }
        }

        public void RenderMessageAndGame(string message)
        {
            Console.Clear();
            ResetPosition();
            WriteAt(message, CeilDivision(Width, 2) - CeilDivision(message.Length, 2), 0, Color.White);
            RenderBlank();
            RenderGame();
        }

        private void RenderAmounts()
        {
            string amountString = Convert.ToString(Game.Player.AmountLeft) + "$";
            WriteAt(amountString, 0, 1, Color.Blue);

            string bankString = Convert.ToString(Game.Dealer.AmountLeft) + "$";
            WriteAt(bankString, Width - bankString.Length, 0, Color.Red);
        }

        private void WriteAtStyled(string s, int x, int y, Color color)
        {
            try
                {
                    Col += x;
                    Row += y;
                    Console.SetCursorPosition(Col, Row);
                    Console.WriteStyled(s, color, StyleSheet);
                }
            catch (ArgumentOutOfRangeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message, Color.Red);
                }
        }

        private void WriteAt(string s, int x, int y, Color color)
        {
            try
                {
                    Col += x;
                    Row += y;
                    Console.SetCursorPosition(Col, Row);
                    Console.Write(s, color);
                }
            catch (ArgumentOutOfRangeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message, Color.Red);
                }
        }

        private void RenderBlank()
        {
            ResetCol();
            WriteAt("", 0, 1, Color.Black);
        }

        private void ResetCol()
        {
            Col = 0;
        }

        private void ResetRow()
        {
            Row = 0;
        }

        private void ResetPosition()
        {
            ResetCol();
            ResetRow();
        }

        //  BET          RESULT           BANK
        // 
        //        VAL   OPTIONS    VAL
        // 
        //  HAND                          HAND
        // 
        //  PROMPT
    }
}