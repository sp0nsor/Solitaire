using UnityEngine;

public class EndStackView : MonoBehaviour
{
    public void ShowCurrentCard(Card card)
    {
        card.transform.SetParent(transform, true);
        card.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
