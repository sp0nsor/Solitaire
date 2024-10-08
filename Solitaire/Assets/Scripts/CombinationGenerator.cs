using System.Collections.Generic;
using UnityEngine;

public class CombinationGenerator : MonoBehaviour
{
    private const float _ascendingChance = 0.65f;
    private const float _directionChangeChance = 0.15f;

    public GameObject CardPrefab;
    public EndStackView DeckView;

    public List<Card> cardModels;
    private List<Sprite>[] _cardsSprites;
    private List<Card>[] _cardsGroup;
    private List<Card> _generatedDeck;

    private SpriteLoader _loader;

    private void Start()
    {
        _loader = GetComponentInChildren<SpriteLoader>();

        GetSortedGroup();
        //_cardsSprites = _loader.GetSpritesGroup();

        var combos = GetCombinations(40);
        InitShuffle(_cardsGroup, combos, out _generatedDeck);
        DeckView.ShowCurrentCard(_generatedDeck[_generatedDeck.Count - 1]);
    }

    private void GetSortedGroup()
    {
        _cardsGroup = new List<Card>[4];
        int cardIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            _cardsGroup[i] = new List<Card>(10);
            for (int j = 0; j < 10; j++)
            {
                _cardsGroup[i].Add(cardModels[cardIndex]);
                cardIndex++;
            }
        }
    }

    private List<List<int>> GetCombinations(int cardsOnField)
    {
        List<List<int>> results = new List<List<int>>();
        while (cardsOnField > 0)
        {
            var rank = Random.Range(1, 14);
            results.Add(new List<int>());
            results[results.Count - 1].Add(rank);
            var length = Mathf.Min(Random.Range(2, 8), cardsOnField);
            cardsOnField -= length;
            var ascending = Random.value < _ascendingChance;
            while (length > 0)
            {
                rank += ascending ? 1 : -1;
                if (rank > 13)
                {
                    rank = 1;
                }
                else if (rank <= 0)
                {
                    rank = 13;
                }
                results[results.Count - 1].Add(rank);
                length--;
                ascending = Random.value < _directionChangeChance ? !ascending : ascending;
            }
        }
        return results;
    }

    private void InitShuffle(List<Card>[] cardStacks, List<List<int>> combinations, out List<Card> deck)
    {
        int[] lastIndexInStack = new int[cardStacks.Length];
        for (int i = 0; i < cardStacks.Length; i++)
        {
            lastIndexInStack[i] = cardStacks[i].Count - 1;
        }
        deck = new List<Card>();
        foreach (var combo in combinations)
        {
            deck.Add(CreateDeckCard(combo[0]));
            for (int i = 1; i < combo.Count; i++)
            {
                int rank = combo[i];
                int stack;
                do
                {
                    stack = Random.Range(0, cardStacks.Length);
                } while (lastIndexInStack[stack] < 0);
                var cardModel = cardStacks[stack][lastIndexInStack[stack]];
                InitFieldCard(rank, stack, cardModel);
                lastIndexInStack[stack]--;
            }
        }
        deck.Reverse();
    }

    private void InitFieldCard(int rank, int stack, Card cardModel) // вот этого здесь быть не должно
    {
        cardModel.Rank = rank;
        //cardModel.Stack = stack;
        //cardModel.GetComponent<CardView>().SetFrontImage(_cardsSprites[rank][Random.Range(0, 4)]);
    }

    private Card CreateDeckCard(int rank) // можно написать что-то типо фабричного метода кторому будем говорить "дай мне карту с тким рангом"
    {
        var deckCard = Instantiate(CardPrefab, transform);
        deckCard.transform.SetAsFirstSibling();
        Card cardModel = deckCard.GetComponent<Card>();
        cardModel.Rank = rank;
        //deckCard.GetComponent<CardView>().SetFrontImage(_cardsSprites[cardModel.Rank][Random.Range(0, 4)]);
        return cardModel;
    }
}
