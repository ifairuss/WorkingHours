using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavesButtonData : MonoBehaviour
{
    public Button DownloadFileButton;
    public TextMeshProUGUI TotalHoursText;
    public TextMeshProUGUI MonthName;

    [Header("Day add preferences")]
    [SerializeField] private DataInt dataInt = new DataInt();
    [SerializeField] private DataFloat dataFloat = new DataFloat();
    [SerializeField] private List<DayDataSave> _allDayData = new List<DayDataSave>();


    public string SavesName;

    public void Start()
    {
        LoadSavesData();
        TotalHoursText.text = $"{dataInt.HourToMonth}h";
    }

    private void LoadSavesData()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SavesName) != false)
        {
            string[] readed = File.ReadAllLines(Application.persistentDataPath + "/" + SavesName);

            dataFloat = JsonUtility.FromJson<DataFloat>(readed[0]);
            dataInt = JsonUtility.FromJson<DataInt>(readed[1]);

            for (int i = 2; i < readed.Length; i++)
            {
                _allDayData[i - 2] = JsonUtility.FromJson<DayDataSave>(readed[i]);
            }
        }
    }
}
