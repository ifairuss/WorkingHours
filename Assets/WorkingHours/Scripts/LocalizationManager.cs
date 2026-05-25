using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AllLocalizationInApplications
{
    public string Name;
    public List<string> Localization;
    public Button ButtonSwitchLanguage;
}

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }

    private int _localizationIndex;
    private int _currentIndex;

    [Header("Words")]
    [SerializeField] private List<TextMeshProUGUI> _allWords;
    [Header("Localizations variable")]
    [SerializeField] private List<AllLocalizationInApplications> _allLocalization;

    [SerializeField] private GameObject _languageWindow;
    [SerializeField] private WHData data;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        _localizationIndex = data.LanguageIndex;

        for (int i = 0; i < _allWords.Count; i++)
        {
            _allWords[i].text = _allLocalization[_localizationIndex].Localization[i];
        }

        _currentIndex = _localizationIndex;
    }

    public void ButtonClick(int index)
    {
        _localizationIndex = index;
        _languageWindow.SetActive(false);
    }

    private void Update()
    {
        if (_currentIndex != _localizationIndex)
        {
            for (int i = 0; i < _allWords.Count; i++)
            {
                _allWords[i].text = _allLocalization[_localizationIndex].Localization[i];
            }
            _currentIndex = _localizationIndex;
            data.LanguageIndex = _localizationIndex;
            data.SaveData();
        }
    }
}
