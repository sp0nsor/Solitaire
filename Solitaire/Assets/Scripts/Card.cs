using UnityEngine;

public class Card : MonoBehaviour
{
    public Card Parent { get; private set; }
    public Card Child { get; private set; }
    public int Rank { get; private set; }
    public int Heap { get; private set; }

    public void Init(Card parent, Card child, int rank, int heap)
    {
        Parent = parent;
        Child = child;
        Rank = rank;
        Heap = heap;

        if (child != null)
            child.Parent = this;
    }
}
