using Prog.Components.Core.MenuCore;
using Prog.Interfaces;

namespace Prog.Components.Core
{
    public class Game
    {
        private Renderer Renderer { get; }
    
        public Menu Menu { get; }

        public Deck Deck { get; }

        public Player Player { get; }
        
        public Dealer Dealer { get; }

        public int CurrentBet { get; set; }

        private bool GameOver { get => Player.AmountLeft <= 0 || Dealer.AmountLeft <= 0; }


        public Game()
        {
            Deck = new();
            Player = new();
            Dealer = new();
            Menu = new();
            Renderer = new(this);
        }

        private void Turn() 
        {
            for(int i = 0; i < 2; i++)
            {
                Player.TakeCard(Deck.GetCard());
            }

            Dealer.TakeCard(Deck.GetCard());

            // Игрок берет карты с помощью меню

            if (Player.Hand.TotalValue < 21)
            {
                bool stay = false;

                List<Option> options = new()
                {
                    new Option("Hit", () => 
                    {
                        Player.TakeCard(Deck.GetCard());
                        Renderer.RenderMessageAndGame("Choose an option");
                    }),
                    new Option("Stay", () =>
                    {
                        stay = true;
                        Renderer.RenderMessageAndGame("Wait for dealers turn");
                    }),
                };
                Menu.ChangeOptions(options);
                
                do
                {
                    Renderer.RenderMessageAndGame("Choose an option");
                    ConsoleKey key = Input.AwaitKey();
                    Menu.Navigate(key);
                } while(Player.Hand.TotalValue < 21 && !stay);

                Menu.ChangeOptions(new());
            }
            
            if (Player.Hand.TotalValue > 21)
            {
                Win(Dealer, Player);
                return;
            }

            do
            {
                Dealer.TakeCard(Deck.GetCard());
                Renderer.RenderMessageAndGame("Dealer took a card");
                Thread.Sleep(3000);
            } while(Dealer.Hand.TotalValue < 17);

            if (Dealer.Hand.TotalValue > 21)
            {
                Win(Player, Dealer);
                return;
            }
            

            if (Player.Hand.TotalValue == Dealer.Hand.TotalValue)
            {
                Even();
                return;
            } else if (Player.Hand.TotalValue > Dealer.Hand.TotalValue)
            {
                Win(Player, Dealer);
                return;
            } else
            {
                Win(Dealer, Player);
                return;
            }
        }

        public void Loop() 
        {
            while(!GameOver)
            {
                Renderer.RenderMessageAndGame("Place your BET");

                int number = Input.AwaitNumber(Player.AmountLeft);
                if (number == -1)
                {
                    return;
                }

                CurrentBet = number;

                if (Deck.Count() < (52 / 3))
                {
                    Renderer.RenderMessageAndGame("Shuffling the deck");

                    string dots = ".";
                    for(int i = 0; i < 3; i++)
                    {
                        Renderer.RenderMessageAndGame($"Shuffling the deck{dots}");
                        dots += ".";
                        Thread.Sleep(3000);
                    }
                    Deck.ShuffleDeck();
                }

                Turn();
            }

            Renderer.RenderMessageAndGame("Game over");
        }

        private void Win(IParticipant winner, IParticipant loser)
        {
            Renderer.RenderMessageAndGame($"{winner} WON!");
            winner.ChangeAmount(CurrentBet);

            while(winner.Hand.Cards.Size > 0)
            {
                Deck.TakeDiscardedCard(winner.Hand.Cards.Pop());
            }

            loser.ChangeAmount(-CurrentBet);

            while(loser.Hand.Cards.Size > 0)
            {
                Deck.TakeDiscardedCard(loser.Hand.Cards.Pop());
            }

            Thread.Sleep(3000);
        }

        private void Even()
        {
            Renderer.RenderMessageAndGame("PUSH!");

            while(Player.Hand.Cards.Size > 0)
            {
                Deck.TakeDiscardedCard(Player.Hand.Cards.Pop());
            }

            while(Dealer.Hand.Cards.Size > 0)
            {
                Deck.TakeDiscardedCard(Dealer.Hand.Cards.Pop());
            }

            Thread.Sleep(3000);
        }
    }
}