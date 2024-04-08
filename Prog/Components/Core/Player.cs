using Prog.Interfaces;

namespace Prog.Components.Core
{
    public class Player : IParticipant
    {
        public Hand Hand { get; private set; }

        public int AmountLeft { get; private set; }

        public Player() {
            Hand = new();
            AmountLeft = 100;
        }

        public void ChangeAmount(int value)
        {
            AmountLeft += value;
        }
        
        public void TakeCard(Card card)
        {
            Hand.TakeCard(card);
        }

        public override string ToString()
        {
            return "Player";
        }
    }
}