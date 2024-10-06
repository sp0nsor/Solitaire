using System;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    public CardModel Parent { get;  set; }
    public CardModel Child { get;  set; }
    public int Rank { get;  set; }
    public int Stack { get; set; } // хз что это конечно 

    public void Init(CardModel parent, CardModel child, int rank)
    {
        Parent = parent;
        Child = child;
        Rank = rank;
    }

    public bool CanMove(CardModel card)
    {
        return card.Rank == Rank + 1 || card.Rank == Rank - 1
            || card.Rank == Rank + 12 || card.Rank == Rank - 12;
    }
}
