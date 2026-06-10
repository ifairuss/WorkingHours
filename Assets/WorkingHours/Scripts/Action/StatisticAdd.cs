using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ShiftButton
{
    public string Name;
    public Button Button;
    public bool Select;
    public Image ButtonBGSelect;
    public char _charShift;
}

public class StatisticAdd : MonoBehaviour
{
    public static StatisticAdd Instance { get; private set; }

    private int _workingTimeInDay;
    private int _currentDay;
    private char _shift;

    [Header("Time preferences")]
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_InputField _timeInputText;

    [Header("Day preferences")]
    [SerializeField] private TMP_InputField _dayInputText;

    [Header("Shift preferences")]
    [SerializeField] private List<ShiftButton> _allShiftButton;
    [SerializeField] private RectTransform _selectImage;


    [Header("Other preferences")]
    [SerializeField] private Button _submitButton;
    [SerializeField] private GameObject _statisticMenu;
    [SerializeField] private List<SavesButtonData> _savesData;

    private WHData _data;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        _data = GetComponent<WHData>();

        _submitButton.onClick.AddListener(() => { SubmitButton(); });
        ButtonShift();

        _dayInputText.text = DateTime.Now.Day.ToString();
    }

    private void ButtonShift()
    {
        _allShiftButton[0].Button.onClick.AddListener(() => { ButtonShiftSelect(0); });
        _allShiftButton[1].Button.onClick.AddListener(() => { ButtonShiftSelect(1); });
        _allShiftButton[2].Button.onClick.AddListener(() => { ButtonShiftSelect(2); });
        _allShiftButton[3].Button.onClick.AddListener(() => { ButtonShiftSelect(3); });
        _allShiftButton[4].Button.onClick.AddListener(() => { ButtonShiftSelect(4); });
        _allShiftButton[5].Button.onClick.AddListener(() => { ButtonShiftSelect(5); });
        _allShiftButton[6].Button.onClick.AddListener(() => { ButtonShiftSelect(6); });
        _allShiftButton[7].Button.onClick.AddListener(() => { ButtonShiftSelect(7); });
        _allShiftButton[8].Button.onClick.AddListener(() => { ButtonShiftSelect(8); });
        _allShiftButton[9].Button.onClick.AddListener(() => { ButtonShiftSelect(9); });
    }

    private void ButtonShiftSelect(int Button)
    {
        for (int i = 0; i < _allShiftButton.Count; i++)
        {
            _allShiftButton[i].Select = false;
        }

        _allShiftButton[Button].Select = true;

        if (Button <= 3) { _timeSlider.value = 8; }
        else if (Button > 3 && Button <= 7) { _timeSlider.value = 12; }
        else { _timeSlider.value = 0; }

        _selectImage.gameObject.SetActive(true);
        _selectImage.position = _allShiftButton[Button].Button.transform.position;
        _shift = _allShiftButton[Button]._charShift;
    }

    private void SubmitButton()
    {
        if (_allShiftButton[8].Select == true)
        {
            _data.SetDayData(_currentDay, _workingTimeInDay = 0, _shift = 'T', _allShiftButton[8].Select);
            _statisticMenu.SetActive(false);
        }
        else
        {
            _data.SetDayData(_currentDay, _workingTimeInDay, _shift, _allShiftButton[8].Select);
            _statisticMenu.SetActive(false);
        }

        for (int i = 0; i < _savesData.Count; i++)
        {
            _savesData[i].UpdateData();
        }
    }

    private void Update()
    {
        _timeInputText.text = _timeSlider.value.ToString();
        _workingTimeInDay = (int)_timeSlider.value;

        if (_dayInputText.text == "") { return; }

        _currentDay = int.Parse(_dayInputText.text);

    }
}
