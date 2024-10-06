using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    private IDeck deck;
    private List<CardModel>[] _cardGroups;
    private List<List<int>> _combinations;

    private void Awake()
    {
        deck = GetComponent<IDeck>();

        _cardGroups = deck.GetCardGroups();
        _combinations = deck.GenerateCombinations();
    }

    public void InitCardFilds()
    {
        List<CardModel> deck = new List<CardModel> ();
        int[] topCardIndices = new int[_cardGroups.Length];

        for(int stackIndex = 0; stackIndex< _cardGroups.Length; stackIndex++)
        {
            topCardIndices[stackIndex] = _cardGroups[stackIndex].Count - 1;
        }

        foreach(var combination in _combinations)
        {
            // логика создания карт и добавления их в deck 
        }
    }

}
