using UnityEngine;
using System.Collections.Generic;

public class CardContainer : MonoBehaviour, ICardContainer
{
    private List<Card> _deckCards;
    private List<List<Card>> _tableCards;

    private void Awake()
    {
        _deckCards = new List<Card>();
        _tableCards = new List<List<Card>>(4);

        for (int i = 0; i < 4; i++)
        {
            _tableCards.Add(new List<Card>(10));
        }
    }

    public void AddTableCard(Card card, int rank)
    {
        foreach (List<Card> heap in _tableCards)
        {
            if (heap.Count < 10)
            {
                InitCardRelationships(heap, card, rank);
                heap.Add(card);

                return;
            }
        }
    }

    private void InitCardRelationships(List<Card> cards, Card card, int rank)
    {
        Card lastCard = cards.Count == 0 ? null : cards[cards.Count - 1];
        card.Init(null, lastCard, rank);
    }

    public void AddDeckCard(Card card, int rank)
    {
        InitCardRelationships(_deckCards, card, rank);
        _deckCards.Add(card);
    }

    public Card GetDeckCard()
    {
        return _deckCards[_deckCards.Count - 1];   
    }

    public void RemoveCard(Card card)
    {
        _deckCards.Remove(card);
    }

    public Card GetFirstTableCard(int croup)
    {
        return _tableCards[croup][0];
    }
}
