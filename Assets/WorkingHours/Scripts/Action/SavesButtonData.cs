using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavesButtonData : MonoBehaviour
{
    public TextMeshProUGUI TotalMoneyToMonth;
    public TextMeshProUGUI TotalHoursText;
    public TextMeshProUGUI MonthName;

    public string MonthNameSchedule;

    public int Month;
    public int Year;

    [Header("Day add preferences")]
    public List<DayDataSave> AllDaysData = new List<DayDataSave>();

    [SerializeField] private int Index;

    [SerializeField] private DataInt dataInt = new DataInt();
    [SerializeField] private DataFloat dataFloat = new DataFloat();

    public string SavesName;

    private Button _loadButton;

    public void UpdateData()
    {
        LoadSavesData();

        TotalHoursText.text = $"{dataInt.HourToMonth}h";
        TotalMoneyToMonth.text = $"{dataFloat.TotalMoneyInMonth}{WHData.Currency}";

        _loadButton = GetComponent<Button>();

        _loadButton.onClick.AddListener(() =>
        {
            ScheduleSaves.Instance.Initialized(Index, Year, Month, MonthNameSchedule);
            UpdateData();
        });
    }

    public void LoadSavesData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SavesName) != false)
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/" + SavesName);

            dataFloat = JsonUtility.FromJson<DataFloat>(readed[0]);
            dataInt = JsonUtility.FromJson<DataInt>(readed[1]);

            for (int i = 2; i < readed.Length; i++)
            {
                AllDaysData[i - 2] = JsonUtility.FromJson<DayDataSave>(readed[i]);
            }
        }
    }
}
