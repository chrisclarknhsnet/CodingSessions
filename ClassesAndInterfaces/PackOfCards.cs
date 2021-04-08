using System.Collections;
using System.Collections.Generic;

namespace ClassesAndInterfaces
{
    public class PackOfCards
    {
        private IList<Card> _cards;

        public PackOfCards()
        {
            _cards = new List<Card>();

            for (int i = 1; i <= 52; i++)
            {
                _cards.Add(new Card(i));
            }
        }

        public Card GetCard(int cardNumber)
        {
            return _cards[cardNumber - 1];
        }

        public IEnumerable<Card> Shuffle()
        {
            return new Shuffler(this);
        }
    }
}
