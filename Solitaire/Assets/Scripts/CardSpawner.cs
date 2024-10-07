using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    private Deck _deck;
    private ICardFactory _cardFactory;
    private List<Card> _currentDeck;

    [SerializeField] private Transform[] _heaps;

    private void Awake()
    {
        _deck = new Deck();
        _cardFactory = GetComponent<CardFactory>();

        SpawnShuffledCards();
    }

    public void SpawnShuffledCards()
    {
        int comboIndex = 0;
        int cardIndex = 0;
        //_currentDeck = new List<CardModel>();
        List<List<int>> combinations = _deck.GenerateCombinations();

        for(int i = 0; i < _heaps.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (cardIndex >= combinations[comboIndex].Count)
                {
                    comboIndex++;
                    cardIndex = 0;

                    if (comboIndex >= combinations.Count)
                    {
                        comboIndex = 0;
                    }
                }
                int rank = combinations[comboIndex][cardIndex];
                cardIndex++;
                Card card = _cardFactory.CreateCard(rank, _heaps[i]);
                //_currentDeck.Add(card);
            }
        }
        //_currentDeck.Reverse();
    }
}
