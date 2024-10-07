using UnityEngine;

public class CardFactory : MonoBehaviour, ICardFactory
{
    [SerializeField] private GameObject _cardPrafab;

    public Card CreateCard(int rank, Transform parent)
    {
        var cardObj = Instantiate(_cardPrafab, parent);
        cardObj.transform.SetAsFirstSibling();

        Card card = cardObj.GetComponent<Card>();
        card.Rank = rank;

        return card;
    }
}
