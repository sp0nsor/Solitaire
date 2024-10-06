using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IDeck
{
    private const float _ascendingChance = 0.65f;
    private const float _directionChangeChance = 0.15f;

    [SerializeField] private List<CardModel> _cards;
    private List<CardModel>[] _cardGroups;

    public List<List<int>> GenerateCombinations()
    {
        int cardsOnField = 40;
        List<List<int>> combinations = new List<List<int>>();

        while (cardsOnField > 0)
        {
            int rank = Random.Range(1, 14);
            combinations.Add(new List<int>());
            int comboLength = Mathf.Min(Random.Range(2, 8), cardsOnField);
            cardsOnField -= comboLength;
            bool isAscending = Random.value < _ascendingChance;

            while (comboLength > 0)
            {
                rank += isAscending ? 1 : -1;

                if (rank > 13)
                    rank = 1;
                if (rank <= 0)
                    rank = 13;

                combinations[combinations.Count - 1].Add(rank);
                comboLength--;

                isAscending = Random.value < _directionChangeChance ? !isAscending : isAscending;
            }
        }

        return combinations;
    }

    private void InitCardGroups()
    {
        _cardGroups = new List<CardModel>[4];
        int cardIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            _cardGroups[i] = new List<CardModel>(10);
            for (int j = 0; j < 10; j++)
            {
                _cardGroups[i].Add(_cards[cardIndex]);
                cardIndex++;
            }
        }
    }

    public List<CardModel>[] GetCardGroups()
    {
        return _cardGroups;
    }
}
