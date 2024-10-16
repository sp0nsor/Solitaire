using UnityEngine;

public interface ICardFactory
{
    Card CreateCard(Transform parent);
}