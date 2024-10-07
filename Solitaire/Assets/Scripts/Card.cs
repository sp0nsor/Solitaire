using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Card Parent { get;  set; }
    public Card Child { get;  set; }
    public int Rank { get;  set; }

    public void Init(Card parent, Card child, int rank)
    {
        Parent = parent;
        Child = child;
        Rank = rank;
    }

    public bool CanMove(Card card)
    {
        return card.Rank == Rank + 1 || card.Rank == Rank - 1
            || card.Rank == Rank + 12 || card.Rank == Rank - 12;
    }
}
