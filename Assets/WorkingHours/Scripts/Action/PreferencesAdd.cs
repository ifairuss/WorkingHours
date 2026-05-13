using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesAdd : MonoBehaviour
{
    public static PreferencesAdd Instance { get; private set; }

    private float _moneyToHour;
    private float _targetMoneyToHour;
    private int _targetHourToMonth;

    [Header("Input field preferences")]
    [SerializeField] private TMP_InputField _inputMoneyToHour;
    [SerializeField] private TMP_InputField _inputTargetMoneyToHour;
    [SerializeField] private TMP_InputField _inputTargetHourToMonth;

    [Header("Button preferences")]
    [SerializeField] private Button _submitText;
    [SerializeField] private GameObject _preferencesMenu;

    private WHData _data;

    private void Awake()
    {
        Instance = this;
    }

    public void Initilized()
    {
        _data = GetComponent<WHData>();
        _submitText.onClick.AddListener(() => { SumbitButton(); });
    }

    private void SumbitButton()
    {   
        if(_inputMoneyToHour.text == "" || _inputTargetMoneyToHour.text == "" || _inputTargetHourToMonth.text == "")
        {
            _preferencesMenu.SetActive(false);
        }
        else
        {         
            _moneyToHour = float.Parse(_inputMoneyToHour.text);
            _targetMoneyToHour = float.Parse(_inputTargetMoneyToHour.text);
            _targetHourToMonth = int.Parse(_inputTargetHourToMonth.text);

            _data.RatePreferences(_targetHourToMonth, _targetMoneyToHour, _moneyToHour);

            _preferencesMenu.SetActive(false);
        }
    }
}
