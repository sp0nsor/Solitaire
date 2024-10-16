using UnityEngine;

public class CardFactory : MonoBehaviour, ICardFactory
{
    [SerializeField] private GameObject _cardPrafab;

    public Card CreateCard(Transform parent)
    {
        var cardObj = Instantiate(_cardPrafab, parent);
        cardObj.transform.SetAsFirstSibling();

        Card card = cardObj.GetComponent<Card>();

        return card;
    }
}
