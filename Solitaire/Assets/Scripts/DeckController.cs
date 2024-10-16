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
        _deckView.OnNextButtonClick += BCD;
    }

    public void ABC(Card card)
    {
        Card currentCard = _cardContainer.GetDeckCard();

        if (card.Rank == currentCard.Rank + 1 || card.Rank == currentCard.Rank - 1 
            || card.Rank == currentCard.Rank - 12 || card.Rank == currentCard.Rank + 12)
        {
            _cardContainer.RemoveCard(currentCard);
            _cardContainer.AddDeckCard(card);
            _deckView.ShowCurrentCard(card);
            _deckView.UpdateCardSprite(card.Parent);
        }
    }

    private void BCD()
    {
        Card currentCard = _cardContainer.GetDeckCard();

        _cardContainer.RemoveCard(currentCard);
        _deckView.ShowCurrentCard(_cardContainer.GetDeckCard());
        _deckView.UpdateCardSprite(_cardContainer.GetDeckCard());
    }

    private void OnDestroy()
    {
        CardView.OnCardClick -= ABC;
        _deckView.OnNextButtonClick -= BCD;
    }

}
