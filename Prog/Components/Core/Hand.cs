
namespace Prog.Components.Core
{
    public struct Hand
    {
        public Stack<Card> Cards { get; private set; }
        public int TotalValue 
        {
            get
            {
                int total = 0;
                foreach(Card card in Cards)
                {
                    total += (int)card.Value;
                }

                return total;
            }
        }

        public Hand() {
            Cards = new();
        }

        public void TakeCard(Card card)
        {
            Cards.Push(card);
        }

        public void Clear()
        {
            Cards.Clear();
        }
    }
}