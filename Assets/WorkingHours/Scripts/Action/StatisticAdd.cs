using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticAdd : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_InputField _timeInputText;

    [SerializeField] private GameObject _statisticMenu;
    [SerializeField] private Button _submitButton;

    [SerializeField] private int _workingTimeInDay;

    public void Start()
    {
        _submitButton.onClick.AddListener(() => { SubmitButton(); });
    }

    private void SubmitButton()
    {
        print($"{_workingTimeInDay} Comlited");

        print($"Add day menu closed");
        _statisticMenu.SetActive( false );
    }

    private void Update()
    {
        _timeInputText.text = _timeSlider.value.ToString();
        _workingTimeInDay = (int)_timeSlider.value;

    }
}
