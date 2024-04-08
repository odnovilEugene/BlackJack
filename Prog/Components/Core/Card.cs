namespace Prog.Components.Core
{

    public enum Suit 
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11,
    }

    public struct Card
    {
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }

        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }

        public override readonly string ToString()
        {
            return $"{Value} of {Suit}";
        }

    }
}