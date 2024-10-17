using UnityEngine;

public class DeckController : MonoBehaviour
{
    private ICardContainer _cardContainer;
    private DeckView _deckView;

    private void Awake()
    {
        _cardContainer = GetComponent<ICardContainer>();
        _deckView = GetComponent<DeckView>();
        CardView.OnCardClick += PlayCard;
        _deckView.OnNextButtonClick += UpdateToNextCard;
    }

    private void PlayCard(Card card)
    {
        Card currentCard = _cardContainer.GetDeckCard();

        if (IsCardPlayable(card, currentCard))
        {
            UpdateDeck(card, currentCard);
        }
    }

    private void UpdateDeck(Card card, Card currentCard)
    {
        _cardContainer.RemoveCard(currentCard);
        _deckView.UpdateCardSprite(card.Parent);
        _cardContainer.AddDeckCard(card, card.Rank);
        _deckView.ShowCurrentCard(card);
    }

    private bool IsCardPlayable(Card card, Card currentCard)
    {
        int rankDifference = Mathf.Abs(card.Rank - currentCard.Rank);

        return rankDifference == 1 || rankDifference == 12;
    }

    private void UpdateToNextCard()
    {
        Card currentCard = _cardContainer.GetDeckCard();

        _cardContainer.RemoveCard(currentCard);
        _deckView.ShowCurrentCard(_cardContainer.GetDeckCard());
        _deckView.UpdateCardSprite(_cardContainer.GetDeckCard());
    }

    private void OnDestroy()
    {
        CardView.OnCardClick -= PlayCard;
        _deckView.OnNextButtonClick -= UpdateToNextCard;
    }

}
