using UnityEngine;

public class DeckController : MonoBehaviour
{
    private ICardContainer _cardContainer;
    private IDeckView _deckView;

    private int _score;

    private void Awake()
    {
        _cardContainer = GetComponent<ICardContainer>();
        _deckView = GetComponent<IDeckView>();

        CardView.OnCardClick += PlayCard;
        _deckView.OnNextButtonClick += UpdateToNextCard;
    }

    private void Start()
    {
        for(int i = 0; i < CardContainer.HEAP_COUNT; i++)
        {
            Card card = _cardContainer.GetFirstTableCard(i);
            _deckView.ShowCard(card);
        }

        _deckView.MoveCardToEndStack(_cardContainer.GetDeckCard());
        _deckView.ShowCard(_cardContainer.GetDeckCard());

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

        _deckView.ShowCard(card.Parent);
        _deckView.MoveCardToEndStack(card);

        _cardContainer.AddDeckCard(card, card.Rank);
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

        if (!CanMakeMove() && _cardContainer.GetCardCount() == 1)
            _deckView.ShowLoseMessage();
    }

    private bool CanMakeMove()
    {
        Card currentCard = _cardContainer.GetDeckCard();

        for (int i = 0; i < CardContainer.HEAP_COUNT; i++)
        {
            Card tableCard = _cardContainer.GetFirstTableCard(i);

            if (tableCard == null)
                continue;

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
        _deckView.MoveCardToEndStack(_cardContainer.GetDeckCard());
        _deckView.ShowCard(_cardContainer.GetDeckCard());

        CheckEndGame();
    }

    private void OnDestroy()
    {
        CardView.OnCardClick -= PlayCard;
        _deckView.OnNextButtonClick -= UpdateToNextCard;
    }
}
