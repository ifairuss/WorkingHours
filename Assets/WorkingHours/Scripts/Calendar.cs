using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar Instance { get; private set; }

    [SerializeField] private List<GameObject> _allDayInMonth;

    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _timeText;

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

        DayInMounth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

        for (int i = 0; i < DayInMounth; i++)
        {
            _allDayInMonth[i].SetActive(true);
        }
    }

    private void DisableAllDay()
    {
        for (int i = 0; i < _allDayInMonth.Count; i++)
        {
            _allDayInMonth[i].SetActive(false);
        }
    }

    private void Update()
    {
        _timeText.text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute.ToString().PadLeft(2,'0')}";
    }
}
