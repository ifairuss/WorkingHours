using System;
using System.IO;
using UnityEngine;

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

    private DataFloat dataFloat = new DataFloat();
    private DataInt dataInt = new DataInt();

     public float MoneyToHour;
     public int MonthToHour;
     public int TargetHourToMonth;
     public float TotalMoneyInMonth;
     public float TargetMoneyToMonth;




    private string _fileName = "WHData";

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        dataFloat.MoneyToHour = 31f;
        dataInt.MonthToHour = 52;
        dataInt.TargetHourToMonth = 160;
        dataFloat.TotalMoneyInMonth = 1530.53f;
        dataFloat.TargetMoneyToMonth = 6500;
    }

    public void RatePreferences(int TargetHour, float TargetMoney, float MoneyToHours)
    {
        dataInt.TargetHourToMonth = TargetHour;
        dataFloat.MoneyToHour = MoneyToHours;
        dataFloat.TargetMoneyToMonth = TargetMoney;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            RatePreferencesSaveData();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RatePreferencesLoadData();
        }
    }

    public void RatePreferencesSaveData()
    {
        dataFloat.MoneyToHour = MoneyToHour;
        dataInt.MonthToHour = MonthToHour;
        dataInt.TargetHourToMonth = TargetHourToMonth;
        dataFloat.TotalMoneyInMonth = TotalMoneyInMonth;
        dataFloat.TargetMoneyToMonth = TargetMoneyToMonth;

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

        MoneyToHour = dataFloat.MoneyToHour;
        MonthToHour = dataInt.MonthToHour;
        TargetHourToMonth = dataInt.TargetHourToMonth;
        TotalMoneyInMonth = dataFloat.TotalMoneyInMonth;
        TargetMoneyToMonth = dataFloat.TargetMoneyToMonth;
    }
}
