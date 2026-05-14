using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AllDayInMonth 
{
    public GameObject _day;
    public Image _dayImage;
}

public class Calendar : MonoBehaviour
{
    public static Calendar Instance { get; private set; }

    [SerializeField] private List<AllDayInMonth> _allDayInMonth;

    [SerializeField] private WHData _data;

    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _timeText;

    [Header("Day stats color preferences")]
    [SerializeField] private Color _workingDayColor;
    [SerializeField] private Color _weekendDayColor;
    [SerializeField] private Color _truancyDayColor;
    [SerializeField] private Color _excessiveDayColor;
    [SerializeField] private Color _monthsDayColor;

    private string Month;
    private string Year;
    private string Day;
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
            Image imageStats = _allDayInMonth[i]._dayImage;
            TextMeshProUGUI dateText = _allDayInMonth[i]._day.GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _monthsDayColor;
            dateText.color = Color.white;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _data.AllDayData.Count; i++)
        {
            CalendarDayData(_data.AllDayData[i], i);

        }

        _timeText.text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute.ToString().PadLeft(2, '0')}";
    }

    public void CalendarDayData(DayDataSave DayData, int i)
    {
        if (DayData.Shift == 'x')
        {
            _allDayInMonth[i]._dayImage.color = _monthsDayColor;
        } 
        else if(DayData.Shift == 'T')
        {
            _allDayInMonth[i]._dayImage.color = _truancyDayColor;
        }
        else if (DayData.Shift == 'W')
        {
            _allDayInMonth[i]._dayImage.color = _weekendDayColor;
        }
        else 
        {
            _allDayInMonth[i]._dayImage.color = _workingDayColor;
        }
    }

    private void DisableAllDay()
    {
        for (int i = 0; i < _allDayInMonth.Count; i++)
        {
            Image imageStats = _allDayInMonth[i]._dayImage;
            TextMeshProUGUI dateText = _allDayInMonth[i]._day.GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _excessiveDayColor;
            dateText.color = _excessiveDayColor;
        }
    }
}
