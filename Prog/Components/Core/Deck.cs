namespace Prog.Components.Core
{
    public class Deck
    {
        private Stack<Card> ActiveCards { get; set; }
        private Stack<Card> DiscardedCards { get; set; }

        public Deck()
        {
            ActiveCards = GenerateDeck();
            DiscardedCards = new();
        }

        public Card GetCard()
        {
            return ActiveCards.Pop();
        }

        public int Count()
        {
            return ActiveCards.Count;
        }

        public void TakeDiscardedCard(Card card)
        {
            DiscardedCards.Push(card);
        }

        private static Stack<Card> GenerateDeck()
        {

            List<Card> cardList = new();

            foreach(var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(var value in Enum.GetValues(typeof(Value)))
                {
                    Card card = new Card((Suit)suit, (Value)value);
                    cardList.Add(card);
                }
            }

            Stack<Card> cardStack = ShuffleDeck(cardList);

            return cardStack;
        }

        private static Stack<Card> ShuffleDeck(List<Card> cardList)
        {   
            return new(cardList.OrderBy(card => Random.Shared.Next()));
        }

        public void ShuffleDeck()
        {
            List<Card> activeCardList = ActiveCards.ToList();
            List<Card> discardedCardList = DiscardedCards.ToList();

            List<Card> cardList = Enumerable.Concat(activeCardList, discardedCardList).ToList();

            ActiveCards = new(cardList.OrderBy(card => Random.Shared.Next()));
        }

        public void ShowDeck()
        {
            foreach(Card card in ActiveCards)
            {
                Console.WriteLine(card);
            }
            // return ActiveCards;
        }
    }
}