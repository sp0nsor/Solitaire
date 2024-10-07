using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private GameObject _front, _back;
    //[SerializeField] private SpriteLoader _spriteLoader;

    private Card _model;

    private void OnEnable()
    {
        //_model = GetComponent<CardModel>();
        //InitFrontImage();
    }

/*    public void SetFrontImage(Sprite sprite)
    {
        _front.GetComponent<Image>().sprite = sprite;
    }*/

/*    public void InitFrontImage()
    {
        Sprite sprite = _spriteLoader.GetSprite(_model.Rank, Random.Range(0, 4));
        _front.GetComponent<Image>().sprite = sprite;
    }*/
}
