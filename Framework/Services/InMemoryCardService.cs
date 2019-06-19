using System.Collections.Generic;
using Framework.Models;

namespace Framework.Services
{

    public class InMemoryCardService : ICardService
    {
        public IList<Card> GetAllCards()
        {
            throw new System.NotImplementedException();
        }

        public Card GetCardByName(string name)
        {
            switch (name)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();

                case "Mirror":
                    return new MirrorCard();

                default:
                    throw new System.ArgumentException($"I don't have {name}");
            }
        }
    }
}