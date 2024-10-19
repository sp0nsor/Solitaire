using UnityEngine;

public class DeckController : MonoBehaviour
{
    private ICardContainer _cardContainer;
    private DeckView _deckView;

    private int _score;

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
            _score++;
        }
        CheckEndGame();
    }

    private void UpdateDeck(Card card, Card currentCard)
    {
        _cardContainer.RemoveTableCard(card.Heap, card);
        _cardContainer.RemoveDeckCard(currentCard);
        _deckView.UpdateCardSprite(card.Parent);
        _cardContainer.AddDeckCard(card, card.Rank);
        _deckView.ShowCurrentCard(card);
    }

    private bool IsCardPlayable(Card card, Card currentCard)
    {
        int rankDifference = Mathf.Abs(card.Rank - currentCard.Rank);
        return rankDifference == 1 || rankDifference == 12;
    }

    private void CheckEndGame()
    {
        if (_score == 40)
            _deckView.ShowWinMessage();

        if (!HasPlayableMoves() && _cardContainer.GetCardCount() == 1)
            _deckView.ShowLooseMassage();
    }

    private bool HasPlayableMoves()
    {
        Card currentCard = _cardContainer.GetDeckCard();

        for (int i = 0; i < 4; i++)
        {
            Card tableCard = _cardContainer.GetFirstTableCard(i);
            if (IsCardPlayable(tableCard, currentCard))
                return true;
        }
        return false;
    }

    private void UpdateToNextCard()
    {
        if(_cardContainer.GetCardCount() == 1)
            return;

        Card currentCard = _cardContainer.GetDeckCard();
        _cardContainer.RemoveDeckCard(currentCard);
        _deckView.ShowCurrentCard(_cardContainer.GetDeckCard());
        _deckView.UpdateCardSprite(_cardContainer.GetDeckCard());

        CheckEndGame();
    }

    private void OnDestroy()
    {
        CardView.OnCardClick -= PlayCard;
        _deckView.OnNextButtonClick -= UpdateToNextCard;
    }
}
