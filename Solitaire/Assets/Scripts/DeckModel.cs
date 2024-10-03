using System.Collections.Generic;
using UnityEngine;

public class DeckModel : MonoBehaviour
{
    public List<CardModel> cardModels;
    public List<CardModel> CurrentDeck {  get; private set; }
    public List<CardModel>[] CardsGroups { get; private set; }
    public List<CardModel> EndStack { get; private set; }

/*    private void Start()
    {
        CardsGroups = new List<CardModel>[4];
        int cardIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            CardsGroups[i] = new List<CardModel>(10);
            for(int j = 0;  j < 10; j++)
            {
                CardsGroups[i].Add(cardModels[cardIndex]);
                cardIndex++;
            }
        }
    }*/

    public void InitGame(List<CardModel>[] cardsCroup, List<CardModel> deck)
    {
        CardsGroups = cardsCroup;
        foreach(var group in CardsGroups)
        {
            CardModel previousCard = null;
            for(int i = 0; i < group.Count; i++)
            {
                CardModel currentCard = group[i];
                CardModel nextCard = i < group.Count - 1 ? group[i + 1] : null;
                 
                // логика назначения потомка и ребенка 
            }
        }
    }
}
