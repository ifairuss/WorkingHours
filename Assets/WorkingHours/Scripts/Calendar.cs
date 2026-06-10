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
    public TextMeshProUGUI _shiftChar;
}

public class Calendar : MonoBehaviour
{
    public static Calendar Instance { get; private set; }

    [SerializeField] private List<AllDayInMonth> _allDayInMonth;

    [SerializeField] private WHData _data;

    [SerializeField] private TextMeshProUGUI _dateText;
    [SerializeField] private TextMeshProUGUI _timeText;

    [Header("Day stats color preferences")]
    public Color WorkingDayColor;
    public Color WeekendDayColor;
    public Color TruancyDayColor;
    public Color ExcessiveDayColor;
    public Color MonthsDayColor;

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

            imageStats.color = MonthsDayColor;
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
        _allDayInMonth[i]._shiftChar = _allDayInMonth[i]._dayImage.GetComponentInChildren<TextMeshProUGUI>();

        if (DayData.Shift == 'x')
        {
            _allDayInMonth[i]._dayImage.color = MonthsDayColor;
            _allDayInMonth[i]._shiftChar.text = ""; 
        } 
        else if(DayData.Shift == 'T')
        {
            _allDayInMonth[i]._dayImage.color = TruancyDayColor;
            _allDayInMonth[i]._shiftChar.text = "";
        }
        else if (DayData.Shift == 'W')
        {
            _allDayInMonth[i]._dayImage.color = WeekendDayColor;
            _allDayInMonth[i]._shiftChar.text = "UW";
        }
        else 
        {
            string ShiftChar = "";

            if (DayData.Shift == 'Ⅰ')
            {
                ShiftChar = "I";
            } 
            else if (DayData.Shift == 'Ⅱ')
            {
                ShiftChar = "II";
            }
            else if (DayData.Shift == 'Ⅲ')
            {
                ShiftChar = "III";
            }
            else if (DayData.Shift == 'Ⅳ')
            {
                ShiftChar = "IV";
            }
            else
            {
                ShiftChar = DayData.Shift.ToString();
            }
            _allDayInMonth[i]._dayImage.color = WorkingDayColor;
            _allDayInMonth[i]._shiftChar.text = ShiftChar;
        }
    }

    private void DisableAllDay()
    {
        for (int i = 0; i < _allDayInMonth.Count; i++)
        {
            Image imageStats = _allDayInMonth[i]._dayImage;
            TextMeshProUGUI dateText = _allDayInMonth[i]._day.GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = ExcessiveDayColor;
            dateText.color = ExcessiveDayColor;
        }
    }
}
