using System;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    public event Action<bool> OnVisibilityChanged;
    public CardModel Parent { get;  set; }
    public CardModel Child { get;  set; }
    public int Rank { get;  set; }
    public int Stack { get; set; } // хз что это конечно 

    private bool _isOpen;

    public CardModel(CardModel parent, CardModel child, int rank)
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

    public void ChangeVisibility(bool visible)
    {
        _isOpen = visible;
        OnVisibilityChanged?.Invoke(visible);
    }
}
