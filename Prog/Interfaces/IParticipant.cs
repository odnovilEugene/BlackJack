using Prog.Components.Core;

namespace Prog.Interfaces
{
    public interface IParticipant
    {
        public Hand Hand { get; }
        public int AmountLeft { get; }

        public void ChangeAmount(int value);
        
        public void TakeCard(Card card);

        public string ToString();
    }
}