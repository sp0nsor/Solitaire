using UnityEngine;
using System.Collections.Generic;

public class Deck
{
    private const float _ascendingChance = 0.65f;
    private const float _directionChangeChance = 0.15f;

    public List<List<int>> GenerateCombinations()
    {
        int cardsOnField = 40;
        List<List<int>> combinations = new List<List<int>>();

        while (cardsOnField > 0)
        {
            int rank = Random.Range(1, 14);
            combinations.Add(new List<int>());
            combinations[combinations.Count - 1].Add(rank);
            int comboLength = Mathf.Min(Random.Range(2, 8), cardsOnField);
            cardsOnField -= comboLength;
            bool isAscending = Random.value < _ascendingChance;

            while (comboLength > 0)
            {
                rank += isAscending ? 1 : -1;

                if (rank > 13)
                    rank = 1;

                if (rank < 1)
                    rank = 13;

                combinations[combinations.Count - 1].Add(rank);
                comboLength--;

                isAscending = Random.value < _directionChangeChance ? !isAscending : isAscending;
            }
        }

        return combinations;
    }
}
