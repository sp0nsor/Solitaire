using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _heaps;

    private Deck _deck;
    
    private ICardFactory _cardFactory;
    private ICardContainer _cardContainer;

    private void Awake()
    {
        _deck = new Deck();

        _cardContainer = GetComponent<ICardContainer>();
        _cardFactory = GetComponent<ICardFactory>();

        SpawnShuffledCards();
    }

    public void SpawnShuffledCards()
    {
        int comboIndex = 1;
        int cardIndex = 0;
        List<List<int>> combinations = _deck.GenerateCombinations();

        foreach(var combo in combinations)
        {
            Card card = _cardFactory.CreateCard(_heaps[0]);
            _cardContainer.AddDeckCard(card, combo[0]);
            combo.Reverse();
        }

        for (int i = 1; i < _heaps.Length; i++)
        {

            for (int j = 0; j < 10; j++)
            {
                if (cardIndex >= combinations[comboIndex].Count)
                {
                    comboIndex++;
                    cardIndex = 0;

                    if (comboIndex >= combinations.Count)
                        comboIndex = 0;
                }
                int rank = combinations[comboIndex][cardIndex];
                Card card = _cardFactory.CreateCard(_heaps[i]);
                _cardContainer.AddTableCard(card, rank);

                cardIndex++;
            }
        }
    }
}
