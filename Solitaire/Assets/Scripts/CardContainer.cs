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

    public void AddTableCard(Card card, int rank, int heap)
    {
        InitCardRelationships(_tableCards[heap], card, rank, heap);
        _tableCards[heap].Add(card);
    }

    private void InitCardRelationships(List<Card> cards, Card card, int rank, int heap)
    {
        Card lastCard = cards.Count == 0 ? null : cards[cards.Count - 1];
        card.Init(null, lastCard, rank, heap);
    }

    public void AddDeckCard(Card card, int rank)
    {
        InitCardRelationships(_deckCards, card, rank, card.Heap);
        _deckCards.Add(card);
    }

    public Card GetDeckCard()
    {
        return _deckCards[_deckCards.Count - 1];   
    }

    public int GetCardCount()
    {
        return _deckCards.Count;
    }

    public void MakeReverseDeck()
    {
        _deckCards.Reverse();
    }

    public void RemoveTableCard(int heap, Card card)
    {
        Card tableCard = _tableCards[heap][0];
        _tableCards[heap].Remove(tableCard);
    }

    public void RemoveDeckCard(Card card)
    {
        _deckCards.Remove(card);
    }

    public Card GetFirstTableCard(int croup)
    {
        return _tableCards[croup][0];
    }
}
