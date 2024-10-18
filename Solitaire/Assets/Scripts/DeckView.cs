using DG.Tweening;
using System;
using UnityEngine;

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
        var rt = card.GetComponent<RectTransform>();
        var targetPosition = Vector3.zero;
        var duration = 0.5f;

        rt.DOAnchorPos(targetPosition, duration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            rt.DOShakeAnchorPos(0.2f, strength: new Vector2(3f, 3f), vibrato: 3, randomness: 90, snapping: false, fadeOut: true);
        });

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
