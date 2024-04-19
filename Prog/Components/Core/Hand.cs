
namespace Prog.Components.Core
{
    public struct Hand
    {
        public CustomStack<Card> Cards { get; private set; }
        public int TotalValue 
        {
            get
            {
                int total = 0;

                Node<Card>? top = Cards.Top;
                while(top != null) 
                {
                    total += (int)top.Element.Value;
                    top = top.Next;
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
            while(Cards.Size > 0) {
                Cards.Pop();
            }
        }
    }
}