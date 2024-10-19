using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckView : MonoBehaviour, IDeckView
{
    [SerializeField] private Transform _endStack;

    [SerializeField] private RectTransform _reloadButtonTransform;
    [SerializeField] private RectTransform _nextButtonTransform;

    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _loseText;

    private ISpriteLoader _spriteLoader;

    public event Action OnNextButtonClick;

    private const float AnimationDuration = 0.5f;
    private const float ButtonStretchScaleY = 0.4f;
    private const float ButtonRotationAngle = 360f;

    private void Awake()
    {
        _spriteLoader = GetComponent<ISpriteLoader>();
    }

    public void MoveCardToEndStack(Card card)
    {
        card.transform.SetParent(_endStack, true);
        RectTransform cardTransform = card.GetComponent<RectTransform>();
        cardTransform.DOAnchorPos(Vector3.zero, AnimationDuration).SetEase(Ease.OutQuad);
    }

    public void ShowCard(Card card)
    {
        if (card == null) 
            return;

        CardView view = card.GetComponent<CardView>();
        view.UpdateFrontSprite(_spriteLoader.GetSprite(card.Rank, UnityEngine.Random.Range(0, 4)));
    }

    private void AnimateButton(RectTransform buttonTransform, Vector3 direction, Action onComplete = null)
    {
        buttonTransform
            .DORotate(direction, AnimationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                onComplete?.Invoke();
            });
    }

    public void OnReloadLevel()
    {
        AnimateButton(_reloadButtonTransform, new Vector3(0f, 0f, -360f), () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void OnNextDeckCard()
    {
        AnimateButton(_nextButtonTransform, new Vector3(360f, 0f, 0f));
        OnNextButtonClick?.Invoke();
    }

    public void ShowWinMessage()
    {
        _winText.SetActive(true);
    }

    public void ShowLoseMessage()
    {
        _loseText.SetActive(true);
    }
}
