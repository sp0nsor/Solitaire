using System;
using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    [SerializeField] private Transform _endStack;

    private ICardContainer _cardContainer;
    private ISpriteLoader _spriteLoader;

    public event Action OnNextButtonClick;

    private void Awake()
    {
        _cardContainer = GetComponent<ICardContainer>();
        _spriteLoader = GetComponent<ISpriteLoader>();
    }

    private void Start()
    {
        ShowGameCards();
    }

    public void ShowCurrentCard(Card card)
    {
        card.transform.SetParent(_endStack, true);
        card.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        UpdateCardSprite(card);
    }


    private void ShowGameCards()
    {
        for(int i = 0; i < 4; i++)
        {
            Card card = _cardContainer.GetFirstTableCard(i);
            UpdateCardSprite(card);
        }

        ShowCurrentCard(_cardContainer.GetDeckCard());
    }

    public void UpdateCardSprite(Card card)
    {
        if(card == null) return;

        CardView view = card.GetComponent<CardView>();
        view.UpdateFrontSprite(_spriteLoader.GetSprite(card.Rank, UnityEngine.Random.Range(0, 4)));
    }

    public void NextDeckCard()
    {
        OnNextButtonClick?.Invoke();
    }
}