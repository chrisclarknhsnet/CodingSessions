using System;

namespace ClassesAndInterfaces
{
    public class Card
    {
        private int _cardNo;

        public Card(int cardno)
        {
            if (cardno < 1 || cardno > 52)
            {
                throw new ArgumentOutOfRangeException("Card no must be between 1 and 52");
            }

            this._cardNo = cardno;

            this.Value = (cardno % 13 == 0) ? 13 : cardno % 13;
            this.Suit = (SuitValues)((cardno -1) / 13);
        }

        public SuitValues Suit { get; private set; }
        
        public int Value { get; private set; }

        public override string ToString()
        {
            string valDesc;

            switch (this.Value)
            {
                case 1:
                    valDesc = "Ace of";
                    break;
                case 11:
                    valDesc = "Jack of";
                    break;
                case 12:
                    valDesc = "Queen of";
                    break;
                case 13:
                    valDesc = "King of";
                    break;
                default:
                    valDesc = $"{this.Value} of";
                    break;
            }

            string suitDesc = Enum.GetName(typeof(SuitValues), this.Suit);
            
            return $"{valDesc} {suitDesc}";
        }
    }
}
