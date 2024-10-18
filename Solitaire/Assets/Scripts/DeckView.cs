using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckView : MonoBehaviour
{
    [SerializeField] private Transform _endStack;
    [SerializeField] private RectTransform _reloadButtonTransform;
    [SerializeField] private RectTransform _nextButtonTransform;

    private ICardContainer _cardContainer;
    private ISpriteLoader _spriteLoader;

    public event Action OnNextButtonClick;

    private const float AnimationDuration = 0.5f;
    private const float ButtonStretchScaleY = 0.4f;

    private void Awake()
    {
        InitializeDependencies();
    }

    private void Start()
    {
        ShowInitialGameCards();
    }

    private void InitializeDependencies()
    {
        _cardContainer = GetComponent<ICardContainer>();
        _spriteLoader = GetComponent<ISpriteLoader>();
    }

    public void ShowCurrentCard(Card card)
    {
        if (card == null) return;

        PlaceCardAtEndStack(card);
        AnimateCardToEndStack(card.GetComponent<RectTransform>());
        UpdateCardSprite(card);
    }

    private void PlaceCardAtEndStack(Card card)
    {
        card.transform.SetParent(_endStack, true);
    }

    private void AnimateCardToEndStack(RectTransform cardTransform)
    {
        cardTransform.DOAnchorPos(Vector3.zero, AnimationDuration).SetEase(Ease.OutQuad);
    }

    private void ShowInitialGameCards()
    {
        for (int i = 0; i < 4; i++)
        {
            Card card = _cardContainer.GetFirstTableCard(i);
            UpdateCardSprite(card);
        }

        ShowCurrentCard(_cardContainer.GetDeckCard());
    }

    public void UpdateCardSprite(Card card)
    {
        if (card == null) return;

        CardView view = card.GetComponent<CardView>();
        view.UpdateFrontSprite(_spriteLoader.GetSprite(card.Rank, UnityEngine.Random.Range(0, 4)));
    }

    public void OnNextDeckCard()
    {
        AnimateButton(_nextButtonTransform, new Vector3(360f, 0f, 0f));
        OnNextButtonClick?.Invoke();
    }

    private void AnimateButton(RectTransform buttonTransform, Vector3 rotation)
    {
        Vector3 stretchedScale = new Vector3(1f, ButtonStretchScaleY, 1f);

        buttonTransform
            .DOScale(stretchedScale, AnimationDuration).SetEase(Ease.OutBack)
            .OnComplete(() => ResetButtonAnimation(buttonTransform));

        buttonTransform
            .DORotate(rotation, AnimationDuration, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
    }

    private void ResetButtonAnimation(RectTransform buttonTransform)
    {
        buttonTransform.DOScale(Vector3.one, AnimationDuration).SetEase(Ease.OutBounce);
        buttonTransform.DORotate(Vector3.zero, AnimationDuration);
    }

    public void OnReloadLevel()
    {
        AnimateReloadButton(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    private void AnimateReloadButton(Action onComplete)
    {
        _reloadButtonTransform
            .DORotate(new Vector3(0f, 0f, -360f), AnimationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => onComplete?.Invoke());
    }
}
