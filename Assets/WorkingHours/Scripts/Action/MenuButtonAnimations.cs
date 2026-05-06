using UnityEngine;

public class MenuButtonAnimations : MonoBehaviour
{
    [SerializeField] private RectTransform _topLine;
    [SerializeField] private RectTransform _middleLine;
    [SerializeField] private RectTransform _bottomLine;

    public void AnimationButton(bool isActive)
    {
        if (isActive)
        {
            _middleLine.gameObject.SetActive(false);
            _topLine.localRotation = Quaternion.Euler(0, 0, 45);
            _bottomLine.localRotation = Quaternion.Euler(0, 0, -45);
            _topLine.localPosition = new Vector3(50 ,-50 ,0);
            _bottomLine.localPosition = new Vector3(50, -50, 0);
        }
        else
        {
            _middleLine.gameObject.SetActive(true);
            _topLine.localRotation = Quaternion.Euler(0, 0, 0);
            _bottomLine.localRotation = Quaternion.Euler(0, 0, 0);
            _topLine.localPosition = new Vector3(50, -30, 0);
            _bottomLine.localPosition = new Vector3(50, -70, 0);
        }
    }
}
