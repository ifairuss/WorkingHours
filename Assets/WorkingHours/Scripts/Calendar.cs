using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public static Calendar Instance { get; private set; }

    [SerializeField] private List<GameObject> _allDayInMonth;

    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _timeText;

    [Header("Day stats color preferences")]
    [SerializeField] private Color _workingDayColor;
    [SerializeField] private Color _weekendDayColor;
    [SerializeField] private Color _truancyDayColor;
    [SerializeField] private Color _excessiveDayColor;
    [SerializeField] private Color _monthsDayColor;

    private string Day;
    private string Month;
    private string Year;
    private int DayInMounth;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        DisableAllDay();

        Day = DateTime.Now.Day.ToString().PadLeft(2, '0');
        Month = DateTime.Now.Month.ToString().PadLeft(2, '0');
        Year = DateTime.Now.Year.ToString();

        _dateText.text = $"{Day}/{Month}/{Year}";

        DayInMounth = DateTime.DaysInMonth(DateTime.Now.Year, 2);

        for (int i = 0; i < DayInMounth; i++)
        {
            Image imageStats = _allDayInMonth[i].GetComponentInChildren<Image>();
            TextMeshProUGUI dateText = _allDayInMonth[i].GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _monthsDayColor;
            dateText.color = Color.white;
        }
    }

    private void DisableAllDay()
    {
        for (int i = 0; i < _allDayInMonth.Count; i++)
        {
            Image imageStats = _allDayInMonth[i].GetComponentInChildren<Image>();
            TextMeshProUGUI dateText = _allDayInMonth[i].GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _excessiveDayColor;
            dateText.color = _excessiveDayColor;
        }
    }

    private void Update()
    {
        _timeText.text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute.ToString().PadLeft(2,'0')}";
    }
}
