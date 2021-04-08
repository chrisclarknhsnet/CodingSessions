using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassesAndInterfaces
{
    public class Shuffler : IEnumerable<Card>, IEnumerator<Card>
    {
        private PackOfCards _pack;
        IList<int> _cardsRemaining;
        private Card _currentCard;
        private Random _random;

        public Shuffler(PackOfCards pack)
        {
            _pack = pack;
            _cardsRemaining = new List<int>();
            initCardNumbers();
            _random = new Random();
        }

        #region IEnumerable interface implementation

        public IEnumerator<Card> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        #endregion

        #region IEnumerator interface implementation

        public Card Current => _currentCard;

        object IEnumerator.Current => _currentCard;

        public void Dispose()
        {
            _cardsRemaining.Clear();
            _cardsRemaining = null;
        }

        public bool MoveNext()
        {
            if (!_cardsRemaining.Any())
            {
                return false;
            }
            
            var cardno = getRandomCardNo();
            _currentCard = _pack.GetCard(cardno);
            return true;
        }

        public void Reset()
        {
            initCardNumbers();
        }

        #endregion

        private int getRandomCardNo()
        {
            var noOfRemainingCards = _cardsRemaining.Count;
            var cardindex = _random.Next(0, noOfRemainingCards);
            var cardno = _cardsRemaining[cardindex];
            _cardsRemaining.Remove(cardno);
            return cardno; 
        }

        private void initCardNumbers()
        {
            _cardsRemaining.Clear();

            for (int i = 1; i <= 52; i++)
            {
                _cardsRemaining.Add(i);
            }
        }
    }
}
