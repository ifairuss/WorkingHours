using UnityEngine;
using UnityEngine.UI;

public class MenuButtonAnimations : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _noActive;
    [SerializeField] private Sprite _active;

    public void AnimationButton(bool isActive)
    {
        if (isActive)
        {
            _buttonImage.sprite = _active;
        }
        else
        {
            _buttonImage.sprite = _noActive;
        }
    }
}
