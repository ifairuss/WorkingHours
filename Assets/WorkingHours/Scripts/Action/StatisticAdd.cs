using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticAdd : MonoBehaviour
{
    [SerializeField] private int _workingTimeInDay;
    [SerializeField] private int _currentDay;

    [Header("Time preferences")]
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_InputField _timeInputText;

    [Header("Day preferences")]
    [SerializeField] private TMP_InputField _dayInputText;

    [Header("Other preferences")]
    [SerializeField] private Button _submitButton;
    [SerializeField] private GameObject _statisticMenu;

    public void Start()
    {
        _submitButton.onClick.AddListener(() => { SubmitButton(); });

        _dayInputText.text = DateTime.Now.Day.ToString();
    }

    private void SubmitButton()
    {
        print($"{_workingTimeInDay} Comlited");
        print($"{_currentDay} Comlited");

        print($"Add day menu closed");
        _statisticMenu.SetActive( false );
    }

    private void Update()
    {
        _timeInputText.text = _timeSlider.value.ToString();
        _workingTimeInDay = (int)_timeSlider.value;

        if (_dayInputText.text == "") { return; }

        _currentDay = int.Parse(_dayInputText.text);

    }
}
