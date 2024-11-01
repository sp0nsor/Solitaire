using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _heaps;
    [SerializeField] private Transform _deckTransform;

    private Deck _deck;
    
    private ICardFactory _cardFactory;
    private ICardContainer _cardContainer;

    [Inject]
    public void Construct(ICardFactory cardFactory, ICardContainer cardContainer)
    {
        _cardContainer = cardContainer;
        _cardFactory = cardFactory;
        _deck = new Deck();
    }

    private void Awake()
    {
        SpawnShuffledCards();
    }

    private void SpawnShuffledCards()
    {
        List<List<int>> combinations = _deck.GenerateCombinations();
        int[] heapCapacities = new int[_heaps.Length];

        for (int i = 0; i < _heaps.Length; i++)
            heapCapacities[i] = CardContainer.CARD_IN_HEAP;

        foreach(var combo in combinations)
        {
            Card card = _cardFactory.CreateCard(_deckTransform);
            _cardContainer.AddDeckCard(card, combo[0]);
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
