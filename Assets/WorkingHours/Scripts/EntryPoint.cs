using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]private bool _firstLoad = false;

    private void Start()
    {
        PreferencesAdd.Instance.Initilized();
        WHData.Instance.Initialized();
        StatisticAdd.Instance.Initialized();
        Calendar.Instance.Initialized();
        ButtonActionInterface.Instance.Initialized();


        _firstLoad = WHData.Instance.AplicationFirstLoad;
        if (_firstLoad == true)
        {
            ButtonActionInterface.Instance.OpenFirstLoadMenu();
            _firstLoad = false;
        }
    }
}
