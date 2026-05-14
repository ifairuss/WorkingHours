using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticAdd : MonoBehaviour
{
    [SerializeField] private int _workingTimeInDay;
    [SerializeField] private int _currentDay;
    [SerializeField] private char _shift;

    [Header("Time preferences")]
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_InputField _timeInputText;

    [Header("Day preferences")]
    [SerializeField] private TMP_InputField _dayInputText;

    [Header("Other preferences")]
    [SerializeField] private Button _submitButton;
    [SerializeField] private GameObject _statisticMenu;

    private WHData _data;

    public void Start()
    {
        _data = GetComponent<WHData>();

        _submitButton.onClick.AddListener(() => { SubmitButton(); });

        _dayInputText.text = DateTime.Now.Day.ToString();
    }

    private void SubmitButton()
    {
        _data.SetDayData(_currentDay, _workingTimeInDay, _shift);
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
