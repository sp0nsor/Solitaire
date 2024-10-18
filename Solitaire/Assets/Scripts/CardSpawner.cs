using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _heaps;
    [SerializeField] private Transform _deckTransform;

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
        List<List<int>> combinations = _deck.GenerateCombinations();
        int[] heapCapacities = new int[_heaps.Length];
        List<Card> deck = new List<Card>();
        for (int i = 0; i < _heaps.Length; i++)
            heapCapacities[i] = 10;

        foreach(var combo in combinations)
        {
            Card card = _cardFactory.CreateCard(_deckTransform);
            _cardContainer.AddDeckCard(card, combo[0]);
            deck.Add(card);
        }

        foreach(var combo in combinations)
        {
            for(int i = 1; i < combo.Count; i++)
            {
                int rank = combo[i];
                int heap;

                do
                {
                    heap = Random.Range(0, _heaps.Length);
                }while(heapCapacities[heap] <= 0);

                Card card = _cardFactory.CreateCard(_heaps[heap]);
                _cardContainer.AddTableCard(card, rank, heap);

                heapCapacities[heap]--;
            }
        }
        _cardContainer.MakeReverseDeck();
    }
}
