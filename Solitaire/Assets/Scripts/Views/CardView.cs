using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _front, _back;
    public bool IsOpen { get; private set; }

    public static event Action<Card> OnCardClick;

    public void UpdateFrontSprite(Sprite sprite)
    {
        _front.GetComponent<Image>().sprite = sprite;
        IsOpen = true;
        _back.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsOpen)
        {
            Card card = GetComponent<Card>();
            OnCardClick?.Invoke(card);
        }
    }
}
