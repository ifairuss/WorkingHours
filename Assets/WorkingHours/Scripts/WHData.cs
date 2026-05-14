using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DataFloatApplication
{
    public float MoneyToHour;
    public float TargetMoneyToMonth;
}

public class DataIntApplication
{
    public int TargetHourToMonth;
}

public class DataFloat
{
    public float TotalMoneyInMonth;
}

public class DataInt
{
    public int HourToMonth;
}

[Serializable]
public class DayDataSave
{
    public string Name;

    public bool Truancy;
    public int Day;
    public int Times;
    public char Shift;
}


public class WHData : MonoBehaviour
{
    public static WHData Instance { get; private set; }

    [SerializeField] private string _currency;

    [Header("Indicator preferences")]
    [SerializeField] private TextMeshProUGUI _totalHourToMonthTextUI;
    [SerializeField] private TextMeshProUGUI _totalMoneyToMonthTextUI;
    [SerializeField] private TextMeshProUGUI _targetHourToMonthTextUI;
    [SerializeField] private TextMeshProUGUI _targetMoneyToMonthTextUI;
    [SerializeField] private Image _timeImage;
    [SerializeField] private Image _moneyImage;

    [Header("Day add preferences")]
    [SerializeField] private List<DayDataSave> _allDayData;

    private DataFloat dataFloat = new DataFloat();
    private DataFloatApplication dataFloatApplication = new DataFloatApplication();
    private DataIntApplication dataIntApplication = new DataIntApplication();
    private DataInt dataInt = new DataInt();

    private string _fileName;
    private string _fileNameApplicationSave = "Application Save";

    private string[] _month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        _fileName = $"{_month[DateTime.Now.Month - 1]}{DateTime.Now.Year}";
        DayListData();

        UpdateStats();
    }

    private void DayListData()
    {
        _allDayData = new List<DayDataSave>(new DayDataSave[DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)]);

        for (int i = 0; i < _allDayData.Count; i++)
        {
            _allDayData[i] = new DayDataSave();
            _allDayData[i].Name = (i+1).ToString();
        }
    }

    public void SetDayData(int Day, int Times, char Shift)
    {
        _allDayData[Day - 1].Day = Day;
        _allDayData[Day - 1].Times = Times;
        _allDayData[Day - 1].Shift = Shift;

        MonthData();
        UpdateStats();
    }

    public void RatePreferences(int TargetHour, float TargetMoney, float MoneyToHours)
    {
        dataIntApplication.TargetHourToMonth = TargetHour;
        dataFloatApplication.MoneyToHour = MoneyToHours;
        dataFloatApplication.TargetMoneyToMonth = TargetMoney;

        PreferencesSaveData();
        MonthSaveData();
        UpdateStats();
    }

    private void UpdateStats()
    {
        PreferencesLoadData();
        MonthLoadData();

        _totalHourToMonthTextUI.text = $"{dataInt.HourToMonth.ToString()}h";
        _totalMoneyToMonthTextUI.text = $"{dataFloat.TotalMoneyInMonth.ToString()}{_currency}";
        _targetHourToMonthTextUI.text = $"{dataIntApplication.TargetHourToMonth}h";
        _targetMoneyToMonthTextUI.text = $"{dataFloatApplication.TargetMoneyToMonth}{_currency}";

        _timeImage.fillAmount = ((float)dataInt.HourToMonth / (float)dataIntApplication.TargetHourToMonth);
        _moneyImage.fillAmount = (dataFloat.TotalMoneyInMonth / dataFloatApplication.TargetMoneyToMonth);
    }

    private void MonthData()
    {
        dataInt.HourToMonth = 0;

        for (int i = 0; i < _allDayData.Count; i++)
        {
            dataInt.HourToMonth += _allDayData[i].Times;

            print(dataInt.HourToMonth);
        }

        dataFloat.TotalMoneyInMonth = 0;
        dataFloat.TotalMoneyInMonth = (dataInt.HourToMonth * dataFloatApplication.MoneyToHour);
        print(dataFloat.TotalMoneyInMonth);

        MonthSaveData();

    }

    public void MonthSaveData()
    {
        StreamWriter SWriter = new StreamWriter(Application.persistentDataPath + "/" + _fileName);

        string dataFloatSave = JsonUtility.ToJson(dataFloat);
        string dataIntSave = JsonUtility.ToJson(dataInt);

        SWriter.WriteLine(dataFloatSave);
        SWriter.WriteLine(dataIntSave);

        for (int i = 0; i < _allDayData.Count; i++)
        {
            string dataAllDaySave = JsonUtility.ToJson(_allDayData[i]);
            SWriter.WriteLine(dataAllDaySave);
        }

        SWriter.Close();
    }

    public void MonthLoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + _fileName))
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/" + _fileName);

            dataFloat = JsonUtility.FromJson<DataFloat>(readed[0]);
            dataInt = JsonUtility.FromJson<DataInt>(readed[1]);

            for (int i = 2; i < readed.Length; i++)
            {
                _allDayData[i - 2] = JsonUtility.FromJson<DayDataSave>(readed[i]);
            }
        }
    }

    public void PreferencesSaveData()
    {
        StreamWriter SWriter = new StreamWriter(Application.persistentDataPath + "/" + _fileNameApplicationSave);

        string dataFloatSave = JsonUtility.ToJson(dataFloatApplication);
        string dataIntSave = JsonUtility.ToJson(dataIntApplication);

        print(dataFloatSave);
        print(dataIntSave);

        SWriter.WriteLine(dataFloatSave);
        SWriter.WriteLine(dataIntSave);

        SWriter.Close();
    }

    public void PreferencesLoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + _fileNameApplicationSave))
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/" + _fileNameApplicationSave);

            for (int i = 0; i < readed.Length; i++)
            {
                dataFloatApplication = JsonUtility.FromJson<DataFloatApplication>(readed[0]);
                dataIntApplication = JsonUtility.FromJson<DataIntApplication>(readed[1]);
            }
        }
    }
}
