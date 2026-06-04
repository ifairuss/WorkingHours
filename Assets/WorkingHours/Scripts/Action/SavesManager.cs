using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SavesData
{
    public SavesButtonData ButtonData;
    public string SavesName;
}

public class SavesManager : MonoBehaviour
{
    [SerializeField] private List<SavesButtonData> SavesButton;
    [SerializeField] private List<SavesData> SavesDataMonth;

    public void MonthAdd(string[] month)
    {
        for (int i = 0; i < month.Length; i++)
        {
            if (DateTime.Now.Month >= 2 && DateTime.Now.Day >= 1)
            {
                SavesDataMonth[i].SavesName = $"{month[i]}{DateTime.Now.Year}";
                SavesDataMonth[12].SavesName = $"{month[0]}{DateTime.Now.Year + 1}";
            }
            else
            {
                SavesDataMonth[i].SavesName = $"{month[i]}{DateTime.Now.Year - 1}";
                SavesDataMonth[12].SavesName = $"{month[0]}{DateTime.Now.Year}";
            }

            SavesDataMonth[i].ButtonData = SavesButton[i];
            SavesButton[i].SavesName = SavesDataMonth[i].SavesName;
            SavesDataMonth[12].ButtonData = SavesButton[12];
            SavesButton[12].SavesName = SavesDataMonth[12].SavesName;

            SavesButton[i].MonthName.text = month[i];
        }
    }
}
