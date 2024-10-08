using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CardContainer : MonoBehaviour, ICardContainer
{
    private List<Card> _deckCards;
    private List<List<Card>> _tableCards;

    private void Awake()
    {
        _tableCards = new List<List<Card>>(4);
        _deckCards = new List<Card>();

        for (int i = 0; i < 4; i++)
        {
            _tableCards.Add(new List<Card>(10));
        }
    }

    public void AddTableCard(Card card)
    {
        foreach (var heap in _tableCards)
        {
            if (heap.Count < 10)
            {
                heap.Add(card);
                return;
            }
        }
    }

    public void AddDeckCard(Card card)
    {
        _deckCards.Add(card);
    }

    public Card GetDeckCard()
    {
        return _deckCards[0];
    }
}
