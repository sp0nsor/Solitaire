using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _heaps;

    private Deck _deck;
    private ICardFactory _cardFactory;
    private ISpriteLoader _spriteLoader;

    private void Awake()
    {
        _deck = new Deck();
        _cardFactory = GetComponent<ICardFactory>();
        _spriteLoader = GetComponent<ISpriteLoader>();

        SpawnShuffledCards();
    }

    public void SpawnShuffledCards()
    {
        int comboIndex = 1;
        int cardIndex = 0;
        List<List<int>> combinations = _deck.GenerateCombinations();

        foreach(var combo in combinations)
        {
            Card card = _cardFactory.CreateCard(combo[0], _heaps[0]);
            CardView cardView = card.GetComponent<CardView>();
            cardView.UpdateFrontSprite(_spriteLoader.GetSprite(combo[0], Random.Range(0, 4)));
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
                cardIndex++;
                Card card = _cardFactory.CreateCard(rank, _heaps[i]);
                CardView cardView = card.GetComponent<CardView>();
                cardView.UpdateFrontSprite(_spriteLoader.GetSprite(rank, Random.Range(0, 4)));
            }
        }
    }
}
