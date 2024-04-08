using Prog.Interfaces;

namespace Prog.Components.Core
{
    public class Dealer: IParticipant
    {
        public Hand Hand { get; private set; }

        public int AmountLeft { get; private set; }

        public Dealer() {
            Hand = new();
            AmountLeft = 1000;
        }

        public void TakeCard(Card card)
        {
            Hand.TakeCard(card);
        }

        public void ChangeAmount(int value)
        {
            AmountLeft += value;
        }

        public override string ToString()
        {
            return "Dealer";
        }
    }
}