using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleSaves : MonoBehaviour
{
    public static ScheduleSaves Instance;

    [Header("Saves schedule window <List> ")]
    [SerializeField] private List<AllDayInMonth> _allDayInMonth;
    [SerializeField] private List<SavesButtonData> _allDataButton;

    [Header("Components")]
    [SerializeField] private GameObject _scheduleWindow;
    [SerializeField] private Calendar _colorData;
    [SerializeField] private TextMeshProUGUI _monthName;
    [SerializeField] private Button _closedScheduleWindow;

    public int DataIndex;

    private int DayInMounth;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized(int index, int year, int month, string nameMonth)
    {
        _closedScheduleWindow.onClick.AddListener(() => { _scheduleWindow.SetActive(false); });

        _scheduleWindow.SetActive(true);

        DataIndex = index;

        DayInMounth = DateTime.DaysInMonth(year, month);

        _monthName.text = nameMonth;

        DisableAllDay();

        for (int i = 0; i < DayInMounth; i++)
        {
            Image imageStats = _allDayInMonth[i]._dayImage;
            TextMeshProUGUI dateText = _allDayInMonth[i]._day.GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _colorData.MonthsDayColor;
            dateText.color = Color.white;

            _allDayInMonth[i]._shiftChar.text = "";
        }
    }

    private void Update()
    {
        for (int i = 0; i < _allDataButton[DataIndex].AllDaysData.Count; i++)
        {
            CalendarDayData(_allDataButton[DataIndex].AllDaysData[i], i);
        }
    }

    public void CalendarDayData(DayDataSave DayData, int i)
    {
        _allDayInMonth[i]._shiftChar = _allDayInMonth[i]._dayImage.GetComponentInChildren<TextMeshProUGUI>();

        if (DayData.Shift == 'x')
        {
            _allDayInMonth[i]._dayImage.color = _colorData.MonthsDayColor;
            _allDayInMonth[i]._shiftChar.text = "";
        }
        else if (DayData.Shift == 'T')
        {
            _allDayInMonth[i]._dayImage.color = _colorData.TruancyDayColor;
            _allDayInMonth[i]._shiftChar.text = "";
        }
        else if (DayData.Shift == 'W')
        {
            _allDayInMonth[i]._dayImage.color = _colorData.WeekendDayColor;
            _allDayInMonth[i]._shiftChar.text = "";
        }
        else
        {
            string ShiftChar = "";

            if (DayData.Shift == 'Ⅰ')
            {
                ShiftChar = "I";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'Ⅱ')
            {
                ShiftChar = "II";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'Ⅲ')
            {
                ShiftChar = "III";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'Ⅳ')
            {
                ShiftChar = "IV";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'D')
            {
                ShiftChar = "D";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'P')
            {
                ShiftChar = "P";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'S')
            {
                ShiftChar = "S";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else if (DayData.Shift == 'N')
            {
                ShiftChar = "N";
                _allDayInMonth[i]._dayImage.color = _colorData.WorkingDayColor;
                _allDayInMonth[i]._shiftChar.text = ShiftChar;
            }
            else
            {
                ShiftChar = DayData.Shift.ToString();
            }
        }
    }

    private void DisableAllDay()
    {
        for (int i = 0; i < _allDayInMonth.Count; i++)
        {
            Image imageStats = _allDayInMonth[i]._dayImage;
            TextMeshProUGUI dateText = _allDayInMonth[i]._day.GetComponentInChildren<TextMeshProUGUI>();

            imageStats.color = _colorData.ExcessiveDayColor;
            dateText.color = _colorData.ExcessiveDayColor;
        }
    }
}
