using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private GameObject _front, _back;

    public void UpdateFrontSprite(Sprite sprite)
    {
        _front.GetComponent<Image>().sprite = sprite;
        _back.SetActive(false);
    }
}
