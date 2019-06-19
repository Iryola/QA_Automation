using System.Collections.Generic;
using Framework.Models;

namespace Framework.Services
{
    public interface ICardService
    {
        IList<Card> GetAllCards();

        Card GetCardByName(string name);
    }
}