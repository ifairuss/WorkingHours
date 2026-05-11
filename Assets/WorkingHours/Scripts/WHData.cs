using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DataFloat
{
    public float TotalMoneyInMonth;
    public float MoneyToHour;
    public float TargetMoneyToMonth;
}

public class DataInt
{
    public int MonthToHour;
    public int TargetHourToMonth;
}


public class WHData : MonoBehaviour
{
    public static WHData Instance { get; private set; }

    [Header("Indicator preferences")]
    [SerializeField] private TextMeshProUGUI _totalHourToMonthTextUI;
    [SerializeField] private TextMeshProUGUI _totalMoneyToMonthTextUI;
    [SerializeField] private Image _timeImage;
    [SerializeField] private Image _moneyImage;

    private DataFloat dataFloat = new DataFloat();
    private DataInt dataInt = new DataInt();

    private string _fileName = "WHData";

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        dataFloat.TargetMoneyToMonth = 6500;
        dataFloat.TotalMoneyInMonth = 1543.54f;

        dataInt.MonthToHour = 52;
        dataInt.TargetHourToMonth = 160;
    }

    public void RatePreferences(int TargetHour, float TargetMoney, float MoneyToHours)
    {
        dataInt.TargetHourToMonth = TargetHour;
        dataFloat.MoneyToHour = MoneyToHours;
        dataFloat.TargetMoneyToMonth = TargetMoney;
    }

    private void Update()
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        _totalHourToMonthTextUI.text = dataInt.MonthToHour.ToString();
        _totalMoneyToMonthTextUI.text = dataFloat.TotalMoneyInMonth.ToString();

        _timeImage.fillAmount = ((float)dataInt.MonthToHour / (float)dataInt.TargetHourToMonth);
        _moneyImage.fillAmount = (dataFloat.TotalMoneyInMonth / dataFloat.TargetMoneyToMonth);
    }

    public void RatePreferencesSaveData()
    {
        StreamWriter SWriter = new StreamWriter(Application.persistentDataPath + "/" + _fileName);

        string dataFloatSave = JsonUtility.ToJson(dataFloat);
        string dataIntSave = JsonUtility.ToJson(dataInt);

        print(dataFloatSave);
        print(dataIntSave);

        SWriter.WriteLine(dataFloatSave);
        SWriter.WriteLine(dataIntSave);

        SWriter.Close();
    }

    public void RatePreferencesLoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + _fileName))
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/" + _fileName);

            for (int i = 0; i < readed.Length; i++)
            {
                dataFloat = JsonUtility.FromJson<DataFloat>(readed[0]);
                dataInt = JsonUtility.FromJson<DataInt>(readed[1]);
            }
        }
    }
}
