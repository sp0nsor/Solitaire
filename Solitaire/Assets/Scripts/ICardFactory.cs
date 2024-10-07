using UnityEngine;

public interface ICardFactory
{
    Card CreateCard(int rank, Transform parent);
}