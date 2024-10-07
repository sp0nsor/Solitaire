using UnityEngine;

public class DeckView : MonoBehaviour
{
    public void ShowCurrentCard(Card card)
    {
        card.transform.SetParent(transform, true);
        card.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
