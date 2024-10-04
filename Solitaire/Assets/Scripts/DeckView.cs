using UnityEngine;

public class DeckView : MonoBehaviour
{
    public void ShowCurrentCard(CardModel card)
    {
        card.transform.SetParent(transform, true);
        card.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
