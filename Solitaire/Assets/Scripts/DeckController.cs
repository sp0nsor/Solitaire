using UnityEngine;

public class DeckController : MonoBehaviour
{
    private ICardContainer _cardContainer;
    private DeckView _deckView;

    private void Awake()
    {
        _cardContainer = GetComponent<ICardContainer>();
        _deckView = GetComponent<DeckView>();
        CardView.OnCardClick += ABC;
    }

    public void ABC(Card card)
    {
        Card currentCard = _cardContainer.GetDeckCard();
        _cardContainer.RemoveCard(currentCard);
        _cardContainer.AddDeckCard(currentCard);
        _deckView.ShowCurrentCard(card);
        _deckView.UpdateCardSprite(card.Parent);

/*        if (card.Rank == currentCard.Rank + 1 || card.Rank == currentCard.Rank - 1)
        {
            _cardContainer.RemoveCard(currentCard);
            _cardContainer.AddDeckCard(card, card.Rank);
            _deckView.ShowCurrentCard(card);
            _deckView.UpdateCardSprite(card.Parent);
        }*/

    }

    private void OnDestroy()
    {
        CardView.OnCardClick -= ABC;
    }

}
